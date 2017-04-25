//	+---------------------------------------+
//	| elmProject Diplomarbeit 2016/2017		|
//	| elm-project@hotmail.com				|
//	| https://github/com/sunriax/			|
//	|										|
//	| Header: system.h						|
//	| Bibliothek: system.c					|
//	| Version: 1.0							|
//	| Hardware: Megacard, STK500			|
//	|										|
//	| (c) 2017, Alle Rechte vorbehalten		|
//	+---------------------------------------+

#include "system.h"

//	+---------------------------------------------------------------+
//	|					System Initialisierung						|
//	+---------------------------------------------------------------+
void system_init()
{
	unsigned char buffer[10];
	
	DDROUT = HIGH;	// Datenrichtungsregister des Ausgabeports einstellen
	DDRIN = LOW;	// Datenrichtungsregister des Eingabeports einstellen
	INPULL = HIGH;	// Pullup Widerstände an Eingabeport aktivieren
	OUTPUT = LOW;	// Ausgabe Port rücksetzten

	// System aktiv und in STARTPHASE
	load(&OUTPUT, 1, 250);		// Ladebalken erhöhen

	// UART Initialisierung
	uart_init(8, 0, 1);			// UART Initialisierung
	load(&OUTPUT, 1, 250);		// Ladebalken erhöhen
	rom_block(eeSTART, buffer, sizeof(eeSTART));
	load(&OUTPUT, 1, 250);		// Ladebalken erhöhen
	uart_setstring(buffer, 1);	// Initialisierung auf Konsole ausgeben
	load(&OUTPUT, 1, 250);		// Ladebalken erhöhen

	// I2C Initialisierung
	i2c_init();					// I2C Bus Initialisieren

	// LCD Initialisierung
	lcd_init();					// LCD Initialisierung
	load(&OUTPUT, 1, 250);		// Ladebalken erhöhen
	display(buffer, 0,0);		// Initialisierung auf Display ausgeben
	load(&OUTPUT, 1, 250);		// Ladebalken erhöhen
	
	// EEPROM Initialisierung
#ifdef SYS_INIT
	rom_init();
	load(&OUTPUT, 1, 250);		// Ladebalken erhöhen
	rom_block(eeINIT, buffer, sizeof(eeINIT));
	load(&OUTPUT, 1, 250);		// Ladebalken erhöhen
	display(buffer, 0,1);		// Initialisierung auf Display ausgeben
	uart_setstring(buffer, 1);	// Initialisierung auf Konsole ausgeben
	load(&OUTPUT, 1, 250);		// Ladebalken erhöhen
	blink(&OUTPUT, 10, 500);
#else
	blink(&OUTPUT, 10, 100);
#endif

	// UART / LCD Initialisierungs Ausgabe
	rom_block(eeTITLE, buffer, sizeof(eeTITLE));
	display(buffer, 0,0);								// Daten auf Display ausgeben
	uart_setstring(buffer, 1);							// Daten auf Konsole ausgeben
	rom_block(eeVERSION, buffer, sizeof(eeVERSION));
	display(buffer, 0,1);								// Daten auf Display ausgeben
	uart_setstring(buffer, 1);							// Daten auf Konsole ausgeben
}

//	+---------------------------------------------------------------+
//	|					LCD Display Ausgabe							|
//	+---------------------------------------------------------------+
void display(unsigned char string[], unsigned char colum, unsigned char row)
{
	lcd_pos(row, colum);	// Positionszeiger auf Zeile, Spalte
	printf("        ");		// Zeile Leeren
	lcd_pos(row, colum);	// Positionszeiger auf Zeile, Spalte
	printf("%s", string);	// String auf Display ausgeben
}

//	+---------------------------------------------------------------+
//	|				Programmier Funktion EEPROM/FPGA				|
//	+---------------------------------------------------------------+
void getmode(void)
{
	unsigned char buffer[10];	// Zwischenspeicher für Empfangene Zeichen
	
	// Wenn Mode(0) ausgwählt
	if(IN(INPUT, MODE0))
	{
		rom_block(eeMODE0, buffer, sizeof(eeMODE0));
		promer(buffer);		// EEPROM Promer aufrufen
	}
	// Wenn Mode(1) ausgewählt
	else if(IN(INPUT, MODE1))
	{
		while (1)
		{
			rom_block(eeMODE1, buffer, sizeof(eeMODE1));
			display(buffer, 0, 1);			// Daten auf Display ausgeben
			uart_setstring(buffer, 1);		// Daten auf Konsole ausgeben
		}
	}
	// Wenn Mode(2) ausgewählt
	else if(IN(INPUT, MODE2))
	{
		while (1)
		{
			rom_block(eeMODE2, buffer, sizeof(eeMODE2));
			display(buffer, 0, 1);			// Daten auf Display ausgeben
			uart_setstring(buffer, 1);		// Daten auf Konsole ausgeben
		}
	}
	// Wenn kein Mode ausgewählt
	else
	{
		rom_block(eeNOMODE, buffer, sizeof(eeNOMODE));
		display(buffer, 0, 1);		// Daten auf Display ausgeben
		uart_setstring(buffer, 1);	// Daten auf Konsole ausgeben
	}
}

//	+---------------------------------------------------------------+
//	|					Programmier Routine							|
//	+---------------------------------------------------------------+
void program(unsigned char transfer, unsigned long long datasize)
{
	
}

//	+---------------------------------------------------------------+
//	|						Blink Funktion							|
//	+---------------------------------------------------------------+
void blink(volatile unsigned char *port, unsigned char ticks, unsigned int delay)
{
	*port = 0x00;

	for(unsigned char i=0; i < ticks; i++)
	{
		*port = ~(*port);
		wait(delay, 0);
	}
	
	*port = 0x00;
}

//	+---------------------------------------------------------------+
//	|					Ladebalken Funktion							|
//	+---------------------------------------------------------------+
void load(volatile unsigned char *port, unsigned char pos, unsigned int delay)
{	
		*port |= 0x01 | (*port<<1);
		
		if(delay > 0)
			wait(delay, 0);
			
		if(*port == 0xFF)
			*port = 0x00;
}

//	+---------------------------------------------------------------+
//	|				Einstellbare Wartefunktion						|
//	+---------------------------------------------------------------+
void wait(unsigned int cycle, unsigned char type)
{
	for(unsigned int i=0; i < cycle; i++)
		switch(type)
		{
			case 1	:	_delay_us(1);
			default	:	_delay_ms(1);
		}
}

//	+---------------------------------------------------------------+
//	|					Display Prozentanzeige						|
//	+---------------------------------------------------------------+
unsigned char percent(unsigned long long number, unsigned long long size)
{
	// Ausrechnen der Prozentwerte
	unsigned char percentage = (number * 100UL/size);
	
	lcd_pos(1, 0);			// Positionszeiger auf Zeile, Spalte
	printf("        ");		// Zeile Leeren
	lcd_pos(1, 0);			// Positionszeiger auf Zeile, Spalte
	printf("P=%u%s", percentage, "%");	// String auf Display ausgeben
	
	return percentage;
}

//	+---------------------------------------+
//	| elmProject Diplomarbeit 2016/2017		|
//	| elm-project@hotmail.com				|
//	| https://github/com/sunriax/			|
//	|										|
//	| Header: uart.h						|
//	| Bibliothek: uart.c					|
//	| Version: 1.0							|
//	| Hardware: Megacard, STK500			|
//	|										|
//	| (c) 2017, Alle Rechte vorbehalten		|
//	+---------------------------------------+

#include "uart.h"

#ifndef BAUD
	#define BAUD 9600UL	// Übertragungsgeschwindigkeit
#endif

//	+---------------------------------------------------------------+
//	|					UART Initialisieren							|
//	+---------------------------------------------------------------+
void uart_init(unsigned char datasize, unsigned char parity, unsigned char stopbits)	{
	
	unsigned int UBRR = 0;
	unsigned char SETREG = 0x00;
	
// Abtastungsrateneinstellung überprüfen
#ifdef U2XEN
	UCSRA = (1<<U2X);						// Double Speed Mode einschalten
	UBRR = F_CPU / (8 * (BAUD - 1)) ;		// UBRR Faktor berechnen
#else
	UCSRA = ~(1<<U2X);						// Double Speed Mode ausschalten
	UBRR = F_CPU / (16 * (BAUD - 1)) ;		// UBRR Faktor berechnen
#endif

	// Baudrateneinstellung
	UBRRH = (UBRR>>8);						// Einstellung der Baudrate (Register High)
	UBRRL = UBRR;							// Einstellung der Baudrate (Register Low)

	SETREG = (1<<URSEL);					// URSEL (Register UCSRC) auf 1

	// Datenbitbreite einstellen
	SETREG &= ~((1<<UCSZ2) | (1<<UCSZ1) | (1<<UCSZ0));	// Datenbitbreite rücksetzten
	
	switch(datasize)
	{
		case '5' : SETREG &= ~((1<<UCSZ2) | (1<<UCSZ1) | (1<<UCSZ0));	break;	// 5 Bit Modus
		case '6' : SETREG |= (1<<UCSZ0);								break;	// 6 Bit Modus
		case '7' : SETREG |= (1<<UCSZ1);								break;	// 7 Bit Modus
		case '9' : SETREG |= (1<<UCSZ2) | (1<<UCSZ1) | (1<<UCSZ0);		break;	// 9 Bit Modus
		default	 : SETREG |= (1<<URSEL) | (1<<UCSZ1) | (1<<UCSZ0);		break;	// 8 Bit Modus (Standard)
	}
	
	// Parität einstellen
	SETREG &= ~((1<<UPM1) | (1<<UPM0));		// keine Parität
	
	switch(parity)
	{
		case 'E' :	SETREG |= (1<<UPM1);				break;	// gerade Parität
		case 'O' :	SETREG |= (1<<UPM1) | (1<<UPM0);	break;	// ungerade Parität
		default  :  SETREG &= ~((1<<UPM1) | (1<<UPM0));	break;	// keine Parität (Standard)
	}
	
	// Stoppbits einstellen
	switch(stopbits)
	{
		case '2' :	SETREG |= (1<<USBS);		break;	// 2 Stoppbit
		default  :	SETREG &= ~(1<<USBS);	break;	// 1 Stoppbit (Standard)
	}
	
	// SETREG Einstellungen in UCSRC übernehmen
	UCSRC = SETREG;
	
	// UART Modul aktivieren
	UCSRB = (1<<RXEN) | (1<<TXEN);			// Transmitter und Receivcer einschalten

// Interrupt Steuerung
#ifdef UARTRXCIE
	UCSRB  |= (1<<RXCIE);					// Empfangs Intrerrpt Freigeben
	sei();
#endif

#ifdef UARTTXCIE
	UCSRB  |= (1<<TXCIE);					// Sende Intrerrpt Freigeben
	sei();
#endif

#ifdef UARTUDRIE
	UCSRB  |= (1<<UDRIE);					// Sende (erweitert) Intrerrpt Freigeben
	sei();
#endif

uart_setchar(0x00);							// NUL Senden (Dummy Byte)
}

//	+---------------------------------------------------------------+
//	|					UART Zeichen senden							|
//	+---------------------------------------------------------------+
void uart_setchar(unsigned char data)	{
	while(!(UCSRA & (1<<UDRE)));			// Warten bis Sendedatenbuffer leer
		UDR = data;							// Schreiben der Daten in Sendebuffer
}

//	+---------------------------------------------------------------+
//	|					UART Zeichensatz senden						|
//	+---------------------------------------------------------------+
void uart_setstring(unsigned char *string, unsigned char line)	{
	while(*string)	{
			uart_setchar(*string);
		string++;								// Daten um 1 erhöhen
	}
	switch (line)
	{
		case(0)	:	uart_setchar(0x00);	break;	// NUL		(NULL)
		case(1)	:	uart_setchar(0x0A);			// LF		(Line Feed)
					uart_setchar(0x0D);	break;	// CR		(Carriage Return)
		case(2)	:	uart_setchar(0x09);	break;	// TAB		(Tabulator)
		case(3)	:	uart_setchar(0x20);	break;	// SPACE	(Leertaste)
		default	:	uart_setchar(0x1B);	break;	// ESC		(Escape)
	}
}

//	+---------------------------------------------------------------+
//	|					UART Zeichen empfangen						|
//	+---------------------------------------------------------------+
void uart_getchar(unsigned char *dataaddr)	{
	if(UCSRA & (1<<RXC))					// Überprüfen ob Daten in Empfangsbuffer
		*dataaddr = UDR;					// Daten auf in Variable der Adresse address schreiben
}

//	+---------------------------------------------------------------+
//	|					UART Zeichen empfangen mit Status			|
//	+---------------------------------------------------------------+
unsigned char uart_getchar_status(unsigned char *dataaddr)	{
	if(UCSRA & (1<<RXC))	{				// Überprüfen ob Daten in Empfangsbuffer
		*dataaddr = UDR;					// Daten auf in Variable der Adresse address schreiben
		return 0xFF;						// Wenn neue Daten vorhanden Status 0xFF
	}
	return 0x00;							// Wenn keine neuen Daten vorhanden Status 0x00
}

//	+---------------------------------------------------------------+
//	|					UART Zeichen abholen						|
//	+---------------------------------------------------------------+
void uart_fetchchar(unsigned char *dataaddr)	{
	while(!(UCSRA & (1<<RXC)));				// Warten bis neues Zeichen verfügbar
		*dataaddr = UDR;					// Daten auf in Variable der Adresse address schreiben
	uart_setchar(*dataaddr);
}

//	+---------------------------------------------------------------+
//	|					UART Argument empfangen						|
//	+---------------------------------------------------------------+
void uart_getarg(unsigned char arg[])
{
	unsigned char data = 0;
	unsigned char loop = 0;
	unsigned char cancel = 0x00;
	
	// Loop bis Datensatz beginnt
	while(1)
	{
		uart_getchar(&data);
		
		if(data == '{')
		{
			arg[loop] = data;	// Empfangenes Zeichen auf Buffer legen
			loop++;					// Arrayzeiger erhöhen
		
			uart_setchar(data);
			
			do
			{
				uart_fetchchar(&data);	// Warten bis Zeichen verfügbar
				arg[loop] = data;	// Zeichen in Array schreiben
				loop++;					// Arrayzeiger erhöhen
				
				// Überprüfen ob Loop Zähler >= (Arraygröße - 1)
				if(loop >= (unsigned char)(MAXCMDSIZE))
				{
					cancel = 0xFF;		// Programmabbruchflag aktivieren
					break;				// Schleifenabbruch initiieren
				}
			} while (data != '}');		// Schleife solange durchlaufen bis Endzeichen erreicht
		}
		
		// CANCEL
		if(cancel == 0xFF)
			break;
		
		arg[loop] = '\0';	// Array Endstring hinzufügen
		
		if(loop > 0)
		{
			break;
			arg[loop] = '\0';	// Array Endstring hinzufügen
		}
	}
}

//	+---------------------------------------------------------------+
//	|					UART Kommando empfangen						|
//	+---------------------------------------------------------------+
void uart_getcmd(unsigned char cmd[])
{
	unsigned char data = 0;
	unsigned char loop = 0;
	unsigned char cancel = 0x00;
	
	// Loop bis Datensatz beginnt
	while(1)
	{
		
		uart_getchar(&data);

		if(data == '[')
		{
			
			cmd[loop] = data;	// Empfangenes Zeichen auf Buffer legen
			loop++;				// Arrayzeiger erhöhen
			
			uart_setchar(data);
			
			do
			{
				uart_fetchchar(&data);	// Warten bis Zeichen verfügbar
				cmd[loop] = data;		// Zeichen in Array schreiben
				loop++;					// Arrayzeiger erhöhen
				
				// Überprüfen ob Loop Zähler >= (Arraygröße - 1)
				if(loop >= (unsigned char)(MAXCMDSIZE))
				{
					cancel = 0xFF;		// Programmabbruchflag aktivieren
					break;				// Schleifenabbruch initiieren
				}
			} while (data != ']');		// Schleife solange durchlaufen bis Endzeichen erreicht
		}
		
		// CANCEL
		if(cancel == 0xFF)
			break;
			
		if(loop > 0)
		{
			break;
			cmd[loop] = '\0';	// Array Endstring hinzufügen
		}
	}
}
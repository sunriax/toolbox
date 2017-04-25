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

#include "promer.h"

//	+---------------------------------------------------------------+
//	|					EEPROM Konfiguration						|
//	+---------------------------------------------------------------+
void promer(unsigned char buffer[])
{
	unsigned char cmd[10];
	unsigned char mem[10];
	unsigned char arg[10];

	unsigned char addr = 0;
	unsigned char word = 0;
	unsigned char data[256];
	unsigned char datasize = 0;
	unsigned char fail = 0;
	
	unsigned char modus = 0;
	unsigned char loop = 0;

	display(buffer, 0, 1);			// Daten ([PROM]) auf Display ausgeben
	uart_setstring(buffer, 1);		// Daten ([PROM]) auf Konsole ausgeben

	while(1)
	{	
		switch(loop)
		{	
			// Adressabfrage (7 Bit Adresse)
			case 1	:	rom_block(eeSETADDR, mem, sizeof(eeSETADDR));		// [ADDR] Kommando von EEPROM in lokalen Speicher laden
						uart_getcmd(cmd);									// Warten bis Kommando über UART empfangen
			
						// Überprüfen ob empfangene Daten gleich dem erwarteten Kommando
						if(!memcmp(cmd, mem, sizeof(eeSETADDR) - 1))	{
							rom_block(eeGETADDR, mem, sizeof(eeGETADDR));	// {ADDR} Kommando von EEPROM in lokalen Speicher laden
							uart_setstring(mem, 1);							// {ADDR} Kommando über UART senden
				
							uart_getarg(arg);								// Warten bis Argument über UART empfangen
							addr = arg[0];									// Aus empfangenem Argument Adresse extrahieren
							loop++;											// Loop Variable inkrementieren
						}
						else
						{
							rom_block(eeFAIL, mem, sizeof(eeFAIL));			// [FAIL] Kommando von EEPROM in lokalen Speicher laden
							uart_setstring(mem, 1);							// [FAIL] Kommando über UART senden
							
							loop = 0;										// Loop Variable Rücksetzten
							OUTPUT = 0x02;									// Fehler in Kommandosequenz anzeigen
						}
			break;
			
			// Wortadresseabfrage (7 Bit Adresse)
			case 2	:	rom_block(eeSETWORD, mem, sizeof(eeSETWORD));		// [WORD] Kommando von EEPROM in lokalen Speicher laden
						uart_getcmd(cmd);									// Warten bis Kommando über UART empfangen
			
						// Überprüfen ob empfangene Daten gleich dem erwarteten Kommando
						if(!memcmp(cmd, mem, sizeof(eeSETWORD) - 1))	{
							rom_block(eeGETWORD, mem, sizeof(eeGETWORD));	// {WORD} Kommando von EEPROM in lokalen Speicher laden
							uart_setstring(mem, 1);							// {WORD} Kommando über UART senden
				
							uart_getarg(arg);								// Warten bis Argument über UART empfangen
							word = arg[0];									// Aus empfangenem Argument Wortadresse extrahieren
							loop++;											// Loop Variable inkrementieren
						}
						else
						{
							rom_block(eeFAIL, mem, sizeof(eeFAIL));			// [FAIL] Kommando von EEPROM in lokalen Speicher laden
							uart_setstring(mem, 1);							// [FAIL] Kommando über UART senden
				
							loop = 0;										// Loop Variable Rücksetzten
							OUTPUT = 0x04;									// Fehler in Kommandosequenz anzeigen
						}
			break;
			
			// Modusabfrage (Lesen/Schreiben)
			case 3	:	rom_block(eeREAD, mem, sizeof(eeREAD));				// [READ] Kommando von EEPROM in lokalen Speicher laden
						uart_getcmd(cmd);									// Warten bis Kommando über UART empfangen
			
						// Überprüfen ob empfangene Daten gleich dem erwarteten Kommando
						if(!memcmp(cmd, mem, sizeof(eeREAD) - 1))	{
							modus = 10;										// EEPROM Lesemodus aktiv			
							loop++;											// Loop Variable inkrementieren
						}
						else
						{
							rom_block(eeWRITE, mem, sizeof(eeWRITE));		// [SAVE] Kommando von EEPROM in lokalen Speicher laden
							
							if(!memcmp(cmd, mem, sizeof(eeREAD) - 1))	{
								modus = 20;									// EEPROM Schreibmodus aktiv
								loop++;										// Loop Variable inkrementieren
							}
							else
							{
								rom_block(eeFAIL, mem, sizeof(eeFAIL));		// [FAIL] Kommando von EEPROM in lokalen Speicher laden
								uart_setstring(mem, 1);						// [FAIL] Kommando über UART senden
								
								loop = 0;									// Loop Variable Rücksetzten
								OUTPUT = 0x05;								// Fehler in Kommandosequenz anzeigen
							}
						}
			break;
			
			// Abfrage der Datengröße
			case 4	:	rom_block(eeSIZE, mem, sizeof(eeSIZE));				// {SIZE} Kommando von EEPROM in lokalen Speicher laden
						uart_setstring(mem, 1);								// {SIZE} Kommando über UART Senden
						uart_getarg(arg);									// {.} Größe (max. 1 Byte empfangen 0-255)
			
						datasize = arg[0];									// Datengröße abspeichern
						
						// !!!!!!!!!!!!!!!!!!!!!!!!!!
						datasize = 7;	// Für Testzwecke
						addr = 0xA0;
						word = 0x00;
						// !!!!!!!!!!!!!!!!!!!!!!!!!!
			
						// Überprüfen ob Datengröße > 0
						if(datasize > 0)
						{
							// Überprüfen ob Lesemodus aktiv
							if(modus == 10)
							{
								rom_block(eeSETDATA, mem, sizeof(eeSETDATA));	// [XSET] Kommando von EEPROM in lokalen Speicher laden
								uart_setstring(mem, 1);							// [XSET] Kommando über UART Senden
								
								// Überprüfen ob Datenwort = 1 Byte
								if(datasize == 1)
								{
									i2c_eeprom_read_byte(addr, word, &data[0]);		// Byte aus EEPROM lesen
									uart_setchar(data[0]);							// Byte über UART senden	
								}
								else
								{
									i2c_eeprom_read_block(addr, word, &data[0], datasize);		// Block aus EEPROM lesen
									
									for(unsigned char i=0; i < datasize; i++)
										uart_setchar(data[i]);									// Block über UART senden
								}
								
								rom_block(eeDONE, mem, sizeof(eeDONE));			// [DONE] Kommando von EEPROM in lokalen Speicher laden
								uart_setstring(mem, 1);							// [DONE] Kommando über UART Senden
							}
							// Überprüfen ob Schreibmodus aktiv
							else if(modus == 20)
							{
								rom_block(eeGETDATA, mem, sizeof(eeGETDATA));	// {XGET} Kommando von EEPROM in lokalen Speicher laden
								uart_setstring(mem, 1);							// {XGET} Kommando über UART Senden
								
								// Überprüfen ob Datenwort = 1 Byte
								if(datasize == 1)
								{
									uart_fetchchar(&data[0]);							// Byte über UART empfangen
									fail = i2c_eeprom_write_byte(addr, word, data[0]);	// Byte in EEPROM schreiben
								}
								else
								{
									for(unsigned char i=0; i < datasize; i++)
										uart_fetchchar(&data[i]);
									
									fail = i2c_eeprom_write_block(addr, word, &data[0], datasize);
								}
								
								if(fail == 0xFF)
									rom_block(eeDONE, mem, sizeof(eeDONE));		// [DONE] Kommando von EEPROM in lokalen Speicher laden
								else
									rom_block(eeFAIL, mem, sizeof(eeFAIL));		// [FAIL] Kommando von EEPROM in lokalen Speicher laden
								uart_setstring(mem, 1);							// [DONE]/[FAIL] Kommando über UART Senden
							}
							else
							{
								rom_block(eeFAIL, mem, sizeof(eeFAIL));			// [FAIL] Kommando von EEPROM in lokalen Speicher laden
								uart_setstring(mem, 1);							// [FAIL] Kommando über UART senden
															
								loop = 0;										// Loop Variable Rücksetzten
								OUTPUT = 0x06;									// Fehler in Kommandosequenz anzeigen
							}
							
						}
						else
						{
							rom_block(eeFAIL, mem, sizeof(eeFAIL));			// [FAIL] Kommando von EEPROM in lokalen Speicher laden
							uart_setstring(mem, 1);							// [FAIL] Kommando über UART senden
														
							loop = 0;										// Loop Variable Rücksetzten
							OUTPUT = 0x08;									// Fehler in Kommandosequenz anzeigen
						}
						
						// Rücksetzten der Variablen
						for(unsigned i=0; i < sizeof(unsigned char); i++)
							data[i] = 0x00;
						
						loop = 0;
						addr = 0;
						word = 0;
						datasize = 0;
						
			break;
			
			// Initialisierungsfall (Startbedingung)
			default	:	OUTPUT = 0x00;									// Ausgabe PORTC (LEDs) auf LOW
						rom_block(eeMODE0, mem, sizeof(eeMODE0));		// [PROM] Kommando von EEPROM in lokalen Speicher laden
						uart_getcmd(cmd);								// Warten bis Kommando über UART empfangen
						
						// Überprüfen ob empfangene Daten gleich dem erwarteten Kommando
						if(!memcmp(cmd, mem, sizeof(eeMODE0) - 1))	{
							rom_block(eeDONE, mem, sizeof(eeDONE));		// [DONE] Kommando von EEPROM in lokalen Speicher laden
							uart_setstring(mem, 1);						// [DONE] Kommando über UART senden
							
							loop = 0;									// Loop Variable auf 0
							loop++;										// Loop Variable inkrementieren
							
							// !!!!!!!!!!!!!!!!!!!!!!!!!!
							loop = 3;	// Für Testzwecke
							// !!!!!!!!!!!!!!!!!!!!!!!!!!
						}
						// Falsches kommando empfangen
						else
						{
							rom_block(eeFAIL, mem, sizeof(eeFAIL));		// [FAIL] Kommando von EEPROM in lokalen Speicher laden
							uart_setstring(mem, 1);						// [FAIL] Kommando über UART senden
							
							loop = 0;									// Loop Variable Rücksetzten
							OUTPUT = 0x01;								// Fehler in Kommandosequenz anzeigen
						}
			break;
		}
	}
}
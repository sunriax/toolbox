//	+---------------------------------------+
//	| elmProject Diplomarbeit 2016/2017		|
//	| elm-project@hotmail.com				|
//	| https://github/com/sunriax/			|
//	|										|
//	| Header: promer.h						|
//	| Bibliothek: promer.c					|
//	| Version: 1.0							|
//	| Hardware: Megacard, STK500			|
//	|										|
//	| (c) 2017, Alle Rechte vorbehalten		|
//	+---------------------------------------+

#ifndef PROMER_H_
#define PROMER_H_

// System definitionen
#ifndef F_CPU
#define F_CPU 12000000UL // Systemtakt
#endif

// Standardbibliotheken
#include <avr/io.h>
#include <avr/eeprom.h>

// Eigene Bibliotheken
#include "definition.h"
#include "system.h"
#include "eeprom.h"
#include "lcd.h"
#include "uart.h"
#include "i2c.h"

// Funktionsaufrufe
void promer(unsigned char buffer[]);

#endif /* PROMER_H_ */
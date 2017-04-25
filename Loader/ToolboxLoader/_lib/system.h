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

#ifndef SYSTEM_H_
#define SYSTEM_H_

// System definitionen
#ifndef F_CPU
	#define F_CPU 12000000UL // Systemtakt
#endif

// Systeminitialisierung (Systemprogrammierung)
//#define SYS_INIT

// Standardbibliotheken
#include <avr/io.h>
#include <inttypes.h>
#include <util/delay.h>
#include <avr/eeprom.h>
#include <string.h>

// Eigene Bibliotheken
#include "definition.h"
#include "lcd.h"
#include "uart.h"
#include "i2c.h"
#include "eeprom.h"

// Funktionsaufrufe
void system_init(void);
void display(unsigned char string[], unsigned char colum, unsigned char row);
void getmode(void);
void program(unsigned char transfer, unsigned long long datasize);
void promer(unsigned char buffer[]);
void blink(volatile unsigned char *port, unsigned char ticks, unsigned int delay);
void load(volatile unsigned char *port, unsigned char pos, unsigned int delay);
void wait(unsigned int cycle, unsigned char type);
unsigned char percent(unsigned long long number, unsigned long long size);

#endif /* SYSTEM_H_ */
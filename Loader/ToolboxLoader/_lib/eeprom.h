//	+---------------------------------------+
//	| elmProject Diplomarbeit 2016/2017		|
//	| elm-project@hotmail.com				|
//	| https://github/com/sunriax/			|
//	|										|
//	| Header: eeprom.h						|
//	| Bibliothek: eeprom.c					|
//	| Version: 1.0							|
//	| Hardware: Megacard, STK500			|
//	|										|
//	| (c) 2017, Alle Rechte vorbehalten		|
//	+---------------------------------------+

#ifndef EEPROM_H_
#define EEPROM_H_

// EEPROM definitionen
#ifndef F_CPU
	#define F_CPU 12000000UL // Systemtakt
#endif

#include <avr/io.h>
#include <avr/eeprom.h>
#include <util/delay.h>
#include <string.h>

#include "definition.h"

void rom_init(void);
void rom_block(unsigned char eeADDRESS[], unsigned char buffer[], unsigned char size);

#endif /* EEPROM_H_ */
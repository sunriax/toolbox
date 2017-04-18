//	+---------------------------------------+
//	| elmProject Diplomarbeit 2016/2017		|
//	| elm-project@hotmail.com				|
//	| https://github/com/sunriax/			|
//	|										|
//	| (c) 2017, Alle Rechte vorbehalten		|
//	+---------------------------------------+

// Systemdefinitionen
#define F_CPU 12000000UL
#define F_SCL 100000UL

// Standardbibliotheken
#include <avr/io.h>
#include <avr/interrupt.h>
#include <util/delay.h>
#include <avr/eeprom.h>

// Eigene Bibliotheken
#include "_lib/definition.h"
#include "_lib/eeprom.h"
#include "_lib/system.h"
#include "_lib/promer.h"
#include "_lib/lcd.h"
#include "_lib/uart.h"
#include "_lib/i2c.h"
#include "_lib/spi.h"

int main(void)
{
	// System Initialisierung
	system_init();

	// Programmer aufruf
	getmode();
	
	// Endlosschleife
	while (1)
	{
		asm volatile("nop");
	}
}
// Programmende


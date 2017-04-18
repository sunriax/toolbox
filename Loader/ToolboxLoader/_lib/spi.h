//	+---------------------------------------+
//	| elmProject Diplomarbeit 2016/2017		|
//	| elm-project@hotmail.com				|
//	| https://github/com/sunriax/			|
//	|										|
//	| Header: spi.h							|
//	| Bibliothek: spi.c						|
//	| Version: 1.0							|
//	| Hardware: Megacard, STK500			|
//	|										|
//	| (c) 2017, Alle Rechte vorbehalten		|
//	+---------------------------------------+

#ifndef SPI_H_
#define SPI_H_

#ifndef F_SCK
	#define F_SCK 1000000UL		// SPI Takt
#endif

#ifndef SPI2XEN
	#define SPI2XEN				// Doppelte Baudrate aktivieren
#endif

#ifndef SPI_DDR
	#define SPI_DDR DDRB
#endif

#ifndef SPI_PORT
	#define SPI_PORT PORTB
#endif

#ifndef SCK
	#define SCK PB7
#endif

#ifndef MOSI
	#define MOSI PB5
#endif

#ifndef MISO
	#define MISO PB6
#endif

#ifndef SS
	#define SS PB4
#endif

#ifndef SPI_PRESCALE
	#define SPI_PRESCALE 8
#endif

#ifndef SPI_ORDER
	#define SPI_ORDER LSB
	//#define SPI_ORDER MSB
#endif

#ifndef SPI_POLARITY
	#define SPI_POLARITY LOW
	//#define SPI_POLARITY HIGH
#endif

#ifndef SPI_PHASE
	#define SPI_PHASE DIRECT
	//#define SPI_PHASE OFFSET
#endif

#ifndef SPIXIE
	#define SPIXIE
#endif

#include <avr/io.h>
#include <avr/interrupt.h>

#include "definition.h"

#endif /* SPI_H_ */
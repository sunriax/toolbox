//	+---------------------------------------+
//	| elmProject Diplomarbeit 2016/2017		|
//	| elm-project@hotmail.com				|
//	| https://github/com/sunriax/			|
//	|										|
//	| Header: i2c.h							|
//	| Bibliothek: i2c.c						|
//	| Version: 1.0							|
//	| Hardware: Megacard, STK500			|
//	|										|
//	| (c) 2017, Alle Rechte vorbehalten		|
//	+---------------------------------------+

#ifndef I2C_H_
#define I2C_H_

#ifndef I2C_ADDRESS
	#define I2C_ADDRESS 0xA0
#endif

#ifndef F_SCL
	#define F_SCL 100000UL		// I2C Takt
#endif

#ifndef I2C_PRESCALE
	#define I2C_PRESCALE 0
#endif

#ifndef I2C_SPEED
	#define I2C_SPEED ((F_CPU/F_SCL) - 16) / (2 * 4<<I2C_PRESCALE)
#endif

#ifndef ACK
	#define ACK 0x01
#endif

#ifndef NACK
	#define NACK 0x00
#endif

#ifndef I2C_READ
	#define I2C_READ 0x01
#endif

#ifndef I2C_WRITE
	#define I2C_WRITE 0x00
#endif

#include <avr/io.h>

#endif /* I2C_H_ */
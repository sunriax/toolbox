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

#include "i2c.h"

//	+---------------------------------------------------------------+
//	|					I²C START Kommando							|
//	+---------------------------------------------------------------+
void i2c_start(void)
{
	TWCR = (1<<TWINT) | (1<<TWSTA) | (1<<TWEN);

	while(!(TWCR & (1<<TWINT)));
}

//	+---------------------------------------------------------------+
//	|					I²C STOP Kommando							|
//	+---------------------------------------------------------------+
void i2c_stop(void)
{
	TWCR = (1<<TWINT) | (1<<TWSTO) | (1<<TWEN);
}


//	+---------------------------------------------------------------+
//	|					I²C Senderoutine							|
//	+---------------------------------------------------------------+
void i2c_transmit(unsigned char data)
{
	TWDR = data;
	TWCR = (1<<TWINT) | (1<<TWEN);
	
	while(!(TWCR & (1<<TWINT)));
}

//	+---------------------------------------------------------------+
//	|					I²C Empfangsroutine							|
//	+---------------------------------------------------------------+
void i2c_receive(unsigned char acknowledge, unsigned char *data)
{
	switch(acknowledge)
	{
		case 0	:	TWCR = (1<<TWINT) | (1<<TWEN);				break;
		default	:	TWCR = (1<<TWINT) | (1<<TWEA) | (1<<TWEN);	break;
	}
	while (!(TWCR & (1<<TWINT)));
		*data = TWDR;
}
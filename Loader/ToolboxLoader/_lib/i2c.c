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

void i2c_init(void)
{
	TWSR = 0x00;
	TWBR = 7;	
}

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
unsigned char i2c_receive(unsigned char acknowledge)
{
	// Überprüfen ob Quittierung erforderlich
	if(acknowledge == NACK)
		TWCR = ((1<<TWINT) | (1<<TWEN));			// Keine Quittierung senden
	else
		TWCR = (1<<TWINT) | (1<<TWEA) | (1<<TWEN);	// Quittierung senden

	// Warten bis Daten über I2C empfangen
	while (!(TWCR & (1<<TWINT)));
		return TWDR;								// Empfangene Daten zurückgeben
}

//	+---------------------------------------------------------------+
//	|					I²C EEPROM Byte schreiben					|
//	+---------------------------------------------------------------+
unsigned char i2c_eeprom_write_byte(unsigned char deviceaddr, unsigned char wordaddr, unsigned char data)
{
	unsigned char read;
	
	// Daten in EEPROM schreiben
	i2c_start();
	i2c_transmit(deviceaddr | I2C_WRITE);
	i2c_transmit(wordaddr);
	i2c_transmit(data);
	i2c_stop();
	
	// Wartezeit bis Daten in EEPROM gespeichert
	_delay_ms(I2C_EEPROM_WRITE);
	
	// Daten aus EEPROM lesen
	i2c_eeprom_read_byte(deviceaddr, wordaddr, &read);
	
	// Überprüfen ob geschriebene Daten korrekt
	if(read == data)
		return 0xFF;	// Rückgabewert Daten korrekt
	return 0x00;		// Rückgabewert Daten falsch
}

//	+---------------------------------------------------------------+
//	|					I²C EEPROM Block schreiben					|
//	+---------------------------------------------------------------+
unsigned char i2c_eeprom_write_block(unsigned char deviceaddr, unsigned char wordaddr, unsigned char *data, unsigned char blocksize)
{
	unsigned char read[blocksize];
	
	// Array in EEPROM schreiben
	i2c_start();
	i2c_transmit(deviceaddr | I2C_WRITE);
	i2c_transmit(wordaddr);
	
	for(unsigned char i=0; i < blocksize; i++)
	{
		i2c_transmit(*data);
		data++;
	}
	
	i2c_stop();
	data = data - blocksize;
	
	// Wartezeit bis Daten in EEPROM gespeichert
	_delay_ms(I2C_EEPROM_WRITE);
	
	// Array aus EEPROM lesen
	i2c_eeprom_read_block(deviceaddr, wordaddr, &read[0], blocksize);
	// oder
	// i2c_eeprom_read_block(deviceaddr, wordaddr, read, blocksize);
	
	for(unsigned char j=0; j < blocksize; j++)
	{
		if(read[j] != *data)
			return 0x00;
		data++;
	}
	return 0xFF;
}

//	+---------------------------------------------------------------+
//	|					I²C EEPROM Byte lesen						|
//	+---------------------------------------------------------------+
void i2c_eeprom_read_byte(unsigned char deviceaddr, unsigned char wordaddr, unsigned char *data)
{	
	// Dummy Write
	i2c_start();
	i2c_transmit(deviceaddr | I2C_WRITE);
	i2c_transmit(wordaddr);
	
	// Daten aus EEPROM lesen
	i2c_start();
	i2c_transmit(deviceaddr | I2C_READ);
	*data = i2c_receive(NACK);
	i2c_stop();
}

//	+---------------------------------------------------------------+
//	|					I²C EEPROM Block lesen						|
//	+---------------------------------------------------------------+
void i2c_eeprom_read_block(unsigned char deviceaddr, unsigned char wordaddr, unsigned char *data, unsigned char blocksize)
{
		// Dummy Write
		i2c_start();
		i2c_transmit(deviceaddr | I2C_WRITE);
		i2c_transmit(wordaddr);
		
		// EEPROM Lesen initiieren
		i2c_start();
		i2c_transmit(deviceaddr | I2C_READ);
		
		// Datenblock aus EEPROM lesen
		for(unsigned char i=0; i < blocksize; i++)
		{
			// Überprüfen ob Datensatz durchlaufen
			if((blocksize - 1) >= i)
			{
				*data = i2c_receive(NACK);		// Daten Empfangen ohne Quittierung
				data++;
			}
			else
				*data = i2c_receive(ACK);		// Daten Empfangen mit Quittierung
				
			data++;
			
			percent((i+1), blocksize);
		}
		
		i2c_stop();
}

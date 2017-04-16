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

#include "spi.h"

void spi_init(void)
{	
	// Automatische Master/Slave auswahl
	// Wenn SS auf bei Initialiserung auf LOW
	// erfolgt Masterabbruch, somit befindet
	// sich das System im Slavebetrieb

	SPI_DDR  |= (1<<SCK) | (1<<MOSI) | (1<<MISO);
	SPI_PORT |= (1<<SS) | (1<<MISO);	

#ifdef SPI2XEN
	SPSR = (1<<SPI2X);
#else
	SPSR = ~(1<<SPI2X)
#endif

#ifdef SPI_PRESCALE
	SPCR = ~((1<<SPR1) |(1<<SPR0));

	switch((unsigned char)(SPI_PRESCALE))
	{
		case 16		:	SPCR |= (1<<SPR0);					break;
		case 64		:	SPCR |= (1<<SPR1);					break;
		case 128	:	SPCR |= (1<<SPR1) | (1<<SPR0);		break;
		default		:	SPCR &= ~((1<<SPR1) |(1<<SPR0));	break;
	}
#endif

#if (SPI_ORDER == MSB)
	SPCR |= (1<<DORD);
#else
	SPCR &= ~(1<<DORD);
#endif

#if (SPI_POLARITY == HIGH)
	SPCR |= (1<<CPOL);
#else
	SPCR &= ~(1<<CPOL);
#endif

#if (SPI_PHASE == DIRECT)
	SPCR |= (1<<CPHA);
#else
	SPCR &= ~(1<<CPHA);
#endif


	SPCR |= (1<<MSTR) | (1<<SPE);	// Voteiler auf 8 (SPI2X=1!)

#ifdef SPIXIE
	SPCR |= (1<<SPIE);
	sei();
#endif

}

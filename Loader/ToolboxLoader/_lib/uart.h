//	+---------------------------------------+
//	| elmProject Diplomarbeit 2016/2017		|
//	| elm-project@hotmail.com				|
//	| https://github/com/sunriax/			|
//	|										|
//	| Header: uart.h						|
//	| Bibliothek: uart.c					|
//	| Version: 1.0							|
//	| Hardware: Megacard, STK500			|
//	|										|
//	| (c) 2017, Alle Rechte vorbehalten		|
//	+---------------------------------------+

#ifndef UART_H_
#define UART_H_

// U(S)ART definitionen
#ifndef F_CPU
	#define F_CPU 12000000UL // Systemtakt
#endif

#ifndef BAUD
	#define BAUD 57600UL	// Übertragungsgeschwindigkeit
#endif

#ifndef U2XEN
	#define U2XEN			// Doppelte Baudrate aktivieren
#endif

//#ifndef UARTRXCIE
//	#define UARTRXCIE		// Empfangsdaten Interrupt
//#endif

#ifndef MAXCMDSIZE
	#define MAXCMDSIZE 8		// Empfangsdaten Buffer
#endif

#include <avr/io.h>
#include <avr/interrupt.h>
#include <util/delay.h>
#include <string.h>

void uart_init(unsigned char datasize, unsigned char parity, unsigned char stopbits);
void uart_setchar(unsigned char data);
void uart_setstring(unsigned char *string, unsigned char line);
void uart_getchar(unsigned char *dataaddr);
unsigned char uart_getchar_status(unsigned char *dataaddr);
void uart_fetchchar(unsigned char *dataaddr);
void uart_getcmd(unsigned char cmd[]);
void uart_getarg(unsigned char arg[]);

#endif /* UART_H_ */
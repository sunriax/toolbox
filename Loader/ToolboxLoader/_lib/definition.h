//	+---------------------------------------+
//	| elmProject Diplomarbeit 2016/2017		|
//	| elm-project@hotmail.com				|
//	| https://github/com/sunriax/			|
//	|										|
//	| Header: definition.h					|
//	| Bibliothek: definition.c				|
//	| Version: 1.0							|
//	| Hardware: Megacard, STK500			|
//	|										|
//	| (c) 2017, Alle Rechte vorbehalten		|
//	+---------------------------------------+

#ifndef DEFINITION_H_
#define DEFINITION_H_

// Systemdefinitionen
#ifndef DDROUT
	#define DDROUT DDRC		// Ausgabe Richtungsregister
#endif

#ifndef DDRIN
	#define DDRIN DDRA		// Eingabe Richtungsregister
#endif

#ifndef OUTPUT
	#define OUTPUT PORTC	// Ausgabe Port
#endif

#ifndef INPUT
	#define INPUT PINA		// Eingabe Port
#endif

#ifndef INPULL
	#define INPULL PORTA	// Eingabe Port Pullup aktivieren
#endif

#ifndef MODE0
	#define MODE0 PA0
#endif

#ifndef MODE1
	#define MODE1 PA1
#endif

#ifndef MODE2
	#define MODE2 PA2
#endif

#ifndef IN
	#define IN(PORT, PIN) (!(PORT & (1<<PIN)))
#endif

#ifndef HIGH
	#define HIGH 0xFF		// HIGH Byte
#endif

#ifndef LOW
	#define LOW 0x00		// LOW Byte
#endif

#ifndef NIBBLE
	#define NIBBLE 0x0F		// HIGH Byte
#endif

#include <avr/io.h>
#include <avr/eeprom.h>

extern unsigned char eeTITLE[8];	//	elmTOOL
extern unsigned char eeVERSION[8];	//	V1|FyLa
extern unsigned char eeINIT[8];		//	ROMINIT
extern unsigned char eeSTART[6];	//	START
extern unsigned char eeNOMODE[8];	//	NoMODE!
extern unsigned char eeMODE0[7];	//	[PROM]
extern unsigned char eeMODE1[7];	//	[FPGA]
extern unsigned char eeMODE2[7];	//	[DBUG]
extern unsigned char eeDONE[7];		//	[DONE]
extern unsigned char eeFAIL[7];		//	[FAIL]
extern unsigned char eeSETDATA[7];	//	[XSET]
extern unsigned char eeGETDATA[7];	//	{XGET}
extern unsigned char eeSETADDR[7];	//	[ADDR]
extern unsigned char eeGETADDR[7];	//	{ADDR}
extern unsigned char eeSETWORD[7];	//	[WORD]
extern unsigned char eeGETWORD[7];	//	{WORD}
extern unsigned char eeREAD[7];		//	[READ]
extern unsigned char eeWRITE[7];	//	[SAVE]
extern unsigned char eeDATA[7];		//	[DATA]
extern unsigned char eeSIZE[7];		//	{SIZE}

#endif /* DEFINITION_H_ */
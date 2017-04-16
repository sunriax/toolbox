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

#include "eeprom.h"

//	+---------------------------------------------------------------+
//	|				EEPROM Initialisierung (deaktiviert)			|
//	+---------------------------------------------------------------+
void rom_init(void)
{
	unsigned char buffer[10];
	
	memcpy(buffer, "elmTOOL",	sizeof(eeTITLE));	eeprom_write_block (buffer, eeTITLE,	sizeof(eeTITLE));
	memcpy(buffer, "V1|LyFy",	sizeof(eeVERSION));	eeprom_write_block (buffer, eeVERSION,	sizeof(eeVERSION));
	memcpy(buffer, "ROMINIT",	sizeof(eeINIT));	eeprom_write_block (buffer, eeINIT,		sizeof(eeINIT));
	memcpy(buffer, "START",		sizeof(eeSTART));	eeprom_write_block (buffer, eeSTART,	sizeof(eeSTART));
	memcpy(buffer, "NoMODE!",	sizeof(eeNOMODE));	eeprom_write_block (buffer, eeNOMODE,	sizeof(eeNOMODE));
	memcpy(buffer, "[PROM]",	sizeof(eeMODE0));	eeprom_write_block (buffer, eeMODE0,	sizeof(eeMODE0));
	memcpy(buffer, "[FPGA]",	sizeof(eeMODE1));	eeprom_write_block (buffer, eeMODE1,	sizeof(eeMODE1));
	memcpy(buffer, "[DBUG]",	sizeof(eeMODE2));	eeprom_write_block (buffer, eeMODE2,	sizeof(eeMODE2));
	memcpy(buffer, "[DONE]",	sizeof(eeDONE));	eeprom_write_block (buffer, eeDONE,		sizeof(eeDONE));
	memcpy(buffer, "[FAIL]",	sizeof(eeFAIL));	eeprom_write_block (buffer, eeFAIL,		sizeof(eeFAIL));
	memcpy(buffer, "[XSET]",	sizeof(eeSETDATA));	eeprom_write_block (buffer, eeSETDATA,	sizeof(eeSETDATA));
	memcpy(buffer, "{SIZE}",	sizeof(eeSIZE));	eeprom_write_block (buffer, eeSIZE,		sizeof(eeSIZE));
	memcpy(buffer, "{XGET}",	sizeof(eeGETDATA));	eeprom_write_block (buffer, eeGETDATA,	sizeof(eeGETDATA));
}

//	+---------------------------------------------------------------+
//	|					EEPROM Block lesen							|
//	+---------------------------------------------------------------+
void rom_block(unsigned char eeADDRESS[], unsigned char buffer[], unsigned char size)
{	
	eeprom_read_block (buffer, eeADDRESS, size);
}

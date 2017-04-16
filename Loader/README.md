# C Toolbox Loader for Atmel ATmega16

*The Toolbox Loader Software for ATmega16 uCs is needed to transfer*
*Date from the Toolbox Windows Interface over the STK500/Megacard*
*to the elmProject System. This tool has got 3 Modes.

# Mode 1
	* Configuring the FPGA [FPGA] command
# Mode 2
	* Configuring the EEPROM of an extension PCB [PROM] command
# Mode 3
	* Mode for Self-Test and Debug Tool

# Toolbox Loader Libraries
	1. definition.h
	1. eeprom.h
		* void rom_init(void);
		* void rom_block(unsigned char eeADDRESS[], unsigned char buffer[], unsigned char size);
	1. i2c.h
	1. lcd.h
		* void lcd_init(void);
		* void lcd_home(void);
		* void lcd_zToLCD(char dataD);
		* void lcd_pos(unsigned char zeile, unsigned char Pos);
		* void my_putc ( void* p, char c);
	1. printf.h
		* void init_printf(void* putp,void (*putf) (void*,char));
		* void tfp_printf(char *fmt, ...);
		* void tfp_sprintf(char* s,char *fmt, ...);
		* void tfp_format(void* putp,void (*putf) (void*,char),char *fmt, va_list va);
	1. spi.h
	1. system.h
		* void system_init(void);
		* void display(unsigned char string[], unsigned char colum, unsigned char row);
		* void getmode(void);
		* void program(unsigned char transfer, unsigned long long datasize);
		* void promer(unsigned char buffer[]);
		* void blink(volatile unsigned char *port, unsigned char ticks, unsigned int delay);
		* void load(volatile unsigned char *port, unsigned char pos, unsigned int delay);
		* void wait(unsigned int cycle, unsigned char type);
		* unsigned char percent(unsigned long long number, unsigned long long size);
	1. uart.h
		* void uart_init(unsigned char datasize, unsigned char parity, unsigned char stopbits);
		* void uart_setchar(unsigned char data);
		* void uart_setstring(unsigned char *string, unsigned char line);
		* void uart_getchar(unsigned char *address);
		* void uart_fetchchar(unsigned char *address);
		* void uart_getcmd(unsigned char cmd[]);
		* void uart_getarg(unsigned char arg[]);

*Please read the copyright*

*sunriax@elmProject*
----------------------------------------------------------------------
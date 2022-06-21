#include <stc8.h>

sbit DS_RESET=P2^0;
sbit DS_IO=P4^2;
sbit DS_SCLK=P2^1;
void Delaylong(unsigned int ch);
void time_wite_1(unsigned char TBuffer);
void v_W1302(unsigned char ucAddr,unsigned char ucDa);
void Write_DS1302Init(unsigned char *ptr);
unsigned char time_read_1();
unsigned char uc_R1302(unsigned char ucAddr);
unsigned char bcdtodec(unsigned char bcd);
void Run_DS1302();
void DS1302Reset();
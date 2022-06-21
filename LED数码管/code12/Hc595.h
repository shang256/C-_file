#include <stc8.h>

sbit SPI_SHCP=P3^5;//移位脉冲
sbit SPI_STCP=P3^4;//锁存脉冲
sbit SPI_DS=P3^7;//串行数据输入

void SEG_HC595send(unsigned char x);
void DisplayScan(void);
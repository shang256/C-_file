#include <stc8.h>

sbit SPI_SHCP=P3^5;//��λ����
sbit SPI_STCP=P3^4;//��������
sbit SPI_DS=P3^7;//������������

void SEG_HC595send(unsigned char x);
void DisplayScan(void);
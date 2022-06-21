#include <STC8.H>

#include <stdio.h> //printf��ӡ
#include "hc595.h"
#include "key.h"
#include "intrins.h"

unsigned char key_val, key_Data;//key_val = 0xFF quan mie �����������ʾ�� key_Data�������SBUF���ͱ�־

void UartInit(void)		//115200bps@11.0592MHz
{
	SCON = 0x50;		//8λ����,�ɱ䲨����
	AUXR |= 0x40;		//��ʱ��ʱ��1Tģʽ
	AUXR &= 0xFE;		//����1ѡ��ʱ��1Ϊ�����ʷ�����
	TMOD &= 0x0F;		//���ö�ʱ��ģʽ
	TL1 = 0xE8;		//���ö�ʱ��ʼֵ
	TH1 = 0xFF;		//���ö�ʱ��ʼֵ
	ET1 = 0;		//��ֹ��ʱ��%d�ж�
	TR1 = 1;		//��ʱ��1��ʼ��ʱ
	
	ES = 1;
	EA = 1;
}

void main()
{
	unsigned char keyvalue; // keyvalue���ڻ�ȡʵʱ��ֵ��
	UartInit();
	while(1)
	{
		keyvalue = key_scan();   // �������ɨ�裬keyvalue��ŷ���ֵ
		if(keyvalue != 16)
		{
			key_val = keyvalue;  // �õ����һ�ΰ��µļ�ֵ
		}
		display(6,key_val/10);      // ��ʱ��ʾ�ļ�ֵ�������һ�ΰ��µļ�ֵ	
		display(7,key_val%10);      // ��ʱ��ʾ�ļ�ֵ�������һ�ΰ��µļ�ֵ		
		key_Data = keyvalue;
		switch(key_Data)
		{
			case 0:printf("Key=0\r\n\r\n");break;
			case 1:printf("Key=1\r\n\r\n");break;
			case 2:printf("Key=2\r\n\r\n");break;
			case 3:printf("Key=3\r\n\r\n");break;
			case 4:printf("Key=4\r\n\r\n");break;
			case 5:printf("Key=5\r\n\r\n");break;
			case 6:printf("Key=6\r\n\r\n");break;
			case 7:printf("Key=7\r\n\r\n");break;
			case 8:printf("Key=8\r\n\r\n");break;
			case 9:printf("Key=9\r\n\r\n");break;
			case 10:printf("Key=10\r\n\r\n");break;
			case 11:printf("Key=11\r\n\r\n");break;
			case 12:printf("Key=12\r\n\r\n");break;
			case 13:printf("Key=13\r\n\r\n");break;
			case 14:printf("Key=14\r\n\r\n");break;
			case 15:printf("Key=15\r\n\r\n");break;
		}		
	}
}

//��дprintf
void UartSend(unsigned char ch){
		SBUF=ch;
		while(!TI);
		TI=0;
}
char putchar(char c){
	UartSend(c);
	return c;
}


void Serial_isr() interrupt 4
{
	unsigned char temp;
	if(RI)
	{
		RI=0;
		temp = SBUF;
	}
	if(TI)//��Ƭ����������
	{
		key_Data = 16;
		TI = 0;
	}
}

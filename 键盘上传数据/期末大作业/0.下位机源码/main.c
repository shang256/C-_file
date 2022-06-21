#include <STC8.H>

#include <stdio.h> //printf打印
#include "hc595.h"
#include "key.h"
#include "intrins.h"

unsigned char key_val, key_Data;//key_val = 0xFF quan mie 用于数码管显示， key_Data用于清除SBUF发送标志

void UartInit(void)		//115200bps@11.0592MHz
{
	SCON = 0x50;		//8位数据,可变波特率
	AUXR |= 0x40;		//定时器时钟1T模式
	AUXR &= 0xFE;		//串口1选择定时器1为波特率发生器
	TMOD &= 0x0F;		//设置定时器模式
	TL1 = 0xE8;		//设置定时初始值
	TH1 = 0xFF;		//设置定时初始值
	ET1 = 0;		//禁止定时器%d中断
	TR1 = 1;		//定时器1开始计时
	
	ES = 1;
	EA = 1;
}

void main()
{
	unsigned char keyvalue; // keyvalue用于获取实时键值，
	UartInit();
	while(1)
	{
		keyvalue = key_scan();   // 矩阵键盘扫描，keyvalue存放返回值
		if(keyvalue != 16)
		{
			key_val = keyvalue;  // 得到最近一次按下的键值
		}
		display(6,key_val/10);      // 这时显示的键值是你最近一次按下的键值	
		display(7,key_val%10);      // 这时显示的键值是你最近一次按下的键值		
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

//重写printf
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
	if(TI)//单片机发送数据
	{
		key_Data = 16;
		TI = 0;
	}
}

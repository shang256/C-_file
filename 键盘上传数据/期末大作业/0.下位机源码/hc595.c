#include "hc595.h"

// 段选：dp、g、f、e、d、c、b、a --共阴
unsigned char const LedData[]=
   {0xc0,0xf9,0xa4,0xb0,0x99,0x92,0x82,0xf8,0x80,0x90,0x88,0x83,0xc6,0xa1,0x86,0x8e,0xFF , 0x00, 0xbf,0x7f};
//  "0"  "1"  "2"  "3"  "4"  "5"  "6"  "7"  "8"   "9"  "A"  "B"  "C"  "D"  "E"  "F" "全灭" "全亮" "-"  "."

// 位选：					  CS1、CS2、CS3、CS4、CS5、CS6、CS7、CS8
unsigned char const LedPos[]={0x01,0x02,0x04,0x08,0x10,0x20,0x40,0x80};

//数码管延时
void DelayCub(unsigned int xms)//11.0592
{
	unsigned char i, j,k;
	for(k=xms; k>0; k--)
	{
		_nop_();_nop_();_nop_();
		i = 11;
		j = 190;
		do{
			while (--j);
		} while (--i);
	}
}

//发送一个字节的数据
void Send_595(unsigned char dat)
{	
	unsigned char i;
	for(i=0; i<8; i++)
	{
		dat <<= 1;
		P_HC595_SDA  = CY;//CY是进位标志，CY=0无进位 ，CY=1表示进位
		P_HC595_SRCLK = 1;//移位时钟线
		P_HC595_SRCLK = 0;
	}
}

//数码管显示函数
void display(unsigned char pos,unsigned char dat)
{
	Send_595(LedPos[pos]);//位选
	Send_595(LedData[dat]);//段选
	P_HC595_RCLK = 1;	//锁存时钟线
	P_HC595_RCLK = 0;
    DelayCub(5);
}



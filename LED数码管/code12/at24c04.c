#include <stc8.h>
#include <intrins.h>
#include <at24c04.h>
#define AT24_add 0xA0//1010 0000 1010 0001

sbit SDA=P7^6;
sbit SCL=P7^7;
void Delay5us()
{
	unsigned char i;

	_nop_();
	i = 11;
	while (--i);
}
void I2C_Start()
{
	SDA=1;
	Delay5us();
	SCL=1;
	Delay5us();
	SDA=0;
	Delay5us();
	
}
void I2C_Stop()
{
	SDA=0;
	Delay5us();
	SCL=1;
	Delay5us();
	SDA=1;
	Delay5us();
}
void I2C_WriteByte(unsigned char byt)
{
	unsigned char i;
	for(i=0;i<8;i++)
	{
		SCL=0;
		Delay5us();
		if(byt&0x80)
		{
			SDA=1;
		}
		else SDA=0;
		Delay5us();
		SCL=1;
		Delay5us();
		byt<<=1;
	}
	SCL=0;
	Delay5us();
//	SDA=0;
//	Delay5us();
}
unsigned char I2C_ReadByte()
{
	unsigned char da,i;
	for(i=0;i<8;i++)
	{
		SCL=1;
		Delay5us();
		da<<=1;
		if(SDA)da|=1;
		SCL=0;
		Delay5us();
	}
	return da;
}
bit I2C_CheckAck()
{
	SCL=1;
	Delay5us();
	CY=SDA;
	SCL=0;
	Delay5us();
	return CY;
}
//������˳���׵�ַadd����������*s���ֽ���Ŀcount
bit Mult_Write24c04(unsigned char add,unsigned char *s,unsigned char count)
{
	unsigned char i;
	bit ack;
	I2C_Start();
	I2C_WriteByte(AT24_add);//����������ַ+д
	ack=I2C_CheckAck();
	
	I2C_WriteByte(add);//���ʹ洢��Ԫ�׵�ַ
	ack=I2C_CheckAck();
	for(i=0;i<count;i++)
	{
		I2C_WriteByte(*s);
		ack &= I2C_CheckAck();
		s++;
	}
	I2C_Stop();
	if(ack) return 1;
	else return 0;
	
}
unsigned char read_24c04(unsigned char add)
{
	unsigned char temp;
	bit ack;
	I2C_Start();
	I2C_WriteByte(AT24_add);//����������ַ+αд
	ack=I2C_CheckAck();
	
	I2C_WriteByte(add);//���ʹ洢��Ԫ�׵�ַ
	ack=I2C_CheckAck();
	
	I2C_Start();
	I2C_WriteByte(AT24_add|0x01);//����������ַ+��
	ack=I2C_CheckAck();
	
	temp=I2C_ReadByte();
	
	I2C_Stop();
	return temp;
}
void Mult_Read24c04(unsigned char add,unsigned char *str,unsigned char count)
{
	unsigned char i;
	for(i=0;i<count;i++)
	{
		str[i]=read_24c04(add);
		add=add+0x01;
	}
}








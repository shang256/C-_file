//Ds1302驱动
#include <Ds1302.h>
#include <intrins.h>
//用来记录时间
unsigned char xdata sec,min,hour,day,month,year;
unsigned char bdata time_rx;
sbit time_rx7=time_rx^7;
void Delaylong(unsigned int ch)		//@11.0592MHz延时任意微妙
{
	unsigned int j;
	for(j=0;j<ch;j++){
	_nop_();
	_nop_();
	_nop_();
	}
}

//写一个字节
void time_wite_1(unsigned char TBuffer){
	unsigned char i;	
	for(i=0;i<8;i++)
		{
			DS_IO=0;
			DS_SCLK=0;
			if(TBuffer&0x01){
				DS_IO=1;
			}
			TBuffer=TBuffer>>1;
			DS_SCLK=1;
		}
		DS_SCLK=0;
}
//1302写入数据
void v_W1302(unsigned char ucAddr,unsigned char ucDa){
		DS_RESET=0;
		DS_SCLK=0;
		DS_RESET=1;
		time_wite_1(ucAddr);
		_nop_();
		_nop_();
		time_wite_1(ucDa);
		DS_SCLK=1;
		DS_RESET=0;	
}
//初始化1302时间
void Write_DS1302Init(unsigned char *ptr){
	unsigned char i;
	unsigned char addr=0x80;
	
	v_W1302(0x8e,0x00);//允许写入数据
	
	for(i=7;i>0;i--){
		v_W1302(addr,*ptr++);
		addr+=2;
	}
	
	v_W1302(0x8e,0x80);//禁止写入数据
}
//读一个字节
unsigned char time_read_1(){
	unsigned char i;
	DS_IO=1;
	for(i=0;i<8;i++){
	DS_SCLK=0;
	time_rx=time_rx>>1;
	time_rx7=DS_IO;
	DS_SCLK=1;
	}
	DS_SCLK=0;
	return time_rx;
}
//从1302读数据
unsigned char uc_R1302(unsigned char ucAddr){
	unsigned char ucDa;	
	
	DS_RESET=0;
	DS_SCLK=0;
	DS_RESET=1;	
	
	time_wite_1(ucAddr);
	_nop_();
	_nop_();
	ucDa=time_read_1();	
	
	DS_SCLK=1;
	DS_RESET=0;
	return ucDa;
}
//bcd码转16进制
//0x27 bcd码 如果看成是无符号数 等于十进制39
//0x1b dec   如果看成是无符号数 等于十进制27  
unsigned char bcdtodec(unsigned char bcd){
	unsigned char data1;
	data1=bcd & 0x0f;//取低四位
	bcd=bcd & 0x70;
	
	data1 += bcd>>1;
	data1 += bcd>>3;
	
	return data1;
}
//
void Run_DS1302(){
	v_W1302(0x8f,0);//允许写入
	sec=bcdtodec(uc_R1302(0x81));//读秒
	v_W1302(0x8f,0);//允许写入
	min=bcdtodec(uc_R1302(0x83));//读分
	v_W1302(0x8f,0);//允许写入
	hour=bcdtodec(uc_R1302(0x85));//读小时
	v_W1302(0x8f,0);//允许写入
	day=bcdtodec(uc_R1302(0x87));//读日
	v_W1302(0x8f,0);//允许写入
	month=bcdtodec(uc_R1302(0x89));//读月
	v_W1302(0x8f,0);//允许写入
	year=bcdtodec(uc_R1302(0x8d));//读年
}

//复位ds1302
void DS1302Reset(){
	DS_SCLK=0;
	Delaylong(100);
	DS_SCLK=1;
	DS_RESET=0;
}



//Ds1302����
#include <Ds1302.h>
#include <intrins.h>
//������¼ʱ��
unsigned char xdata sec,min,hour,day,month,year;
unsigned char bdata time_rx;
sbit time_rx7=time_rx^7;
void Delaylong(unsigned int ch)		//@11.0592MHz��ʱ����΢��
{
	unsigned int j;
	for(j=0;j<ch;j++){
	_nop_();
	_nop_();
	_nop_();
	}
}

//дһ���ֽ�
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
//1302д������
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
//��ʼ��1302ʱ��
void Write_DS1302Init(unsigned char *ptr){
	unsigned char i;
	unsigned char addr=0x80;
	
	v_W1302(0x8e,0x00);//����д������
	
	for(i=7;i>0;i--){
		v_W1302(addr,*ptr++);
		addr+=2;
	}
	
	v_W1302(0x8e,0x80);//��ֹд������
}
//��һ���ֽ�
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
//��1302������
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
//bcd��ת16����
//0x27 bcd�� ����������޷����� ����ʮ����39
//0x1b dec   ����������޷����� ����ʮ����27  
unsigned char bcdtodec(unsigned char bcd){
	unsigned char data1;
	data1=bcd & 0x0f;//ȡ����λ
	bcd=bcd & 0x70;
	
	data1 += bcd>>1;
	data1 += bcd>>3;
	
	return data1;
}
//
void Run_DS1302(){
	v_W1302(0x8f,0);//����д��
	sec=bcdtodec(uc_R1302(0x81));//����
	v_W1302(0x8f,0);//����д��
	min=bcdtodec(uc_R1302(0x83));//����
	v_W1302(0x8f,0);//����д��
	hour=bcdtodec(uc_R1302(0x85));//��Сʱ
	v_W1302(0x8f,0);//����д��
	day=bcdtodec(uc_R1302(0x87));//����
	v_W1302(0x8f,0);//����д��
	month=bcdtodec(uc_R1302(0x89));//����
	v_W1302(0x8f,0);//����д��
	year=bcdtodec(uc_R1302(0x8d));//����
}

//��λds1302
void DS1302Reset(){
	DS_SCLK=0;
	Delaylong(100);
	DS_SCLK=1;
	DS_RESET=0;
}



#include <stc8.h>
#include <Hc595.h>
#include <Ds1302.h>
#include <stdio.h> //printf��ӡ
#include <at24c04.h>
unsigned char cnt;

bit REAAok;//��ʼ���ձ�־,1��ʾ��ʼ���ܣ�0��ʾδ��ʼ
bit RECCFinish; //������־ 0��ʾ�����ˣ�1��ʾû����
unsigned char ReNum;//��������
unsigned char Rebuffer[13];//���ܻ�����
unsigned char *p;

unsigned char displayDat[7]={0x00};
extern unsigned char xdata sec,min,hour,day,month,year;
//�롢�֡�ʱ���ա��¡����ڡ���
unsigned char Timedata[7]={0x50,0x30,0x16,0x21,0x10,0x01,0x19};
unsigned char buf[8]={0x01,0x02,0x04,0x08,0x10,0x20,0x40,0x80};

unsigned char Romdata[6]={255};
unsigned char device=5;//�����豸
unsigned char led_flag=0;
unsigned char display_flag=0;
unsigned char display_count=0;
unsigned char led_count=0;
void InitTime(){
	displayDat[7]=sec%10;
	displayDat[6]=sec/10;
	displayDat[5]=min%10;
	displayDat[4]=min/10;
	displayDat[3]=hour%10;
	displayDat[2]=hour/10;
	displayDat[1]=day%10;
	displayDat[0]=day/10;
}
void Timer0Init(void)		//5����@11.0592MHz
{
	AUXR |= 0x80;		//��ʱ��ʱ��1Tģʽ
	TMOD &= 0xF0;		//���ö�ʱ��ģʽ
	TL0 = 0x00;		//���ö�ʱ��ʼֵ
	TH0 = 0x28;		//���ö�ʱ��ʼֵ
	TF0 = 0;		//���TF0��־
	TR0 = 1;		//��ʱ��0��ʼ��ʱ
	ET0=1;
	EA=1;
}
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
	ES=1;
}

void main(){
	//REAAok=0;
	RECCFinish=0;
	ReNum=0;
	*p=&Rebuffer;
	cnt=0;
	UartInit();
	Timer0Init();
	DS1302Reset();
	//Write_DS1302Init(Timedata);

	while(1)
	{
		if(led_flag==0)
		P6=~ReNum;
		if(led_flag==1)
		{
		P6=~buf[led_count];
		}
		
		DisplayScan();
	}
}

void UartSend(unsigned char ch){
		SBUF=ch;
		while(!TI);
		TI=0;
}
char putchar(char c){
	UartSend(c);
	return c;
}


void Timer0_isr() interrupt 1
{
	  unsigned char val=0x00,i;
		cnt++;

		if(cnt==200){
			cnt=0;
/////////////////////////////////////////////////////////////////////////////////////////////
			if(led_flag==1)
			{
				led_count++;
				if(led_count>7)
					led_count=0;
			}
			if(display_flag==0)
			InitTime();
			if(display_flag==1)//�������ˮ
			{
				for(i=0;i<8;i++)
				{
					if(i!=display_count)
						displayDat[i]=18;//����ʾ
					else
						displayDat[i]=19;//��ʾ -
				}
				
				display_count++;
				if(display_count>8) display_count=0;
			}
/////////////////////////////////////////////////////////////////////////////////////////////
			Run_DS1302();//��ȡ1302��ʱ��
			Mult_Read24c04(val,Romdata,6);
			switch(device){
				case 1:{printf("Date is %02bd",year);
								printf(".%02bd",month);
								printf(".%02bd",day);
								printf(",%02bd",hour);
								printf(":%02bd",min);
								printf(":%02bd",sec);
								printf("\r\n");	
				break;}
				case 2:{printf("EEPROM stores:");
				printf(":%02bu",Romdata[0]);
				printf(":%02bu",Romdata[1]);
				printf(":%02bu",Romdata[2]);
				printf(":%02bu",Romdata[3]);
				printf(":%02bu",Romdata[4]);
				printf(":%02bu",Romdata[5]);
				printf("\r\n");
					break;
				}
				default:{printf("no device command!\r\n");break;}
			}				
		}
		TF0=0;
}
void CommandProcess(unsigned char Array[]){
	unsigned char i;
	for(i=0;i<7;i++)
		{
			Timedata[i]=Array[i+1];
		}
	if(Array[0]==0x01){device=1;}
	if(Array[0]==0x02){device=2;}
	if(Array[0]==0x03){device=3;}
	if(Array[0]==0x04){device=4;}
}
void Serial_isr() interrupt 4
{
		unsigned char temp,val;
		if(RI){
			RI=0;
			temp=SBUF;
			if(RECCFinish==0){//�ж��Ƿ������һ֡���ݽ���
				if(REAAok){//�ж��Ƿ��յ�����ʼ�ֽ�
				 Rebuffer[ReNum]=temp;
					if(ReNum>1&& Rebuffer[ReNum]==0x33 && Rebuffer[ReNum-1]==0xCC){//�ж��Ƿ��յ������ַ�
							RECCFinish=1;
							CommandProcess(Rebuffer);
						switch(device)
						{
							case 1:{Write_DS1302Init(Timedata);break;}
							case 2:val=0x00;Mult_Write24c04(val,Timedata,6);break;
							case 3:led_count=0;led_flag=!led_flag;break;
							case 4:display_flag=!display_flag;break;
							default:{break;}
						}
							RECCFinish=0;
							REAAok=0;					
					}
				 ReNum++;				
				}
			if(!REAAok && temp==0xAA){//�ж��Ƿ���ܵ���ʼ�ֽ�
					REAAok=1;
					ReNum=0;			
				}			
			}		
		}
}

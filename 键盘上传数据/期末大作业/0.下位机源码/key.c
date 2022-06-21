#include "key.h"
#include <STC8.H>

//������ʱ����
void DelayKey(unsigned int xms)    // ����11.0592MHz
{
	unsigned char i, j,k;
	for(k=xms; k>0; k--)
	{
		_nop_();
		_nop_();
		_nop_();
		i = 11;
		j = 190;
		do
		{
			while (--j);
		} while (--i);
	}
}

//����ɨ��
unsigned char key_scan()
{
	unsigned char keyvalue,num=0;	//������ֵ������������ʱ����
	GPIO_KEY = 0xf0;               	// ����λΪ1������λΪ0
	if(GPIO_KEY != 0xf0)			//����Ƿ��а�������
	{
		DelayKey(10);            	// ��ʱ����
		if(GPIO_KEY != 0xf0)		//�ٴμ��
		{
			GPIO_KEY=0xf0;
			switch(GPIO_KEY)
			{
				case 0xe0: keyvalue = 3;break;     	// ��3�� ȷ�����󰴼������µ�λ���ǵڼ���
				case 0xd0: keyvalue = 2;break;     	//   2 (1101 0000)
				case 0xb0: keyvalue = 1;break;		//   1
				case 0x70: keyvalue = 0;break;		//	 0
			}
			GPIO_KEY=0x0f;  //���з�ת
			//�ж��Ƿ�Ϊ��0��
			if((GPIO_KEY != 0x0d)||(GPIO_KEY != 0x0b)||(GPIO_KEY != 0x07)){keyvalue = keyvalue;}//ȷ�����ǵ�123��
			if(GPIO_KEY == 0x0d){keyvalue = keyvalue+4;}//��1�У�����4����4���ǵ�0�е��ĸ�����
			if(GPIO_KEY == 0x0b){keyvalue = keyvalue+8;}
			if(GPIO_KEY == 0x07){keyvalue = keyvalue+12;}				
			while((num<50)&&(GPIO_KEY!=0x0f))//����ͣ���ȴ����0.5s
			{
				DelayKey(10);
				num++;
			}
		}			
	}
	// û�а�������ʱ������ֵΪ16
	if(GPIO_KEY==0xF0){keyvalue = 16;}
	return keyvalue;
}



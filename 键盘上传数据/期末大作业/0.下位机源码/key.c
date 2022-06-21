#include "key.h"
#include <STC8.H>

//按键延时消抖
void DelayKey(unsigned int xms)    // 晶振：11.0592MHz
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

//按键扫描
unsigned char key_scan()
{
	unsigned char keyvalue,num=0;	//按键键值变量，按键计时变量
	GPIO_KEY = 0xf0;               	// 高四位为1，低四位为0
	if(GPIO_KEY != 0xf0)			//检测是否有按键按下
	{
		DelayKey(10);            	// 延时消抖
		if(GPIO_KEY != 0xf0)		//再次检测
		{
			GPIO_KEY=0xf0;
			switch(GPIO_KEY)
			{
				case 0xe0: keyvalue = 3;break;     	// 第3列 确定矩阵按键被按下的位置是第几列
				case 0xd0: keyvalue = 2;break;     	//   2 (1101 0000)
				case 0xb0: keyvalue = 1;break;		//   1
				case 0x70: keyvalue = 0;break;		//	 0
			}
			GPIO_KEY=0x0f;  //行列反转
			//判断是否为第0行
			if((GPIO_KEY != 0x0d)||(GPIO_KEY != 0x0b)||(GPIO_KEY != 0x07)){keyvalue = keyvalue;}//确定不是第123行
			if(GPIO_KEY == 0x0d){keyvalue = keyvalue+4;}//第1行，加上4，”4“是第0行的四个按键
			if(GPIO_KEY == 0x0b){keyvalue = keyvalue+8;}
			if(GPIO_KEY == 0x07){keyvalue = keyvalue+12;}				
			while((num<50)&&(GPIO_KEY!=0x0f))//按下停留等待最高0.5s
			{
				DelayKey(10);
				num++;
			}
		}			
	}
	// 没有按键按下时，返回值为16
	if(GPIO_KEY==0xF0){keyvalue = 16;}
	return keyvalue;
}



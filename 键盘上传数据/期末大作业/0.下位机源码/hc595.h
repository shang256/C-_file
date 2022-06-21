#ifndef __HC595_H__
#define __HC595_H__

#include <STC8.H>

#include "intrins.h"

sbit P_HC595_SRCLK = P3^5;            // ��λʱ��
sbit P_HC595_RCLK  = P3^4;            // �洢ʱ��
sbit P_HC595_SDA   = P3^7;            // ���������

void SEG_HC595send(unsigned char x);  // hc595����һ���ֽ�����
void display(unsigned char pos,unsigned char dat); // posλ�������ʾ����dat

#endif

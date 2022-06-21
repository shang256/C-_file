#ifndef __HC595_H__
#define __HC595_H__

#include <STC8.H>

#include "intrins.h"

sbit P_HC595_SRCLK = P3^5;            // 移位时钟
sbit P_HC595_RCLK  = P3^4;            // 存储时钟
sbit P_HC595_SDA   = P3^7;            // 数据输入端

void SEG_HC595send(unsigned char x);  // hc595发送一个字节数据
void display(unsigned char pos,unsigned char dat); // pos位数码管显示数字dat

#endif

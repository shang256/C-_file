#ifndef __KEY_H
#define __KEY_H
#include "stc8a8k64s4a12.h"
#include "intrins.h"

#define GPIO_KEY P0              //宏定义

void DelayKey(unsigned int xms);    // 按键消抖延时函数 ，晶振：11.0592MHz
unsigned char key_scan();			// 按键扫描函数

#endif
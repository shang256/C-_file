#ifndef __KEY_H
#define __KEY_H
#include "stc8a8k64s4a12.h"
#include "intrins.h"

#define GPIO_KEY P0              //�궨��

void DelayKey(unsigned int xms);    // ����������ʱ���� ������11.0592MHz
unsigned char key_scan();			// ����ɨ�躯��

#endif
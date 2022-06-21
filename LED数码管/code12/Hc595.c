//595驱动文件
#include <Hc595.h>
///0,1,2,3,4,5,6,7,8,9,A,B,C,D,E,F 段选                                                                                  18  19
unsigned char const LedData[]={0xc0,0xf9,0xa4,0xb0,0x99,0x92,0x82,0xf8,0x80,0x90,0x88,0x83,0xc6,0xa1,0x8e,0xff,0x00,0xf7,0xff,0xbf};
//位选
unsigned char const LedPos[]={0x01,0x02,0x04,0x08,0x10,0x20,0x40,0x80};
unsigned char display_index=0;
extern unsigned char displayDat[];
void SEG_HC595send(unsigned char x){
	unsigned char i;
	for(i=0;i<8;i++){
	x<<=1;
	SPI_DS=CY;
	SPI_SHCP=1;
	SPI_SHCP=0;
	}
}
void DisplayScan(void){	
	SEG_HC595send(LedPos[display_index]);
	SEG_HC595send(LedData[displayDat[display_index]]);
	SPI_STCP=1;
	SPI_STCP=0;
	if(++display_index>=8)display_index=0;
}
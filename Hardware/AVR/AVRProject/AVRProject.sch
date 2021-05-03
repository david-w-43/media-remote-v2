EESchema Schematic File Version 4
EELAYER 30 0
EELAYER END
$Descr A4 11693 8268
encoding utf-8
Sheet 1 1
Title ""
Date ""
Rev ""
Comp ""
Comment1 ""
Comment2 ""
Comment3 ""
Comment4 ""
$EndDescr
$Comp
L MCU_Microchip_ATmega:ATmega1284P-PU U?
U 1 1 608FE0B0
P 2350 5350
F 0 "U?" H 1850 3300 50  0000 C CNN
F 1 "ATmega1284P-PU" H 1850 3200 50  0000 C CNN
F 2 "Package_DIP:DIP-40_W15.24mm" H 2350 5350 50  0001 C CIN
F 3 "http://ww1.microchip.com/downloads/en/DeviceDoc/Atmel-8272-8-bit-AVR-microcontroller-ATmega164A_PA-324A_PA-644A_PA-1284_P_datasheet.pdf" H 2350 5350 50  0001 C CNN
	1    2350 5350
	1    0    0    -1  
$EndComp
$Comp
L power:+5V #PWR?
U 1 1 6090165E
P 900 6200
F 0 "#PWR?" H 900 6050 50  0001 C CNN
F 1 "+5V" H 915 6373 50  0000 C CNN
F 2 "" H 900 6200 50  0001 C CNN
F 3 "" H 900 6200 50  0001 C CNN
	1    900  6200
	1    0    0    -1  
$EndComp
$Comp
L power:+5V #PWR?
U 1 1 6090247B
P 2400 3250
F 0 "#PWR?" H 2400 3100 50  0001 C CNN
F 1 "+5V" H 2415 3423 50  0000 C CNN
F 2 "" H 2400 3250 50  0001 C CNN
F 3 "" H 2400 3250 50  0001 C CNN
	1    2400 3250
	1    0    0    -1  
$EndComp
Wire Wire Line
	2350 3350 2350 3300
Wire Wire Line
	2350 3300 2400 3300
Wire Wire Line
	2400 3300 2400 3250
Wire Wire Line
	2400 3300 2450 3300
Wire Wire Line
	2450 3300 2450 3350
Connection ~ 2400 3300
$Comp
L Device:CP_Small C?
U 1 1 60903118
P 900 6450
F 0 "C?" H 988 6496 50  0000 L CNN
F 1 "4.7uF" H 988 6405 50  0000 L CNN
F 2 "" H 900 6450 50  0001 C CNN
F 3 "~" H 900 6450 50  0001 C CNN
	1    900  6450
	1    0    0    -1  
$EndComp
$Comp
L Device:C_Small C?
U 1 1 60903CF0
P 1350 6450
F 0 "C?" H 1442 6496 50  0000 L CNN
F 1 "100nF" H 1442 6405 50  0000 L CNN
F 2 "" H 1350 6450 50  0001 C CNN
F 3 "~" H 1350 6450 50  0001 C CNN
	1    1350 6450
	1    0    0    -1  
$EndComp
$Comp
L power:GND #PWR?
U 1 1 60904732
P 1350 6750
F 0 "#PWR?" H 1350 6500 50  0001 C CNN
F 1 "GND" H 1355 6577 50  0000 C CNN
F 2 "" H 1350 6750 50  0001 C CNN
F 3 "" H 1350 6750 50  0001 C CNN
	1    1350 6750
	1    0    0    -1  
$EndComp
Wire Wire Line
	900  6200 900  6300
Wire Wire Line
	1350 6350 1350 6300
Wire Wire Line
	1350 6300 900  6300
Connection ~ 900  6300
Wire Wire Line
	900  6300 900  6350
Wire Wire Line
	900  6550 900  6650
Wire Wire Line
	900  6650 1350 6650
Wire Wire Line
	1350 6650 1350 6750
Wire Wire Line
	1350 6550 1350 6650
Connection ~ 1350 6650
$Comp
L Device:Crystal Y?
U 1 1 609064D0
P 900 4050
F 0 "Y?" H 900 4450 50  0000 C CNN
F 1 "16MHz" H 900 4350 50  0000 C CNN
F 2 "" H 900 4050 50  0001 C CNN
F 3 "~" H 900 4050 50  0001 C CNN
	1    900  4050
	1    0    0    -1  
$EndComp
$Comp
L power:GND #PWR?
U 1 1 60907213
P 900 4500
F 0 "#PWR?" H 900 4250 50  0001 C CNN
F 1 "GND" H 905 4327 50  0000 C CNN
F 2 "" H 900 4500 50  0001 C CNN
F 3 "" H 900 4500 50  0001 C CNN
	1    900  4500
	1    0    0    -1  
$EndComp
$Comp
L power:GND #PWR?
U 1 1 609073EE
P 1650 4500
F 0 "#PWR?" H 1650 4250 50  0001 C CNN
F 1 "GND" H 1655 4327 50  0000 C CNN
F 2 "" H 1650 4500 50  0001 C CNN
F 3 "" H 1650 4500 50  0001 C CNN
	1    1650 4500
	1    0    0    -1  
$EndComp
Wire Wire Line
	1650 4500 1650 4250
Wire Wire Line
	1650 4250 1750 4250
$Comp
L Device:C_Small C?
U 1 1 60907944
P 650 4300
F 0 "C?" H 742 4346 50  0000 L CNN
F 1 "22pF" H 742 4255 50  0000 L CNN
F 2 "" H 650 4300 50  0001 C CNN
F 3 "~" H 650 4300 50  0001 C CNN
	1    650  4300
	1    0    0    -1  
$EndComp
$Comp
L Device:C_Small C?
U 1 1 60907EC5
P 1150 4300
F 0 "C?" H 1242 4346 50  0000 L CNN
F 1 "22pF" H 1242 4255 50  0000 L CNN
F 2 "" H 1150 4300 50  0001 C CNN
F 3 "~" H 1150 4300 50  0001 C CNN
	1    1150 4300
	1    0    0    -1  
$EndComp
Wire Wire Line
	650  4200 650  4050
Wire Wire Line
	650  4050 750  4050
Wire Wire Line
	650  4400 650  4450
Wire Wire Line
	650  4450 900  4450
Wire Wire Line
	900  4450 900  4500
Wire Wire Line
	900  4450 1150 4450
Wire Wire Line
	1150 4450 1150 4400
Connection ~ 900  4450
Wire Wire Line
	1050 4050 1150 4050
Wire Wire Line
	1150 4050 1150 4200
Wire Wire Line
	1150 4050 1750 4050
Connection ~ 1150 4050
Wire Wire Line
	650  4050 650  3850
Wire Wire Line
	650  3850 1750 3850
Connection ~ 650  4050
$Comp
L power:GND #PWR?
U 1 1 6090BE84
P 2350 7400
F 0 "#PWR?" H 2350 7150 50  0001 C CNN
F 1 "GND" H 2355 7227 50  0000 C CNN
F 2 "" H 2350 7400 50  0001 C CNN
F 3 "" H 2350 7400 50  0001 C CNN
	1    2350 7400
	1    0    0    -1  
$EndComp
Wire Wire Line
	2350 7350 2350 7400
Wire Wire Line
	1750 3650 1350 3650
Text Label 1350 3650 0    50   ~ 0
RESET
Wire Wire Line
	2950 4650 3550 4650
Text Label 3550 4650 2    50   ~ 0
LCD_RST
Wire Wire Line
	2950 4850 3550 4850
Text Label 3550 4850 2    50   ~ 0
LCD_BKL
Wire Wire Line
	2950 4950 3550 4950
Wire Wire Line
	2950 5050 3550 5050
Wire Wire Line
	2950 5150 3550 5150
Wire Wire Line
	2950 5250 3550 5250
Text Label 3550 4950 2    50   ~ 0
LCD_SS
Text Label 3550 5050 2    50   ~ 0
MOSI
Text Label 3550 5150 2    50   ~ 0
MISO
Text Label 3550 5250 2    50   ~ 0
SCK
Wire Wire Line
	2950 3650 3550 3650
Wire Wire Line
	2950 3750 3550 3750
Wire Wire Line
	2950 3850 3550 3850
Wire Wire Line
	2950 3950 3550 3950
Wire Wire Line
	2950 4050 3550 4050
Wire Wire Line
	2950 4150 3550 4150
Text Label 3550 3650 2    50   ~ 0
SW1
Text Label 3550 3750 2    50   ~ 0
SW2
Text Label 3550 3850 2    50   ~ 0
SW3
Text Label 3550 3950 2    50   ~ 0
SW4
Text Label 3550 4050 2    50   ~ 0
SW_ENC
Text Label 3550 4150 2    50   ~ 0
TEMP_1W
Wire Wire Line
	2950 5450 3550 5450
Wire Wire Line
	2950 5550 3550 5550
Text Label 3550 5450 2    50   ~ 0
SCL
Text Label 3550 5550 2    50   ~ 0
SDA
Wire Wire Line
	2950 6350 3550 6350
Wire Wire Line
	2950 6450 3550 6450
Wire Wire Line
	2950 6550 3550 6550
Wire Wire Line
	2950 6650 3550 6650
Text Label 3550 6350 2    50   ~ 0
RXD
Text Label 3550 6450 2    50   ~ 0
TXD
Text Label 3550 6550 2    50   ~ 0
ENC_0
Text Label 3550 6650 2    50   ~ 0
ENC_1
NoConn ~ 2950 4250
NoConn ~ 2950 4350
NoConn ~ 2950 4550
NoConn ~ 2950 4750
NoConn ~ 2950 5650
NoConn ~ 2950 5750
NoConn ~ 2950 5850
NoConn ~ 2950 5950
NoConn ~ 2950 6050
NoConn ~ 2950 6150
NoConn ~ 2950 6750
NoConn ~ 2950 6850
NoConn ~ 2950 6950
NoConn ~ 2950 7050
$Comp
L Interface_USB:FT232RL U?
U 1 1 60937708
P 9300 4650
F 0 "U?" H 9600 5850 50  0000 C CNN
F 1 "FT232RL" H 9600 5750 50  0000 C CNN
F 2 "Package_SO:SSOP-28_5.3x10.2mm_P0.65mm" H 10400 3750 50  0001 C CNN
F 3 "https://www.ftdichip.com/Support/Documents/DataSheets/ICs/DS_FT232R.pdf" H 9300 4650 50  0001 C CNN
	1    9300 4650
	1    0    0    -1  
$EndComp
$Comp
L power:GND #PWR?
U 1 1 6093A8A2
P 9300 5850
F 0 "#PWR?" H 9300 5600 50  0001 C CNN
F 1 "GND" H 9305 5677 50  0000 C CNN
F 2 "" H 9300 5850 50  0001 C CNN
F 3 "" H 9300 5850 50  0001 C CNN
	1    9300 5850
	1    0    0    -1  
$EndComp
Wire Wire Line
	9100 5650 9100 5750
Wire Wire Line
	9100 5750 9300 5750
Wire Wire Line
	9300 5750 9300 5850
Wire Wire Line
	9300 5650 9300 5750
Connection ~ 9300 5750
Wire Wire Line
	9400 5650 9400 5750
Wire Wire Line
	9400 5750 9300 5750
Wire Wire Line
	9500 5650 9500 5750
Wire Wire Line
	9500 5750 9400 5750
Connection ~ 9400 5750
$Comp
L Device:R_Small R?
U 1 1 6093DD7C
P 10350 3950
F 0 "R?" V 10154 3950 50  0000 C CNN
F 1 "1K" V 10245 3950 50  0000 C CNN
F 2 "" H 10350 3950 50  0001 C CNN
F 3 "~" H 10350 3950 50  0001 C CNN
	1    10350 3950
	0    1    1    0   
$EndComp
$Comp
L Device:R_Small R?
U 1 1 6093E1FD
P 10350 4050
F 0 "R?" V 10450 4050 50  0000 C CNN
F 1 "1K" V 10550 4050 50  0000 C CNN
F 2 "" H 10350 4050 50  0001 C CNN
F 3 "~" H 10350 4050 50  0001 C CNN
	1    10350 4050
	0    1    1    0   
$EndComp
Wire Wire Line
	10100 3950 10250 3950
Wire Wire Line
	10100 4050 10250 4050
Wire Wire Line
	10450 3950 10850 3950
Wire Wire Line
	10450 4050 10850 4050
Text Label 10850 3950 2    50   ~ 0
TXD
Text Label 10850 4050 2    50   ~ 0
RXD
$Comp
L Device:C_Small C?
U 1 1 6094228B
P 10350 4350
F 0 "C?" V 10450 4350 50  0000 C CNN
F 1 "100n" V 10550 4350 50  0000 C CNN
F 2 "" H 10350 4350 50  0001 C CNN
F 3 "~" H 10350 4350 50  0001 C CNN
	1    10350 4350
	0    1    1    0   
$EndComp
Wire Wire Line
	10100 4350 10250 4350
Wire Wire Line
	10450 4350 10850 4350
Text Label 10850 4350 2    50   ~ 0
RESET
$Comp
L power:+5V #PWR?
U 1 1 60945426
P 11000 4850
F 0 "#PWR?" H 11000 4700 50  0001 C CNN
F 1 "+5V" H 11015 5023 50  0000 C CNN
F 2 "" H 11000 4850 50  0001 C CNN
F 3 "" H 11000 4850 50  0001 C CNN
	1    11000 4850
	1    0    0    -1  
$EndComp
$Comp
L Device:LED_Small_ALT D?
U 1 1 60946A1F
P 10650 4900
F 0 "D?" H 10650 5135 50  0000 C CNN
F 1 "RED" H 10650 5044 50  0000 C CNN
F 2 "" V 10650 4900 50  0001 C CNN
F 3 "~" V 10650 4900 50  0001 C CNN
	1    10650 4900
	1    0    0    -1  
$EndComp
$Comp
L Device:LED_Small_ALT D?
U 1 1 60947350
P 10650 5100
F 0 "D?" H 10650 5000 50  0000 C CNN
F 1 "GREEN" H 10650 4900 50  0000 C CNN
F 2 "" V 10650 5100 50  0001 C CNN
F 3 "~" V 10650 5100 50  0001 C CNN
	1    10650 5100
	1    0    0    -1  
$EndComp
$Comp
L Device:R_Small R?
U 1 1 6094A12F
P 10350 4900
F 0 "R?" V 10150 4900 50  0000 C CNN
F 1 "220R" V 10250 4900 50  0000 C CNN
F 2 "" H 10350 4900 50  0001 C CNN
F 3 "~" H 10350 4900 50  0001 C CNN
	1    10350 4900
	0    1    1    0   
$EndComp
$Comp
L Device:R_Small R?
U 1 1 6094AB36
P 10350 5100
F 0 "R?" V 10450 5100 50  0000 C CNN
F 1 "220R" V 10550 5100 50  0000 C CNN
F 2 "" H 10350 5100 50  0001 C CNN
F 3 "~" H 10350 5100 50  0001 C CNN
	1    10350 5100
	0    1    1    0   
$EndComp
Wire Wire Line
	10100 4950 10150 4950
Wire Wire Line
	10150 4950 10150 4900
Wire Wire Line
	10150 4900 10250 4900
Wire Wire Line
	10450 4900 10550 4900
Wire Wire Line
	10750 4900 11000 4900
Wire Wire Line
	11000 4900 11000 4850
Wire Wire Line
	10150 5050 10150 5100
Wire Wire Line
	10150 5100 10250 5100
Wire Wire Line
	10100 5050 10150 5050
Wire Wire Line
	10450 5100 10550 5100
Wire Wire Line
	10750 5100 11000 5100
Wire Wire Line
	11000 5100 11000 4900
Connection ~ 11000 4900
$Comp
L power:GND #PWR?
U 1 1 60957A3E
P 8400 5450
F 0 "#PWR?" H 8400 5200 50  0001 C CNN
F 1 "GND" H 8405 5277 50  0000 C CNN
F 2 "" H 8400 5450 50  0001 C CNN
F 3 "" H 8400 5450 50  0001 C CNN
	1    8400 5450
	1    0    0    -1  
$EndComp
Wire Wire Line
	8500 5350 8400 5350
Wire Wire Line
	8400 5350 8400 5450
$Comp
L Connector:USB_B J?
U 1 1 6095A3CB
P 7750 4250
F 0 "J?" H 7807 4717 50  0000 C CNN
F 1 "USB_B" H 7807 4626 50  0000 C CNN
F 2 "" H 7900 4200 50  0001 C CNN
F 3 " ~" H 7900 4200 50  0001 C CNN
	1    7750 4250
	1    0    0    -1  
$EndComp
Wire Wire Line
	8050 4250 8500 4250
Wire Wire Line
	8050 4350 8500 4350
$Comp
L power:+5V #PWR?
U 1 1 6095EF78
P 8150 3950
F 0 "#PWR?" H 8150 3800 50  0001 C CNN
F 1 "+5V" H 8165 4123 50  0000 C CNN
F 2 "" H 8150 3950 50  0001 C CNN
F 3 "" H 8150 3950 50  0001 C CNN
	1    8150 3950
	1    0    0    -1  
$EndComp
$Comp
L power:+5V #PWR?
U 1 1 6095FC36
P 9300 3500
F 0 "#PWR?" H 9300 3350 50  0001 C CNN
F 1 "+5V" H 9315 3673 50  0000 C CNN
F 2 "" H 9300 3500 50  0001 C CNN
F 3 "" H 9300 3500 50  0001 C CNN
	1    9300 3500
	1    0    0    -1  
$EndComp
Wire Wire Line
	9300 3500 9300 3600
Wire Wire Line
	9300 3600 9200 3600
Wire Wire Line
	9200 3600 9200 3650
Wire Wire Line
	9300 3600 9400 3600
Wire Wire Line
	9400 3600 9400 3650
Connection ~ 9300 3600
Wire Wire Line
	8050 4050 8150 4050
Wire Wire Line
	8150 4050 8150 3950
$Comp
L power:GND #PWR?
U 1 1 6096520D
P 7700 4750
F 0 "#PWR?" H 7700 4500 50  0001 C CNN
F 1 "GND" H 7705 4577 50  0000 C CNN
F 2 "" H 7700 4750 50  0001 C CNN
F 3 "" H 7700 4750 50  0001 C CNN
	1    7700 4750
	1    0    0    -1  
$EndComp
Wire Wire Line
	7650 4650 7650 4700
Wire Wire Line
	7650 4700 7700 4700
Wire Wire Line
	7700 4700 7700 4750
Wire Wire Line
	7750 4650 7750 4700
Wire Wire Line
	7750 4700 7700 4700
Connection ~ 7700 4700
$Comp
L Device:CP_Small C?
U 1 1 60971303
P 7500 5500
F 0 "C?" H 7588 5546 50  0000 L CNN
F 1 "4.7uF" H 7588 5455 50  0000 L CNN
F 2 "" H 7500 5500 50  0001 C CNN
F 3 "~" H 7500 5500 50  0001 C CNN
	1    7500 5500
	1    0    0    -1  
$EndComp
$Comp
L Device:C_Small C?
U 1 1 60971309
P 7950 5500
F 0 "C?" H 8042 5546 50  0000 L CNN
F 1 "100nF" H 8042 5455 50  0000 L CNN
F 2 "" H 7950 5500 50  0001 C CNN
F 3 "~" H 7950 5500 50  0001 C CNN
	1    7950 5500
	1    0    0    -1  
$EndComp
$Comp
L power:GND #PWR?
U 1 1 6097130F
P 7950 5800
F 0 "#PWR?" H 7950 5550 50  0001 C CNN
F 1 "GND" H 7955 5627 50  0000 C CNN
F 2 "" H 7950 5800 50  0001 C CNN
F 3 "" H 7950 5800 50  0001 C CNN
	1    7950 5800
	1    0    0    -1  
$EndComp
Wire Wire Line
	7500 5250 7500 5350
Wire Wire Line
	7950 5400 7950 5350
Wire Wire Line
	7950 5350 7500 5350
Connection ~ 7500 5350
Wire Wire Line
	7500 5350 7500 5400
Wire Wire Line
	7500 5600 7500 5700
Wire Wire Line
	7500 5700 7950 5700
Wire Wire Line
	7950 5700 7950 5800
Wire Wire Line
	7950 5600 7950 5700
Connection ~ 7950 5700
$Comp
L power:+5V #PWR?
U 1 1 60973610
P 7500 5250
F 0 "#PWR?" H 7500 5100 50  0001 C CNN
F 1 "+5V" H 7515 5423 50  0000 C CNN
F 2 "" H 7500 5250 50  0001 C CNN
F 3 "" H 7500 5250 50  0001 C CNN
	1    7500 5250
	1    0    0    -1  
$EndComp
NoConn ~ 8500 4650
NoConn ~ 8500 4850
NoConn ~ 8500 5050
NoConn ~ 10100 5350
NoConn ~ 10100 5250
NoConn ~ 10100 5150
NoConn ~ 10100 4650
NoConn ~ 10100 4550
NoConn ~ 10100 4450
NoConn ~ 10100 4250
NoConn ~ 10100 4150
$Comp
L power:+3.3V #PWR?
U 1 1 6098BC1A
P 8400 3850
F 0 "#PWR?" H 8400 3700 50  0001 C CNN
F 1 "+3.3V" H 8415 4023 50  0000 C CNN
F 2 "" H 8400 3850 50  0001 C CNN
F 3 "" H 8400 3850 50  0001 C CNN
	1    8400 3850
	1    0    0    -1  
$EndComp
Wire Wire Line
	8400 3850 8400 3950
Wire Wire Line
	8400 3950 8500 3950
$Comp
L Connector_Generic:Conn_01x09 J?
U 1 1 609BA52F
P 5050 1750
F 0 "J?" H 5130 1792 50  0000 L CNN
F 1 "LCD_CONN" H 5130 1701 50  0000 L CNN
F 2 "" H 5050 1750 50  0001 C CNN
F 3 "~" H 5050 1750 50  0001 C CNN
	1    5050 1750
	1    0    0    -1  
$EndComp
$Comp
L power:+5V #PWR?
U 1 1 609BB43C
P 4300 1250
F 0 "#PWR?" H 4300 1100 50  0001 C CNN
F 1 "+5V" H 4315 1423 50  0000 C CNN
F 2 "" H 4300 1250 50  0001 C CNN
F 3 "" H 4300 1250 50  0001 C CNN
	1    4300 1250
	1    0    0    -1  
$EndComp
Wire Wire Line
	4300 1250 4300 1450
Wire Wire Line
	4300 1450 4300 2050
Connection ~ 4300 1450
$Comp
L power:GND #PWR?
U 1 1 609C14E8
P 4400 2100
F 0 "#PWR?" H 4400 1850 50  0001 C CNN
F 1 "GND" H 4405 1927 50  0000 C CNN
F 2 "" H 4400 2100 50  0001 C CNN
F 3 "" H 4400 2100 50  0001 C CNN
	1    4400 2100
	1    0    0    -1  
$EndComp
Wire Wire Line
	4400 1350 4400 1850
Connection ~ 4400 1850
Wire Wire Line
	4400 1850 4400 2100
Wire Wire Line
	4400 1350 4850 1350
Wire Wire Line
	4300 1450 4850 1450
Wire Wire Line
	4400 1850 4850 1850
Wire Wire Line
	4300 2050 4850 2050
Text Label 4500 1950 0    50   ~ 0
LCD_RST
Wire Wire Line
	4850 1550 4500 1550
Wire Wire Line
	4500 1950 4850 1950
Wire Wire Line
	4850 1650 4500 1650
Wire Wire Line
	4850 1750 4500 1750
Text Label 4500 1550 0    50   ~ 0
LCD_SS
Text Label 4500 1650 0    50   ~ 0
MOSI
Text Label 4500 1750 0    50   ~ 0
SCK
$Comp
L Device:Q_NPN_BCE Q?
U 1 1 609EDBC8
P 4700 2400
F 0 "Q?" H 4891 2446 50  0000 L CNN
F 1 "2N3904TA" H 4891 2355 50  0000 L CNN
F 2 "" H 4900 2500 50  0001 C CNN
F 3 "~" H 4700 2400 50  0001 C CNN
	1    4700 2400
	1    0    0    -1  
$EndComp
Wire Wire Line
	4800 2200 4800 2150
Wire Wire Line
	4800 2150 4850 2150
$Comp
L power:GND #PWR?
U 1 1 609F3212
P 4800 2600
F 0 "#PWR?" H 4800 2350 50  0001 C CNN
F 1 "GND" H 4805 2427 50  0000 C CNN
F 2 "" H 4800 2600 50  0001 C CNN
F 3 "" H 4800 2600 50  0001 C CNN
	1    4800 2600
	1    0    0    -1  
$EndComp
$Comp
L Device:R_Small R?
U 1 1 609F3A00
P 4400 2400
F 0 "R?" V 4500 2400 50  0000 C CNN
F 1 "4K7" V 4600 2400 50  0000 C CNN
F 2 "" H 4400 2400 50  0001 C CNN
F 3 "~" H 4400 2400 50  0001 C CNN
	1    4400 2400
	0    1    1    0   
$EndComp
Text Label 3950 2400 0    50   ~ 0
LCD_BKL
Wire Wire Line
	3950 2400 4300 2400
Text Notes 1650 3200 0    100  ~ 20
MCU
Text Notes 4600 850  0    100  ~ 20
LCD
Text Notes 8300 3450 0    100  ~ 20
USB
$Comp
L Timer:MCP7940N-xMS U?
U 1 1 609FC5A6
P 2050 1700
F 0 "U?" H 1550 1200 50  0000 C CNN
F 1 "MCP79410-I/MS" H 1600 1100 50  0000 C CNN
F 2 "" H 2050 1700 50  0001 C CNN
F 3 "http://ww1.microchip.com/downloads/en/DeviceDoc/20005010F.pdf" H 2050 1700 50  0001 C CNN
	1    2050 1700
	1    0    0    -1  
$EndComp
$Comp
L power:+5V #PWR?
U 1 1 609FE9A1
P 1950 1200
F 0 "#PWR?" H 1950 1050 50  0001 C CNN
F 1 "+5V" H 1965 1373 50  0000 C CNN
F 2 "" H 1950 1200 50  0001 C CNN
F 3 "" H 1950 1200 50  0001 C CNN
	1    1950 1200
	1    0    0    -1  
$EndComp
$Comp
L power:+BATT #PWR?
U 1 1 609FFB6F
P 2250 1200
F 0 "#PWR?" H 2250 1050 50  0001 C CNN
F 1 "+BATT" H 2265 1373 50  0000 C CNN
F 2 "" H 2250 1200 50  0001 C CNN
F 3 "" H 2250 1200 50  0001 C CNN
	1    2250 1200
	1    0    0    -1  
$EndComp
Wire Wire Line
	2150 1250 2150 1300
Wire Wire Line
	2050 1250 2050 1300
Wire Wire Line
	1950 1200 1950 1250
Wire Wire Line
	1950 1250 2050 1250
Wire Wire Line
	2250 1250 2250 1200
Wire Wire Line
	2150 1250 2250 1250
$Comp
L Device:Crystal_Small Y?
U 1 1 60A140D5
P 2600 1700
F 0 "Y?" V 2554 1788 50  0000 L CNN
F 1 "32.768kHz" V 2645 1788 50  0000 L CNN
F 2 "" H 2600 1700 50  0001 C CNN
F 3 "~" H 2600 1700 50  0001 C CNN
	1    2600 1700
	0    1    1    0   
$EndComp
$Comp
L Device:C_Small C?
U 1 1 60A14FEA
P 3200 1600
F 0 "C?" V 2971 1600 50  0000 C CNN
F 1 "10p" V 3062 1600 50  0000 C CNN
F 2 "" H 3200 1600 50  0001 C CNN
F 3 "~" H 3200 1600 50  0001 C CNN
	1    3200 1600
	0    1    1    0   
$EndComp
$Comp
L Device:C_Small C?
U 1 1 60A15A83
P 3200 1800
F 0 "C?" V 3350 1800 50  0000 C CNN
F 1 "10p" V 3450 1800 50  0000 C CNN
F 2 "" H 3200 1800 50  0001 C CNN
F 3 "~" H 3200 1800 50  0001 C CNN
	1    3200 1800
	0    1    1    0   
$EndComp
$Comp
L power:GND #PWR?
U 1 1 60A16392
P 3400 1900
F 0 "#PWR?" H 3400 1650 50  0001 C CNN
F 1 "GND" H 3405 1727 50  0000 C CNN
F 2 "" H 3400 1900 50  0001 C CNN
F 3 "" H 3400 1900 50  0001 C CNN
	1    3400 1900
	1    0    0    -1  
$EndComp
Wire Wire Line
	2450 1600 2600 1600
Wire Wire Line
	2600 1600 3100 1600
Connection ~ 2600 1600
Wire Wire Line
	2450 1800 2600 1800
Wire Wire Line
	2600 1800 3100 1800
Connection ~ 2600 1800
Wire Wire Line
	3300 1600 3400 1600
Wire Wire Line
	3400 1600 3400 1800
Wire Wire Line
	3300 1800 3400 1800
Connection ~ 3400 1800
Wire Wire Line
	3400 1800 3400 1900
$Comp
L power:GND #PWR?
U 1 1 60A2FF94
P 2050 2100
F 0 "#PWR?" H 2050 1850 50  0001 C CNN
F 1 "GND" H 2055 1927 50  0000 C CNN
F 2 "" H 2050 2100 50  0001 C CNN
F 3 "" H 2050 2100 50  0001 C CNN
	1    2050 2100
	1    0    0    -1  
$EndComp
$Comp
L power:+5V #PWR?
U 1 1 60A304A9
P 1200 1200
F 0 "#PWR?" H 1200 1050 50  0001 C CNN
F 1 "+5V" H 1215 1373 50  0000 C CNN
F 2 "" H 1200 1200 50  0001 C CNN
F 3 "" H 1200 1200 50  0001 C CNN
	1    1200 1200
	1    0    0    -1  
$EndComp
$Comp
L Device:R_Small R?
U 1 1 60A311C5
P 1450 1400
F 0 "R?" H 1509 1446 50  0000 L CNN
F 1 "4K7" H 1509 1355 50  0000 L CNN
F 2 "" H 1450 1400 50  0001 C CNN
F 3 "~" H 1450 1400 50  0001 C CNN
	1    1450 1400
	1    0    0    -1  
$EndComp
$Comp
L Device:R_Small R?
U 1 1 60A319FC
P 1200 1500
F 0 "R?" H 1259 1546 50  0000 L CNN
F 1 "4K7" H 1259 1455 50  0000 L CNN
F 2 "" H 1200 1500 50  0001 C CNN
F 3 "~" H 1200 1500 50  0001 C CNN
	1    1200 1500
	1    0    0    -1  
$EndComp
Wire Wire Line
	1650 1500 1450 1500
Wire Wire Line
	1650 1600 1200 1600
Wire Wire Line
	1200 1200 1200 1250
Wire Wire Line
	1450 1300 1450 1250
Wire Wire Line
	1450 1250 1200 1250
Connection ~ 1200 1250
Wire Wire Line
	1200 1250 1200 1400
NoConn ~ 1650 1800
Wire Wire Line
	1450 1500 1450 1700
Wire Wire Line
	1450 1700 800  1700
Connection ~ 1450 1500
Wire Wire Line
	1200 1600 1200 1800
Wire Wire Line
	1200 1800 800  1800
Connection ~ 1200 1600
Text Label 800  1700 0    50   ~ 0
SCL
Text Label 800  1800 0    50   ~ 0
SDA
Text Notes 2000 750  0    100  ~ 20
RTC
$Comp
L Sensor_Temperature:DS18B20 U?
U 1 1 60A54FF9
P 4700 4200
F 0 "U?" H 4470 4246 50  0000 R CNN
F 1 "DS18B20" H 4470 4155 50  0000 R CNN
F 2 "Package_TO_SOT_THT:TO-92_Inline" H 3700 3950 50  0001 C CNN
F 3 "http://datasheets.maximintegrated.com/en/ds/DS18B20.pdf" H 4550 4450 50  0001 C CNN
	1    4700 4200
	1    0    0    -1  
$EndComp
$Comp
L power:+5V #PWR?
U 1 1 60A55CC5
P 4700 3700
F 0 "#PWR?" H 4700 3550 50  0001 C CNN
F 1 "+5V" H 4715 3873 50  0000 C CNN
F 2 "" H 4700 3700 50  0001 C CNN
F 3 "" H 4700 3700 50  0001 C CNN
	1    4700 3700
	1    0    0    -1  
$EndComp
$Comp
L Device:R_Small R?
U 1 1 60A568D3
P 5100 4000
F 0 "R?" H 5159 4046 50  0000 L CNN
F 1 "6K8" H 5159 3955 50  0000 L CNN
F 2 "" H 5100 4000 50  0001 C CNN
F 3 "~" H 5100 4000 50  0001 C CNN
	1    5100 4000
	1    0    0    -1  
$EndComp
Wire Wire Line
	4700 3900 4700 3800
Wire Wire Line
	4700 3800 5100 3800
Wire Wire Line
	5100 3800 5100 3900
Connection ~ 4700 3800
Wire Wire Line
	4700 3800 4700 3700
Wire Wire Line
	5000 4200 5100 4200
Wire Wire Line
	5100 4200 5100 4100
Wire Wire Line
	5100 4200 5450 4200
Connection ~ 5100 4200
Text Label 5450 4200 2    50   ~ 0
TEMP_1W
$Comp
L power:GND #PWR?
U 1 1 60A6DEB7
P 4700 4500
F 0 "#PWR?" H 4700 4250 50  0001 C CNN
F 1 "GND" H 4705 4327 50  0000 C CNN
F 2 "" H 4700 4500 50  0001 C CNN
F 3 "" H 4700 4500 50  0001 C CNN
	1    4700 4500
	1    0    0    -1  
$EndComp
Text Notes 4550 3250 0    100  ~ 20
TEMP
$Comp
L Connector_Generic:Conn_02x03_Odd_Even J?
U 1 1 60A6EEA3
P 4700 5850
F 0 "J?" H 4750 6167 50  0000 C CNN
F 1 "ICSP" H 4750 6076 50  0000 C CNN
F 2 "" H 4700 5850 50  0001 C CNN
F 3 "~" H 4700 5850 50  0001 C CNN
	1    4700 5850
	1    0    0    -1  
$EndComp
Wire Wire Line
	4500 5750 4100 5750
Wire Wire Line
	4500 5850 4100 5850
Wire Wire Line
	4500 5950 4100 5950
Wire Wire Line
	5000 5850 5350 5850
Text Label 4100 5750 0    50   ~ 0
MISO
Text Label 4100 5850 0    50   ~ 0
SCK
Text Label 4100 5950 0    50   ~ 0
RESET
Text Label 5350 5850 2    50   ~ 0
MOSI
$Comp
L power:GND #PWR?
U 1 1 60A95E3B
P 5100 6050
F 0 "#PWR?" H 5100 5800 50  0001 C CNN
F 1 "GND" H 5105 5877 50  0000 C CNN
F 2 "" H 5100 6050 50  0001 C CNN
F 3 "" H 5100 6050 50  0001 C CNN
	1    5100 6050
	1    0    0    -1  
$EndComp
$Comp
L power:+5V #PWR?
U 1 1 60A96875
P 5100 5650
F 0 "#PWR?" H 5100 5500 50  0001 C CNN
F 1 "+5V" H 5115 5823 50  0000 C CNN
F 2 "" H 5100 5650 50  0001 C CNN
F 3 "" H 5100 5650 50  0001 C CNN
	1    5100 5650
	1    0    0    -1  
$EndComp
Wire Wire Line
	5100 5650 5100 5750
Wire Wire Line
	5100 5750 5000 5750
Wire Wire Line
	5000 5950 5100 5950
Wire Wire Line
	5100 5950 5100 6050
Text Notes 4500 5100 0    100  ~ 20
ICSP
$Comp
L Connector_Generic:Conn_01x02 J?
U 1 1 60AA3C92
P 4300 7350
F 0 "J?" H 4218 7025 50  0000 C CNN
F 1 "RESET" H 4218 7116 50  0000 C CNN
F 2 "" H 4300 7350 50  0001 C CNN
F 3 "~" H 4300 7350 50  0001 C CNN
	1    4300 7350
	-1   0    0    1   
$EndComp
Text Notes 4150 6600 0    100  ~ 20
Manual Reset
$Comp
L power:+5V #PWR?
U 1 1 60AB10C5
P 4700 7000
F 0 "#PWR?" H 4700 6850 50  0001 C CNN
F 1 "+5V" H 4715 7173 50  0000 C CNN
F 2 "" H 4700 7000 50  0001 C CNN
F 3 "" H 4700 7000 50  0001 C CNN
	1    4700 7000
	1    0    0    -1  
$EndComp
$Comp
L Device:R_Small R?
U 1 1 60AB230F
P 4700 7100
F 0 "R?" H 4759 7146 50  0000 L CNN
F 1 "10K" H 4759 7055 50  0000 L CNN
F 2 "" H 4700 7100 50  0001 C CNN
F 3 "~" H 4700 7100 50  0001 C CNN
	1    4700 7100
	1    0    0    -1  
$EndComp
Wire Wire Line
	4500 7250 4700 7250
Wire Wire Line
	4700 7250 4700 7200
Wire Wire Line
	4700 7250 5150 7250
Connection ~ 4700 7250
Text Label 5150 7250 2    50   ~ 0
RESET
$Comp
L power:GND #PWR?
U 1 1 60AC00B1
P 4550 7400
F 0 "#PWR?" H 4550 7150 50  0001 C CNN
F 1 "GND" H 4555 7227 50  0000 C CNN
F 2 "" H 4550 7400 50  0001 C CNN
F 3 "" H 4550 7400 50  0001 C CNN
	1    4550 7400
	1    0    0    -1  
$EndComp
Wire Wire Line
	4500 7350 4550 7350
Wire Wire Line
	4550 7350 4550 7400
Wire Notes Line
	3750 500  3750 7800
Wire Notes Line
	5650 6350 3750 6350
Wire Notes Line
	5650 500  5650 7800
$Comp
L Switch:SW_SPST SW?
U 1 1 60BD9218
P 6600 1250
F 0 "SW?" H 6600 1485 50  0000 C CNN
F 1 "SW_SPST" H 6600 1394 50  0000 C CNN
F 2 "" H 6600 1250 50  0001 C CNN
F 3 "~" H 6600 1250 50  0001 C CNN
	1    6600 1250
	1    0    0    -1  
$EndComp
$Comp
L Switch:SW_SPST SW?
U 1 1 60BD9F08
P 6600 1650
F 0 "SW?" H 6600 1885 50  0000 C CNN
F 1 "SW_SPST" H 6600 1794 50  0000 C CNN
F 2 "" H 6600 1650 50  0001 C CNN
F 3 "~" H 6600 1650 50  0001 C CNN
	1    6600 1650
	1    0    0    -1  
$EndComp
$Comp
L Switch:SW_SPST SW?
U 1 1 60BDA329
P 6600 2050
F 0 "SW?" H 6600 2285 50  0000 C CNN
F 1 "SW_SPST" H 6600 2194 50  0000 C CNN
F 2 "" H 6600 2050 50  0001 C CNN
F 3 "~" H 6600 2050 50  0001 C CNN
	1    6600 2050
	1    0    0    -1  
$EndComp
$Comp
L Switch:SW_SPST SW?
U 1 1 60BDA60F
P 6600 2450
F 0 "SW?" H 6600 2685 50  0000 C CNN
F 1 "SW_SPST" H 6600 2594 50  0000 C CNN
F 2 "" H 6600 2450 50  0001 C CNN
F 3 "~" H 6600 2450 50  0001 C CNN
	1    6600 2450
	1    0    0    -1  
$EndComp
$Comp
L power:GND #PWR?
U 1 1 60BDAF81
P 6900 2650
F 0 "#PWR?" H 6900 2400 50  0001 C CNN
F 1 "GND" H 6905 2477 50  0000 C CNN
F 2 "" H 6900 2650 50  0001 C CNN
F 3 "" H 6900 2650 50  0001 C CNN
	1    6900 2650
	1    0    0    -1  
$EndComp
Wire Wire Line
	6800 1250 6900 1250
Wire Wire Line
	6900 1250 6900 1650
Wire Wire Line
	6800 1650 6900 1650
Connection ~ 6900 1650
Wire Wire Line
	6900 1650 6900 2050
Wire Wire Line
	6800 2050 6900 2050
Connection ~ 6900 2050
Wire Wire Line
	6900 2050 6900 2450
Wire Wire Line
	6800 2450 6900 2450
Connection ~ 6900 2450
Wire Wire Line
	6900 2450 6900 2650
Wire Wire Line
	6400 1250 6050 1250
Wire Wire Line
	6400 1650 6050 1650
Wire Wire Line
	6400 2050 6050 2050
Wire Wire Line
	6400 2450 6050 2450
Text Label 6050 1250 0    50   ~ 0
SW1
Text Label 6050 1650 0    50   ~ 0
SW2
Text Label 6050 2050 0    50   ~ 0
SW3
Text Label 6050 2450 0    50   ~ 0
SW4
Text Notes 6150 900  0    100  ~ 20
SPST Array
$Comp
L Device:Rotary_Encoder_Switch SW?
U 1 1 60C2454E
P 6550 4100
F 0 "SW?" H 6550 4467 50  0000 C CNN
F 1 "Rotary_Encoder_Switch" H 6550 4376 50  0000 C CNN
F 2 "" H 6400 4260 50  0001 C CNN
F 3 "~" H 6550 4360 50  0001 C CNN
	1    6550 4100
	1    0    0    -1  
$EndComp
$Comp
L power:GND #PWR?
U 1 1 60C255D4
P 6900 4250
F 0 "#PWR?" H 6900 4000 50  0001 C CNN
F 1 "GND" H 6905 4077 50  0000 C CNN
F 2 "" H 6900 4250 50  0001 C CNN
F 3 "" H 6900 4250 50  0001 C CNN
	1    6900 4250
	1    0    0    -1  
$EndComp
Wire Wire Line
	6850 4200 6900 4200
Wire Wire Line
	6900 4200 6900 4250
$Comp
L power:GND #PWR?
U 1 1 60C2E45C
P 6200 4300
F 0 "#PWR?" H 6200 4050 50  0001 C CNN
F 1 "GND" H 6205 4127 50  0000 C CNN
F 2 "" H 6200 4300 50  0001 C CNN
F 3 "" H 6200 4300 50  0001 C CNN
	1    6200 4300
	1    0    0    -1  
$EndComp
Text Label 7200 4000 2    50   ~ 0
SW_ENC
Wire Wire Line
	6850 4000 7200 4000
Wire Wire Line
	6250 4000 5950 4000
Wire Wire Line
	6250 4200 5950 4200
Wire Wire Line
	6250 4100 6200 4100
Wire Wire Line
	6200 4100 6200 4300
Text Label 5950 4200 0    50   ~ 0
ENC_1
Text Label 5950 4000 0    50   ~ 0
ENC_0
Text Notes 6250 3250 0    100  ~ 20
Encoder
Wire Notes Line
	500  3000 7300 3000
Wire Notes Line
	3750 4800 7300 4800
Wire Notes Line
	7300 500  7300 4800
$Comp
L Device:Battery_Cell BT?
U 1 1 60CC736F
P 2700 2550
F 0 "BT?" H 2818 2646 50  0000 L CNN
F 1 "CR2032" H 2818 2555 50  0000 L CNN
F 2 "" V 2700 2610 50  0001 C CNN
F 3 "~" V 2700 2610 50  0001 C CNN
	1    2700 2550
	1    0    0    -1  
$EndComp
$Comp
L power:+BATT #PWR?
U 1 1 60CCA25E
P 2700 2350
F 0 "#PWR?" H 2700 2200 50  0001 C CNN
F 1 "+BATT" H 2715 2523 50  0000 C CNN
F 2 "" H 2700 2350 50  0001 C CNN
F 3 "" H 2700 2350 50  0001 C CNN
	1    2700 2350
	1    0    0    -1  
$EndComp
$Comp
L power:GND #PWR?
U 1 1 60CCA6F0
P 2700 2650
F 0 "#PWR?" H 2700 2400 50  0001 C CNN
F 1 "GND" H 2705 2477 50  0000 C CNN
F 2 "" H 2700 2650 50  0001 C CNN
F 3 "" H 2700 2650 50  0001 C CNN
	1    2700 2650
	1    0    0    -1  
$EndComp
$EndSCHEMATC
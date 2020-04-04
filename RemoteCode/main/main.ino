// Simplifies buttons
#include <JC_Button.h>

// LCD libraries
#include <U8g2lib.h>
#include <U8x8lib.h>

// DS18B20 libraries
#include <DallasTemperature.h>
#include <OneWire.h>

// Rotary encoder library, optimised interrupt definition
#define ENCODER_OPTIMIZE_INTERRUPTS
#include <Encoder.h>

// Pin definitions ------------------------------------------------------------------------

// Encoder
#define ENC1 10
#define ENC2 11
#define ENC_SW 19

// BS18B20 data is connected to digital pin 5
#define ONE_WIRE_BUS A6
#define ONE_WIRE_ADDRESS 0
#define READING_RESOLUTION 9

// LCD digital pins
#define LCD_RS 4 //4 // Chip select
#define LCD_RW 5 //5 // Data
#define LCD_E 7 //6 // Clock
#define LCD_RESET 13

// LCD backlight PWM pin
#define LCD_BACKLIGHT 3 // OC0A

// Momentary switches
#define BTN_A 23
#define BTN_B 22
#define BTN_C 21
#define BTN_D 20

// Object definitions ---------------------------------------------------------------------

// LCD constructor (rotation, clock, data, chip select, reset)
// Using full frame buffer
U8G2_ST7920_128X64_F_SW_SPI lcd(U8G2_R2, LCD_E, LCD_RW, LCD_RS, LCD_RESET);

// Create oneWire instance
OneWire oneWire(ONE_WIRE_BUS);
// Pass oneWire instance reference to DallasTemperature constructor
DallasTemperature sensors(&oneWire);
// Address of the sensor
DeviceAddress tempSensor = {0x28, 0x02, 0x00, 0x07, 0xFE, 0xA1, 0x01, 0xFB};

// Defines button objects
Button btnA(BTN_A);
Button btnB(BTN_B);
Button btnC(BTN_C);
Button btnD(BTN_D);
Button btnENC(ENC_SW);

// Defines rotary encoder, pins 2 and 3
Encoder enc(ENC2, ENC1);

// Constants ------------------------------------------------------------------------------
// Toggles frame debug information display (frame interval and flash)
#define ENABLE_SERIAL_FRAME_DEBUG false
#define ENABLE_DISPLAY_FRAME_DEBUG false

// Serial baud rate
#define BAUD_RATE 9600

// Display dimensions
#define HEIGHT 64
#define WIDTH 128

// Interval (ms) between temperature readings
#define TEMPERATURE_INTERVAL 30000

// If pin is held down for this many milliseconds, it is considered a long press
#define LONG_PRESS 500

// Enumerators
enum DeviceMode { CLOCK, VLC, MEDIA, MENU };

// Shorthand font definitions -------------------------------------------------------------

const uint8_t* logisoso16 = u8g2_font_logisoso16_tf;
const uint8_t* logisoso18 = u8g2_font_logisoso18_tf;
const uint8_t* logisoso32 = u8g2_font_logisoso32_tf;

const uint8_t* smallFont = u8g2_font_6x10_tf;

const uint8_t* inconsolata16 = u8g2_font_inr16_mf;
const uint8_t* inconsolata24 = u8g2_font_inr24_mf;

const uint8_t* profont12 = u8g2_font_profont12_mr;
const uint8_t* profont15 = u8g2_font_profont15_mr;
const uint8_t* profont17 = u8g2_font_profont17_mr;

const uint8_t* helv8R = u8g2_font_helvR08_tf;
const uint8_t* helv10R = u8g2_font_helvR10_tf;
const uint8_t* helv12R = u8g2_font_helvR12_tf;
const uint8_t* helv14R = u8g2_font_helvR14_tf;
const uint8_t* helv18R = u8g2_font_helvR18_tf;
const uint8_t* helv24R = u8g2_font_helvR24_tf;

const uint8_t* helv8B = u8g2_font_helvB08_tf;
const uint8_t* helv10B = u8g2_font_helvB10_tf;
const uint8_t* helv12B = u8g2_font_helvB12_tf;
const uint8_t* helv14B = u8g2_font_helvB14_tf;
const uint8_t* helv18B = u8g2_font_helvB18_tf;
const uint8_t* helv24B = u8g2_font_helvB24_tf;

const uint8_t* iconic_play8 = u8g2_font_open_iconic_play_1x_t;
const uint8_t* iconic_arrow8 = u8g2_font_open_iconic_arrow_1x_t;

// Global variables -----------------------------------------------------------------------

// Device mode, CLOCK by default
DeviceMode deviceMode = CLOCK;

// Stores temperature in celsius, 1 decimal place with unit, as string
String temperatureStr;

// Previous temperature reading time
unsigned long prevTempMillis;
unsigned long receivedMillis;

unsigned int backlightLevel;

// Setup ----------------------------------------------------------------------------------
void setup() {
  // Using pin 7 for encoder click
  pinMode(LCD_BACKLIGHT, OUTPUT);

  // Initialises buttons
  btnA.begin();
  btnB.begin();
  btnC.begin();
  btnD.begin();
  btnENC.begin();

  // Connects to DS18B20
  sensors.begin();

  backlightLevel = 32;
  SetBacklight(backlightLevel);

  // Sets temperature resolution to 9 bits for faster access speed
  sensors.setResolution(tempSensor, READING_RESOLUTION);

  // Connects to serial
  Serial.begin(BAUD_RATE);
  Serial.println("REQUESTACCEPTED");

  temperatureStr = GetTemperatureStr();

  // Starts communication with LCD
  delay(200);
  lcd.begin();

  // Display initialisation message

  lcd.clearBuffer();
  lcd.setFont(profont17);
  lcd.drawStr(0, 20, "Media Remote");
  lcd.drawStr(0, 36, "V2");
  lcd.setFont(profont12);
  lcd.drawStr(0, 60, "A second attempt");
  lcd.sendBuffer();

  delay(1000);
  lcd.clear();
}

// Loop -----------------------------------------------------------------------------------

// Toggles each loop / new frame
bool frameSwitch = false;

bool longA, longD = false;
bool prevlongA, prevlongD = false;

void loop() {
  
  // Toggles each frame
  frameSwitch = !frameSwitch;
  // Gets time between frames
  int frameInterval = GetFrameInterval();

  // If interval has passed, record temperature again
  if (millis() > prevTempMillis + TEMPERATURE_INTERVAL) {
    temperatureStr = GetTemperatureStr();
  }

  // Get button states
  bool A = btnA.read();
  bool B = btnB.read();
  bool C = btnC.read();
  bool D = btnD.read();
  bool E = btnENC.read();

  // Gets whether or not A or D is newly long pressed
  if (btnA.pressedFor(LONG_PRESS) && !prevlongA ) {
    longA = true;
    prevlongA = true;
  }
  if (btnD.pressedFor(LONG_PRESS) && !prevlongD ) {
    longD = true;
    prevlongD = true;
  }
  if ( btnA.wasReleased() ) {
    prevlongA = false;
  }
  if ( btnD.wasReleased() ) {
    prevlongD = false;
  }

  // If A or D was long pressed, go to next/prev mode
  if ( longA ) {
    longA = false;
    if (deviceMode != 0) { // Decrement device mode
      deviceMode = (DeviceMode)((int)deviceMode - 1);
    } else {
      deviceMode = (DeviceMode)3; // Wrap around
    }
    Serial.println("MODESWITCH(" + (String)(int)deviceMode + ")");
  }
  else if ( longD ) {
    longD = false;
    if (deviceMode != 3) { // Increment device mode
      deviceMode = (DeviceMode)((int)deviceMode + 1);
    } else {
      deviceMode = (DeviceMode)0; // Wrap around
    }
    Serial.println("MODESWITCH(" + (String)(int)deviceMode + ")");
  }

  // Behaviour depends on the current mode
  switch (deviceMode) {
    case CLOCK:
      DisplayClock();
      break;
    case VLC:
      DisplayVLC();
      break;
    case MEDIA:
      DisplayMedia();
      break;
    case MENU:
      DisplayMenu();
      break;
  }

  //  int encoderValue = GetEncoderValue();
  //  //Serial.println(encoderValue);
  ////  int frameInterval = GetFrameInterval();
  //
  //  // Buttons are pulled up, so usually high
  //  if (!digitalRead(BTN_A)) { A = true;} else { A = false; }
  //  if (!digitalRead(BTN_B)) { B = true;} else { B = false; }
  //  if (!digitalRead(BTN_C)) { C = true;} else { C = false; }
  //  if (!digitalRead(BTN_D)) { D = true;} else { D = false; }
  //
  //  // If interval has passed, record temperature again
  //  if (millis() > prevTempMillis + TEMPERATURE_INTERVAL) {
  //    temperatureStr = GetTemperatureStr();
  //  }
  //
  //  String showPressed = "";
  //  if (A) {showPressed += "A";} else {showPressed += " ";}
  //  if (B) {showPressed += "B";} else {showPressed += " ";}
  //  if (C) {showPressed += "C";} else {showPressed += " ";}
  //  if (D) {showPressed += "D";} else {showPressed += " ";}
  //
  //  // Debug
  //  Serial.println(showPressed);
  //
  //  // https://github.com/olikraus/u8glib/wiki/tpictureloop
  //  lcd.firstPage();
  //  do {
  //    lcd.setFont(logisoso16);
  //    lcd.setCursor(0, 20);
  //    lcd.print(temperatureStr);
  //
  //    lcd.setCursor(0, 40);
  //    lcd.print(showPressed);
  //
  //    // If frame debug enabled, show frame timing data on display
  //    if (ENABLE_DISPLAY_FRAME_DEBUG) {
  //      lcd.setFont(smallFont);
  //      lcd.setCursor(0, 40);
  //      lcd.print(String(frameInterval) + " ms");
  //      if (frameSwitch){lcd.drawBox(85, 32, 8, 8);}
  //    }
  //
  //    lcd.setCursor(0, 63);
  //    lcd.print(encoderValue);
  //  } while (lcd.nextPage());
  //
  //  if (!digitalRead(ENC_SW)) {
  //    Serial.println("Clearing");
  //    enc.write(0);
  //  }
  //
  //  // Print frame intervals to serial monitor
  //  if (ENABLE_SERIAL_FRAME_DEBUG) {
  //    Serial.println(frameInterval);
  //  }
}


// GetTemperatureStr -----------------------------------------------------------------
// Returns temperature with units ----------------------------------------------------
// Relatively slow
String GetTemperatureStr() {
  // Updates time of previous reading
  prevTempMillis = millis();

  // Asks all sensors (just one) for its temperature
  sensors.requestTemperaturesByAddress(tempSensor);

  // Gets temperature in C for first sensor
  double celsius = sensors.getTempC(tempSensor);
  String celsiusStr = String(round(celsius * 10) / 10);
  // Formats as string with degree symbol
  temperatureStr = celsiusStr + (char)0xB0 + "C";
  //Serial.println("Temp: " + celsiusStr + " C");
  return (temperatureStr);
}

// GetEncoderValue --------------------------------------------------------------------
// Gets the value stored in the encoder -----------------------------------------------
int GetEncoderValue() {
  return enc.read();
}

// GetFrameInterval -------------------------------------------------------------------
// Gets the time between frames -------------------------------------------------------
// Stores previous time
unsigned long prevMillis;

int GetFrameInterval() {
  int currentMillis = millis();
  // Finds the difference in time between the current and previous frames
  int interval = currentMillis - prevMillis;
  prevMillis = currentMillis;
  return (interval);
}

// SetBacklight ------------------------------------------------------------------------
// Sets backlight level
void SetBacklight(int level) {
  analogWrite(LCD_BACKLIGHT, level);
  //digitalWrite(LCD_BACKLIGHT, HIGH);
}
#define VOLUME_X 0
#define VOLUME_Y 45

struct SystemMediaValues {
  int volume;
};

SystemMediaValues currentSystemMediaValues;

void DisplaySystemMedia(){
  lcd.setFontPosBaseline();
  
  lcd.clearBuffer();
  
  // Find difference in encoder value, send as change in volume
  int encoderValue = enc.read();
  int encoderDifference = prevEncoderVal - encoderValue;
  if (encoderDifference != 0)
  {
    Serial.println("VOLCHANGE(" + (String)encoderDifference + ")");
  }
  prevEncoderVal = encoderValue;

  // Detect new button presses and send appropriate command
  if (btnA.wasPressed()) {
    Serial.println("PREV()");
  }
  if (btnD.wasPressed()) {
    Serial.println("NEXT()");
  }
  if (btnENC.wasPressed()) {
    Serial.println("PAUSE()");
  }

  lcd.clearBuffer();

//  PrintVolume(VOLUME_X, VOLUME_Y, currentSystemMediaValues.volume);
  
  lcd.sendBuffer();
}

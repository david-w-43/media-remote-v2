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
  int encoderValue = GetEncoderValue();
  int encoderDifference = prevEncoderVal - encoderValue;
  if (encoderDifference != 0)
  {
    Serial.println("VOLCHANGE(" + (String)encoderDifference + ")");
  }
  prevEncoderVal = encoderValue;

  // Detect new button presses and send appropriate command
  if (btnA.wasReleased()) {
    Serial.println("PREV()");
  }
  if (btnD.wasReleased()) {
    Serial.println("NEXT()");
  }
  if (btnENC.wasReleased()) {
    Serial.println("PAUSE()");
  }

  lcd.clearBuffer();

  lcd.setFont(inconsolata24);
  lcd.drawUTF8(0, 30, "System");
//  PrintVolume(VOLUME_X, VOLUME_Y, currentSystemMediaValues.volume);
  
  lcd.sendBuffer();
}

// Runs while in Clock mode
void DisplayClock() {
  // GetTimeStr();
  char timeStr[] = "18:16";
  lcd.firstPage();

  // Get the width of the time string, find position
  // required to centre it on the display
  int x, y;
  lcd.setFont(inconsolata24);
  x = (int)((WIDTH / 2) - (lcd.getStrWidth(timeStr) / 2));

  lcd.clearBuffer();
  // Print the time in the centre
  lcd.setFont(inconsolata24);
  lcd.setFontPosCenter();
  lcd.setCursor(x, (HEIGHT / 2));
  lcd.print(timeStr);

  //Print temperature in the bottom left
  lcd.setFont(inconsolata16);
  lcd.setFontPosBaseline();
  lcd.setCursor(2, (HEIGHT - 2));
  lcd.print(temperatureStr);
  lcd.sendBuffer();
}

// Runs while in Clock mode
void DisplayClock() {
  // GetTimeStr();
  //char timeStr[] = "18:16";
  
  byte second, minute, hour, dayOfWeek, dayOfMonth, month, year;
  String secStr, minuteStr, hourStr;

  // Get the date/time from the RTC:
  rtc.getDateTime(&second, &minute, &hour, &dayOfWeek, &dayOfMonth, &month, &year);

  secStr = (String)second;
  if (secStr.length() == 1) {secStr = "0" + secStr; }
  minuteStr = (String)minute;
  if (minuteStr.length() == 1) {minuteStr = "0" + minuteStr; }
  hourStr = (String)hour;
  if (hourStr.length() == 1) {hourStr = "0" + hourStr; }

  String timeString = hourStr + ":" + minuteStr;
  String dateString = (String)dayOfMonth + '/' + (String)month + '/' + (String)year;

  // Get the width of the time string, find position
  // required to centre it on the display
  int timeX, dateX;
  lcd.setFont(helv24B);
  timeX = (int)((WIDTH / 2) - (lcd.getStrWidth(timeString.c_str()) / 2));
  lcd.setFont(helv12R);
  dateX = (int)((WIDTH / 2) - (lcd.getStrWidth(dateString.c_str()) / 2));

  lcd.clearBuffer();
  
  // Print date along top
  lcd.setFont(helv12R);
  lcd.setFontPosBaseline();
  lcd.setCursor(dateX, 12);
  lcd.print(dateString);
  
  // Print the time in the centre
  lcd.setFontPosCenter();
  lcd.setFont(helv24B);
  lcd.setCursor(timeX, (HEIGHT / 2));
  lcd.print(timeString);

  //Print temperature in the bottom left
  lcd.setFont(helv14R);
  lcd.setFontPosBaseline();
  lcd.setCursor(2, (HEIGHT - 2));
  lcd.print(temperatureStr);
  
  lcd.sendBuffer();
}

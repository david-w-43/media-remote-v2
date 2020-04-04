void DisplayMedia(){
  lcd.setFontPosBaseline();
  
  lcd.clearBuffer();
  
  lcd.setFont(inconsolata24);
  lcd.drawStr(0, 32, "Media");
  
  lcd.sendBuffer();
}

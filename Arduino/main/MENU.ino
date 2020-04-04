void DisplayMenu(){
  lcd.setFontPosBaseline();
  
  lcd.clearBuffer();
  
  lcd.setFont(inconsolata24);
  lcd.drawStr(0, 32, "Menu");
  
  lcd.sendBuffer();
}

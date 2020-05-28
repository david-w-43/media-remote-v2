int selectedMenuItem = 0;

void DisplayMenu() {
  // Define menu --------------------------------------
  char title[5] = "Mode";
  String options[4] = {
    "Clock",
    "iTunes",
    "VLC"
  };

  // Draw menu ----------------------------------------

  lcd.clearBuffer();

  // Title
  lcd.setFont(helv12B);
  lcd.drawUTF8(40, 12, title);

  // Bar
  lcd.drawHLine(0, 13, WIDTH);

  // Options
  lcd.setFont(helv10R);
  for (int i = 0; i <= 3; i ++) {
    int y = 26 + (12 * i);

    if (selectedMenuItem == i) {
      //Draw asterisk next to option
      lcd.setCursor(0, y);
      lcd.print('*');
    }

    // Print option text
    lcd.setCursor(8, y);
    lcd.print(options[i]);
  }

  lcd.sendBuffer();

  // Get inputs ---------------------------------------
  if (menuInputEnabled) {    
    // Reads current value of rotary encoder
    int encoderValue = GetEncoderValue();

    // Sets encoder change based on turn direction
    if (encoderValue < prevEncoderVal) {
      // Increment selected option, with wraparound
        if (selectedMenuItem >= 2) {
          selectedMenuItem = 0;
        }
        else {
          selectedMenuItem ++;
        }
    }
    else if (encoderValue > prevEncoderVal) {
      // Decrement selected option, with wraparound
        if (selectedMenuItem <= 0) {
          selectedMenuItem = 2;
        }
        else {
          selectedMenuItem --;
        }
    }

    prevEncoderVal = encoderValue;

    // Stores input states
    bool enter, cancel;

    // Enter = encoder switch
    if (btnENC.wasReleased()) {
      enter = true;
    } else {  enter = false; }
    if (btnA.wasReleased() || btnB.wasReleased() || btnC.wasReleased() || btnD.wasReleased()) {
      cancel = true;
    } else { cancel = false; }

    // Act upon inputs ----------------------------------

    // If enter pressed
    if (enter) {
      switch (selectedMenuItem) {
        case 0:
          SetMode(Clock);
          break;
        case 1:
          Serial.println("SETAPP(iTunes)");
          SetMode(ApplicationControl);
          break;
        case 2:
          Serial.println("SETAPP(VLC)");
          SetMode(ApplicationControl);
          break;
      }

      // Exit
      ExitMenu();
    }
    else if (cancel) {
      // Cancel
      ExitMenu();
    }
  }
}

void ExitMenu(){
  inMenu = false;
  menuInputEnabled = false;
  SetSensitivity(prevSensitivity);
}

// Sets and reports new mode
void SetMode(DeviceMode mode) {
  deviceMode = mode;
  Serial.println("MODESWITCH(" + (String)(int)mode + ")");
}

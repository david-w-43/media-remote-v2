// Can hold up to 10 lines
#define LINECOUNT 9

void serialEvent() {
  Serial.flush(); // Wait for outgoing data to transmit

  //Serial.println("Data received");
  
  String lines[LINECOUNT];
  int lineCounter = 0;

  // Read incoming data into array
  while (Serial.available() > 0) {
    // Used to detect timeout
    bool timeout = false;
    double startMillis = millis();
    // Read incoming data up to line feed
    String line = Serial.readStringUntil(0xA);

    if (millis() > startMillis + SERIAL_TIMEOUT)
    {
      // If timeout detected, clear buffer
      while (Serial.available() > 0) { Serial.read(); }
    } 
    else 
    {
      // If no timeout,
      // Trim whitespace and write to array
      line.trim();
      lines[lineCounter] = line;
  
      // Increment line counter
      lineCounter ++;
    }
  }

  for (int i = 0; i < LINECOUNT; i++) {
    // Read incoming data up to line feed
    String line = lines[i];

    // If line not empty
    if (line != "") {
      int identifierEnd = line.indexOf("(");
      String identifier = line.substring(0, identifierEnd);
      int expectedLengthEnd = line.indexOf("|");
      String strExpectedLength = line.substring(identifierEnd + 1, expectedLengthEnd);
      int expectedLength = strExpectedLength.toInt();
      int parameterEnd = line.lastIndexOf(")");
      String parameter = line.substring(expectedLengthEnd + 1, parameterEnd);

      // Check if received line is valid
      if (parameter.length() == expectedLength) {
        // Do stuff as usual

        // COMMANDS THAT APPLY TO ALL OR NONE OF THE MODES
        if (identifier == "HAND") {
          // Handshakes with the PC
          Serial.println("REQUESTACCEPTED");
        } else if (identifier == "MDQU") {
          // Report the current device mode
          Serial.println("MODESWITCH(" + (String)(int)deviceMode + ")");
        } else if (identifier == "MDST") {
          // Switch to appropriate mode
          deviceMode = (DeviceMode)parameter.toInt();
        } else if (identifier == "CONN") {
          if (parameter == "1") {
            companionConnected = true;
          } else {
            companionConnected = false;
            // Clock mode on disconnect
            deviceMode = Clock;
          }
        } else if (identifier == "APPC") {
          if (parameter == "1" ) {
            applicationPlaying = true;
          }
          else {
            applicationPlaying = false;
          }
        }

        // Commands that update device settings
        if (identifier.startsWith("UP")) {
          if (identifier == "UPSCR") {
            // Scrolling of long strings
            if (parameter == "0") {
              deviceOptions.stringScroll = false;
            } else {
              deviceOptions.stringScroll = true;
            }
          }
          else if (identifier == "UPBCK") {
            int level = parameter.toInt();
            deviceOptions.brightness = level;
            SetBacklight(level);
          }
          else if (identifier == "UPTIM") {
            byte second = (byte)(getParameter(parameter, '|', 0).toInt());
            byte minute = (byte)(getParameter(parameter, '|', 1).toInt());
            byte hour = (byte)(getParameter(parameter, '|', 2).toInt());
            byte dayOfWeek = (byte)(getParameter(parameter, '|', 3).toInt());
            byte dayOfMonth = (byte)(getParameter(parameter, '|', 4).toInt());
            byte month = (byte)(getParameter(parameter, '|', 5).toInt());
            byte year  = (byte)(getParameter(parameter, '|', 6).toInt());

            // Sets the time on the RTC
            rtc.setDateTime(second, minute, hour, dayOfWeek, dayOfMonth, month, year);
          }

          // Update EEPROM
          EEPROM.put(EEPROM_OPTIONS, deviceOptions);
        }

        // Commands that depend on mode
        switch (deviceMode) {
          case Clock:
            ClockCommands(identifier, parameter);
            break;
          case ApplicationControl:
            ApplicationControlCommands(identifier, parameter);
            break;
          case SystemMedia:
            SystemMediaCommands(identifier, parameter);
            break;
          case Menu:
            MenuCommands(identifier, parameter);
            break;
        }
      } else {
        // If mismatched length detected
        // Request resend of line
        Serial.println("RESEND(" + identifier + ")");
      }
    }
  }
}

void ClockCommands(String identifier, String parameter) {
  // Nothing yet
}

void ApplicationControlCommands(String identifier, String parameter) {
  // Nothing yet
  if (identifier == "TIME") {
    currentValues.playbackPos = parameter.toInt();
  }
  else if (identifier == "VOL") {
    currentValues.volume = parameter.toInt();
  }
  else if (identifier == "TITL") {
    currentValues.title = parameter;
  }
  else if (identifier == "SUBT") {
    currentValues.subtitle = parameter;
  }
  else if (identifier == "LEN") {
    currentValues.trackLength = parameter.toInt();
  }
  else if (identifier == "SHUFF") {
    if (parameter == "1") {
      currentValues.shuffle = true;
    }
    else {
      currentValues.shuffle = false;
    }
  }
  else if (identifier == "RPTM") {
    currentValues.repeatMode = (RepeatMode)(parameter.toInt());
  }
  else if (identifier == "STAT") {
    currentValues.playbackStatus = (PlaybackStatus)parameter.toInt();
  }
}

void SystemMediaCommands(String identifier, String parameter) {
  // Nothing yet
}

void MenuCommands(String identifier, String parameter) {
  // Nothing yet
}

String getParameter(String data, char separator, int index)
{
  int found = 0;
  int strIndex[] = {0, -1};
  int maxIndex = data.length() - 1;

  for (int i = 0; i <= maxIndex && found <= index; i++) {
    if (data.charAt(i) == separator || i == maxIndex) {
      found++;
      strIndex[0] = strIndex[1] + 1;
      strIndex[1] = (i == maxIndex) ? i + 1 : i;
    }
  }

  return found > index ? data.substring(strIndex[0], strIndex[1]) : "";
}

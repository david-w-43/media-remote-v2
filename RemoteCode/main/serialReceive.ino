void serialEvent() {
  //receivedMillis = millis();
  Serial.flush(); // Wait for outgoing data to transmit

  //Serial.println("Data received");

  // String receivedString = "";
  // While there are bytes available to read, read data into string
  while (Serial.available() > 0) {
    //receivedString += Serial.readString();

    // Read incoming data up to line feed
    String line = Serial.readStringUntil(0xA);

    // Trim whitespace
    line.trim();

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
      if (identifier == "CONNECTIONREQUEST") {
        // Handshakes with the PC
        Serial.println("REQUESTACCEPTED");
      } else if (identifier == "MODEQUERY") {
        // Report the current device mode
        Serial.println("MODESWITCH(" + (String)(int)deviceMode + ")");
      } else if (identifier == "MODESET") {
        // Switch to appropriate mode
        deviceMode = (DeviceMode)parameter.toInt();
      } else if (identifier == "CONNECTED") {
        if (parameter == "1"){
          companionConnected = true;
        } else {
          companionConnected = false;
          // Clock mode on disconnect
          deviceMode = Clock;
        }
      } else if (identifier == "PLAYING") {
        if (parameter == "1" ) {applicationPlaying = true; }
        else { applicationPlaying = false; }
      }

      // Commands that update device settings
      if (identifier.startsWith("UPD")) {
        if (identifier == "UPDSCROLL") {
          // Scrolling of long strings
          if (parameter == "0") {
            deviceOptions.stringScroll = false;
          } else {
            deviceOptions.stringScroll = true;
          }
        } else if (identifier == "UPDALBUM") {
          // Display of album over artist
          if (parameter == "0") {
            deviceOptions.displayAlbum = false;
          }
          else
          {
            deviceOptions.displayAlbum = true;
          }
        }
        else if (identifier == "UPDBRIGHT") {
          int level = parameter.toInt();
          deviceOptions.brightness = level;
          SetBacklight(level);
        }
        else if (identifier == "UPDTIME"){
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

void ClockCommands(String identifier, String parameter) {
  // Nothing yet
}

void ApplicationControlCommands(String identifier, String parameter) {
  // Nothing yet
  if (identifier == "TIME") {
    currentValues.playbackPos = parameter.toInt();
  } else if (identifier == "PLAYING") {
    if (parameter == "1") {
      applicationPlaying = true;
    }
    else {
      applicationPlaying = false;
    }
  }
  else if (identifier == "VOLUME") {
    currentValues.volume = parameter.toInt();
  }
  else if (identifier == "TITLE") {
    currentValues.title = parameter;
  }
  else if (identifier == "ARTIST") {
    currentValues.artist = parameter;
  }
  else if (identifier == "ALBUM") {
    currentValues.album = parameter;
  }
  else if (identifier == "LENGTH") {
    currentValues.trackLength = parameter.toInt();
  }
  else if (identifier == "SHUFFLE") {
    if (parameter == "1") {
      currentValues.shuffle = true;
    }
    else {
      currentValues.shuffle = false;
    }
  }
  else if (identifier == "REPEATMODE") {
    currentValues.repeatMode = (RepeatMode)(parameter.toInt());
  }
  else if (identifier == "STATUS") {
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

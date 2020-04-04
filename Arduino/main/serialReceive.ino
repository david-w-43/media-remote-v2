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

    // Gets position of first space
    int parametersStart = line.indexOf("(") + 1;
    int parametersEnd = line.lastIndexOf(")");

    String identifier = line.substring(0, parametersStart - 1);
    String parametersStr = line.substring(parametersStart, parametersEnd);

    //Serial.println("Command separated");

    // Maximum number of parameters
    String parameters[5];
    if (parametersStr.indexOf("|") == -1) {
      // If there is only one parameter
      parameters[0] = parametersStr;
    } else {
      // If multiple parameters
      for (int i = 0; i < 5; i++) {
        parameters[i] = getParameter(parametersStr, '|', i);
      }
    }

    //Serial.println("Parameters parsed");

    // COMMANDS THAT APPLY TO ALL OR NONE OF THE MODES
    if (identifier == "CONNECTIONREQUEST") {
      // Handshakes with the PC
      Serial.println("REQUESTACCEPTED");
    } else if (identifier == "MODEQUERY") {
      // Report the current device mode
      Serial.println("MODESWITCH(" + (String)(int)deviceMode + ")");
    }

    // Commands that depend on mode
    switch (deviceMode) {
      case CLOCK:
        ClockCommands(identifier, parameters);
        break;
      case VLC:
        VLCCommands(identifier, parameters);
        break;
      case MEDIA:
        MediaCommands(identifier, parameters);
        break;
      case MENU:
        MenuCommands(identifier, parameters);
        break;
    }
  }
}

void ClockCommands(String identifier, String parameters[]) {
  // Nothing yet
}

void VLCCommands(String identifier, String parameters[]) {
  // Nothing yet
  if (identifier == "TIME") {
    currentVLCValues.playbackPos = parameters[0].toInt();
    //Serial.println("process" + (millis() - receivedMillis));
  }
  else if (identifier == "STATUS") {
    currentVLCValues.playbackStatus = (VLCPlaybackStatus)parameters[0].toInt();
  }
  else if (identifier == "VOLUME") {
    currentVLCValues.volume = parameters[0].toInt();
  }
  else if (identifier == "TITLE") {
    currentVLCValues.title = parameters[0];
  }
  else if (identifier == "ARTIST") {
    currentVLCValues.artist = parameters[0];
  }
  else if (identifier == "ALBUM") {
    currentVLCValues.album = parameters[0];
  }
  else if (identifier == "LENGTH") {
    currentVLCValues.trackLength = parameters[0].toInt();
  }
}

void MediaCommands(String identifier, String parameters[]) {
  // Nothing yet
}

void MenuCommands(String identifier, String parameters[]) {
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

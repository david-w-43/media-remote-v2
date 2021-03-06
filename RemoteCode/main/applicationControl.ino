// Display constants
#define TITLE_X 0
#define TITLE_Y 14
const uint8_t* TITLE_FONT = helv14R;

#define SUBTITLE_X 0
#define SUBTITLE_Y 31
const uint8_t* SUBTITLE_FONT = helv12R;

#define VOLUME_X 0
#define VOLUME_Y 45
const uint8_t* VOLUME_FONT = helv8R;

#define SHUFFLE_X 96
#define SHUFFLE_Y 45

#define REPEAT_X 64
#define REPEAT_Y 45

#define BAR_Y 55
#define MARKER_RADIUS 2
const uint8_t* BAR_FONT = helv8RN;

// Repeat mode enumerator
enum RepeatMode { OFF, ALL, ONE };
enum PlaybackStatus { PLAYING, PAUSED, STOPPED };

// Values structure
struct Values {
  String title;
  //String artist;
  //String album;
  String subtitle;
  unsigned int trackLength;
  unsigned int playbackPos;
  unsigned int volume;
  RepeatMode repeatMode;
  PlaybackStatus playbackStatus;
  bool shuffle;
};

Values currentValues;
bool applicationPlaying = false;

void DisplayApplicationControl() {
  // For testing purposes -----------------------------
  //  currentValues.title = "Big Iron";
  //  currentValues.artist = "Marty Robbins";
  //  currentValues.album = "Gunfighter Ballads and Trail Songs";
  //  currentValues.trackLength = 236;
  //  currentValues.playbackPos = 97;
  //  currentValues.volume = 75;
  //  currentValues.repeatMode = ALL;
  //  currentValues.shuffle = true;
  // End example values -------------------------------
  if (applicationPlaying) {

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
    if (btnB.wasReleased()) {
      Serial.println("REPEAT()");
    }
    if (btnC.wasReleased()) {
      Serial.println("SHUFFLE()");
    }
    if (btnD.wasReleased()) {
      Serial.println("NEXT()");
    }
    if (btnENC.wasReleased()) {
      Serial.println("PAUSE()");
    }

    // Reset font positioning
    lcd.setFontPosBaseline();

    // Clear contents of buffer
    lcd.clearBuffer();

    // Print title
    PrintTitle();
    // Print subtitle
    PrintSubtitle();
    // Print volume icon
    PrintVolume();
    // Print repeat icon
    PrintRepeat();
    // Print shuffle icon
    PrintShuffle();
    // Print progress bar
    PrintBar();

    // Update LCD
    lcd.sendBuffer();
  } else {
    // If not connected to the application
    lcd.clearBuffer();
    lcd.setFont(helv12R);
    lcd.drawUTF8(0, 20, "Not connected to");
    lcd.drawUTF8(0, 40, "media player");
    lcd.drawUTF8(0, 60, "application");
    lcd.sendBuffer();
  }
}

void PrintTitle() {
  // Temp
  lcd.setFont(TITLE_FONT);
  ScrollText(currentValues.title, TITLE_Y);
}

void PrintSubtitle() {
  lcd.setFont(SUBTITLE_FONT);
  ScrollText(currentValues.subtitle, SUBTITLE_Y);
}

void ScrollText(String text, int yPos) {
  // Convert String into char array
  int arrayLength = text.length() + 1;
  char charArray[arrayLength];
  text.toCharArray(charArray, arrayLength);

  // Find the width of the text, and amount of excess
  int strWidth = lcd.getStrWidth(charArray) + 2;
  int excess = strWidth - WIDTH;
  // If scrolling strings is enabled and it is longer than one width
  if ((excess > 0) && deviceOptions.stringScroll) {
    int offset = (0.5f * excess * cos((float)millis() / ((float)50 * excess))) - (0.5f * excess);
    lcd.drawUTF8(offset, yPos, charArray);
  } else {
    // Draw normally
    lcd.drawUTF8(0, yPos, charArray);
  }
}

void PrintVolume() {
  lcd.setFont(iconic_play8);
  unsigned int volumeIcon;

  // Selects icon depending on volume
  if (currentValues.volume < 33) {
    volumeIcon = 0x51;
  }
  else if (currentValues.volume < 67) {
    volumeIcon = 0x50;
  }
  else {
    volumeIcon = 0x4f;
  }

  lcd.drawGlyph(VOLUME_X, VOLUME_Y, volumeIcon);
  lcd.setFont(VOLUME_FONT);

  // Prints value
  lcd.setCursor((VOLUME_X + 11), VOLUME_Y);
  lcd.print(currentValues.volume);
}

void PrintRepeat() {
  unsigned int repeatIcon;
  bool print1 = false;
  switch (currentValues.repeatMode) {
    case OFF:
      repeatIcon = 0x00;
      break;
    case ALL:
      repeatIcon = 0x56;
      break;
    case ONE:
      repeatIcon = 0x56; // Replace later
      print1 = true;
      break;
  }
  lcd.setFont(iconic_arrow8);
  lcd.drawGlyph(REPEAT_X, REPEAT_Y, repeatIcon);
  if (print1) {
    lcd.drawVLine(REPEAT_X + 9, REPEAT_Y - 1, 3);
  }
}

void PrintShuffle() {
  lcd.setFont(iconic_arrow8);
  if (currentValues.shuffle) {
    lcd.drawGlyph(SHUFFLE_X, SHUFFLE_Y, 0x59);
  }
}

void PrintBar() {
  // Set font position to centre
  lcd.setFontPosCenter();
  lcd.setFont(BAR_FONT);

  // Get times as char arrays
  String posStr = secondsToTimeStr(currentValues.playbackPos);
  String lengthStr = secondsToTimeStr(currentValues.trackLength);

  // posWidth should be fixed for a set number of characters
  int posWidth = 0;
  if (posStr.length() == 5) {
    posWidth = lcd.getUTF8Width("00:00");
  }
  else if (posStr.length() == 7) {
    posWidth = lcd.getUTF8Width("0:00:00");
  }
  else if (posStr.length() == 8) {
    posWidth = lcd.getUTF8Width("00:00:00");
  }
  //int posWidth = lcd.getStrWidth(posStr.c_str());
  int lengthWidth = lcd.getStrWidth(lengthStr.c_str());

  // Print current position
  lcd.setCursor(0, BAR_Y);
  lcd.print(posStr);
  // Print track length
  lcd.setCursor(WIDTH - lengthWidth, BAR_Y);
  lcd.print(lengthStr);

  // Draw bar
  int barStart = posWidth + 2 + MARKER_RADIUS;
  int barEnd = WIDTH - (lengthWidth + 2 + MARKER_RADIUS);
  int barLength = barEnd - barStart;

  lcd.drawHLine(barStart, BAR_Y, barLength);

  // Draw marker on bar
  // Calculate position of marker along bar
  float fracProgress =  (float)currentValues.playbackPos / (float)currentValues.trackLength;
  int markerPos = (int)(fracProgress * barLength);
  lcd.drawDisc(markerPos + barStart, BAR_Y, MARKER_RADIUS);

  // Reset font position to centre
  lcd.setFontPosBaseline();
}

String secondsToTimeStr(int seconds) {
  bool displayHours = true;
  String secs = String(seconds % 60); //No of seconds
  String mins = String((seconds / 60) % 60); //No of minutes
  String hours = String((seconds / 3600) % 60); //No of hours

  //If hours is unnecessary, do not display them
  if (hours == "0") {
    displayHours = false;
  }

  //Format to be two digits
  if (secs.length() == 1) {
    secs = String("0" + secs);
  }
  if (mins.length() == 1) {
    mins = String("0" + mins);
  }

  if (displayHours) { //If hours is to be displayed
    return String(hours + ":" + mins + ":" + secs);
  } else {
    return String(mins + ":" + secs);
  }

}

// Display constants
#define TITLE_X 0
#define TITLE_Y 14
const uint8_t* TITLE_FONT = helv14R;

#define ARTIST_X 0
#define ARTIST_Y 31
const uint8_t* ARTIST_FONT = helv12R;

#define ALBUM_X 0
#define ALBUM_Y 31
const uint8_t* ALBUM_FONT = helv12R;

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
enum VLCRepeatMode { OFF, ALL, ONE };
enum VLCPlaybackStatus { PLAYING, PAUSED, STOPPED };

// VLC values structure
struct VLCValues {
  String title;
  String artist;
  String album;
  unsigned int trackLength;
  unsigned int playbackPos;
  unsigned int volume;
  VLCRepeatMode repeatMode;
  VLCPlaybackStatus playbackStatus;
  bool shuffle;
};

VLCValues currentVLCValues;

// Stores the previous encoder value so that the change may be found
int prevEncoderVal;

void DisplayVLC() {
  // For testing purposes -----------------------------
  //  currentVLCValues.title = "Big Iron";
  //  currentVLCValues.artist = "Marty Robbins";
  //  currentVLCValues.album = "Gunfighter Ballads and Trail Songs";
  //  currentVLCValues.trackLength = 236;
  //  currentVLCValues.playbackPos = 97;
  //  currentVLCValues.volume = 75;
  //  currentVLCValues.repeatMode = ALL;
  //  currentVLCValues.shuffle = true;
  // End example values -------------------------------

  // Find difference in encoder value, send as change in volume
  int encoderValue = enc.read();
  int encoderDifference = prevEncoderVal - encoderValue;
  if (encoderDifference != 0)
  {
    Serial.println("VOLCHANGE(" + (String)encoderDifference + ")");
  }
  prevEncoderVal = encoderValue;

  // Detect new button presses and send appropriate command
  if (btnA.wasPressed()) {
    Serial.println("PREV()");
  }
  if (btnB.wasPressed()) {
    Serial.println("REPEAT()");
  }
  if (btnC.wasPressed()) {
    Serial.println("SHUFFLE()");
  }
  if (btnD.wasPressed()) {
    Serial.println("NEXT()");
  }
  if (btnENC.wasPressed()) {
    Serial.println("PAUSE()");
  }

  // Reset font positioning
  lcd.setFontPosBaseline();

  // Clear contents of buffer
  lcd.clearBuffer();

  // Print title
  PrintTitle();
  // Print either artist or album
  if (!deviceOptions.displayAlbum) {
    PrintArtist();
  } else {
    PrintAlbum();
  }
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
  //Serial.println("update" + (millis() - receivedMillis));
}

void PrintTitle() {
  // Temp
  lcd.setFont(TITLE_FONT);
  ScrollText(currentVLCValues.title, TITLE_Y);
}

void PrintArtist() {
  lcd.setFont(ARTIST_FONT);
  ScrollText(currentVLCValues.artist, ARTIST_Y);
}

void PrintAlbum() {
  lcd.setFont(ALBUM_FONT);
  ScrollText(currentVLCValues.album, ALBUM_Y);
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
  if (currentVLCValues.volume < 33) {
    volumeIcon = 0x51;
  }
  else if (currentVLCValues.volume < 67) {
    volumeIcon = 0x50;
  }
  else {
    volumeIcon = 0x4f;
  }

  lcd.drawGlyph(VOLUME_X, VOLUME_Y, volumeIcon);
  lcd.setFont(VOLUME_FONT);

  // Prints value
  lcd.setCursor((VOLUME_X + 11), VOLUME_Y);
  lcd.print(currentVLCValues.volume);
}

void PrintRepeat() {
  unsigned int repeatIcon;
  bool print1 = false;
  switch (currentVLCValues.repeatMode) {
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
  if (currentVLCValues.shuffle) {
    lcd.drawGlyph(SHUFFLE_X, SHUFFLE_Y, 0x59);
  }
}

void PrintBar() {
  // Set font position to centre
  lcd.setFontPosCenter();
  lcd.setFont(BAR_FONT);

  // Get times as char arrays
  String posStr = secondsToTimeStr(currentVLCValues.playbackPos);
  String lengthStr = secondsToTimeStr(currentVLCValues.trackLength);

  int posWidth = lcd.getStrWidth(posStr.c_str());
  int lengthWidth = lcd.getStrWidth(lengthStr.c_str());

  // Print current position
  lcd.setCursor(0, BAR_Y);
  lcd.print(posStr);
  // Print track length
  lcd.setCursor(WIDTH - lengthWidth, BAR_Y);
  lcd.print(lengthStr);

  // Draw bar
  int barStart = posWidth + 1 + MARKER_RADIUS;
  int barEnd = WIDTH - (lengthWidth + 1 + MARKER_RADIUS);
  int barLength = barEnd - barStart;

  lcd.drawHLine(barStart, BAR_Y, barLength);

  // Draw marker on bar
  // Calculate position of marker along bar
  float fracProgress =  (float)currentVLCValues.playbackPos / (float)currentVLCValues.trackLength;
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

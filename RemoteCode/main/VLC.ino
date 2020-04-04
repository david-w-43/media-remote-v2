// Display constants
#define TITLE_X 0
#define TITLE_Y 15
const uint8_t* TITLE_FONT = helv14R;

#define ARTIST_X 0
#define ARTIST_Y 30
const uint8_t* ARTIST_FONT = helv12R;

#define ALBUM_X 0
#define ALBUM_Y 30
const uint8_t* ALBUM_FONT = helv12R;

#define VOLUME_X 0
#define VOLUME_Y 45
const uint8_t* VOLUME_FONT = helv8R;

#define SHUFFLE_X 64
#define SHUFFLE_Y 45

#define REPEAT_X 96
#define REPEAT_Y 45

#define BAR_Y 60
#define MARKER_RADIUS 2
const uint8_t* BAR_FONT = helv8R;

// Toggles whether the album title is displayed instead of artist
#define DISPLAY_ALBUM 0

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
  currentVLCValues.repeatMode = ALL;
  currentVLCValues.shuffle = true;
  // End example values -------------------------------

  // Find difference in encoder value
  int encoderValue = enc.read();
  int encoderDifference = prevEncoderVal - encoderValue;

  // Reset font positioning
  lcd.setFontPosBaseline();

  // Clear contents of buffer
  lcd.clearBuffer();

  // Print title
  PrintTitle();
  // Print either artist or album
  if (!DISPLAY_ALBUM) {
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
  lcd.setFont(TITLE_FONT);
  lcd.setCursor(TITLE_X, TITLE_Y);
  lcd.print(currentVLCValues.title);
}

void PrintArtist() {
  lcd.setFont(ARTIST_FONT);
  lcd.setCursor(ARTIST_X, ARTIST_Y);
  lcd.print(currentVLCValues.artist);
}

void PrintAlbum() {
  lcd.setFont(ALBUM_FONT);
  lcd.setCursor(ALBUM_X, ALBUM_Y);
  lcd.print(currentVLCValues.album);
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
  lcd.setCursor((VOLUME_X + 9), VOLUME_Y);
  lcd.print(currentVLCValues.volume);
}

void PrintRepeat() {
  unsigned int repeatIcon;
  switch (currentVLCValues.repeatMode) {
ALL:
      repeatIcon = 0x56;
      break;
ONE:
      repeatIcon = 0x56; // Replace later
      break;
  }
  lcd.setFont(iconic_arrow8);
  lcd.drawGlyph(REPEAT_X, REPEAT_Y, repeatIcon);
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

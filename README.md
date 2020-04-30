# Media remote
### Version 2 - Work in progress


## Current Features:
- Clock mode
    - Ambient temperature display
    - Real-time clock displaying time and date
- Media Application Control mode
    - Control over VLC and iTunes:
        - Next / previous track
        - Play / pause
        - Volume
        - Shuffle toggle
        - Repeat mode
    - Displays information:
        - Track title
        - Artist or album (configurable)
        - Current volume
        - Playback position with progress bar
        - Shuffle and repeat modes
    - Discord Rich Presence integration
        - Adjustable privacy
- Configurable backlight brightness
- Long text scrolls across display

### Planned features:
- System Media Control mode:
    - Switch between audio devices
    - Adjust system-wide volume
    - Simulate multimedia keys for basic control over many applications

## Hardware
### Microcontroller
The device uses a custom PCB, on which is an **ATmega1284P** microcontroller (clocked at 16 MHz) that is used for all of the remote-side processing.

### Additional ICs
Also on-board are a **DS18B20** 1-wire digital thermometer, used to provide the ambient temperature readings shown in Clock mode; an SSOP **FT232RL** USB to UART converter, for communication over the remote's USB port; and an MSOP **MCP79410** I2C real-time clock to keep accurate time even when the device is disconnected.

### Display
The display is a 128 x 64 monochrome LCD display, the **ST7920**, driven by an attached controller board and fed data over SPI.

### User Input
The remote uses four 6 x 6 mm tactile SPST PTM switches, as well as a **PEC11R** rotary encoder with switch for user input.

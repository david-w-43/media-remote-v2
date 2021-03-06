# Media remote
### Version 2

<img src="./docs/images/headerImage.jpg" width="100%"> 

## Features:
- Clock mode

    <img src="./docs/images/clockmode.jpg" width="420"> 

    - Ambient temperature display
    - Real-time clock displaying time and date
    - Whole-system audio control
        - Volume
        - Play / pause
        - Next / previous track
        
- Media Application Control mode

    <img src="./docs/images/mediaapplicationmode.jpg" width="420"> 

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
    
        <img src="./docs/images/discordRP.jpg"> 

        - Adjustable privacy
        
- Configurable backlight brightness

    <img src="./docs/images/backlightselect.jpg"> 
    
- Adjustable rotary encoder sensitivity
- Long text scrolls across display

## Hardware

<img src="./docs/images/pcbtop.png"> 

### Microcontroller
The device uses a custom PCB, on which is an **ATmega1284P** microcontroller (clocked at 16 MHz) that is used for all of the remote-side processing.

### Additional ICs
Also on-board are a **DS18B20** 1-wire digital thermometer, used to provide the ambient temperature readings shown in Clock mode; an SSOP **FT232RL** USB to UART converter, for communication over the remote's USB port; and an MSOP **MCP79410** I2C real-time clock to keep accurate time even when the device is disconnected.

### Display
The display is a 128 x 64 monochrome LCD display, the **ST7920**, driven by an attached controller board and fed data over SPI.

### User Input
The remote uses four 6 x 6 mm tactile SPST PTM switches, as well as a **PEC11R** rotary encoder with switch for user input.

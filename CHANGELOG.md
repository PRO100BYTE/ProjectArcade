# **ProjectArcade Changelog**

<h1 align="left">
  <br>
  <a href="https://projectarcade.ru/"><img src="https://raw.githubusercontent.com/PRO100BYTE/ProjectArcade/master/resources/images/pa-github.png" alt="ProjectArcade" width="500"></a>
</h1>

## **ProjectArcade 1.0**
- The first version of the shell

## **ProjectArcade 1.1**
- The first public release of the shell
- Added a boot screen saver 

## **ProjectArcade 1.2**
- Minor bug fixes
- New default theme

## **ProjectArcade 1.3**
- Added additional cores for RetroArch
- Fixed bugs that occur when starting some emulators

## **ProjectArcade 1.4**
- Minor bug fixes
- Updating the design
- Adding a built-in Kodi media player

## **ProjectArcade 1.5.1**
- Modified configs for PS1 and PS2 emulators
- Minor bug fixes

## **ProjectArcade 1.5.2**
- Correction of Kodi "hanging" when exiting the media player

## **ProjectArcade 1.5.3**
- Minor bug fixes
- Redesigned the ProjectArcade Dynamic theme
- Added a new theme: ProjectArcade Simple
- Added new platforms and emulators

## **ProjectArcade 1.5.4-beta1**
- Minor bug fixes
- Built-in Ludo - libretro frontend
- New boot animations

## **ProjectArcade 1.5.4-beta2**
- Minor bug fixes
- New background music
- Updated Kodi to version 20.1

## **ProjectArcade 1.5.4-beta3**
- Main ProjectArcade theme renamed to ProjectArcade Dynamic
- New theme: ProjectArcade Material
- The RetroBat Store has been replaced with the ProjectArcade Content Store
- Updated emulatorLauncher design; the interface has been translated into Russian
- Now emulatorLauncher downloads emulators from ProjectArcade servers without using RetroBat resources
- The ability to download skins has been added to the ProjectArcade Content Store

## **ProjectArcade 1.5.4**
- Minor bug fixes
- New emulators: OpenMSX, Flycast
- Updated Russian localization in EmulationStation
- Reduced the size of the shell in the installed form

## **ProjectArcade 1.6.0-beta1**
- Minor bug fixes
- Added the ability to launch games via OpenMSX and Flycast emulators
- Support for new emulators: SF, mylands, HBMAME, ZiNc
- When starting the game, it is now possible to display the screensaver (.mp4)

## **ProjectArcade 1.6.0-beta2**
- Minor bug fixes
- A new mechanism for working with themes (EmulationStation)
- Update background music
- Adding new boot animations

## **ProjectArcade 1.6.0-beta3**
- Minor bug fixes
- Update of the emulatorLauncher
- Updating emulators
- Adding ArcadeGUI, a user-friendly interface for managing ProjectArcade configuration

## **ProjectArcade 1.6.0**
- Minor bug fixes
- Update the emulatorLauncher
- Update the emulators
- Adding ArcadeGUI, a user-friendly interface for managing ProjectArcade configuration
- Adding new boot animations
- Adding new background music
- Adding new frames for emulators
and much, much more :)

## **ProjectArcade 1.6.1**
- Based on **RetroBat 6.3**
  
<details>
  <summary>What was taken from RetroBat 6.3?</summary>
    
    Emulators\cores:
    - Update Hypseus SINGE and include FrameworkKimmy for latest games
    - Add OpenGOAL (Jak and Daxter 1 and 2 engine)
    - Add Caprice Forever for AMSTRAD CPC & GX4000
    - PPSSPP standalone is now the default for PSP

    Fixes:
    - Fix potential null pointer in libretro guns autoconfiguration
    - Fix EKA2L1 controller index assignment
    - XEMU : change closing hotkey to send CLOSE instead of taskkill : this should fix saves corruption issue
    - Lime3ds : add new executable name
    - PC-ENGINE : default to 2-button pad
    - libretro-Mupen64 : force vulkan when using parallel plugin
    - Few fixes of default settings values for libretro cores
    - RPCS3 : fix features for new version
    - MEDNAFEN : fix psx & saturn controller error
    - VPinball : fix -extminimized and -ini command lines not being passed to command line for new RC versions of VPinball
    - Dolphin : change exit combo to send CLOSE instead of KILL - might fix wiimote disconnection issues some people had
    - MAME & FBNEO : if game is vertical and no specific bezel is set, RetroBat will default to vertical arcade bezel
    - CAP32 : fix running dedicated COMMAND from .m3u file by deactivating autorun when a command is present
    - WINDOWS : .gameexe file to specify process to monitor does now work for any .lnk file

    Features:
    - 3ds : Add bezels for side-by-side layout (also added capability to search for nds, but no bezel is yet available)
    - Libretro nes cores : add palette options
    - BigPEmu : set SDL as default input driver
    - Citra & Lime3DS : enable bezels
    - DOLPHIN: Add Retroachievements support (Gamecube & Wii)            
    - Duckstation: add new shaders
    - HYPSEUS: management of .singe folders
    - JGenesis: Add nes zapper option                                                                   
    - LR-FCEUMM & LR-MESEN: add turbo and core aspect ratio features
    - LR-FCEUMM: fix overscan option
    - Ryujinx : add option to force number of controllers that will be configured, this can avoid the gamepad screen to popup in Ryujinx (by default Retrobat was configuring as many players as the number of connected controllers)
    - Ryujinx : add network features
    - SINGE2: update ways of searching for .singe file and videofile
    - XEMU : add option to select cerbios flashrom (needs 'Cerbios.bin' in retrobat\bios folder)       
    - NEC PC98 : add .cue extension                                                                     
    - RAINE : add features & controller autoconfiguration                                               
    - DOLPHIN : add aspect ratio setting for wii in sysconf
    - Play! : added few missing features
    - FBNEO : add games to autoconfiguration of controllers
    - PCSX2 : add per game memory card option
    - PCSX2 : add .m3u support (RetroBat will launch the file specified in first line of .m3u file)
    - Add squashfs support to some emulators (dolphin, citra, lime3ds, duckstation, bigpemu, ppsspp)
    - Add Retroarch turbo feature to few cores
    - MODEL 3 : add option to use L1 and R1 for racing games instead of triggers for people with arcade cabinets without triggers
    - CEMU : add button mapping to display Gamepad screen
    - PCSX2 and PSX : add option to change controller mapping and use L2 and R2 for driving games (useful for Gran Turismo)
    - SIMPLE64 : add selection of controller pak
    - XENIA & XENIA-CANARY : add some features and fixed a few that have changed with xenia update
    - FLYCAST : add network features in RetroBat menu

    Other stuff:
    - Update WIKI
    - Add animated bezels for RetroArch (only on few systems)
    - Add Retroshooters guns detection
    - Add MAME nvram preconfigured files
    - Add TEKNOPARROT lightgun games in lightgun collection
    - Add lowresNX scrapping capability (screenscraper)
    - French translations rework
</details>

- Minor bug fixes
- Update the emulatorLauncher ([More info in GitHub repo](https://github.com/PRO100BYTE/emulatorlauncher/))
- Update the emulators
- Update tracklist (Add new track provided by [TheDayG0ne](https://music.thedayg0ne.ru) and [Antony Meehan](https://band.link/AntonyMeehan))
  
  **and much, much more :)**

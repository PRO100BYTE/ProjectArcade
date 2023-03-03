Version 36 beta (available zip in releases) (14/11/2022)
https://github.com/pajarorrojo/es-theme-PlayStation-X/releases/tag/beta_release

- Fixed an issue with detailed game list visibility when gamelist.xml file does not exist
- Fixed an issue with 16/10 aspect ratio and médium size carousel
- Fixed top trophy icon activation when system supports retroachievements (batocera 36)
- Enhancement of gamegrid animation
- Changed default carousel logo
- Some menu colors have been slightly changed in black mode
- Added: Lightgun icon to controller activity image
- Added: Bomberman and Geralt de Rivia (The Witcher 3) preset avatar
- Added video to Nintendo WiiU system



-----------------------
Version 35.1 (16/10/2022)


- Changed controller icon position, now is above the clock
- Changed network icon position to the bottom right corner
- Medium carousel size option set by default when large screens with 16/9 aspect ratio are detected or selected
- Font size for the bottom help bar has been adjusted
- Fixed an overlapping with snes control icons
- Fixed a graphic bug with the carousel logos when the japan region is selected
- Fixed missing trophy icon in game list when system doesn't support retroachievements
- Several fixes and corrections in layouts and different aspect ratios
- A small region indicator has been placed in the lower right corner (only on large screens)
- New layouts for screenshots, library, imageviewer and od-commander systems
- Added an alert when retroachievements or netplay username has been selected and are disabled in the system (Batocera 35 or higher)
- Added videos to V.Smile, VTech Socrates, Tiger game.com, Coleco Adam, Amiga CDTV, Atari XE, Atari 800, BBC Micro, Acorn Electron, Arcadia, Astrocade, VTech Creativision,Philips CD-I and Tandy coco systems
- Changed or enhanced videos for Gamegear, Game Boy, Game Boy Color, Megadrive / Genesis, Nintendo 64, Playstation, Sega CD, Sega 32X, 3DO and Atari Jaguar systems
- Added: Medias data and / or infos for Arduboy system
- Added: Pikachu, Bernard (Maniac Mansion) and Peace symbol preset avatars 



-----------------------
Version 35 (21/09/2022)


- Now theme can detect the aspect ratio and automatically adjust to the following types of screens (requires Batocera 35 or higher)
   - 16:9 widescreen
   - 4:3 standard
   - 16:10
   - 3:2
   - 5:3
   - 5:4 (new option!)
- Added ticker scroll effect to username, developer, year, game title and game genre when the string are too long
-  New: Now you can choose your Netplay ID as displayed username in theme option (requires Batocera 35 or higher and Netplay enabled)
- Remove: Some text glows for weak devices for a better performance
- Added: Medias data and / or infos for Library, Od-commander, PDP-1, Atari 8 Bits, Lightguns, Vtech Laser 310, Video computer 4000 and Game Park 32 systems


-----------------------
Version 34 (25/05/2022)


- UX/UI: New theme option: Secondary color scheme for selectors and some theme layout's details. Colors available:
  - Red
  - Green
  - Yellow
  - Blue
  - Black
  - Purple
  - Orange
  - Pink
- UX/UI: New carousel system animation (from bottom to top) when opening 
- UX/UI: Improved the logo zoom animation when entering a game list
- UX/UI: New game selector in detailed gamelist with upper and bottom color lines, more clear 
- UX/UI: Improved detailed gamelist layout and placed info bar icons at the bottom of the screen
- UX/UI: Added new colorful logos, icons, descriptions, backgrounds and/or media for the automatic collections by genre
- UX/UI: Added fanart random game image as default background image in the system view if there are no images predefined by the theme
- UX/UI: Added random "marquee" images as logo or system console images in the system view if there are no images predefined by the theme
- UX/UI: Added title system predefined tag as default when no title are provided by theme
- UX/UI: Added default system logo in gamelist upper left corner if there are no logo predefined by the theme
- UX/UI: New media and infos have been added in a lot of new systems compatible with Batocera 34
- Layout: Improved Retrobat logo for splash screen and top line
- Fix: Issue with an overflow of battery tag percentages when more than one controller is connected
- Fix: Issue with a double video show by error in grid view and mode "Video inside the tile" selected.
- Fix: an issue with misplaced "start" tag on medium carousel and 4:3 aspect ratio selected
- Performance: Improvements to system view animations and game list animations in general
- Added: Media for Compatible systems with Batocera plus have been added, such as internet or linux
- Added: Strider, Nanaki (FFVII), Rastan, Willow (Arcade), Mazinger Z, Robocop (Arcade),Rolling Thunder, Super Pang, Guy (Final Fight) and Q-Bert preset avatars 


-----------------------
Version 33.2 (16/03/2022)


- UX/UI: Changed top trophy picto behaviour. Now the trophy highlights in system view when the system has trophy compatibility and blinks in the gamelist view when a game have achievements. Requires retroachievements enabled
- Removed trophy picto from the gamelist info bar
- Added: Medias data and / or infos for Macintosh, SEGA Hikaru, VTech Creativision and Coleco Adam
- Added: New zoom animation for logo carousel when entering to a gamelist. Only works when "Animated transitions in systems view" are enabled in theme options.
- Changes: The systems carousel logo has been placed in the gamelist upper left corner by default, if there is no carousel logo it shows another type of media, such as the logo or the console
- Added: Bart Simpson (Arcade), Barbarian (CPC), Fatal Fury (Terry) and Crash Bandicoot preset avatars
- Changed the yellow plus logo for a new svg logo with four letters "BATO" replacing the official playstation icons


-----------------------
Version 33.1 (02/03/2022)


- UX/UI: Minor changes in black colorset mode
- UX/UI: Minor changes and improvements in graphics and layouts in general
- UX/UI: Some grid view changes for thumbnail and boxart modes: Centered game selected, zoomed in and color highlight removed
- UX/UI: New autolayouts in grid view and thumbnail/boxart mode for some systems 
- Options Changes: Set retrobat option as default in "Favorite Frontend" subset if Retrobat software detected
- Added: Kingdom Hearts (Sora), Pole Position, Dragon's Lair and Super Hang-On (bike) preset avatars



-----------------------
Version 33 (06/02/2022)


- UX/UI Complete rebuilt of the theme layouts to support multiple aspect ratios and tiny screens. You can select your display type aspect ratio in theme settings with the following options:
   - 16:9 widescreen
   - 4:3 standard
   - 16:10
   - 3:2
   - 5:3
- UX/UI (small screens) Rebuilt layouts, some elements have been hidden and some theme options have been forced by default for a better user experience on first boot, with a cleaner interface adapted to small screens and portable devices
- UX/UI: Complete rebuilt of system view carousel, now the selected logo size is always relative to the rest of carousel size
- UI/UX: Force "instant" transition from systemlist to gamelist by default for a better UX (works in bato 33 and later)
- Theme options: New subset. "Select your favorite frontend". Change the splash and front logo with the next options:
  - Batocera (default)
  - Retrobat
  - Emuelec
  - Batocera Plus
  - No frontend
- UX/UI: Now custom username and retroachievements id (if active) are visibles in the list option when selecting
- UX/UI: now the top trophy icon turns yellow when a retroachievements compatible system is selected (requires retroachievemnts enabled in global game settings)
- UX/UI: new set of colorful icons for gamelists (trophy, favorites, gamesaves etc). Can be customized, you will find the icons in the root folder "resources". To disable the entire iconset, simply rename or delete this folder 
- UX/UI: Two new set of minimalist help icons. Moved the actual default iconset to the option 3-psx-color.
- New: Gamesplash screen layout
- Normalized audio levels for system videos (TV commercials)
- Normalized and compressed background default sounds
- Performance: Changes, improves and fixes in code, graphics, languages and UX in general
- Theme option: Changed subset "Random videosnap if no system video" to "Show random videosnap" with next options:
  - Always: (always show a random videosnap and skip the dedicated system video)
  - Never: (never show a random videosnap)
  - If there no video system: (by default, show random videosnap only when no video detected for the selected system)
- Added: new trophy icon for tiles in grid view
- UX/UI Minor improvements in animations
- Added: New option "Oversize" in "Show Videosnap in gamelist" subset. Show a front big videosnap over the gamelist layout
- Added: Medias data and / or infos for LCD Games, XBOX 360, Visual Pinball, Atari Jaguar CD, Switch, steam, windows installer, SEGA model 2, Fujitsu FM-7 and Philips CD-i systems



-----------------------
Version 32.2 (01/11/2021)

- Performance: Changes, improves and fixes in code, graphics, languages and UX in general
- Theme option: New supported images source options for medias in views. Now we can choose between next metadata tags for a better user customization layouts: 
  - image 
  - thumbnail (AKA box in batocera)
  - titleshot
  - marquee (AKA logo in batocera)
  - boxart
  - fanart
  - cartridge
- Design: New grid layout for boxart and thumbnail if selected as grid image source
- Design: New videosnap (window) mode in grid view
- Fixed: an issue whith no displaying custom avatar and custom nickname
- Customization: Change the background music path to "_theme_music" folder in root for an easier music customization
- Added: 2 new background audio files
- Added: Claptrap preset avatar


------------------------
Version 32.1 (hotfix) (04/10/2021)


- fixed an issue that showed the option "splash" in Theme configuration settings -> Gamelist view style


------------------------

Version 32 (03/10/2021)


- New: Theme option: Select image source in detailed view (image, thumbnail or marquee)
- New: Theme option: Select main image source in grid view (image, thumbnail or marquee)
- Added: Medias data and / or infos for Cplus4, MsxturboR, Commodore PET, Uzebox, Sonic Retro, Super Game Boy, Super Cassette Vision and Apple 2 GS systems
- Added: Medias and data to the most common used auto collections, like Shooter, RPG, Shoot em up, Fighting etc... up to 27 main collections.
- Added: Daytona USA Hornet, Double Dragon, Lemmings, HE-MAN and Goku preset avatars
- Minor changes, improves and fixes in graphics, languages and UX in general


------------------------
Version 31.1 (03/07/2021)


- Design: Game list layouts redesigned with username, infos etc. according to system view layout. 
- Show time played info in game list now are always displayed in top info bar. Deleted option in theme options
- New: Theme option: Enable or disable animated transitions in system view
- Performance: System videos and animations disabled by default for slow boards.
- New: Select your Retroachievements ID as displayed username in theme option (requires login and enabling Retroachievements in global games setting)
- Added: Lara Croft, PlayStation logo and Bubble Bobble preset avatars
- Minor changes, improves and fixes in graphics and UX in general
- Note: For a better user experience with the new gamelist layout, is recommended to set instant transition style in the User Interface global settings

------------------------
Version 31 (19/06/2021)

- Ready for batocera 31!
- New: Now compatible with multi region (EU / JP / US) 
- New: Theme option: Show time played info in game list
- New: Theme option: Enable animated transitions in game list
- New: Theme option: Select image origin in grid view (thumbnail, marquee or image)
- New: Theme option: Show videosnap in window or background type in game list
- New: Theme option: Enable or disable random videosnap in system view
- New: Theme option: Enable or disable audio for system videos
- New: Theme option: Enable or disable audio for game list videosnaps (don't work in embed gamegrid)
- Added: Retrobat preset username and avatar
- Added: Batocera Plus preset username and avatar
- Game list theme settings can now be applied per system in custom game list settings
- Added: xml data, info and/or medias to Flash player, Watara supervision, Super disc system, Windows, Flatpak, Lightgun, N64DD, TIC-80, Thomson MO/TO and Future pinball systems 
- Added: Video (advertising) to Watara supervision, FM Towns, Thomson, Nintendo 64 DD and Playstation 3 systems
- Performance: Theme size has been reduced 300MB (aprox.) 
- Note: Some new features only are supported in Batocera 31


------------------------
Version 30.5 (19/04/2021)

- New: Reworking and redesign of entire carousel images. Now the carousel images are HQ, optimized and ready for high resolution 4k Tv's
- Added: Metal Slug and Outrun preset avatars
- Added: data and media for Devilution X, Cannonball, Mrboom, Prboom and Sdlpop systems
- Fix: controller activity icon sizes

------------------------
Version 30.4.2 (12/04/2021)

- Added: xml data to Commodore Plus/4 system
- Fixed: Gamecube Media names
- Minor: changes in some systems description (ES)


------------------------
Version 30.4.1 (11/04/2021)

- Added: new medias and data to Solarus, Wii, Gamecube, Atari Jaguar, Nintendo 3ds, Nintendo Ds, Mugen, tic-80 (thanks to Soaresden for aporting some materials)
- Added: xml data to Commander Genius system
- Added: xml data to Super Disc System
- Added: xml data and medias to Xbox system
- Minor: changes in some storyboards (animations)
- Minor: changes in french language (thx to soaresden)
- Graphics changes and performance in some carousel logos

------------------------
Version 30.4 (06/04/2021)

- New theme option: Show logos and consoles in system view (yes, no, random game)
- New theme option: theme colorsets (blue or black)
- New theme option in "show videos in system view" subset: added small screen (muted)
- New splash loading screen, redesigned with avatar and username
- Added default lang (EN) variables into a new separated file "/_theme_lang/default_en.xml"
- Added Commodore Amiga grouped system media
- Added Tyrquake media (thanks to hansolo77 for the logo)
- Fixed some default lang (EN) variables
- Fixed "choice" icon in PSX and PSX COLOR iconsets 
- Fixed system description position when no video selected in theme options
- Adjust font sizes of the bottom help bar in the languages (es, fr, it) to avoid overflow 
- Minor changes in menu colors (blue) to improve contrast in selected items
- Minor changes in some system descriptions (ES)

------------------------
Version 30.3 (30/03/2021)

- New Video snapshot delay customizable in theme options (0secs, 0.5, 1, 2, 3, video off)
- New italian (IT) language to interface (not systems desc.)
- Added new nicknames presets on theme options
- Added new image avatars presets on theme options
- Added missing arcade systems partial data
- Added missing systems partial data
- Fixed and added some french translation to interface and systems description (thanks to soaresden)
- Fixed Atari Jaguar system data
- Fixed Gamecube system data


-----------------------
Version 30.2 (25/03/2021)

- Added New Avatars and Nickname presets! choose between more than 20 Avatars or Nicknames in theme options.
- Fixed an issue where snapshot slots could not be identified.
- Fixed a problem with the 12h clock format in the new beta 31

-----------------------
Version 30.1 (22/03/2021)

- Added a new grid gamelist view (looks better with no scraped image mixes)
- Added thumbnails and data to “arcade systems” in systems view.

-----------------------
Version 30 (08/03/2021)

- Ready for batocera 30
- Added new info bar icons in gamelist, show/hide is optional in theme config 
- Added new info data games in top of systems view (N. of games, favorites, played, most played)
- Added a random game video when system don’t have video background and video is enabled.
- Animated background now is optional in theme config
- Image compression and code performance, theme more stable and fluid.
- Minor changes on graphic interface, normalize colours, overlay etc
- Theme options translated to spanish, french and portuguese
- Added new systems data, info, cover etc
- New folder structure
- PSX iconset to SVG 
- Change Version number according to batocera compatible version

-------------------------
Version 2.1 (13/12/2020)

- Ready for batocera 29
- Added animated storyboards in many items of the interface. Now the interface is more precise and fluid with the new effects. (only compatible with batocera 29)
- Added new button iconsets in theme options, with controller activity custom image (psx, snes, xbox, arcade)
- New theme options for the size of the carousel images (small, medium, big) 
- Fixed scrolling sounds in system view. Enable or disable navigation sounds in general system settings. (only compatible with batocera 29)
- Console images in system menu and game list
- Some minor graphics changes have been made to improve the user experience

--------------------------
Version 2.0 (12/11/2020)

- More customizable  via theme options.
- New spot videos in systems view!. (Enable or disable is optional in theme config).
- Video system options: Background video / Small video (muted) / Small video with audio
- Now the system description is optional! (enable or disable in theme config).
- Added a scroll sound on systems selection  (enable or disable in theme config).
- Added a default animated background for systems when no background image available.
- Added a defatult logo (cover) for system when no image available.

---------------------------
Version 1 (31/10/2020)
- theme published on github, until this version it was a custom private theme, there is no registered change log 


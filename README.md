<h1 align="left">
  <br>
  <a href="https://projectarcade.ru/"><img src="https://raw.githubusercontent.com/TheDayG0ne/ProjectArcade/master/resources/images/projectarcade-github.png" alt="ProjectArcade" width="500"></a>
</h1>

[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](https://opensource.org/licenses/MIT)   [![License: LGPL v3](https://img.shields.io/badge/License-LGPL_v3-blue.svg)](https://www.gnu.org/licenses/lgpl-3.0)   [![License: CC BY-NC-SA 4.0](https://img.shields.io/badge/License-CC_BY--NC--SA_4.0-lightgrey.svg)](https://creativecommons.org/licenses/by-nc-sa/4.0/)   ![Based on RetroBat](https://img.shields.io/badge/Based%20on-RetroBat-brightgreen)   ![GitHub release](https://img.shields.io/github/v/release/TheDayG0ne/ProjectArcade?display_name=release)

ProjectArcade is a software for 64-bit versions of Windows designed for retro-gaming and running various emulators of gaming systems.

ProjectArcade is a free open source project based on the Open-Source [EmulationStation](https://github.com/fabricecaruso/batocera-emulationstation), [emulatorLauncher](https://github.com/fabricecaruso/batocera-ports) and [RetroBat](https://github.com/kaylh/Retrobat) projects. The software was developed by enthusiasts for non-commercial use, namely a fun pastime. All code and configs written by #TheDayG0ne is distributed under the MIT license, and the source code written by RetroBat Team is distributed under the LGPL v3 and CC BY-NC-SA 4.0 license.

With it you will be able to quickly run games from many compatible ROM collections. This saves hours of configuration and installation time, leaving you free to play your favourite retro games.

ProjectArcade automatically downloads and installs all the relevant software needed to have the best retro gaming experience on your Windows PC.

ProjectArcade can also run in Portable Mode. This means you can play games from an external hard drive or from any removable storage device, as long as the computer meets the minimum requirements.

## 💻 System Requirements

|**Supported OS:**|Windows 11, Windows 10, Windows 8.1|
|---|---|
|**Processor:**|CPU with SSE2 support. Two or more cores, 3GHz or faster, 2008 or later. Intel Core i3 / Core i5 / Core i7 / Core i9 recommended, AMD Ryzen also recommended|
|**Graphics:**|Modern, with Direct3D 11.1 / OpenGL 4.4 / Vulkan support|
|**Dependencies:**|[Visual C++ 2005-2022 Redistributable Packages (32 and 64 bit)](https://dl.projectarcade.ru/dependencies/vcr/VCRHyb_x86-x64.exe)|
|   |[DirectX](https://dl.projectarcade.ru/dependencies/directx/directx_websetup.exe)|
|   |[.NET Framework 6.0 Desktop Runtime](https://dl.projectarcade.ru/dependencies/netframework/6.0/netruntime-6.0.14_win64.exe)|
|   |[.NET Framework 7.0 Desktop Runtime](https://dl.projectarcade.ru/dependencies/netframework/7.0/netruntime-7.0.3_win64.exe)|
|**Controllers:**|Gamepads with XInput support are recommended. You can test your gamepad here: [Gamepad Tester](https://gamepad-tester.com)|

**After installing the dependencies, it is recommended to restart the computer**

## 🎮 Supported Platforms

![Supported Platforms](https://raw.githubusercontent.com/TheDayG0ne/ProjectArcade/master/resources/images/pasystems.png)

**ProjectArcade or RetroBat will never provide copyrighted/commercial ROMs or BIOS files.**

## 🧰 Build Instructions

Do you want to build your own version of RetroBat or create a fork based on it? Then this guide is for you.

The batch script `build.bat` will download all the softwares required, set the config files and build the RetroBat Setup from `setup.nsi` sources script.

- Download and install [Git for Windows](https://gitforwindows.org/) (follow default setup settings).

- Open CMD Windows Terminal and run the following commands to clone recursively the RetroBat git with its submodules and run build.bat to launch the build routine:
```
git clone --recursive https://github.com/kaylh/RetroBat.git
```
```
cd RetroBat
build.bat
```
- Once the build process is done, you will find the RetroBat Setup in the build directory.


## 💟 Special Thanks

- [kaylh](https://github.com/kaylh) - For a great RetroBat project and informative documentation, and so on...
- [Fabrice Caruso](https://github.com/fabricecaruso) - For the development of EmulatorLauncher and Batocera scripts port
- [Hel Mic](https://github.com/lehcimcramtrebor) - For his wonderful themes.
- [Batocera](https://www.batocera.org) - For their wonderful retrogaming dedicated Operating System.
- [pajarorrojo](https://github.com/pajarorrojo) - For PlayStation-X theme and support
- [mluizvitor](https://github.com/mluizvitor) - For Elementerial theme
- [NoCopyrightSounds](https://ncs.io) - For an excellent copyright-free music library

## And also - many thanks to 🦇 RetroBat Team:

- [Adrien Chalard "Kayl"](https://github.com/kaylh) - creator of the project, developer
- [Lorenzolamas](https://github.com/lorenzolamas) - community management, graphics (former active)
- [Fabrice Caruso](https://github.com/fabricecaruso) - lead developer, theme creation
- [GetUpOr](https://github.com/getupor) - community, support
- RetroBoy - community, support
- [Tartifless](https://github.com/Tartifless) - developer, documentation

## ⚖ Licenses

ProjectArcade License Agreement

ProjectArcade is a software for 64-bit versions of Windows designed for retro-gaming and running various emulators of gaming systems.

Copyright (c) 2017-2019 Adrien Chalard "Kayl", (c) 2020-2023 RetroBat Team, (c) 2022-2023 #TheDayG0ne

ProjectArcade is a free open source project based on the Open-Source EmulationStation and RetroBat project. The software was developed by enthusiasts for non-commercial use, namely a fun pastime. All code, configs and themes created or written by #TheDayG0ne is distributed under the MIT license, and the source code written by RetroBat Team is distributed under the LGPL v3 and CC BY-NC-SA 4.0 license. All other software and scripts used belongs to their creators under their licenses

### ProjectArcade License (MIT)

Copyright (c) 2023 TheDayG0ne

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.

### RetroBat License (LGPL v3 & CC BY-NC-SA 4.0)

Copyright (c) 2017-2019 Adrien Chalard "Kayl", (c) 2020-2023 RetroBat Team

RetroBat is a Windows softwares distribution dedicated to retrogaming and emulation.

RetroBat is free and open source project. It should not be used for commercial purposes. 
It is done by a team of enthusiasts in their free time mainly for fun.
All the code written by RetroBat Team, unless covered by a licence from an upstream project, is given under the LGPL v3 licence.
See https://www.gnu.org/licenses.

It is not allowed to sell RetroBat on a pre-installed machine or on any storage devices. 
RetroBat includes softwares which cannot be associated with any commercial activities.
Shipping RetroBat with additional proprietary and copyrighted content is illegal, strictly forbidden and strongly discouraged by the RetroBat Team.
Otherwise, you can start a new project off RetroBat sources if you follow the same conditions.

Finally, the license which concerns the entire RetroBat Project as a work, in particular the written or graphic content broadcast on its various media, is conditioned by the terms of the  [CC BY-NC-SA 4.0 license](https://creativecommons.org/licenses/by-nc-sa/4.0/).


## © Credits

- RetroBat (c) 2017-2019 Adrien Chalard "Kayl", 2020-2023 RetroBat Team (LGPL v3 and CC BY-NC-SA 4.0 License)
- EmulationStation (C) 2014 Alec Lofquist, contributions from community (MIT License).
- EmulatorLauncher (C) Fabrice Caruso 
- Batocera-ports (C) Fabrice Caruso
- Carbon Theme (c) Fabrice Caruso (CC BY-NC-SA License). Originally based on the work of Eric Hettervik (Original Carbon Theme) and Nils Bonenberger (Simple Theme).
- WiimoteGun (c) Fabrice Caruso (GPL3 License).
- RetroArch by Libretro Team (GPL3 License).
- PlayStation-X theme by pajarorrojo (CC BY-NC-SA 4.0 License)
- Elementerial theme by mluizvitor (MIT License)

## 💬 Social & Support

### #TheDayG0ne
- Site: https://thedayg0ne.ru
- Telegram: https://t.me/thedayg0ne
- VK: https://vk.com/thedayg0ne
- E-mail: me@thedayg0ne.ru

### ProjectArcade
- Official Website: https://projectarcade.ru
- Telegram: https://t.me/projectarcade_support
- VK: https://vk.com/projectarcade

### RetroBat Team
- Official Website: https://www.retrobat.org/
- Facebook: https://social.retrobat.org/facebook
- Wiki: https://wiki.retrobat.org/
- Forum: https://social.retrobat.org/forum
- Discord: https://social.retrobat.org/discord

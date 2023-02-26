<h1 align="left">
  <br>
  <a href="https://projects.thedayg0ne.ru/"><img src="https://raw.githubusercontent.com/TheDayG0ne/ProjectArcade/master/resources/images/projectarcade-github.png" alt="ProjectArcade" width="500"></a>
</h1>

[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](https://opensource.org/licenses/MIT)   [![License: LGPL v3](https://img.shields.io/badge/License-LGPL_v3-blue.svg)](https://www.gnu.org/licenses/lgpl-3.0)   [![License: CC BY-NC-SA 4.0](https://img.shields.io/badge/License-CC_BY--NC--SA_4.0-lightgrey.svg)](https://creativecommons.org/licenses/by-nc-sa/4.0/)   [![Website](https://img.shields.io/website?down_color=lightgrey&down_message=Offline&up_color=green&up_message=Online&url=https%3A%2F%2Fprojects.thedayg0ne.ru%2Fprojectarcade)](https://projects.thedayg0ne.ru/projectarcade)

ProjectArcade is a software for 64-bit versions of Windows designed for retro-gaming and running various emulators of gaming systems.

ProjectArcade is a free open source project based on the Open-Source EmulationStation and RetroBat project. The software was developed by enthusiasts for non-commercial use, namely a fun pastime. All code and configs written by #TheDayG0ne is distributed under the MIT license, and the source code written by RetroBat Team is distributed under the LGPL v3 and CC BY-NC-SA 4.0 license.
You can get detailed information here: https://www.gnu.org/licenses.

With it you will be able to quickly run games from many compatible ROM collections. This saves hours of configuration and installation time, leaving you free to play your favourite retro games.

ProjectArcade thanks to RetroBat developments automatically downloads and installs all the relevant software needed to have the best retro gaming experience on your Windows PC.

ProjectArcade can also run in Portable Mode. This means you can play games from an external hard drive or from any removable storage device, as long as the computer meets the minimum requirements.

## 💻 System Requirements

|**Supported OS:**|Windows 11, Windows 10, Windows 8.1|
|---|---|
|**Processor:**|CPU with SSE2 support. Two or more cores, 3GHz or faster, 2008 or later. Intel Core i3 / Core i5 / Core i7 / Core i9 recommended, AMD Ryzen also recommended|
|**Graphics:**|Modern, with Direct3D 11.1 / OpenGL 4.4 / Vulkan support|
|**Dependencies:**|[Visual C++ 2005-2022 Redistributable Packages (32 and 64 bit)](https://dl.thedayg0ne.ru/VCRHyb_x86-x64.exe)|
|   |[DirectX](https://www.microsoft.com/download/details.aspx?id=35)|
|   |[.NET Framework 6.0 Desktop Runtime](https://dotnet.microsoft.com/en-us/download/dotnet/thank-you/runtime-desktop-6.0.14-windows-x64-installer)|
|   |[.NET Framework 7.0 Desktop Runtime](https://dotnet.microsoft.com/en-us/download/dotnet/thank-you/runtime-desktop-7.0.3-windows-x64-installer)|
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

- [RetroBat](https://github.com/kaylh/RetroBat) - For a great project and informative documentation, and so on...
- [Fabrice Caruso](https://github.com/fabricecaruso) - For the development of EmulatorLauncher
- [Hel Mic](https://github.com/lehcimcramtrebor/) - For his wonderful themes.
- [Batocera](https://www.batocera.org/) - For their wonderful retrogaming dedicated Operating System.
- [Gitbook](https://www.gitbook.com/) - For supporting ProjectArcade and RetroBat project.
- [pajarorrojo](https://github.com/pajarorrojo) - For PlayStation-X theme
- [20GotoTen](https://github.com/20GotoTen) - For Retrofix theme

** And also - many thanks to 🦇 RetroBat Team: **

- Adrien Chalard "Kayl" - creator of the project, developer
- Lorenzolamas - community management, graphics (former active)
- Fabrice Caruso - lead developer, theme creation
- GetUpOr - community, support
- RetroBoy - community, support
- Tartifless - developer, documentation

## ⚖ Licenses

ProjectArcade License Agreement

ProjectArcade is a software for 64-bit versions of Windows designed for retro-gaming and running various emulators of gaming systems.

Copyright (c) 2017-2019 Adrien Chalard "Kayl"
Copyright (c) 2020-2023 RetroBat Team
Copyright (c) 2022-2023 #TheDayG0ne

ProjectArcade is a free open source project based on the Open-Source EmulationStation and RetroBat project. The software was developed by enthusiasts for non-commercial use, namely a fun pastime. All code and configs written by #TheDayG0ne is distributed under the MIT license, and the source code written by RetroBat Team is distributed under the LGPL v3 and CC BY-NC-SA 4.0 license.
You can get detailed information here: https://www.gnu.org/licenses.

ProjectArcade MIT License
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

RetroBat LGPL v3 License
Copyright (c) 2017-2019 Adrien Chalard "Kayl"
Copyright (c) 2020-2023 RetroBat Team

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
- Carbon Theme (c) Fabrice Caruso (CC BY-NC-SA License). Originally based on the work of Eric Hettervik (Original Carbon Theme) and Nils Bonenberger (Simple Theme).
- WiimoteGun (c) Fabrice Caruso (GPL3 License).
- RetroArch by Libretro Team (GPL3 License).
- PlayStation-X theme by pajarorrojo (CC BY-NC-SA 4.0 License)
- Retrofix theme by 20GotoTen (CC BY-NC-SA 4.0 License)

## 💬 Social & Support

** #TheDayG0ne **
- Official Website: https://projects.thedayg0ne.ru/projectarcade
- Telegram: https://t.me/thedayg0ne
- E-mail: me@thedayg0ne.ru

** RetroBat Team **
- Official Website: https://www.retrobat.org/
- Facebook Group: https://social.retrobat.org/facebook
- Wiki: https://wiki.retrobat.org/
- You need help ? You found a bug ? Please visit RetroBat Forum: https://social.retrobat.org/forum
- Join us on our Discord server: https://social.retrobat.org/discord
- <a class="twitter-timeline" href="https://twitter.com/RetroBat_Off?ref_src=twsrc%5Etfw">Tweets by RetroBat_Off</a>

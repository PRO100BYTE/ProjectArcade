; Script generated by the Inno Setup Script Wizard.
; SEE THE DOCUMENTATION FOR DETAILS ON CREATING INNO SETUP SCRIPT FILES!

#define MyAppName "ProjectArcade"
#define MyAppVersion "1.5.4-beta2"
#define MyAppPublisher "#TheDayG0ne"
#define MyAppURL "https://projectarcade.ru"
#define MyPublisherURL "https://thedayg0ne.ru"
#define MyAppExeName "projectarcade.exe"
#define MyAppCopyright "Copyright (C) 2023 #TheDayG0ne"

[Setup]
; NOTE: The value of AppId uniquely identifies this application. Do not use the same AppId value in installers for other applications.
; (To generate a new GUID, click Tools | Generate GUID inside the IDE.)
AppId={{B43C3830-8D79-4C32-B4C4-B29BBBAAFFCE}
AppName={#MyAppName}
AppVersion={#MyAppVersion}
;AppVerName={#MyAppName} {#MyAppVersion}
AppPublisher={#MyAppPublisher}
AppPublisherURL={#MyPublisherURL}
AppSupportURL={#MyAppURL}
AppUpdatesURL={#MyAppURL}
AppCopyright={#MyAppCopyright}
DefaultDirName=C:\ProjectArcade
DisableProgramGroupPage=yes
LicenseFile=C:\Users\TheDayG0ne\Desktop\ProjectArcade-setupfiles\LICENSE.txt
InfoBeforeFile=C:\Users\TheDayG0ne\Desktop\ProjectArcade-setupfiles\REQUIREMENTS.txt
UninstallDisplayIcon=C:\Users\TheDayG0ne\Desktop\ProjectArcade-setupfiles\projectarcade.ico
WizardImageFile=C:\Users\TheDayG0ne\Desktop\ProjectArcade-setupfiles\projectarcade_wizard.bmp
WizardSmallImageFile=C:\Users\TheDayG0ne\Desktop\ProjectArcade-setupfiles\pa-headerlogo.bmp
DisableWelcomePage=no
VersionInfoVersion=1.5.4
; Uncomment the following line to run in non administrative install mode (install for current user only.)
;PrivilegesRequired=lowest
OutputDir=C:\Users\TheDayG0ne\Desktop\ProjectArcade-setupbuilds\1.5.4-beta2\
OutputBaseFilename=ProjectArcade-1.5.4-beta2_setup
SetupIconFile=C:\Users\TheDayG0ne\Desktop\ProjectArcade-setupfiles\projectarcade.ico
Compression=lzma
SolidCompression=yes
WizardStyle=modern

[Languages]
Name: "english"; MessagesFile: "C:\Users\TheDayG0ne\Desktop\ProjectArcade-setupfiles\english.isl"
Name: "russian"; MessagesFile: "C:\Users\TheDayG0ne\Desktop\ProjectArcade-setupfiles\russian.isl"

[Tasks]
Name: "desktopicon"; Description: "{cm:CreateDesktopIcon}"; GroupDescription: "{cm:AdditionalIcons}"; Flags: unchecked

[Files]
Source: "C:\Users\TheDayG0ne\Desktop\ProjectArcade-builds\1.5.4-beta2\{#MyAppExeName}"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\TheDayG0ne\Desktop\ProjectArcade-builds\1.5.4-beta2\*"; DestDir: "{app}"; Flags: ignoreversion recursesubdirs createallsubdirs
Source: "C:\Users\TheDayG0ne\Desktop\ProjectArcade-builds\1.5.4-beta2\projectarcade.ini"; DestDir: "{app}"; Flags: ignoreversion; Attribs: readonly
Source: "C:\Users\TheDayG0ne\Desktop\ProjectArcade-builds\1.5.4-beta2\emulationstation\about.info"; DestDir: "{app}\emulationstation"; Flags: ignoreversion; Attribs: readonly
Source: "C:\Users\TheDayG0ne\Desktop\ProjectArcade-builds\1.5.4-beta2\emulationstation\version.info"; DestDir: "{app}\emulationstation"; Flags: ignoreversion; Attribs: readonly 

; NOTE: Don't use "Flags: ignoreversion" on any shared system files

[Icons]
Name: "{autoprograms}\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"; Comment: "Launch ProjectArcade"; IconFilename: "{app}\projectarcade.ico"
Name: "{autodesktop}\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"; Comment: "Launch ProjectArcade"; IconFilename: "{app}\projectarcade.ico"; Tasks: desktopicon

[Run]
Filename: "{app}\{#MyAppExeName}"; Description: "{cm:LaunchProgram,{#StringChange(MyAppName, '&', '&&')}}"; Flags: nowait postinstall skipifsilent

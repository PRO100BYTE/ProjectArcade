; ProjectArcade Installer Build Script
;
; More info - on GitHub:
; https://github.com/PRO100BYTE/ProjectArcade
; ---------------------------------------------------------------------

#define PAName "ProjectArcade"
#define PAVersion "1.6.1"
#define PADevs "PRO100BYTE Team"
#define PAURL "https://projectarcade.ru"
#define PADevsURL "https://pro100byte.ru"
#define PAExec "projectarcade.exe"
#define PACopyright "Copyright (C) 2023-2025 PRO100BYTE Team"
#define public Dependency_Path_NetCoreCheck "dependencies\"
#define public Dependency_Path_DirectX "dependencies\"

#include "CodeDependencies.iss"

[Setup]
; NOTE: The value of AppId uniquely identifies this application. Do not use the same AppId value in installers for other applications.
; (To generate a new GUID, click Tools | Generate GUID inside the IDE.)
AppId={{B43C3830-8D79-4C32-B4C4-B29BBBAAFFCE}
AppName={#PAName}
AppVersion={#PAVersion}
;AppVerName={#PAName} {#PAVersion}
AppPublisher={#PADevs}
AppPublisherURL={#PADevsURL}
AppSupportURL={#PAURL}
AppUpdatesURL={#PAURL}
AppCopyright={#PACopyright}
DefaultDirName=C:\ProjectArcade
DisableProgramGroupPage=yes
LicenseFile=P:\Software\ProjectArcade\ProjectArcade-setupfiles\LICENSE.txt
InfoBeforeFile=P:\Software\ProjectArcade\ProjectArcade-setupfiles\REQUIREMENTS.txt
UninstallDisplayIcon=P:\Software\ProjectArcade\ProjectArcade-setupfiles\projectarcade.ico
WizardImageFile=P:\Software\ProjectArcade\ProjectArcade-setupfiles\projectarcade_wizard.bmp
WizardImageStretch=no
WizardImageBackColor=clWhite
WizardSmallImageFile=P:\Software\ProjectArcade\ProjectArcade-setupfiles\pa-headerlogo.bmp
WizardSmallImageBackColor=clWhite
DisableWelcomePage=no
VersionInfoVersion={#PAVersion}
; Uncomment the following line to run in non administrative install mode (install for current user only.)
;PrivilegesRequired=lowest
OutputDir=P:\Software\ProjectArcade\ProjectArcade-setupbuilds\{#PAVersion}\
OutputBaseFilename=ProjectArcade-{#PAVersion}_setup
SetupIconFile=P:\Software\ProjectArcade\ProjectArcade-setupfiles\projectarcade.ico
Compression=lzma2/ultra64
InternalCompressLevel=ultra
SolidCompression=yes
WizardStyle=modern
DirExistsWarning=yes
AlwaysShowDirOnReadyPage=yes



[Languages]
Name: "english"; MessagesFile: "P:\Software\ProjectArcade\ProjectArcade-setupfiles\english.isl"
Name: "russian"; MessagesFile: "P:\Software\ProjectArcade\ProjectArcade-setupfiles\russian.isl"

[Tasks]
Name: "desktopicon"; Description: "{cm:CreateDesktopIcon}"; GroupDescription: "{cm:AdditionalIcons}"; Flags: unchecked

[Files]
Source: "P:\Software\ProjectArcade\ProjectArcade-builds\{#PAVersion}\{#PAExec}"; DestDir: "{app}"; Flags: ignoreversion;
Source: "P:\Software\ProjectArcade\ProjectArcade-builds\{#PAVersion}\*"; DestDir: "{app}"; Flags: ignoreversion recursesubdirs createallsubdirs;
Source: "P:\Software\ProjectArcade\ProjectArcade-builds\{#PAVersion}\projectarcade.ini"; DestDir: "{app}"; Flags: ignoreversion;
Source: "P:\Software\ProjectArcade\ProjectArcade-builds\{#PAVersion}\emulationstation\about.info"; DestDir: "{app}\emulationstation"; Flags: ignoreversion; 
; Attribs: readonly;
Source: "P:\Software\ProjectArcade\ProjectArcade-builds\{#PAVersion}\emulationstation\version.info"; DestDir: "{app}\emulationstation"; Flags: ignoreversion
; Attribs: readonly; 

; NOTE: Don't use "Flags: ignoreversion" on any shared system files

[Icons]
Name: "{autoprograms}\{#PAName}"; Filename: "{app}\{#PAExec}"; Comment: "Launch ProjectArcade"; IconFilename: "{app}\projectarcade.exe"
Name: "{autodesktop}\{#PAName}"; Filename: "{app}\{#PAExec}"; Comment: "Launch ProjectArcade"; IconFilename: "{app}\projectarcade.exe"; Tasks: desktopicon

[Run]
Filename: "{app}\{#PAExec}"; Description: "{cm:LaunchProgram,{#StringChange(PAName, '&', '&&')}}"; Flags: nowait postinstall skipifsilent

[Code]
function InitializeSetup: Boolean;
begin
  // comment out functions to disable installing them
  Dependency_AddDotNet35;

#ifdef Dependency_Path_NetCoreCheck
  Dependency_ForceX86 := True;
  Dependency_AddNetCore31;
  Dependency_AddNetCore31Asp;
  Dependency_AddNetCore31Desktop;
  Dependency_AddDotNet50;
  Dependency_AddDotNet50Asp;
  Dependency_AddDotNet50Desktop;
  Dependency_AddDotNet60;
  Dependency_AddDotNet60Asp;
  Dependency_AddDotNet60Desktop;
  Dependency_AddDotNet70;
  Dependency_AddDotNet70Asp;
  Dependency_AddDotNet70Desktop;
  Dependency_AddDotNet80;
  Dependency_AddDotNet80Asp;
  Dependency_AddDotNet80Desktop;
  Dependency_ForceX86 := False;
#endif

  Dependency_ForceX86 := True;
  Dependency_AddVC2005;
  Dependency_AddVC2008;
  Dependency_AddVC2010;
  Dependency_AddVC2012;
  Dependency_AddVC2013;
  Dependency_AddVC2015To2022;
  Dependency_ForceX86 := False;

  Dependency_AddDirectX;

  Result := True;
end;


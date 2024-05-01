#define MyAppName "RetroBat"
#define MyAppPublisher "The RetroBat Team"
#define MyAppURL "https://retrobat.org"
#define MyAppExeName "retrobat.exe"
#define public Dependency_NoExampleSetup

#ifndef MyAppVersion
#define MyAppVersion "6.0"
#endif

#ifndef MyAppArchitecture
#define MyAppArchitecture "x64"
#endif

#ifndef MyAppArchitecture
#define MyAppArchitecture "x64"
#endif

#ifndef InstallerCompressionType
#define InstallerCompressionType "lzma2/normal"
#endif

#ifndef EnableDiskSpanning
#define EnableDiskSpanning "no"
#endif

#ifndef InstallRootUrl
#define InstallRootUrl "http://www.retrobat.ovh/repo/win64"
#endif

#include "dependencies.iss"

[Setup]
;PrivilegesRequiredOverridesAllowed=dialog
AllowCancelDuringInstall=False
AppId={{043F867E-BDFC-4305-AB2D-AFE933BE6AFA} 
AppName={#MyAppName}
AppPublisher={#MyAppPublisher}
AppPublisherURL={#MyAppURL}
AppSupportURL={#MyAppURL}
AppUpdatesURL={#MyAppURL}
AppVerName={#MyAppName} {#MyAppVersion}
AppVersion={#MyAppVersion}
ArchitecturesAllowed={#MyAppArchitecture}
ArchitecturesInstallIn64BitMode=x64
Compression={#InstallerCompressionType}
DefaultDirName=C:\{#MyAppName}
DefaultGroupName={#MyAppName}
DisableProgramGroupPage=yes
DisableWelcomePage=no
DiskSpanning={#EnableDiskSpanning}
InfoBeforeFile=".\readme.txt"
LicenseFile=.\..\license.txt
MinVersion=0,6.1sp1
OutputBaseFilename={#MyAppName}-v{#MyAppVersion}-setup
OutputDir={#SourceDir}
OutputManifestFile={#MyAppName}-v{#MyAppVersion}-setup_Manifest.txt
PrivilegesRequired=lowest
SetupIconFile=".\resources\launcher.ico"
ShowLanguageDialog=yes
SlicesPerDisk=3
DiskSliceSize=1566000000
SolidCompression=yes
Uninstallable=no
VersionInfoCopyright={#MyAppPublisher}
VersionInfoVersion=1.0.0.0
WizardImageFile=".\resources\retrobat_wizard.bmp"
WizardImageStretch=yes
WizardSmallImageFile=".\resources\WizardSmall.bmp"
WizardStyle=modern

[Languages]
Name: "english"; MessagesFile: "compiler:Default.isl"
Name: "armenian"; MessagesFile: "compiler:Languages\Armenian.isl"
Name: "brazilianportuguese"; MessagesFile: "compiler:Languages\BrazilianPortuguese.isl"
Name: "bulgarian"; MessagesFile: "compiler:Languages\Bulgarian.isl"
Name: "catalan"; MessagesFile: "compiler:Languages\Catalan.isl"
Name: "corsican"; MessagesFile: "compiler:Languages\Corsican.isl"
Name: "czech"; MessagesFile: "compiler:Languages\Czech.isl"
Name: "danish"; MessagesFile: "compiler:Languages\Danish.isl"
Name: "dutch"; MessagesFile: "compiler:Languages\Dutch.isl"
Name: "finnish"; MessagesFile: "compiler:Languages\Finnish.isl"
Name: "french"; MessagesFile: "compiler:Languages\French.isl"
Name: "german"; MessagesFile: "compiler:Languages\German.isl"
Name: "hebrew"; MessagesFile: "compiler:Languages\Hebrew.isl"
;Name: "hungarian"; MessagesFile: "compiler:Languages\Hungarian.isl"
Name: "icelandic"; MessagesFile: "compiler:Languages\Icelandic.isl"
Name: "italian"; MessagesFile: "compiler:Languages\Italian.isl"
Name: "japanese"; MessagesFile: "compiler:Languages\Japanese.isl"
Name: "norwegian"; MessagesFile: "compiler:Languages\Norwegian.isl"
Name: "polish"; MessagesFile: "compiler:Languages\Polish.isl"
Name: "portuguese"; MessagesFile: "compiler:Languages\Portuguese.isl"
Name: "russian"; MessagesFile: "compiler:Languages\Russian.isl"
Name: "slovak"; MessagesFile: "compiler:Languages\Slovak.isl"
Name: "slovenian"; MessagesFile: "compiler:Languages\Slovenian.isl"
Name: "spanish"; MessagesFile: "compiler:Languages\Spanish.isl"
Name: "turkish"; MessagesFile: "compiler:Languages\Turkish.isl"
Name: "ukrainian"; MessagesFile: "compiler:Languages\Ukrainian.isl"

[Types]
Name: "custom"; Description: "Custom installation"; Flags: iscustom

[Components]
Name: "main"; Description: "RetroBat"; Types: custom; Flags: fixed
Name: "directx"; Description: "DirectX9"; Types: custom
Name: "vcredist"; Description: "Visual C++ 2010-2022 Redistributables (32 & 64 bit)"; Types: custom

[Tasks]
Name: "desktopicon"; Description: "{cm:CreateDesktopIcon}"; GroupDescription: "{cm:AdditionalIcons}"

[Files]
Source: "{#SourceDir}\*"; Excludes: "es_input.cfg,es_settings.cfg"; DestDir: "{app}"; Flags: ignoreversion createallsubdirs recursesubdirs
Source: "{#SourceDir}\emulationstation\.emulationstation\es_settings.cfg"; DestDir: "{app}\emulationstation\.emulationstation\"; Flags: ignoreversion onlyifdoesntexist
Source: "{#SourceDir}\emulationstation\.emulationstation\es_input.cfg"; DestDir: "{app}\emulationstation\.emulationstation\"; Flags: ignoreversion onlyifdoesntexist

#ifdef UseDirectX
Source: ".\redist\dxwebsetup.exe"; Components: directx; Flags: dontcopy noencryption
#endif

[Icons]
;Name: "{group}\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"
Name: "{autodesktop}\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"; Tasks: desktopicon

[Registry]
Root: "HKCU"; Subkey: "Software\RetroBat"; ValueType: string; ValueName: "LatestKnownInstallPath"; ValueData: "{app}"; Flags: createvalueifdoesntexist; MinVersion: 0,6.2;
Root: "HKCU64"; Subkey: "Software\RetroBat"; ValueType: string; ValueName: "InstallRootUrl"; ValueData: "{#InstallRootUrl}"; Flags: createvalueifdoesntexist; MinVersion: 0,6.2; Check: IsWin64
Root: "HKCU32"; Subkey: "Software\RetroBat"; ValueType: string; ValueName: "InstallRootUrl"; ValueData: "{#InstallRootUrl}"; Flags: createvalueifdoesntexist; MinVersion: 0,6.2; Check: not IsWin64

[Code]

function InitializeSetup: Boolean;
begin

  Dependency_AddDirectX;
  Dependency_ForceX86 := True;
  Dependency_AddVC2010;
  Dependency_AddVC2012;
  Dependency_AddVC2013;
  Dependency_AddVC2015To2022;
  Dependency_ForceX86 := False;
  Dependency_AddVC2010;
  Dependency_AddVC2012;
  Dependency_AddVC2013;
  Dependency_AddVC2015To2022;

  Result := True;
end;
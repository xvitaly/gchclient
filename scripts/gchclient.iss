; Скрипт программы (мастера) установки Garant Checker Offline.
;  
; Copyright 2012 - 2017 EasyCoding Team (ECTeam).
; Copyright 2005 - 2017 EasyCoding Team.
; 
; Лицензия кода: модифицированная лицензия BSD.
; Лицензия контента: Creative Commons 3.0 BY.
; 
; Полный текст лицензии находится в файле LICENSE.TXT.
; 
; Официальный блог EasyCoding Team: http://www.easycoding.org/
; Официальная страница проекта: http://www.easycoding.org/projects/gchclient

[Setup]
; Задаём основные параметры...
AppId={{8388BE2D-6463-4278-98B2-9572D345C67A}
AppName=Garant Checker Offline
AppVerName=Garant Checker Offline
AppPublisher=EasyCoding Team
AppPublisherURL=https://www.easycoding.org/
AppVersion=1.0.0.888
AppSupportURL=https://www.easycoding.org/projects/gchclient
AppUpdatesURL=https://www.easycoding.org/projects/gchclient
DefaultDirName={code:GetDefRoot}\Garant Checker Offline
DefaultGroupName=Garant Checker Offline
AllowNoIcons=yes
LicenseFile=LICENSE.txt
InfoBeforeFile=README.txt
OutputBaseFilename=gchclient_10
SetupIconFile=gchclient.ico
UninstallDisplayIcon={app}\gchclient.exe
Compression=lzma2
SolidCompression=yes
PrivilegesRequired=lowest
ArchitecturesInstallIn64BitMode=x64

; Здесь указываем данные, которые будут добавлены в свойства установщика...
VersionInfoVersion=1.0.0.888
VersionInfoDescription=Garant Checker Offline Setup
VersionInfoCopyright=(c) 2005-2017 EasyCoding Team. All rights reserved.
VersionInfoCompany=EasyCoding Team

[Languages]
Name: "russian"; MessagesFile: "compiler:Languages\Russian.isl";

[CustomMessages]
AdvFeatGroupDesc=Дополнительные возможности:
ShcLicenseAgrr=Лицензионное соглашение
ShcReadme=Файл ПрочтиМеня
ShcNETFx=Установить Microsoft .NET Framework 4.6
ShcLocTexts=Информация
OptNetStatus=Идёт оптимизация MSIL приложения...
OptNetUninstallStatus=Идёт удаление машинных сборок MSIL...
ShcNFxUrl=https://www.microsoft.com/ru-RU/download/details.aspx?id=49981
RepAppErrText=Сообщить об ошибке в программе
InstDebugInfo=Установить отладочную информацию
InstAutorun=Автоматический запуск программы

[Tasks]
Name: "desktopicon"; Description: "{cm:CreateDesktopIcon}"; GroupDescription: "{cm:AdditionalIcons}"
Name: "quicklaunchicon"; Description: "{cm:CreateQuickLaunchIcon}"; GroupDescription: "{cm:AdditionalIcons}"; Flags: unchecked
Name: "insdebginf"; Description: "{cm:InstDebugInfo}"; GroupDescription: "{cm:AdvFeatGroupDesc}"
Name: "autorun"; Description: "{cm:InstAutorun}"; GroupDescription: "{cm:AdvFeatGroupDesc}"

[Files]
Source: "LICENSE.txt"; DestDir: "{app}"; Flags: ignoreversion
Source: "README.txt"; DestDir: "{app}"; Flags: ignoreversion
Source: "gchcore.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "gchcore.dll.sig"; DestDir: "{app}"; Flags: ignoreversion
Source: "gchcore.pdb"; DestDir: "{app}"; Flags: ignoreversion; Tasks: insdebginf
Source: "gchclient.exe"; DestDir: "{app}"; Flags: ignoreversion
Source: "gchclient.pdb"; DestDir: "{app}"; Flags: ignoreversion; Tasks: insdebginf
Source: "gchclient.exe.sig"; DestDir: "{app}"; Flags: ignoreversion
Source: "gchclient.exe.config"; DestDir: "{app}"; Flags: ignoreversion

[Icons]
Name: "{group}\Garant Checker Offline"; Filename: "{app}\gchclient.exe"
Name: "{group}\{cm:ShcLocTexts}\{cm:ShcLicenseAgrr}"; Filename: "{app}\LICENSE.txt"
Name: "{group}\{cm:ShcLocTexts}\{cm:ShcReadme}"; Filename: "{app}\README.txt"
Name: "{group}\{cm:ShcLocTexts}\{cm:ProgramOnTheWeb,SRC Repair}"; Filename: "https://www.easycoding.org/projects/gchclient"
Name: "{group}\{cm:UninstallProgram,SRC Repair}"; Filename: "{uninstallexe}"
Name: "{group}\{cm:RepAppErrText}"; Filename: "https://github.com/xvitaly/gchclient/issues"
Name: "{commondesktop}\Garant Checker Offline"; Filename: "{app}\gchclient.exe"; Tasks: desktopicon
Name: "{userappdata}\Microsoft\Internet Explorer\Quick Launch\Garant Checker Offline"; Filename: "{app}\gchclient.exe"; Tasks: quicklaunchicon
Name: "{group}\{cm:ShcNETFx}"; Filename: "{cm:ShcNFxUrl}"

[Registry]
Root: HKCU; Subkey: "SOFTWARE\Microsoft\Windows\CurrentVersion\Run"; ValueType: string; ValueName: "gchclient"; ValueData: """{app}\gchclient.exe"" /hide"; Flags: uninsdeletevalue; Tasks: autorun

[Run]
Filename: "{app}\gchclient.exe"; Description: "{cm:LaunchProgram,Garant Checker Offline}"; Flags: nowait postinstall skipifsilent
Filename: {code:GetNetInstallPath}ngen.exe; Parameters: "install ""{app}\gchcore.dll"""; StatusMsg: {cm:OptNetStatus}; Flags: runhidden; Check: IsAdminLoggedOn()
Filename: {code:GetNetInstallPath}ngen.exe; Parameters: "install ""{app}\gchclient.exe"""; StatusMsg: {cm:OptNetStatus}; Flags: runhidden; Check: IsAdminLoggedOn()

[UninstallRun]
Filename: {code:GetNetInstallPath}ngen.exe; Parameters: "uninstall ""{app}\gchcore.dll"""; StatusMsg: {cm:OptNetUninstallStatus}; Flags: runhidden; Check: IsAdminLoggedOn()
Filename: {code:GetNetInstallPath}ngen.exe; Parameters: "uninstall ""{app}\gchclient.exe"""; StatusMsg: {cm:OptNetUninstallStatus}; Flags: runhidden; Check: IsAdminLoggedOn()

[Code]
function GetDefRoot(Param: String): String;
begin
  if not IsAdminLoggedOn then
    Result := ExpandConstant('{localappdata}')
  else
    Result := ExpandConstant('{pf}')
end;

function GetNetInstallPath(Param: String): String;
var
  NetPath: String;
begin
  RegQueryStringValue(HKLM, 'SOFTWARE\Microsoft\NET Framework Setup\NDP\v4\Client', 'InstallPath', NetPath);
  Result := NetPath;
end;
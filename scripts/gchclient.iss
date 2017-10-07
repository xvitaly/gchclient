; 
; This file is a part of Garant Checker Offline. For more information
; visit official site: https://www.easycoding.org/projects/gchclient
; 
; Copyright (c) 2012 - 2017 EasyCoding Team (ECTeam).
; Copyright (c) 2005 - 2017 EasyCoding Team.
; 
; This program is free software: you can redistribute it and/or modify
; it under the terms of the GNU General Public License as published by
; the Free Software Foundation, either version 3 of the License, or
; (at your option) any later version.
; 
; This program is distributed in the hope that it will be useful,
; but WITHOUT ANY WARRANTY; without even the implied warranty of
; MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
; GNU General Public License for more details.
; 
; You should have received a copy of the GNU General Public License
; along with this program. If not, see <http://www.gnu.org/licenses/>.
;

[Setup]
; Задаём основные параметры...
AppId={{8388BE2D-6463-4278-98B2-9572D345C67A}
AppName=Garant Checker Offline
AppVerName=Garant Checker Offline
AppPublisher=EasyCoding Team
AppPublisherURL=https://www.easycoding.org/
AppVersion=2.1.0.920
AppSupportURL=https://www.easycoding.org/projects/gchclient
AppUpdatesURL=https://www.easycoding.org/projects/gchclient
DefaultDirName={code:GetDefRoot}\Garant Checker Offline
DefaultGroupName=Garant Checker Offline
AllowNoIcons=yes
LicenseFile=COPYING
InfoBeforeFile=README.txt
OutputBaseFilename=gchclient_21
SetupIconFile=gchclient.ico
UninstallDisplayIcon={app}\gchclient.exe
Compression=lzma2
SolidCompression=yes
PrivilegesRequired=lowest
ArchitecturesInstallIn64BitMode=x64
MinVersion=6.1.7601

; Здесь указываем данные, которые будут добавлены в свойства установщика...
VersionInfoVersion=2.1.0.920
VersionInfoDescription=Garant Checker Offline Setup
VersionInfoCopyright=(c) 2005-2017 EasyCoding Team. All rights reserved.
VersionInfoCompany=EasyCoding Team

[Languages]
Name: "russian"; MessagesFile: "compiler:Languages\Russian.isl";

[CustomMessages]
AdvFeatGroupDesc=Дополнительные возможности:
OptNetStatus=Идёт оптимизация MSIL приложения...
OptNetUninstallStatus=Идёт удаление машинных сборок MSIL...
RepAppErrText=Сообщить об ошибке в программе
InstDebugInfo=Установить отладочную информацию
InstAutorun=Автоматический запуск программы

[Tasks]
Name: "desktopicon"; Description: "{cm:CreateDesktopIcon}"; GroupDescription: "{cm:AdditionalIcons}"
Name: "quicklaunchicon"; Description: "{cm:CreateQuickLaunchIcon}"; GroupDescription: "{cm:AdditionalIcons}"; Flags: unchecked
Name: "insdebginf"; Description: "{cm:InstDebugInfo}"; GroupDescription: "{cm:AdvFeatGroupDesc}"
Name: "autorun"; Description: "{cm:InstAutorun}"; GroupDescription: "{cm:AdvFeatGroupDesc}"; Flags: unchecked

[Files]
Source: "gchcore.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "gchcore.dll.sig"; DestDir: "{app}"; Flags: ignoreversion
Source: "gchcore.pdb"; DestDir: "{app}"; Flags: ignoreversion; Tasks: insdebginf
Source: "gchclient.exe"; DestDir: "{app}"; Flags: ignoreversion
Source: "gchclient.pdb"; DestDir: "{app}"; Flags: ignoreversion; Tasks: insdebginf
Source: "gchclient.exe.sig"; DestDir: "{app}"; Flags: ignoreversion
Source: "gchclient.exe.config"; DestDir: "{app}"; Flags: ignoreversion

[Icons]
Name: "{group}\Garant Checker Offline"; Filename: "{app}\gchclient.exe"
Name: "{group}\{cm:ProgramOnTheWeb,Garant Checker Offline}"; Filename: "https://www.easycoding.org/projects/gchclient"
Name: "{group}\{cm:RepAppErrText}"; Filename: "https://github.com/xvitaly/gchclient/issues"
Name: "{userdesktop}\Garant Checker Offline"; Filename: "{app}\gchclient.exe"; Tasks: desktopicon
Name: "{userappdata}\Microsoft\Internet Explorer\Quick Launch\Garant Checker Offline"; Filename: "{app}\gchclient.exe"; Tasks: quicklaunchicon

[Registry]
Root: HKCU; Subkey: "SOFTWARE\Microsoft\Windows\CurrentVersion\Run"; ValueType: string; ValueName: "gchclient"; ValueData: """{app}\gchclient.exe"" /hide"; Flags: uninsdeletevalue; Tasks: autorun

[Run]
Filename: "{app}\gchclient.exe"; Description: "{cm:LaunchProgram,Garant Checker Offline}"; Flags: nowait postinstall skipifsilent
Filename: "{dotnet40}\ngen.exe"; Parameters: "install ""{app}\gchcore.dll"""; StatusMsg: {cm:OptNetStatus}; Flags: runhidden; Check: IsAdminLoggedOn()
Filename: "{dotnet40}\ngen.exe"; Parameters: "install ""{app}\gchclient.exe"""; StatusMsg: {cm:OptNetStatus}; Flags: runhidden; Check: IsAdminLoggedOn()

[UninstallRun]
Filename: "{dotnet40}\ngen.exe"; Parameters: "uninstall ""{app}\gchcore.dll"""; StatusMsg: {cm:OptNetUninstallStatus}; Flags: runhidden; Check: IsAdminLoggedOn()
Filename: "{dotnet40}\ngen.exe"; Parameters: "uninstall ""{app}\gchclient.exe"""; StatusMsg: {cm:OptNetUninstallStatus}; Flags: runhidden; Check: IsAdminLoggedOn()

[Code]
function GetDefRoot(Param: String): String;
begin
  if not IsAdminLoggedOn then
    Result := ExpandConstant('{localappdata}')
  else
    Result := ExpandConstant('{pf}')
end;
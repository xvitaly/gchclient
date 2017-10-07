@echo off

rem This file is a part of Garant Checker Offline. For more information
rem visit official site: https://www.easycoding.org/projects/gchclient
rem 
rem Copyright (c) 2012 - 2017 EasyCoding Team (ECTeam).
rem Copyright (c) 2005 - 2017 EasyCoding Team.
rem 
rem This program is free software: you can redistribute it and/or modify
rem it under the terms of the GNU General Public License as published by
rem the Free Software Foundation, either version 3 of the License, or
rem (at your option) any later version.
rem 
rem This program is distributed in the hope that it will be useful,
rem but WITHOUT ANY WARRANTYrem without even the implied warranty of
rem MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
rem GNU General Public License for more details.
rem 
rem You should have received a copy of the GNU General Public License
rem along with this program. If not, see <http://www.gnu.org/licenses/>.

set GPGKEY=D45AB90A

echo Starting build process using MSBUILD...
"%ProgramFiles(x86)%\Microsoft Visual Studio\2017\Community\MSBuild\15.0\Bin\msbuild.exe" ..\gchclient.sln /m /t:Build /p:Configuration=Release /p:TargetFramework=v4.6.1

echo Changing directory to built version...
cd "..\gchclient\bin\Release"

echo Signing binaries...
"%ProgramFiles(x86)%\GNU\GnuPG\gpg2.exe" --sign --detach-sign --default-key %GPGKEY% gchclient.exe
"%ProgramFiles(x86)%\GNU\GnuPG\gpg2.exe" --sign --detach-sign --default-key %GPGKEY% gchcore.dll

echo Compiling Installer...
"%ProgramFiles(x86)%\Inno Setup 5\ISCC.exe" gchclient.iss

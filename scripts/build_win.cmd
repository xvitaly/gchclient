@echo off

echo Starting build process using MSBUILD...
"%ProgramFiles(x86)%\MSBuild\14.0\bin\msbuild.exe" ..\gchclient.sln /t:Build /p:Configuration=Release /p:TargetFramework=v4.6.1

echo Changing directory to built version...
cd "..\gchclient\bin\Release"

echo Signing binaries...
"%ProgramFiles(x86)%\GNU\GnuPG\gpg2.exe" --sign --detach-sign --default-key D45AB90A gchclient.exe
"%ProgramFiles(x86)%\GNU\GnuPG\gpg2.exe" --sign --detach-sign --default-key D45AB90A gchcore.dll

echo Compiling Installer...
"%ProgramFiles(x86)%\Inno Setup 5\ISCC.exe" gchclient.iss

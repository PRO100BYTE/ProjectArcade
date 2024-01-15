@echo OFF

REM HERE MODIFY YOUR STEAM APPID:
START steam://rungameid/000000

TIMEOUT /t 30
:RUNNING

REM HERE YOU MUST ENTER THE RIGHT NAME OF THE EXECUTABLE, FOR EXAMPLE: "MyGame.exe"
tasklist|findstr "Mygame.exe" > nul

if %errorlevel%==1 timeout /t 5 & GOTO ENDLOOP
timeout /t 2
GOTO RUNNING
:ENDLOOP
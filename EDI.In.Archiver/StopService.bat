sc query "EDI.In.Archiver" | find "STATE" | find "STOPPED"
if %errorlevel%==0 exit
sc stop "EDI.In.Archiver"


sc query "EDI.In.Scheduler" | find "STATE" | find "STOPPED"
if %errorlevel%==0 exit
sc stop "EDI.In.Scheduler"


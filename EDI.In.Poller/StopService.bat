sc query "EDI.In.Poller" | find "STATE" | find "STOPPED"
if %errorlevel%==0 exit
sc stop "EDI.In.Poller"


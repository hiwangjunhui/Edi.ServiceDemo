sc query "EDI.In.Orchestrator" | find "STATE" | find "STOPPED"
if %errorlevel%==0 exit
sc stop "EDI.In.Orchestrator"


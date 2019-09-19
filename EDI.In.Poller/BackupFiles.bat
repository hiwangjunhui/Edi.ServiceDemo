DEL /F /Q /S "D:\Deployments\EDI.In.Poller_Bak\*.*"
xcopy "D:\Deployments\EDI.In.Poller" "D:\Deployments\EDI.In.Poller_Bak" /i /s
DEL /F /Q /S "D:\Deployments\EDI.In.Poller\*.*"
copy "D:\Deployments\EDI.In.Poller_Bak\appsettings.json" "D:\Deployments\EDI.In.Poller\appsettings.json"
copy "D:\Deployments\license.xml" "D:\Deployments\EDI.In.Poller\license.xml"


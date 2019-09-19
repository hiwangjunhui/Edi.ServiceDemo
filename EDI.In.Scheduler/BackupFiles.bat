DEL /F /Q /S "D:\Deployments\EDI.In.Scheduler_Bak\*.*"
xcopy "D:\Deployments\EDI.In.Scheduler" "D:\Deployments\EDI.In.Scheduler_Bak" /i /s
DEL /F /Q /S "D:\Deployments\EDI.In.Scheduler\*.*"
copy "D:\Deployments\EDI.In.Scheduler_Bak\appsettings.json" "D:\Deployments\EDI.In.Scheduler\appsettings.json"
copy "D:\Deployments\license.xml" "D:\Deployments\EDI.In.Scheduler\license.xml"


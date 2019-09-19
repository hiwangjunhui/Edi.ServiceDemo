DEL /F /Q /S "D:\Deployments\EDI.In.Orchestrator_Bak\*.*"
xcopy "D:\Deployments\EDI.In.Orchestrator" "D:\Deployments\EDI.In.Orchestrator_Bak" /i /s
DEL /F /Q /S "D:\Deployments\EDI.In.Orchestrator\*.*"
copy "D:\Deployments\EDI.In.Orchestrator_Bak\appsettings.json" "D:\Deployments\EDI.In.Orchestrator\appsettings.json"
copy "D:\Deployments\license.xml" "D:\Deployments\EDI.In.Orchestrator\license.xml"


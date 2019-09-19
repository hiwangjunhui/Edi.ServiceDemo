DEL /F /Q /S "D:\Deployments\EDI.In.Archiver_Bak\*.*"
xcopy "D:\Deployments\EDI.In.Archiver" "D:\Deployments\EDI.In.Archiver_Bak" /i /s
DEL /F /Q /S "D:\Deployments\EDI.In.Archiver\*.*"
copy "D:\Deployments\EDI.In.Archiver_Bak\appsettings.json" "D:\Deployments\EDI.In.Archiver\appsettings.json"
copy "D:\Deployments\license.xml" "D:\Deployments\EDI.In.Archiver\license.xml"


@echo off
echo Se estan por instalar las dependencias de CEF INTEROP CONTROL para S3
echo 		Microsoft Visual Studio 2015 c++ Dist
echo 		.Net Framework v4.5.2
echo 		Microsoft INTEROP Toolkit 2.0
pause
"vc_redist.x86.exe"
"microsoft.interopformsredist.msi"
"NDP452-KB2901954-Web.exe"

echo Copiando CefInteropControl para S3
xcopy /e /v cefdist "c:\cefdist\"
C:\Windows\Microsoft.NET\Framework\v4.0.30319\RegAsm.exe c:\cefdist\CefInteropControl.dll /tlb:CefInteropControl.tlb /codebase
REM appwiz.cpl



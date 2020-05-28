# Author: Javier Colombera
# Build and register the Interop Control 
# Check first the correct msbuild path

"C:\Windows\Microsoft.NET\Framework\v4.0.30319\msbuild.exe" "CefInteropControl.csproj" /t:Rebuild /p:Configuration=Debug /p:Platform="x86"
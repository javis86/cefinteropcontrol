# CefInteropControl

Interop user control to integrate Chromium Embedded Frame (CefSharp) into VB6 application.

# Pre-requisites

1. .NET Framework 4.5.2
2. Visual Studio 2013
3. [Microsoft InteropForms Toolkit](https://www.microsoft.com/en-us/download/details.aspx?id=3264)
4. [InteropToolkitCs](https://github.com/froque/interoptoolkitcs) para C#:  que nos brinda un conjunto de interfaces a través de un template de Visual Studio para desarrollar sin mayores complicaciones un componente Interop

# Description of needed

The original idea was make an integration of html functionality in a third-party application designed in VB6. The IE6 components is obsolete and the needed is obvious. To perform this task the project use the Microsoft interop Toolkit to build and register de dll in Windows. This is posible by creating the user control through  the InteropToolkitCs that provides a complete interop template. 

List of steps to achievLo que se plantea entonces es lo siguiente:

1. Create a project with CSInteropUSerControlProjectTemplate.
2. Add CefSharp.Winforms Nuget package.
3. Add some required code for CefSharp minimum functioning.
4. Set x86 architecture.
5. Build the project to compile de control and register it.
6. Make some vb6 Demo Project.

# Some considerations

### InteropToolkitcs

Install [Microsoft InteropForms Toolkit](https://www.microsoft.com/en-us/download/details.aspx?id=3264)

Download and copy interoptoolkitcs release:

- ItemTemplates\Visual C#\CSInteropUserControlItemTemplate.zip
- ProjectTemplates\Visual C#\Windows\CSInteropUserControlProjectTemplate.zip

Documentation: [froque/interoptoolkitcs](https://github.com/froque/interoptoolkitcs/wiki)

### CefSharp

Using CefSharp has some important notes, considerations and limitations: [Cefsharp Wiki](https://github.com/cefsharp/CefSharp/wiki)
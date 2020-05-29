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

#### Debugging hybrid applications

From [interoptoolkitcs wiki](https://github.com/froque/interoptoolkitcs/wiki/How-To:-Debug-a-Hybrid-Application):



> # Debugging Visual Basic 6.0 Code
>
> Debugging Visual Basic 6.0 code in a Hybrid application is no different than debugging any other Visual Basic 6.0 project. Press F5 to run, set breakpoints, and debug as you normally would. There are two different methods for stepping into your .NET — by attaching to a process from Visual Studio .NET, or by setting a Start Action in Visual Studio.
>
> # Debugging with Attach to Process
>
> You will not be able to step into .NET code, however, without performing a few additional steps. Follow these steps to debug your .NET code:
>
> 1. Load your .NET project in Visual Studio.
> 2. Build the .NET project if it has not already been built.
> 3. Load your Visual Basic 6.0 code in the Visual Basic 6.0 IDE.
> 4. Run your application by pressing F5 in the Visual Basic 6.0 IDE (Note: You must do this once before attaching the .NET debugger to properly load the .NET code).
> 5. In Visual Studio, select Attach to Process... from the Debug menu.
> 6. In the dialog that appears, select the VB6.exe process (Note: because the Visual Basic 6.0 code runs within the Visual Basic 6.0 IDE, you must select this process to debug).
>
> You only need to repeat the steps above after rebuilding .NET code. The Visual Basic 6.0 IDE must be closed when rebuilding. After completing these steps, press F5 in the Visual Basic 6.0 IDE to run, set breakpoints, and debug as you normally would. Remember that since the Visual Basic 6.0 IDE process is being debugged, you will not be able to navigate in the Visual Basic 6.0 code while stopped on a breakpoint.
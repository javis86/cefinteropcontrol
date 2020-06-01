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

### Debugging hybrid applications

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



### Some Links and articles

- [Interop Forms Toolkit 2.0 Tutorial](https://www.codeproject.com/Articles/18954/Interop-Forms-Toolkit-2-0-Tutorial?fid=422404&df=90&mpp=25&sort=Position&view=Normal&spc=Relaxed&prof=True)

- [Interop Forms Toolkit Wiki](http://froque.github.io/VSIXInteropFormsToolkit/)

- [Deploying Interop User Controls](http://froque.github.io/VSIXInteropFormsToolkit/Getting Started/Deploying Interop User Controls.html)

- [How To Deploy A Hybrid Application](http://froque.github.io/VSIXInteropFormsToolkit/How To/How To Deploy A Hybrid Application.html):

  > Visual Basic 6.0 applications that contain InteropForms or Interop UserControls can be deployed using a Visual Studio .NET Setup and Deployment project, automatically registering the interop assemblies and installing any prerequisites. Alternatively, you can modify an existing Setup script to deploy and register the assemblies, or you can bootstrap an existing setup.exe by creating a custom bootstrapper package.
  >
  > **To deploy with a Setup and Deployment project in Visual Studio .NET**
  >
  > 1. On the **File** menu, click **New Project**.
  > 2. In the **New Project** dialog box, click **Other Project Types**, **Setup and Deployment**, **Setup Project**.
  > 3. Enter a name for the Setup project and click **OK**.
  > 4. In the **File System Editor**, select the **Application Folder**.
  > 5. On the **Action** menu, click **Add**, **File**.
  > 6. In the **Add File** dialog box, browse to the location of your Visual Basic 6.0 .exe and select it, and then click **Open**. Note that only the .exe is added - if your application has dependencies, you must repeat the process for each dependency.
  > 7. On the **Action** menu, click **Add**, **File**.
  > 8. In the **Add File** dialog box, browse to the location of your Interop UserControl or InteropForm and select it, and then click **Open**. Note that when it is added, any dependencies are also added.
  > 9. For each .dll in **Solution Explorer**, select the file and in the **Properties** window, select the **Register** property and set it to **vsdraCOM**.
  > 10. Right-click the files Microsoft.InteropFormTools.dll and Microsoft.InteropFormTools.tlb and click **Exclude**. (These will be installed using the redistributable package in step 13).
  > 11. On the **Project** menu, click **Properties**.
  > 12. In the **Property Pages**, click **Prerequisites**.
  > 13. In the **Prerequisites** dialog box, check the **Microsoft InteropForms Toolkit 2.0** checkbox, and then click **OK**.
  > 14. In the **Property Pages**, click **OK**.
  > 15. On the **Build** menu, choose **Build** to build a Setup.exe and a .msi file for your application.
  >
  >  


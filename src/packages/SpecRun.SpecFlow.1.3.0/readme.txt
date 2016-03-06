** IMPORTANT UPGRADE INFORMATION FOR EXISTING USERS OF SPECFLOW+ 1.2 **
If you are updating SpecFlow+ from an earlier version, please refer to the upgrade guide at http://www.specflow.org/updating-to-specflow-2/ for more information on updating SpecFlow and SpecFlow+.

A number of manual steps are required to update SpecFlow+ from version 1.2 to 1.3:
- Ensure your projects target framework is at least .NET 4.5
- Remove any references to version 1.2.0 from packages.config.
- Delete any old SpecFlow+ folders from your packages directory

If you have customised report templates or are using XAML build agents, please also refer to http://www.specflow.org/specflow-version-1-3-upgrade-notes/ for more information.


Changes since 1.2:

New features:
- Visual Studio 2015 support
- VB.Net support
- Support for project licenses
- Added completion state to console title
- Default report template included (ReportTemplate.cshtml)
- API for stopping the test run
- TechTalk.SpecRun.dll is now signed
- Error message if filter syntax is incorrect
- add new setting to copy the report to the base folder (<Report copyAlsoToBaseFolder="true"/>)


Bug fixes:
- Escape '<' and '>' correctly in Visual Studio Test discovery
- Fixed an occurance of locking an assembly
- Fixed an issue with adaptive test scheduling and tests with a long history
- Enabled useLegacyV2RuntimeActivationPolicy="true" on test executor to support multi-mode assemblies by default 
- use more than 64 threads for test run


Note to Visual Studio 2015 users:
Tests may not initially be displayed in the Test Explorer window when using SpecFlow+ Runner, as Visual Studio seems to handle solution-level NuGet packages differently from previous versions. 
Solution-level NuGet packages now need to be listed at the project-level. If this is not the case, the Test Explorer will not recognise the test runner. 
The easiest way to fix this issue is to reinstall the SpecFlow+ Runner NuGet package. 
Alternatively, you can add the SpecRun.Runner package (<package id="SpecRun.Runner" version="1.3.0" />) to the packages.config file used by your SpecFlow projects. 
You may need to restart Visual Studio to see your tests.

There is also a minor cosmetic issue with tests turning greyish-green once the tests have been executed.


For a complete version history, see changelog.txt
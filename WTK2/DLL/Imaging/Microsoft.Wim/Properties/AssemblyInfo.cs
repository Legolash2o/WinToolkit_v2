using System;
using System.Reflection;
using System.Runtime.InteropServices;

[assembly: AssemblyTitle("Microsoft.Wim")]
[assembly: AssemblyDescription("Managed Windows Imaging API (WIMGAPI)")]

#if DEBUG

[assembly: AssemblyConfiguration("Debug")]
#else
[assembly: AssemblyConfiguration("Release")]
#endif

[assembly: AssemblyCompany("Jeff Kluge")]
[assembly: AssemblyProduct("Microsoft.WimgApi")]
[assembly: AssemblyCopyright("Copyright ©  2013")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]
[assembly: AssemblyVersion("1.0.*")]
[assembly: AssemblyFileVersion("1.0.0.0")]
[assembly: ComVisible(false)]
[assembly: CLSCompliant(false)]
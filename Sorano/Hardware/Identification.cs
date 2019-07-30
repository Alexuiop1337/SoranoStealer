using System;
using System.Collections.Generic;
using Microsoft.Win32;

namespace Sorano.Hardware
{
	// Token: 0x02000009 RID: 9
	internal static class Identification
	{
		// Token: 0x0600001A RID: 26 RVA: 0x00003890 File Offset: 0x00001A90
		public static string GetId()
		{
			string result;
			try
			{
				using (RegistryKey registryKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64))
				{
					using (RegistryKey registryKey2 = registryKey.OpenSubKey("SOFTWARE\\Microsoft\\Cryptography"))
					{
						bool flag = registryKey2 == null;
						if (flag)
						{
							throw new KeyNotFoundException(string.Format("Key Not Found: {0}", "SOFTWARE\\Microsoft\\Cryptography"));
						}
						object value = registryKey2.GetValue("MachineGuid");
						bool flag2 = value == null;
						if (flag2)
						{
							throw new IndexOutOfRangeException(string.Format("Index Not Found: {0}", "MachineGuid"));
						}
						result = value.ToString().ToUpper().Replace("-", string.Empty);
					}
				}
			}
			catch
			{
				result = "HWID not found";
			}
			return result;
		}
	}
}

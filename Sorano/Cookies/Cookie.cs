using System;

namespace Sorano.Cookies
{
	// Token: 0x02000008 RID: 8
	public class Cookie
	{
		// Token: 0x17000001 RID: 1
		// (get) Token: 0x0600000C RID: 12 RVA: 0x00002073 File Offset: 0x00000273
		// (set) Token: 0x0600000B RID: 11 RVA: 0x0000206A File Offset: 0x0000026A
		public string domain { get; set; }

		// Token: 0x17000002 RID: 2
		// (get) Token: 0x0600000E RID: 14 RVA: 0x00002084 File Offset: 0x00000284
		// (set) Token: 0x0600000D RID: 13 RVA: 0x0000207B File Offset: 0x0000027B
		public string expirationDate { get; set; }

		// Token: 0x17000003 RID: 3
		// (get) Token: 0x06000010 RID: 16 RVA: 0x00002095 File Offset: 0x00000295
		// (set) Token: 0x0600000F RID: 15 RVA: 0x0000208C File Offset: 0x0000028C
		public string hostOnly { get; set; }

		// Token: 0x17000004 RID: 4
		// (get) Token: 0x06000012 RID: 18 RVA: 0x000020A6 File Offset: 0x000002A6
		// (set) Token: 0x06000011 RID: 17 RVA: 0x0000209D File Offset: 0x0000029D
		public string name { get; set; }

		// Token: 0x17000005 RID: 5
		// (get) Token: 0x06000014 RID: 20 RVA: 0x000020B7 File Offset: 0x000002B7
		// (set) Token: 0x06000013 RID: 19 RVA: 0x000020AE File Offset: 0x000002AE
		public string path { get; set; }

		// Token: 0x17000006 RID: 6
		// (get) Token: 0x06000016 RID: 22 RVA: 0x000020C8 File Offset: 0x000002C8
		// (set) Token: 0x06000015 RID: 21 RVA: 0x000020BF File Offset: 0x000002BF
		public string secure { get; set; }

		// Token: 0x17000007 RID: 7
		// (get) Token: 0x06000018 RID: 24 RVA: 0x000020D9 File Offset: 0x000002D9
		// (set) Token: 0x06000017 RID: 23 RVA: 0x000020D0 File Offset: 0x000002D0
		public string value { get; set; }
	}
}

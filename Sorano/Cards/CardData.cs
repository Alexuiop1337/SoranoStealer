using System;

namespace Sorano.Cards
{
	// Token: 0x02000018 RID: 24
	public class CardData
	{
		// Token: 0x1700000C RID: 12
		// (get) Token: 0x06000046 RID: 70 RVA: 0x00002140 File Offset: 0x00000340
		// (set) Token: 0x06000047 RID: 71 RVA: 0x00002148 File Offset: 0x00000348
		public string Name { get; set; }

		// Token: 0x1700000D RID: 13
		// (get) Token: 0x06000048 RID: 72 RVA: 0x00002151 File Offset: 0x00000351
		// (set) Token: 0x06000049 RID: 73 RVA: 0x00002159 File Offset: 0x00000359
		public string Exp_m { get; set; }

		// Token: 0x1700000E RID: 14
		// (get) Token: 0x0600004A RID: 74 RVA: 0x00002162 File Offset: 0x00000362
		// (set) Token: 0x0600004B RID: 75 RVA: 0x0000216A File Offset: 0x0000036A
		public string Exp_y { get; set; }

		// Token: 0x1700000F RID: 15
		// (get) Token: 0x0600004C RID: 76 RVA: 0x00002173 File Offset: 0x00000373
		// (set) Token: 0x0600004D RID: 77 RVA: 0x0000217B File Offset: 0x0000037B
		public string Number { get; set; }

		// Token: 0x17000010 RID: 16
		// (get) Token: 0x0600004E RID: 78 RVA: 0x00002184 File Offset: 0x00000384
		// (set) Token: 0x0600004F RID: 79 RVA: 0x0000218C File Offset: 0x0000038C
		public string Billing { get; set; }

		// Token: 0x06000050 RID: 80 RVA: 0x00005F54 File Offset: 0x00004154
		public override string ToString()
		{
			return string.Format("{0}\t{1}/{2}\t{3}\t{4}\r\n******************************\r\n", new object[]
			{
				this.Name,
				this.Exp_m,
				this.Exp_y,
				this.Number,
				this.Billing
			});
		}
	}
}

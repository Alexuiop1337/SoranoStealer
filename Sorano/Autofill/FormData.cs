using System;

namespace Sorano.Autofill
{
	// Token: 0x0200001A RID: 26
	public class FormData
	{
		// Token: 0x17000011 RID: 17
		// (get) Token: 0x06000054 RID: 84 RVA: 0x00002195 File Offset: 0x00000395
		// (set) Token: 0x06000055 RID: 85 RVA: 0x0000219D File Offset: 0x0000039D
		public string Name { get; set; }

		// Token: 0x17000012 RID: 18
		// (get) Token: 0x06000056 RID: 86 RVA: 0x000021A6 File Offset: 0x000003A6
		// (set) Token: 0x06000057 RID: 87 RVA: 0x000021AE File Offset: 0x000003AE
		public string Value { get; set; }

		// Token: 0x06000058 RID: 88 RVA: 0x00006030 File Offset: 0x00004230
		public override string ToString()
		{
			return string.Format("Name: {0}\r\nValue: {1}\r\n----------------------------\r\n", this.Name, this.Value);
		}
	}
}

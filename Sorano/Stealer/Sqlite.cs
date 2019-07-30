using System;
using System.IO;
using System.Text;

namespace Sorano.Stealer
{
	// Token: 0x02000014 RID: 20
	internal class Sqlite
	{
		// Token: 0x0600003C RID: 60 RVA: 0x00005094 File Offset: 0x00003294
		public Sqlite(string fileName)
		{
			this._fileBytes = File.ReadAllBytes(fileName);
			this._pageSize = this.ConvertToULong(16, 2);
			this._dbEncoding = this.ConvertToULong(56, 4);
			this.ReadMasterTable(100L);
		}

		// Token: 0x0600003D RID: 61 RVA: 0x000050F8 File Offset: 0x000032F8
		public string GetValue(int rowNum, int field)
		{
			string result;
			try
			{
				bool flag = rowNum >= this._tableEntries.Length;
				if (flag)
				{
					result = null;
				}
				else
				{
					result = ((field >= this._tableEntries[rowNum].Content.Length) ? null : this._tableEntries[rowNum].Content[field]);
				}
			}
			catch
			{
				result = null;
			}
			return result;
		}

		// Token: 0x0600003E RID: 62 RVA: 0x00005164 File Offset: 0x00003364
		public int GetRowCount()
		{
			return this._tableEntries.Length;
		}

		// Token: 0x0600003F RID: 63 RVA: 0x00005180 File Offset: 0x00003380
		private bool ReadTableFromOffset(ulong offset)
		{
			bool result;
			try
			{
				bool flag = this._fileBytes[(int)(checked((IntPtr)offset))] == 13;
				if (flag)
				{
					ushort num = (ushort)(this.ConvertToULong((int)offset + 3, 2) - 1UL);
					int num2 = 0;
					bool flag2 = this._tableEntries != null;
					if (flag2)
					{
						num2 = this._tableEntries.Length;
						Array.Resize<Sqlite.TableEntry>(ref this._tableEntries, this._tableEntries.Length + (int)num + 1);
					}
					else
					{
						this._tableEntries = new Sqlite.TableEntry[(int)(num + 1)];
					}
					for (ushort num3 = 0; num3 <= num; num3 += 1)
					{
						ulong num4 = this.ConvertToULong((int)offset + 8 + (int)(num3 * 2), 2);
						bool flag3 = offset != 100UL;
						if (flag3)
						{
							num4 += offset;
						}
						int num5 = this.Gvl((int)num4);
						this.Cvl((int)num4, num5);
						int num6 = this.Gvl((int)(num4 + (ulong)((long)num5 - (long)num4) + 1UL));
						this.Cvl((int)(num4 + (ulong)((long)num5 - (long)num4) + 1UL), num6);
						ulong num7 = num4 + (ulong)((long)num6 - (long)num4 + 1L);
						int num8 = this.Gvl((int)num7);
						int num9 = num8;
						long num10 = this.Cvl((int)num7, num8);
						Sqlite.RecordHeaderField[] array = null;
						long num11 = (long)(num7 - (ulong)((long)num8) + 1UL);
						int num12 = 0;
						while (num11 < num10)
						{
							Array.Resize<Sqlite.RecordHeaderField>(ref array, num12 + 1);
							int num13 = num9 + 1;
							num9 = this.Gvl(num13);
							array[num12].Type = this.Cvl(num13, num9);
							array[num12].Size = (long)((array[num12].Type <= 9L) ? ((ulong)this._sqlDataTypeSize[(int)(checked((IntPtr)array[num12].Type))]) : ((ulong)((!Sqlite.IsOdd(array[num12].Type)) ? ((array[num12].Type - 12L) / 2L) : ((array[num12].Type - 13L) / 2L))));
							num11 = num11 + (long)(num9 - num13) + 1L;
							num12++;
						}
						bool flag4 = array != null;
						if (flag4)
						{
							this._tableEntries[num2 + (int)num3].Content = new string[array.Length];
							int num14 = 0;
							for (int i = 0; i <= array.Length - 1; i++)
							{
								bool flag5 = array[i].Type > 9L;
								if (flag5)
								{
									bool flag6 = !Sqlite.IsOdd(array[i].Type);
									if (flag6)
									{
										bool flag7 = this._dbEncoding == 1UL;
										if (flag7)
										{
											this._tableEntries[num2 + (int)num3].Content[i] = Encoding.Default.GetString(this._fileBytes, (int)(num7 + (ulong)num10 + (ulong)((long)num14)), (int)array[i].Size);
										}
										else
										{
											bool flag8 = this._dbEncoding == 2UL;
											if (flag8)
											{
												this._tableEntries[num2 + (int)num3].Content[i] = Encoding.Unicode.GetString(this._fileBytes, (int)(num7 + (ulong)num10 + (ulong)((long)num14)), (int)array[i].Size);
											}
											else
											{
												bool flag9 = this._dbEncoding == 3UL;
												if (flag9)
												{
													this._tableEntries[num2 + (int)num3].Content[i] = Encoding.BigEndianUnicode.GetString(this._fileBytes, (int)(num7 + (ulong)num10 + (ulong)((long)num14)), (int)array[i].Size);
												}
											}
										}
									}
									else
									{
										this._tableEntries[num2 + (int)num3].Content[i] = Encoding.Default.GetString(this._fileBytes, (int)(num7 + (ulong)num10 + (ulong)((long)num14)), (int)array[i].Size);
									}
								}
								else
								{
									this._tableEntries[num2 + (int)num3].Content[i] = Convert.ToString(this.ConvertToULong((int)(num7 + (ulong)num10 + (ulong)((long)num14)), (int)array[i].Size));
								}
								num14 += (int)array[i].Size;
							}
						}
					}
				}
				else
				{
					bool flag10 = this._fileBytes[(int)(checked((IntPtr)offset))] == 5;
					if (flag10)
					{
						ushort num15 = (ushort)(this.ConvertToULong((int)(offset + 3UL), 2) - 1UL);
						for (ushort num16 = 0; num16 <= num15; num16 += 1)
						{
							ushort num17 = (ushort)this.ConvertToULong((int)offset + 12 + (int)(num16 * 2), 2);
							this.ReadTableFromOffset((this.ConvertToULong((int)(offset + (ulong)num17), 4) - 1UL) * this._pageSize);
						}
						this.ReadTableFromOffset((this.ConvertToULong((int)(offset + 8UL), 4) - 1UL) * this._pageSize);
					}
				}
				result = true;
			}
			catch
			{
				result = false;
			}
			return result;
		}

		// Token: 0x06000040 RID: 64 RVA: 0x0000567C File Offset: 0x0000387C
		private void ReadMasterTable(long offset)
		{
			try
			{
				byte b = this._fileBytes[(int)(checked((IntPtr)offset))];
				if (b != 5)
				{
					if (b == 13)
					{
						ulong num = this.ConvertToULong((int)offset + 3, 2) - 1UL;
						int num2 = 0;
						bool flag = this._masterTableEntries != null;
						if (flag)
						{
							num2 = this._masterTableEntries.Length;
							Array.Resize<Sqlite.SqliteMasterEntry>(ref this._masterTableEntries, this._masterTableEntries.Length + (int)num + 1);
						}
						else
						{
							this._masterTableEntries = new Sqlite.SqliteMasterEntry[num + 1UL];
						}
						for (ulong num3 = 0UL; num3 <= num; num3 += 1UL)
						{
							ulong num4 = this.ConvertToULong((int)offset + 8 + (int)num3 * 2, 2);
							bool flag2 = offset != 100L;
							if (flag2)
							{
								num4 += (ulong)offset;
							}
							int num5 = this.Gvl((int)num4);
							this.Cvl((int)num4, num5);
							int num6 = this.Gvl((int)(num4 + (ulong)((long)num5 - (long)num4) + 1UL));
							this.Cvl((int)(num4 + (ulong)((long)num5 - (long)num4) + 1UL), num6);
							ulong num7 = num4 + (ulong)((long)num6 - (long)num4 + 1L);
							int num8 = this.Gvl((int)num7);
							int num9 = num8;
							long num10 = this.Cvl((int)num7, num8);
							long[] array = new long[5];
							for (int i = 0; i <= 4; i++)
							{
								int startIdx = num9 + 1;
								num9 = this.Gvl(startIdx);
								array[i] = this.Cvl(startIdx, num9);
								array[i] = (long)((array[i] <= 9L) ? ((ulong)this._sqlDataTypeSize[(int)(checked((IntPtr)array[i]))]) : ((ulong)((!Sqlite.IsOdd(array[i])) ? ((array[i] - 12L) / 2L) : ((array[i] - 13L) / 2L))));
							}
							bool flag3 = this._dbEncoding != 1UL && this._dbEncoding != 2UL;
							if (flag3)
							{
								long dbEncoding = (long)this._dbEncoding;
							}
							bool flag4 = this._dbEncoding == 1UL;
							if (flag4)
							{
								this._masterTableEntries[num2 + (int)num3].ItemName = Encoding.Default.GetString(this._fileBytes, (int)(num7 + (ulong)num10 + (ulong)array[0]), (int)array[1]);
							}
							else
							{
								bool flag5 = this._dbEncoding == 2UL;
								if (flag5)
								{
									this._masterTableEntries[num2 + (int)num3].ItemName = Encoding.Unicode.GetString(this._fileBytes, (int)(num7 + (ulong)num10 + (ulong)array[0]), (int)array[1]);
								}
								else
								{
									bool flag6 = this._dbEncoding == 3UL;
									if (flag6)
									{
										this._masterTableEntries[num2 + (int)num3].ItemName = Encoding.BigEndianUnicode.GetString(this._fileBytes, (int)(num7 + (ulong)num10 + (ulong)array[0]), (int)array[1]);
									}
								}
							}
							this._masterTableEntries[num2 + (int)num3].RootNum = (long)this.ConvertToULong((int)(num7 + (ulong)num10 + (ulong)array[0] + (ulong)array[1] + (ulong)array[2]), (int)array[3]);
							bool flag7 = this._dbEncoding == 1UL;
							if (flag7)
							{
								this._masterTableEntries[num2 + (int)num3].SqlStatement = Encoding.Default.GetString(this._fileBytes, (int)(num7 + (ulong)num10 + (ulong)array[0] + (ulong)array[1] + (ulong)array[2] + (ulong)array[3]), (int)array[4]);
							}
							else
							{
								bool flag8 = this._dbEncoding == 2UL;
								if (flag8)
								{
									this._masterTableEntries[num2 + (int)num3].SqlStatement = Encoding.Unicode.GetString(this._fileBytes, (int)(num7 + (ulong)num10 + (ulong)array[0] + (ulong)array[1] + (ulong)array[2] + (ulong)array[3]), (int)array[4]);
								}
								else
								{
									bool flag9 = this._dbEncoding == 3UL;
									if (flag9)
									{
										this._masterTableEntries[num2 + (int)num3].SqlStatement = Encoding.BigEndianUnicode.GetString(this._fileBytes, (int)(num7 + (ulong)num10 + (ulong)array[0] + (ulong)array[1] + (ulong)array[2] + (ulong)array[3]), (int)array[4]);
									}
								}
							}
						}
					}
				}
				else
				{
					ushort num11 = (ushort)(this.ConvertToULong((int)offset + 3, 2) - 1UL);
					for (int j = 0; j <= (int)num11; j++)
					{
						ushort num12 = (ushort)this.ConvertToULong((int)offset + 12 + j * 2, 2);
						bool flag10 = offset == 100L;
						if (flag10)
						{
							this.ReadMasterTable((long)((this.ConvertToULong((int)num12, 4) - 1UL) * this._pageSize));
						}
						else
						{
							this.ReadMasterTable((long)((this.ConvertToULong((int)(offset + (long)((ulong)num12)), 4) - 1UL) * this._pageSize));
						}
					}
					this.ReadMasterTable((long)((this.ConvertToULong((int)offset + 8, 4) - 1UL) * this._pageSize));
				}
			}
			catch
			{
			}
		}

		// Token: 0x06000041 RID: 65 RVA: 0x00005B44 File Offset: 0x00003D44
		public bool ReadTable(string tableName)
		{
			bool result;
			try
			{
				int num = -1;
				for (int i = 0; i <= this._masterTableEntries.Length; i++)
				{
					bool flag = string.Compare(this._masterTableEntries[i].ItemName.ToLower(), tableName.ToLower(), StringComparison.Ordinal) == 0;
					if (flag)
					{
						num = i;
						break;
					}
				}
				bool flag2 = num == -1;
				if (flag2)
				{
					result = false;
				}
				else
				{
					string[] array = this._masterTableEntries[num].SqlStatement.Substring(this._masterTableEntries[num].SqlStatement.IndexOf("(", StringComparison.Ordinal) + 1).Split(new char[]
					{
						','
					});
					for (int j = 0; j <= array.Length - 1; j++)
					{
						array[j] = array[j].TrimStart(new char[0]);
						int num2 = array[j].IndexOf(' ');
						bool flag3 = num2 > 0;
						if (flag3)
						{
							array[j] = array[j].Substring(0, num2);
						}
						bool flag4 = array[j].IndexOf("UNIQUE", StringComparison.Ordinal) != 0;
						if (flag4)
						{
							Array.Resize<string>(ref this._fieldNames, j + 1);
							this._fieldNames[j] = array[j];
						}
					}
					result = this.ReadTableFromOffset((ulong)((this._masterTableEntries[num].RootNum - 1L) * (long)this._pageSize));
				}
			}
			catch
			{
				result = false;
			}
			return result;
		}

		// Token: 0x06000042 RID: 66 RVA: 0x00005CD8 File Offset: 0x00003ED8
		private ulong ConvertToULong(int startIndex, int size)
		{
			ulong result;
			try
			{
				bool flag = size > 8 | size == 0;
				if (flag)
				{
					result = 0UL;
				}
				else
				{
					ulong num = 0UL;
					for (int i = 0; i <= size - 1; i++)
					{
						num = (num << 8 | (ulong)this._fileBytes[startIndex + i]);
					}
					result = num;
				}
			}
			catch
			{
				result = 0UL;
			}
			return result;
		}

		// Token: 0x06000043 RID: 67 RVA: 0x00005D40 File Offset: 0x00003F40
		private int Gvl(int startIdx)
		{
			int result;
			try
			{
				bool flag = startIdx > this._fileBytes.Length;
				if (flag)
				{
					result = 0;
				}
				else
				{
					for (int i = startIdx; i <= startIdx + 8; i++)
					{
						bool flag2 = i > this._fileBytes.Length - 1;
						if (flag2)
						{
							return 0;
						}
						bool flag3 = (this._fileBytes[i] & 128) != 128;
						if (flag3)
						{
							return i;
						}
					}
					result = startIdx + 8;
				}
			}
			catch
			{
				result = 0;
			}
			return result;
		}

		// Token: 0x06000044 RID: 68 RVA: 0x00005DD0 File Offset: 0x00003FD0
		private long Cvl(int startIdx, int endIdx)
		{
			long result;
			try
			{
				endIdx++;
				byte[] array = new byte[8];
				int num = endIdx - startIdx;
				bool flag = false;
				bool flag2 = num == 0 | num > 9;
				if (flag2)
				{
					result = 0L;
				}
				else
				{
					int num2 = num;
					if (num2 != 1)
					{
						if (num2 == 9)
						{
							flag = true;
						}
						int num3 = 1;
						int num4 = 7;
						int num5 = 0;
						bool flag3 = flag;
						if (flag3)
						{
							array[0] = this._fileBytes[endIdx - 1];
							endIdx--;
							num5 = 1;
						}
						for (int i = endIdx - 1; i >= startIdx; i += -1)
						{
							bool flag4 = i - 1 >= startIdx;
							if (flag4)
							{
								array[num5] = (byte)((this._fileBytes[i] >> num3 - 1 & 255 >> num3) | (int)this._fileBytes[i - 1] << num4);
								num3++;
								num5++;
								num4--;
							}
							else
							{
								bool flag5 = !flag;
								if (flag5)
								{
									array[num5] = (byte)(this._fileBytes[i] >> num3 - 1 & 255 >> num3);
								}
							}
						}
						result = BitConverter.ToInt64(array, 0);
					}
					else
					{
						array[0] = (this._fileBytes[startIdx] & 127);
						result = BitConverter.ToInt64(array, 0);
					}
				}
			}
			catch
			{
				result = 0L;
			}
			return result;
		}

		// Token: 0x06000045 RID: 69 RVA: 0x00005F38 File Offset: 0x00004138
		private static bool IsOdd(long value)
		{
			return (value & 1L) == 1L;
		}

		// Token: 0x0400001F RID: 31
		private readonly byte[] _sqlDataTypeSize = new byte[]
		{
			0,
			1,
			2,
			3,
			4,
			6,
			8,
			8,
			0,
			0
		};

		// Token: 0x04000020 RID: 32
		private readonly ulong _dbEncoding;

		// Token: 0x04000021 RID: 33
		private readonly byte[] _fileBytes;

		// Token: 0x04000022 RID: 34
		private readonly ulong _pageSize;

		// Token: 0x04000023 RID: 35
		private string[] _fieldNames;

		// Token: 0x04000024 RID: 36
		private Sqlite.SqliteMasterEntry[] _masterTableEntries;

		// Token: 0x04000025 RID: 37
		private Sqlite.TableEntry[] _tableEntries;

		// Token: 0x02000015 RID: 21
		private struct RecordHeaderField
		{
			// Token: 0x04000026 RID: 38
			public long Size;

			// Token: 0x04000027 RID: 39
			public long Type;
		}

		// Token: 0x02000016 RID: 22
		private struct TableEntry
		{
			// Token: 0x04000028 RID: 40
			public string[] Content;
		}

		// Token: 0x02000017 RID: 23
		private struct SqliteMasterEntry
		{
			// Token: 0x04000029 RID: 41
			public string ItemName;

			// Token: 0x0400002A RID: 42
			public long RootNum;

			// Token: 0x0400002B RID: 43
			public string SqlStatement;
		}
	}
}

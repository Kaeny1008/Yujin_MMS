using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class ARIAEngine
{
    static ARIAEngine()
    {
        uint[] array = new uint[256];
        uint[] array2 = new uint[256];
        array[0] = 1U;
        for (int i = 1; i < 256; i++)
        {
            uint num = array[i - 1] << 1 ^ array[i - 1];
            if ((num & 256U) != 0U)
            {
                num ^= 283U;
            }
            array[i] = num;
        }
        for (int j = 1; j < 255; j++)
        {
            array2[(int)array[j]] = (uint)j;
        }
        uint[,] array3 = new uint[,]
        {
        {1U,0U,0U,0U,1U,1U,1U,1U},
        {1U,1U,0U,0U,0U,1U,1U,1U},
        {1U,1U,1U,0U,0U,0U,1U,1U},
        {1U,1U,1U,1U,0U,0U,0U,1U},
        {1U,1U,1U,1U,1U,0U,0U,0U},
        {0U,1U,1U,1U,1U,1U,0U,0U},
        {0U,0U,1U,1U,1U,1U,1U,0U},
        {0U,0U,0U,1U,1U,1U,1U,1U}
        };
        uint[,] array4 = new uint[,]
        {
        {
            0U,
            1U,
            0U,
            1U,
            1U,
            1U,
            1U,
            0U
        },
        {
            0U,
            0U,
            1U,
            1U,
            1U,
            1U,
            0U,
            1U
        },
        {
            1U,
            1U,
            0U,
            1U,
            0U,
            1U,
            1U,
            1U
        },
        {
            1U,
            0U,
            0U,
            1U,
            1U,
            1U,
            0U,
            1U
        },
        {
            0U,
            0U,
            1U,
            0U,
            1U,
            1U,
            0U,
            0U
        },
        {
            1U,
            0U,
            0U,
            0U,
            0U,
            0U,
            0U,
            1U
        },
        {
            0U,
            1U,
            0U,
            1U,
            1U,
            1U,
            0U,
            1U
        },
        {
            1U,
            1U,
            0U,
            1U,
            0U,
            0U,
            1U,
            1U
        }
        };
        for (int k = 0; k < 256; k++)
        {
            uint num2 = 0U;
            uint num3;
            if (k == 0)
            {
                num3 = 0U;
            }
            else
            {
                num3 = array[(int)(255U - array2[k])];
            }
            for (int l = 0; l < 8; l++)
            {
                uint num4 = 0U;
                for (int m = 0; m < 8; m++)
                {
                    if ((num3 >> 7 - m & 1U) != 0U)
                    {
                        num4 ^= array3[m, l];
                    }
                }
                num2 = (num2 << 1 ^ num4);
            }
            num2 ^= 99U;
            ARIAEngine.S1[k] = (byte)num2;
            ARIAEngine.X1[(int)num2] = (byte)k;
        }
        for (int n = 0; n < 256; n++)
        {
            uint num5 = 0U;
            uint num6;
            if (n == 0)
            {
                num6 = 0U;
            }
            else
            {
                num6 = array[(int)(247U * array2[n] % 255U)];
            }
            for (int num7 = 0; num7 < 8; num7++)
            {
                uint num8 = 0U;
                for (int num9 = 0; num9 < 8; num9++)
                {
                    if ((num6 >> num9 & 1U) != 0U)
                    {
                        num8 ^= array4[7 - num7, num9];
                    }
                }
                num5 = (num5 << 1 ^ num8);
            }
            num5 ^= 226U;
            ARIAEngine.S2[n] = (byte)num5;
            ARIAEngine.X2[(int)num5] = (byte)n;
        }
        for (int num10 = 0; num10 < 256; num10++)
        {
            ARIAEngine.TS1[num10] = 65793U * (uint)(ARIAEngine.S1[num10] & byte.MaxValue);
            ARIAEngine.TS2[num10] = 16777473U * (uint)(ARIAEngine.S2[num10] & byte.MaxValue);
            ARIAEngine.TX1[num10] = 16842753U * (uint)(ARIAEngine.X1[num10] & byte.MaxValue);
            ARIAEngine.TX2[num10] = 16843008U * (uint)(ARIAEngine.X2[num10] & byte.MaxValue);
        }
    }

    // Token: 0x06000003 RID: 3 RVA: 0x0000237F File Offset: 0x0000057F
    public ARIAEngine(int keySize)
    {
        this.SetKeySize(keySize);
    }

    // Token: 0x06000004 RID: 4 RVA: 0x0000238E File Offset: 0x0000058E
    public void Reset()
    {
        this.keySize = 0;
        this.numberOfRounds = 0;
        this.masterKey = null;
        this.encRoundKeys = null;
        this.decRoundKeys = null;
    }

    public int GetKeySize()
    {
        return this.keySize;
    }

    public void SetKeySize(int keySize)
    {
        this.Reset();
        this.keySize = keySize;
        if (keySize == 128)
        {
            this.numberOfRounds = 12;
            return;
        }
        if (keySize == 192)
        {
            this.numberOfRounds = 14;
            return;
        }
        if (keySize != 256)
        {
            return;
        }
        this.numberOfRounds = 16;
    }

    public void SetKey(byte[] masterKey)
    {
        this.decRoundKeys = null;
        this.encRoundKeys = null;
        this.masterKey = (byte[])masterKey.Clone();
    }

    public void SetupEncRoundKeys()
    {
        if (this.encRoundKeys == null)
        {
            this.encRoundKeys = new uint[4 * (this.numberOfRounds + 1)];
        }
        this.decRoundKeys = null;
        ARIAEngine.DoEncKeySetup(this.masterKey, this.encRoundKeys, this.keySize);
    }

    // Token: 0x06000009 RID: 9 RVA: 0x00002467 File Offset: 0x00000667
    public void SetupDecRoundKeys()
    {
        this.SetupEncRoundKeys();
        this.decRoundKeys = (uint[])this.encRoundKeys.Clone();
        ARIAEngine.DoDecKeySetup(this.masterKey, this.decRoundKeys, this.keySize);
    }

    // Token: 0x0600000A RID: 10 RVA: 0x0000249C File Offset: 0x0000069C
    public void SetupRoundKeys()
    {
        this.SetupDecRoundKeys();
    }

    // Token: 0x0600000B RID: 11 RVA: 0x000024A4 File Offset: 0x000006A4
    private static void DoCrypt(byte[] i, int ioffset, uint[] rk, int nr, byte[] o, int ooffset)
    {
        uint num = 0U;
        uint num2 = ARIAEngine.ToInt(i[ioffset], i[1 + ioffset], i[2 + ioffset], i[3 + ioffset]);
        uint num3 = ARIAEngine.ToInt(i[4 + ioffset], i[5 + ioffset], i[6 + ioffset], i[7 + ioffset]);
        uint num4 = ARIAEngine.ToInt(i[8 + ioffset], i[9 + ioffset], i[10 + ioffset], i[11 + ioffset]);
        uint num5 = ARIAEngine.ToInt(i[12 + ioffset], i[13 + ioffset], i[14 + ioffset], i[15 + ioffset]);
        for (int j = 1; j < nr / 2; j++)
        {
            num2 ^= rk[(int)num++];
            num3 ^= rk[(int)num++];
            num4 ^= rk[(int)num++];
            num5 ^= rk[(int)num++];
            num2 = (ARIAEngine.TS1[(int)(num2 >> 24 & 255U)] ^ ARIAEngine.TS2[(int)(num2 >> 16 & 255U)] ^ ARIAEngine.TX1[(int)(num2 >> 8 & 255U)] ^ ARIAEngine.TX2[(int)(num2 & 255U)]);
            num3 = (ARIAEngine.TS1[(int)(num3 >> 24 & 255U)] ^ ARIAEngine.TS2[(int)(num3 >> 16 & 255U)] ^ ARIAEngine.TX1[(int)(num3 >> 8 & 255U)] ^ ARIAEngine.TX2[(int)(num3 & 255U)]);
            num4 = (ARIAEngine.TS1[(int)(num4 >> 24 & 255U)] ^ ARIAEngine.TS2[(int)(num4 >> 16 & 255U)] ^ ARIAEngine.TX1[(int)(num4 >> 8 & 255U)] ^ ARIAEngine.TX2[(int)(num4 & 255U)]);
            num5 = (ARIAEngine.TS1[(int)(num5 >> 24 & 255U)] ^ ARIAEngine.TS2[(int)(num5 >> 16 & 255U)] ^ ARIAEngine.TX1[(int)(num5 >> 8 & 255U)] ^ ARIAEngine.TX2[(int)(num5 & 255U)]);
            num3 ^= num4;
            num4 ^= num5;
            num2 ^= num3;
            num5 ^= num3;
            num4 ^= num2;
            num3 ^= num4;
            num3 = ARIAEngine.Badc(num3);
            num4 = ARIAEngine.Cdab(num4);
            num5 = ARIAEngine.Dcba(num5);
            num3 ^= num4;
            num4 ^= num5;
            num2 ^= num3;
            num5 ^= num3;
            num4 ^= num2;
            num3 ^= num4;
            num2 ^= rk[(int)num++];
            num3 ^= rk[(int)num++];
            num4 ^= rk[(int)num++];
            num5 ^= rk[(int)num++];
            num2 = (ARIAEngine.TX1[(int)(num2 >> 24 & 255U)] ^ ARIAEngine.TX2[(int)(num2 >> 16 & 255U)] ^ ARIAEngine.TS1[(int)(num2 >> 8 & 255U)] ^ ARIAEngine.TS2[(int)(num2 & 255U)]);
            num3 = (ARIAEngine.TX1[(int)(num3 >> 24 & 255U)] ^ ARIAEngine.TX2[(int)(num3 >> 16 & 255U)] ^ ARIAEngine.TS1[(int)(num3 >> 8 & 255U)] ^ ARIAEngine.TS2[(int)(num3 & 255U)]);
            num4 = (ARIAEngine.TX1[(int)(num4 >> 24 & 255U)] ^ ARIAEngine.TX2[(int)(num4 >> 16 & 255U)] ^ ARIAEngine.TS1[(int)(num4 >> 8 & 255U)] ^ ARIAEngine.TS2[(int)(num4 & 255U)]);
            num5 = (ARIAEngine.TX1[(int)(num5 >> 24 & 255U)] ^ ARIAEngine.TX2[(int)(num5 >> 16 & 255U)] ^ ARIAEngine.TS1[(int)(num5 >> 8 & 255U)] ^ ARIAEngine.TS2[(int)(num5 & 255U)]);
            num3 ^= num4;
            num4 ^= num5;
            num2 ^= num3;
            num5 ^= num3;
            num4 ^= num2;
            num3 ^= num4;
            num5 = ARIAEngine.Badc(num5);
            num2 = ARIAEngine.Cdab(num2);
            num3 = ARIAEngine.Dcba(num3);
            num3 ^= num4;
            num4 ^= num5;
            num2 ^= num3;
            num5 ^= num3;
            num4 ^= num2;
            num3 ^= num4;
        }
        num2 ^= rk[(int)num++];
        num3 ^= rk[(int)num++];
        num4 ^= rk[(int)num++];
        num5 ^= rk[(int)num++];
        num2 = (ARIAEngine.TS1[(int)(num2 >> 24 & 255U)] ^ ARIAEngine.TS2[(int)(num2 >> 16 & 255U)] ^ ARIAEngine.TX1[(int)(num2 >> 8 & 255U)] ^ ARIAEngine.TX2[(int)(num2 & 255U)]);
        num3 = (ARIAEngine.TS1[(int)(num3 >> 24 & 255U)] ^ ARIAEngine.TS2[(int)(num3 >> 16 & 255U)] ^ ARIAEngine.TX1[(int)(num3 >> 8 & 255U)] ^ ARIAEngine.TX2[(int)(num3 & 255U)]);
        num4 = (ARIAEngine.TS1[(int)(num4 >> 24 & 255U)] ^ ARIAEngine.TS2[(int)(num4 >> 16 & 255U)] ^ ARIAEngine.TX1[(int)(num4 >> 8 & 255U)] ^ ARIAEngine.TX2[(int)(num4 & 255U)]);
        num5 = (ARIAEngine.TS1[(int)(num5 >> 24 & 255U)] ^ ARIAEngine.TS2[(int)(num5 >> 16 & 255U)] ^ ARIAEngine.TX1[(int)(num5 >> 8 & 255U)] ^ ARIAEngine.TX2[(int)(num5 & 255U)]);
        num3 ^= num4;
        num4 ^= num5;
        num2 ^= num3;
        num5 ^= num3;
        num4 ^= num2;
        num3 ^= num4;
        num3 = ARIAEngine.Badc(num3);
        num4 = ARIAEngine.Cdab(num4);
        num5 = ARIAEngine.Dcba(num5);
        num3 ^= num4;
        num4 ^= num5;
        num2 ^= num3;
        num5 ^= num3;
        num4 ^= num2;
        num3 ^= num4;
        num2 ^= rk[(int)num++];
        num3 ^= rk[(int)num++];
        num4 ^= rk[(int)num++];
        num5 ^= rk[(int)num++];
        o[ooffset] = (byte)((uint)ARIAEngine.X1[(int)(255U & num2 >> 24)] ^ rk[(int)num] >> 24);
        o[1 + ooffset] = (byte)((uint)ARIAEngine.X2[(int)(255U & num2 >> 16)] ^ rk[(int)num] >> 16);
        o[2 + ooffset] = (byte)((uint)ARIAEngine.S1[(int)(255U & num2 >> 8)] ^ rk[(int)num] >> 8);
        o[3 + ooffset] = (byte)((uint)ARIAEngine.S2[(int)(255U & num2)] ^ rk[(int)num]);
        o[4 + ooffset] = (byte)((uint)ARIAEngine.X1[(int)(255U & num3 >> 24)] ^ rk[(int)(num + 1U)] >> 24);
        o[5 + ooffset] = (byte)((uint)ARIAEngine.X2[(int)(255U & num3 >> 16)] ^ rk[(int)(num + 1U)] >> 16);
        o[6 + ooffset] = (byte)((uint)ARIAEngine.S1[(int)(255U & num3 >> 8)] ^ rk[(int)(num + 1U)] >> 8);
        o[7 + ooffset] = (byte)((uint)ARIAEngine.S2[(int)(255U & num3)] ^ rk[(int)(num + 1U)]);
        o[8 + ooffset] = (byte)((uint)ARIAEngine.X1[(int)(255U & num4 >> 24)] ^ rk[(int)(num + 2U)] >> 24);
        o[9 + ooffset] = (byte)((uint)ARIAEngine.X2[(int)(255U & num4 >> 16)] ^ rk[(int)(num + 2U)] >> 16);
        o[10 + ooffset] = (byte)((uint)ARIAEngine.S1[(int)(255U & num4 >> 8)] ^ rk[(int)(num + 2U)] >> 8);
        o[11 + ooffset] = (byte)((uint)ARIAEngine.S2[(int)(255U & num4)] ^ rk[(int)(num + 2U)]);
        o[12 + ooffset] = (byte)((uint)ARIAEngine.X1[(int)(255U & num5 >> 24)] ^ rk[(int)(num + 3U)] >> 24);
        o[13 + ooffset] = (byte)((uint)ARIAEngine.X2[(int)(255U & num5 >> 16)] ^ rk[(int)(num + 3U)] >> 16);
        o[14 + ooffset] = (byte)((uint)ARIAEngine.S1[(int)(255U & num5 >> 8)] ^ rk[(int)(num + 3U)] >> 8);
        o[15 + ooffset] = (byte)((uint)ARIAEngine.S2[(int)(255U & num5)] ^ rk[(int)(num + 3U)]);
    }

    // Token: 0x0600000C RID: 12 RVA: 0x00002BC5 File Offset: 0x00000DC5
    public void Encrypt(byte[] i, int ioffset, byte[] o, int ooffset)
    {
        this.SetupEncRoundKeys();
        ARIAEngine.DoCrypt(i, ioffset, this.encRoundKeys, this.numberOfRounds, o, ooffset);
    }

    // Token: 0x0600000D RID: 13 RVA: 0x00002BE4 File Offset: 0x00000DE4
    public byte[] Encrypt(byte[] i, int ioffset)
    {
        byte[] array = new byte[16];
        this.Encrypt(i, ioffset, array, 0);
        return array;
    }

    // Token: 0x0600000E RID: 14 RVA: 0x00002C04 File Offset: 0x00000E04
    public void Decrypt(byte[] i, int ioffset, byte[] o, int ooffset)
    {
        this.SetupDecRoundKeys();
        ARIAEngine.DoCrypt(i, ioffset, this.decRoundKeys, this.numberOfRounds, o, ooffset);
    }

    // Token: 0x0600000F RID: 15 RVA: 0x00002C24 File Offset: 0x00000E24
    public byte[] Decrypt(byte[] i, int ioffset)
    {
        byte[] array = new byte[16];
        this.Decrypt(i, ioffset, array, 0);
        return array;
    }

    // Token: 0x06000010 RID: 16 RVA: 0x00002C44 File Offset: 0x00000E44
    private static void DoEncKeySetup(byte[] mk, uint[] rk, int keyBits)
    {
        int num = 0;
        uint[] array = new uint[4];
        uint[] array2 = new uint[4];
        uint[] array3 = new uint[4];
        uint[] array4 = new uint[4];
        array[0] = ARIAEngine.ToInt(mk[0], mk[1], mk[2], mk[3]);
        array[1] = ARIAEngine.ToInt(mk[4], mk[5], mk[6], mk[7]);
        array[2] = ARIAEngine.ToInt(mk[8], mk[9], mk[10], mk[11]);
        array[3] = ARIAEngine.ToInt(mk[12], mk[13], mk[14], mk[15]);
        int num2 = (keyBits - 128) / 64;
        uint num3 = array[0] ^ ARIAEngine.KRK[num2, 0];
        uint num4 = array[1] ^ ARIAEngine.KRK[num2, 1];
        uint num5 = array[2] ^ ARIAEngine.KRK[num2, 2];
        uint num6 = array[3] ^ ARIAEngine.KRK[num2, 3];
        num3 = (ARIAEngine.TS1[(int)(num3 >> 24 & 255U)] ^ ARIAEngine.TS2[(int)(num3 >> 16 & 255U)] ^ ARIAEngine.TX1[(int)(num3 >> 8 & 255U)] ^ ARIAEngine.TX2[(int)(num3 & 255U)]);
        num4 = (ARIAEngine.TS1[(int)(num4 >> 24 & 255U)] ^ ARIAEngine.TS2[(int)(num4 >> 16 & 255U)] ^ ARIAEngine.TX1[(int)(num4 >> 8 & 255U)] ^ ARIAEngine.TX2[(int)(num4 & 255U)]);
        num5 = (ARIAEngine.TS1[(int)(num5 >> 24 & 255U)] ^ ARIAEngine.TS2[(int)(num5 >> 16 & 255U)] ^ ARIAEngine.TX1[(int)(num5 >> 8 & 255U)] ^ ARIAEngine.TX2[(int)(num5 & 255U)]);
        num6 = (ARIAEngine.TS1[(int)(num6 >> 24 & 255U)] ^ ARIAEngine.TS2[(int)(num6 >> 16 & 255U)] ^ ARIAEngine.TX1[(int)(num6 >> 8 & 255U)] ^ ARIAEngine.TX2[(int)(num6 & 255U)]);
        num4 ^= num5;
        num5 ^= num6;
        num3 ^= num4;
        num6 ^= num4;
        num5 ^= num3;
        num4 ^= num5;
        num4 = ARIAEngine.Badc(num4);
        num5 = ARIAEngine.Cdab(num5);
        num6 = ARIAEngine.Dcba(num6);
        num4 ^= num5;
        num5 ^= num6;
        num3 ^= num4;
        num6 ^= num4;
        num5 ^= num3;
        num4 ^= num5;
        if (keyBits > 128)
        {
            array2[0] = ARIAEngine.ToInt(mk[16], mk[17], mk[18], mk[19]);
            array2[1] = ARIAEngine.ToInt(mk[20], mk[21], mk[22], mk[23]);
            if (keyBits > 192)
            {
                array2[2] = ARIAEngine.ToInt(mk[24], mk[25], mk[26], mk[27]);
                array2[3] = ARIAEngine.ToInt(mk[28], mk[29], mk[30], mk[31]);
            }
            else
            {
                array2[2] = (array2[3] = 0U);
            }
        }
        else
        {
            array2[0] = (array2[1] = (array2[2] = (array2[3] = 0U)));
        }
        array2[0] ^= num3;
        array2[1] ^= num4;
        array2[2] ^= num5;
        array2[3] ^= num6;
        num3 = array2[0];
        num4 = array2[1];
        num5 = array2[2];
        num6 = array2[3];
        num2 = ((num2 == 2) ? 0 : (num2 + 1));
        num3 ^= ARIAEngine.KRK[num2, 0];
        num4 ^= ARIAEngine.KRK[num2, 1];
        num5 ^= ARIAEngine.KRK[num2, 2];
        num6 ^= ARIAEngine.KRK[num2, 3];
        num3 = (ARIAEngine.TX1[(int)(num3 >> 24 & 255U)] ^ ARIAEngine.TX2[(int)(num3 >> 16 & 255U)] ^ ARIAEngine.TS1[(int)(num3 >> 8 & 255U)] ^ ARIAEngine.TS2[(int)(num3 & 255U)]);
        num4 = (ARIAEngine.TX1[(int)(num4 >> 24 & 255U)] ^ ARIAEngine.TX2[(int)(num4 >> 16 & 255U)] ^ ARIAEngine.TS1[(int)(num4 >> 8 & 255U)] ^ ARIAEngine.TS2[(int)(num4 & 255U)]);
        num5 = (ARIAEngine.TX1[(int)(num5 >> 24 & 255U)] ^ ARIAEngine.TX2[(int)(num5 >> 16 & 255U)] ^ ARIAEngine.TS1[(int)(num5 >> 8 & 255U)] ^ ARIAEngine.TS2[(int)(num5 & 255U)]);
        num6 = (ARIAEngine.TX1[(int)(num6 >> 24 & 255U)] ^ ARIAEngine.TX2[(int)(num6 >> 16 & 255U)] ^ ARIAEngine.TS1[(int)(num6 >> 8 & 255U)] ^ ARIAEngine.TS2[(int)(num6 & 255U)]);
        num4 ^= num5;
        num5 ^= num6;
        num3 ^= num4;
        num6 ^= num4;
        num5 ^= num3;
        num4 ^= num5;
        num6 = ARIAEngine.Badc(num6);
        num3 = ARIAEngine.Cdab(num3);
        num4 = ARIAEngine.Dcba(num4);
        num4 ^= num5;
        num5 ^= num6;
        num3 ^= num4;
        num6 ^= num4;
        num5 ^= num3;
        num4 ^= num5;
        num3 ^= array[0];
        num4 ^= array[1];
        num5 ^= array[2];
        num6 ^= array[3];
        array3[0] = num3;
        array3[1] = num4;
        array3[2] = num5;
        array3[3] = num6;
        num2 = ((num2 == 2) ? 0 : (num2 + 1));
        num3 ^= ARIAEngine.KRK[num2, 0];
        num4 ^= ARIAEngine.KRK[num2, 1];
        num5 ^= ARIAEngine.KRK[num2, 2];
        num6 ^= ARIAEngine.KRK[num2, 3];
        num3 = (ARIAEngine.TS1[(int)(num3 >> 24 & 255U)] ^ ARIAEngine.TS2[(int)(num3 >> 16 & 255U)] ^ ARIAEngine.TX1[(int)(num3 >> 8 & 255U)] ^ ARIAEngine.TX2[(int)(num3 & 255U)]);
        num4 = (ARIAEngine.TS1[(int)(num4 >> 24 & 255U)] ^ ARIAEngine.TS2[(int)(num4 >> 16 & 255U)] ^ ARIAEngine.TX1[(int)(num4 >> 8 & 255U)] ^ ARIAEngine.TX2[(int)(num4 & 255U)]);
        num5 = (ARIAEngine.TS1[(int)(num5 >> 24 & 255U)] ^ ARIAEngine.TS2[(int)(num5 >> 16 & 255U)] ^ ARIAEngine.TX1[(int)(num5 >> 8 & 255U)] ^ ARIAEngine.TX2[(int)(num5 & 255U)]);
        num6 = (ARIAEngine.TS1[(int)(num6 >> 24 & 255U)] ^ ARIAEngine.TS2[(int)(num6 >> 16 & 255U)] ^ ARIAEngine.TX1[(int)(num6 >> 8 & 255U)] ^ ARIAEngine.TX2[(int)(num6 & 255U)]);
        num4 ^= num5;
        num5 ^= num6;
        num3 ^= num4;
        num6 ^= num4;
        num5 ^= num3;
        num4 ^= num5;
        num4 = ARIAEngine.Badc(num4);
        num5 = ARIAEngine.Cdab(num5);
        num6 = ARIAEngine.Dcba(num6);
        num4 ^= num5;
        num5 ^= num6;
        num3 ^= num4;
        num6 ^= num4;
        num5 ^= num3;
        num4 ^= num5;
        array4[0] = (num3 ^ array2[0]);
        array4[1] = (num4 ^ array2[1]);
        array4[2] = (num5 ^ array2[2]);
        array4[3] = (num6 ^ array2[3]);
        ARIAEngine.Gsrk(array, array2, 19, rk, num);
        num += 4;
        ARIAEngine.Gsrk(array2, array3, 19, rk, num);
        num += 4;
        ARIAEngine.Gsrk(array3, array4, 19, rk, num);
        num += 4;
        ARIAEngine.Gsrk(array4, array, 19, rk, num);
        num += 4;
        ARIAEngine.Gsrk(array, array2, 31, rk, num);
        num += 4;
        ARIAEngine.Gsrk(array2, array3, 31, rk, num);
        num += 4;
        ARIAEngine.Gsrk(array3, array4, 31, rk, num);
        num += 4;
        ARIAEngine.Gsrk(array4, array, 31, rk, num);
        num += 4;
        ARIAEngine.Gsrk(array, array2, 67, rk, num);
        num += 4;
        ARIAEngine.Gsrk(array2, array3, 67, rk, num);
        num += 4;
        ARIAEngine.Gsrk(array3, array4, 67, rk, num);
        num += 4;
        ARIAEngine.Gsrk(array4, array, 67, rk, num);
        num += 4;
        ARIAEngine.Gsrk(array, array2, 97, rk, num);
        num += 4;
        if (keyBits > 128)
        {
            ARIAEngine.Gsrk(array2, array3, 97, rk, num);
            num += 4;
            ARIAEngine.Gsrk(array3, array4, 97, rk, num);
            num += 4;
        }
        if (keyBits > 192)
        {
            ARIAEngine.Gsrk(array4, array, 97, rk, num);
            num += 4;
            ARIAEngine.Gsrk(array, array2, 109, rk, num);
        }
    }

    // Token: 0x06000011 RID: 17 RVA: 0x00003438 File Offset: 0x00001638
    private static void DoDecKeySetup(byte[] mk, uint[] rk, int keyBits)
    {
        int i = 0;
        uint[] array = new uint[4];
        int num = 32 + keyBits / 8;
        ARIAEngine.SwapBlocks(rk, 0, num);
        i += 4;
        num -= 4;
        while (i < num)
        {
            ARIAEngine.SwapAndDiffuse(rk, i, num, array);
            i += 4;
            num -= 4;
        }
        ARIAEngine.Diff(rk, i, array, 0);
        rk[i] = array[0];
        rk[i + 1] = array[1];
        rk[i + 2] = array[2];
        rk[i + 3] = array[3];
    }

    // Token: 0x06000012 RID: 18 RVA: 0x000034A3 File Offset: 0x000016A3
    private static uint ToInt(byte b0, byte b1, byte b2, byte b3)
    {
        return (uint)((int)(b0 & byte.MaxValue) << 24 ^ (int)(b1 & byte.MaxValue) << 16 ^ (int)(b2 & byte.MaxValue) << 8 ^ (int)(b3 & byte.MaxValue));
    }

    // Token: 0x06000013 RID: 19 RVA: 0x000034CC File Offset: 0x000016CC
    private static void ToByteArray(uint i, byte[] b, int offset)
    {
        b[offset] = (byte)(i >> 24);
        b[offset + 1] = (byte)(i >> 16);
        b[offset + 2] = (byte)(i >> 8);
        b[offset + 3] = (byte)i;
    }

    // Token: 0x06000014 RID: 20 RVA: 0x000034F0 File Offset: 0x000016F0
    private static uint M(uint t)
    {
        return 65793U * (t >> 24 & 255U) ^ 16777473U * (t >> 16 & 255U) ^ 16842753U * (t >> 8 & 255U) ^ 16843008U * (t & 255U);
    }

    // Token: 0x06000015 RID: 21 RVA: 0x0000353C File Offset: 0x0000173C
    private static uint Badc(uint t)
    {
        return (t << 8 & 4278255360U) ^ (t >> 8 & 16711935U);
    }

    // Token: 0x06000016 RID: 22 RVA: 0x00003551 File Offset: 0x00001751
    private static uint Cdab(uint t)
    {
        return (t << 16 & 4294901760U) ^ (t >> 16 & 65535U);
    }

    // Token: 0x06000017 RID: 23 RVA: 0x00003568 File Offset: 0x00001768
    private static uint Dcba(uint t)
    {
        return (t & 255U) << 24 ^ (t & 65280U) << 8 ^ (t & 16711680U) >> 8 ^ (t & 4278190080U) >> 24;
    }

    // Token: 0x06000018 RID: 24 RVA: 0x00003594 File Offset: 0x00001794
    private static void Gsrk(uint[] x, uint[] y, int rot, uint[] rk, int offset)
    {
        int num = 4 - rot / 32;
        int num2 = rot % 32;
        int num3 = 32 - num2;
        rk[offset] = (x[0] ^ y[num % 4] >> num2 ^ y[(num + 3) % 4] << num3);
        rk[offset + 1] = (x[1] ^ y[(num + 1) % 4] >> num2 ^ y[num % 4] << num3);
        rk[offset + 2] = (x[2] ^ y[(num + 2) % 4] >> num2 ^ y[(num + 1) % 4] << num3);
        rk[offset + 3] = (x[3] ^ y[(num + 3) % 4] >> num2 ^ y[(num + 2) % 4] << num3);
    }

    // Token: 0x06000019 RID: 25 RVA: 0x00003638 File Offset: 0x00001838
    private static void Diff(uint[] i, int offset1, uint[] o, int offset2)
    {
        uint num = ARIAEngine.M(i[offset1]);
        uint num2 = ARIAEngine.M(i[offset1 + 1]);
        uint num3 = ARIAEngine.M(i[offset1 + 2]);
        uint num4 = ARIAEngine.M(i[offset1 + 3]);
        num2 ^= num3;
        num3 ^= num4;
        num ^= num2;
        num4 ^= num2;
        num3 ^= num;
        num2 ^= num3;
        num2 = ARIAEngine.Badc(num2);
        num3 = ARIAEngine.Cdab(num3);
        num4 = ARIAEngine.Dcba(num4);
        num2 ^= num3;
        num3 ^= num4;
        num ^= num2;
        num4 ^= num2;
        num3 ^= num;
        num2 ^= num3;
        o[offset2] = num;
        o[offset2 + 1] = num2;
        o[offset2 + 2] = num3;
        o[offset2 + 3] = num4;
    }

    // Token: 0x0600001A RID: 26 RVA: 0x000036CC File Offset: 0x000018CC
    private static void SwapBlocks(uint[] arr, int offset1, int offset2)
    {
        for (int i = 0; i < 4; i++)
        {
            uint num = arr[offset1 + i];
            arr[offset1 + i] = arr[offset2 + i];
            arr[offset2 + i] = num;
        }
    }

    // Token: 0x0600001B RID: 27 RVA: 0x000036FB File Offset: 0x000018FB
    private static void SwapAndDiffuse(uint[] arr, int offset1, int offset2, uint[] tmp)
    {
        ARIAEngine.Diff(arr, offset1, tmp, 0);
        ARIAEngine.Diff(arr, offset2, arr, offset1);
        arr[offset2] = tmp[0];
        arr[offset2 + 1] = tmp[1];
        arr[offset2 + 2] = tmp[2];
        arr[offset2 + 3] = tmp[3];
    }

    //private void SetInitKey()
    //{
    //    byte[] key = new byte[]{
    //        115,97,109,115,117,110,103,32,115,32,116,101,99,104,119,105,110,110,101,114,32,119,32,53,116,107,97,116,116,106,100,33
    //    }; //samsung s techwinner w 5tkattjd! <- 이거 바이트화 시킨거 확인완료.
    //    this.SetKey(key);
    //    this.SetupRoundKeys();
    //}

    public string SetEnc(string strValue)
    {
        if (strValue == "" || strValue == null || strValue == string.Empty)
        {
            return strValue;
        }
        //this.SetInitKey();
        byte[] array = new byte[67600];
        byte[] array2 = new byte[67600];
        byte[] bytes = Encoding.UTF8.GetBytes(strValue);
        Buffer.BlockCopy(bytes, 0, array, 0, bytes.Length);
        int num = bytes.Length / 16;
        byte[] array3 = new byte[16];
        byte[] array4 = new byte[16];
        for (int i = 0; i < num + 1; i++)
        {
            Buffer.BlockCopy(array, i * 16, array3, 0, 16);
            this.Encrypt(array3, 0, array4, 0);
            Buffer.BlockCopy(array4, 0, array2, i * 16, 16);
        }
        string text = "";
        int num2 = (num + 1) * 16;
        for (int j = 0; j < num2; j++)
        {
            string str = string.Format("{0:x2}", array2[j]);
            text += str;
        }
        return text;
    }

    public string SetEncForSWLicense(string strValue)
    {
        if (strValue == "" || strValue == null || strValue == string.Empty)
        {
            return strValue;
        }
        byte[] array = new byte[67600];
        byte[] array2 = new byte[67600];
        byte[] bytes = Encoding.UTF8.GetBytes(strValue);
        Buffer.BlockCopy(bytes, 0, array, 0, bytes.Length);
        int num = bytes.Length / 16;
        byte[] array3 = new byte[16];
        byte[] array4 = new byte[16];
        for (int i = 0; i < num + 1; i++)
        {
            Buffer.BlockCopy(array, i * 16, array3, 0, 16);
            this.Encrypt(array3, 0, array4, 0);
            Buffer.BlockCopy(array4, 0, array2, i * 16, 16);
        }
        string text = "";
        int num2 = (num + 1) * 16;
        for (int j = 0; j < num2; j++)
        {
            string str = string.Format("{0:x2}", array2[j]);
            text += str;
        }
        return text;
    }

    // Token: 0x0600001F RID: 31 RVA: 0x00003950 File Offset: 0x00001B50
    public string SetDec(string strValue)
    {
        if (strValue == "" || strValue == null || strValue == string.Empty)
        {
            return strValue;
        }
        //this.SetInitKey();
        int num = strValue.Length / 2;
        byte[] array = new byte[67600];
        byte[] array2 = new byte[67600];
        for (int i = 0; i < num; i++)
        {
            byte b = Convert.ToByte(strValue.Substring(i * 2, 2), 16);
            array[i] = b;
        }
        byte[] array3 = new byte[16];
        int num2 = num / 16;
        for (int j = 0; j < num2; j++)
        {
            Buffer.BlockCopy(array, j * 16, array3, 0, 16);
            this.Decrypt(array3, 0, array2, j * 16);
        }
        return Encoding.UTF8.GetString(array2).Trim(new char[1]);
    }

    // Token: 0x04000004 RID: 4
    private const int MAX_PATH = 260;

    // Token: 0x04000005 RID: 5
    private const int ENC_LENGTH = 16;

    // Token: 0x04000006 RID: 6
    private static readonly char[] HEX_DIGITS = new char[]
    {
    '0',
    '1',
    '2',
    '3',
    '4',
    '5',
    '6',
    '7',
    '8',
    '9',
    'a',
    'b',
    'c',
    'd',
    'e',
    'f'
    };

    // Token: 0x04000007 RID: 7
    private static readonly uint[,] KRK = new uint[,]
    {
        {1367130551U,656542356U,4262702056U,4204424928U},
        {
            1840335564U,
            2653014048U,
            4280857045U,
            4015907504U
        },
        {
            3683792669U,
            556198256U,
            52729717U,
            82364686U
        }
    };

    // Token: 0x04000008 RID: 8
    private static readonly byte[] S1 = new byte[256];

    // Token: 0x04000009 RID: 9
    private static readonly byte[] S2 = new byte[256];

    // Token: 0x0400000A RID: 10
    private static readonly byte[] X1 = new byte[256];

    // Token: 0x0400000B RID: 11
    private static readonly byte[] X2 = new byte[256];

    // Token: 0x0400000C RID: 12
    private static readonly uint[] TS1 = new uint[256];

    // Token: 0x0400000D RID: 13
    private static readonly uint[] TS2 = new uint[256];

    // Token: 0x0400000E RID: 14
    private static readonly uint[] TX1 = new uint[256];

    private static readonly uint[] TX2 = new uint[256];

    private int keySize;

    private int numberOfRounds;

    private byte[] masterKey;

    private uint[] encRoundKeys;

    private uint[] decRoundKeys;
}
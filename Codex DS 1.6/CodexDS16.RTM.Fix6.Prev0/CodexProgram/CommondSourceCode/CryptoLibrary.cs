using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ILG.Codex.Cryptography.CodexSafeModule
{
    public class CodexCryptoIDEAEncryption
    {
        static String Version = "10.2.0.0";
        // With Cancellation Token

        #region Internal

        class UTkeyArray
        {
            public UInt16[] Item;
        }

        class UTBlock64
        {
            public UInt16[] Item;
            public UTBlock64()
            {
                Item = new UInt16[4];
            }
        }

        class UTkey128
        {
            public UInt16[] Item;
        }

        UInt16 IDEAMUL(Int32 a, Int32 b)
        {
            Int32 p = a * b;
            UInt16 x, y;
            if (p == 0) x = (UInt16)(65537 - a - b);
            else
            {
                x = (UInt16)(p >> 16);
                y = (UInt16)(p % 65536);
                x = (UInt16)(y - x);
                if (y < x) x = (UInt16)(x + 65537);
            }
            return (UInt16)(x % 65536);

        }

        UInt16 IDEAAdd(Int32 Source, Int32 Key)
        {    // Addition modulo 65536 

            return (UInt16)((Source + Key) % 65536);
        }

        UInt16 MulInv(Int32 val, Int32 mod)
        {
            Int32 a, b;
            Int32 x1, x2, x;
            a = mod; b = val; x1 = 1; x2 = 0;
            while (b != 1)
            {

                x = x2 - (a / b * x1);
                x2 = x1;
                x1 = x;
                x = a % b;
                a = b;
                b = x;
            }
            val = (x1 + mod) % mod;
            return (UInt16)(val);
        }

        private UTkey128 SHLR128(UTkey128 Src)
        {
            UTkey128 Res = new UTkey128();
            Res.Item = new ushort[_UTBlock128_Size];

            UInt16 i;
            UInt16 D;
            for (i = 0; i <= 7; i++) Res.Item[i] = 0;

            D = 0;
            for (i = 0; i <= 7; i++)
            {
                Res.Item[i] = (UInt16)((UInt16)(Src.Item[i] << 1) | (UInt16)(D));
                D = (UInt16)(Src.Item[i] >> 15);
            }
            Res.Item[0] = (UInt16)(Res.Item[0] | D);
            return Res;
        }

        void Rol128bit(ref UTkey128 Data, int n)
        {
            for (int i = 1; i <= n; i++)
            {
                Data = SHLR128(Data);
            }
        }

        void GenerateKeys(ref UTkeyArray NewKeys, UTkey128 Key128)
        {
            UTkey128 Tempkey = new UTkey128();
            Tempkey.Item = new ushort[_UTkeyArray_Size];

            for (int i = 0; i < 8; i++) { Tempkey.Item[i] = 0; }

                //int i, j;
                for (int i = 1; i <= 6; i++)
                {
                    for (int j = 0; j <= 7; j++)
                    {
                        NewKeys.Item[(i - 1) * 8 + j] = Key128.Item[j];
                    }
                    Rol128bit(ref Key128, 25);
                }
                for (int i = 0; i <= 3; i++)
                { NewKeys.Item[48 + i] = Key128.Item[i]; }
            
            return;
        }

        void GenerateDeKeys(ref UTkeyArray NewKeys, UTkey128 Key128)
        {
            
                UTkeyArray tempkey = new UTkeyArray();
            tempkey.Item = new ushort[_UTkeyArray_Size];

            for (int i = 0; i < tempkey.Item.Count(); i++) tempkey.Item[i] = 0;
                int round;

                GenerateKeys(ref tempkey, Key128);
                for (round = 1; round <= 9; round++)
                {
                    #region rounds
                    NewKeys.Item[(round - 1) * 6] = (UInt16)(MulInv(tempkey.Item[51 - ((round - 1) * 6) - 3], 65537));
                    NewKeys.Item[(round - 1) * 6 + 3] = (UInt16)(MulInv(tempkey.Item[51 - ((round - 1) * 6)], 65537));
                    if ((round != 1) && (round != 9))
                    {
                        NewKeys.Item[(round - 1) * 6 + 1] = (UInt16)((65536 - tempkey.Item[51 - ((round - 1) * 6) - 1]) % 65536);
                        NewKeys.Item[(round - 1) * 6 + 2] = (UInt16)((65536 - tempkey.Item[51 - ((round - 1) * 6) - 2]) % 65536);
                        NewKeys.Item[(round - 1) * 6 + 4] = (UInt16)(tempkey.Item[45 - ((round - 1) * 6) + 1]);
                        NewKeys.Item[(round - 1) * 6 + 5] = (UInt16)(tempkey.Item[45 - ((round - 1) * 6) + 2]);
                    }
                    else
                    if (round == 1)
                    {
                        NewKeys.Item[(round - 1) * 6 + 2] = (UInt16)((65536 - tempkey.Item[51 - ((round - 1) * 6) - 1]) % 65536);
                        NewKeys.Item[(round - 1) * 6 + 1] = (UInt16)((65536 - tempkey.Item[51 - ((round - 1) * 6) - 2]) % 65536);
                        NewKeys.Item[(round - 1) * 6 + 4] = (UInt16)(tempkey.Item[45 - ((round - 1) * 6) + 1]);
                        NewKeys.Item[(round - 1) * 6 + 5] = (UInt16)(tempkey.Item[45 - ((round - 1) * 6) + 2]);
                    }
                    else if (round == 9)
                    {

                        NewKeys.Item[(round - 1) * 6 + 2] = (UInt16)((65536 - tempkey.Item[51 - ((round - 1) * 6) - 1]) % 65536);
                        NewKeys.Item[(round - 1) * 6 + 1] = (UInt16)((65536 - tempkey.Item[51 - ((round - 1) * 6) - 2]) % 65536);
                    }
                    #endregion rounds
                }
            
        }

        void IDEARound(ref UTBlock64 Source, ref UTBlock64 Res, ref UTkeyArray AllKeys, int Runde)
        {
            Int32[] NeededKeys = new Int32[6];
            Int32[] x = new Int32[6];

            Int32 t1, t2, kk;

            if (Runde < 9)
            {
                #region round less that 9
                for (int i = 0; i <= 5; i++)
                {
                        NeededKeys[i] = AllKeys.Item[(Runde - 1) * 6 + i];

                        x[0] = IDEAMUL(Source.Item[0], NeededKeys[0]);
                        x[1] = IDEAAdd(Source.Item[1], NeededKeys[1]);
                        x[2] = IDEAAdd(Source.Item[2], NeededKeys[2]);
                        x[3] = IDEAMUL(Source.Item[3], NeededKeys[3]);

                        kk = IDEAMUL(NeededKeys[4], (x[0] ^ x[2]));
                        t1 = IDEAMUL(NeededKeys[5], IDEAAdd(kk, (x[1] ^ x[3])));
                        t2 = IDEAAdd(kk, t1);
                    
                        Res.Item[0] = (UInt16)(x[0] ^ t1);
                        Res.Item[3] = (UInt16)(x[3] ^ t2);
                        Res.Item[1] = (UInt16)(x[2] ^ t1);
                        Res.Item[2] = (UInt16)(x[1] ^ t2);
                    
                }
                #endregion round less that 9
            }
            else
            {
                #region round 9
                if (Runde == 9)
                {
                   Res.Item[0] = IDEAMUL(Source.Item[0], AllKeys.Item[48]);
                   Res.Item[1] = IDEAAdd(Source.Item[2], AllKeys.Item[49]);
                   Res.Item[2] = IDEAAdd(Source.Item[1], AllKeys.Item[50]);
                   Res.Item[3] = IDEAMUL(Source.Item[3], AllKeys.Item[51]);
                }
                #endregion round 9
            }

            return;
        }

   
        void EncryptBlock(ref UTBlock64 InBlock, ref UTBlock64 OutBlock, ref UTkeyArray Keys)
        {
            for (int i = 1; i <= 9; i++)
             {
              IDEARound(ref InBlock, ref OutBlock, ref Keys, i);
                for (int j = 0; j <= 3; j++)
                  InBlock.Item[j] = OutBlock.Item[j];
                 
            }
            return;
        }

        void DecryptBlock(ref UTBlock64 InBlock, ref UTBlock64 OutBlock, ref UTkeyArray Keys)
        {

            for (int i = 1; i <= 9; i++)
            {
                IDEARound(ref InBlock, ref OutBlock, ref Keys, i);
                for (int j = 0; j <= 3; j++)
                    InBlock.Item[j] = OutBlock.Item[j];
            }


            return;
        }

      
        #endregion Internal

       
        public static int _UTkeyArray_Size = 52;
        public static int _UTBlock64_Size = 4;
        public static int _UTBlock128_Size = 8;

        class MTBlock64
        {
            public UInt16[] Item;
            public MTBlock64(int i) { Item = new UInt16[4]; }
            public void write(BinaryWriter bw)
            {
                for (int i = 0; i <= 3; i++)
                    bw.Write(Item[i]);
                return;
            }
            public void read(BinaryReader bw)
            {
                for (int i = 0; i <= 3; i++)
                {
                    Item[i] = bw.ReadUInt16();
                }
            }
        };

        class FIDEAHeader
        {
            public Char[] FileID;
            public Byte offset;
            public FIDEAHeader(Int64 filesize)
            {
                FileID = new Char[3];
                FileID[0] = 'X'; FileID[1] = 'C'; FileID[2] = 'F';
                offset = (Byte)(filesize % 8);  ///H[4] := Chr( Byte(FS Mod 8 ) );
            }
            public void write(BinaryWriter bw)
            {
                bw.Write(FileID);
                bw.Write(offset);
            }

            public void read(BinaryReader bw)
            {
                FileID = bw.ReadChars(3);
                offset = bw.ReadByte();
            }
        };

        UTkey128 StringToKey(string str)
        {
            UTkey128 result = new UTkey128();
            result.Item = new UInt16[_UTBlock128_Size];

            for (int i = 0; i <= 7; i++)
                result.Item[i] = UInt16.Parse(str.Substring((i) * 4, 4).ToString(), System.Globalization.NumberStyles.HexNumber);
            return result;

        }

        public int IDEAEncrypt(String infilename, String outfilename, String keystr, String errorStr)
        {
            UTkey128 EKey128 = new UTkey128(); EKey128.Item = new ushort[_UTBlock128_Size];
            EKey128 = StringToKey(keystr);
            UTkeyArray Keys = new UTkeyArray(); Keys.Item = new ushort[_UTkeyArray_Size];
            GenerateKeys(ref Keys, EKey128);
            int bufferSize = 1024 * 128;
            FileStream fin;
            try
            {
                fin = new FileStream(infilename, FileMode.Open, FileAccess.Read, FileShare.Read, bufferSize);
            }
            catch (Exception)
            { // can't open infile
              //errorStr = e.Message;
                return 1;
            }

            FileStream fout;
            try
            {
                fout = new FileStream(outfilename, FileMode.Create, FileAccess.ReadWrite, FileShare.None, bufferSize);
            }
            catch (Exception)
            { // can't open outfile
              //errorStr = e.Message;
                return 2;
            }

            BinaryWriter bwout = null;
            BinaryReader bwin = null; 

            try
            {
                // Initialise File
                Int64 fs = fin.Length;

                Int64 fs2 = fs;
                int fm = (int)fs % 8;
                // make header
                FIDEAHeader ID = new FIDEAHeader((int)fs);
                bwout = new BinaryWriter(fout);
                // save id
                ID.write(bwout);
                bwin = new BinaryReader(fin);
                UTBlock64 InBlock = new UTBlock64(); InBlock.Item = new ushort[_UTBlock64_Size];
                UTBlock64 OutBlock = new UTBlock64(); OutBlock.Item = new ushort[_UTBlock64_Size];
                MTBlock64 m = new MTBlock64(1);


                while (fs > 8)
                {
                    m.read(bwin);
                    InBlock.Item[0] = m.Item[0]; InBlock.Item[1] = m.Item[1]; InBlock.Item[2] = m.Item[2]; InBlock.Item[3] = m.Item[3];
                    EncryptBlock(ref InBlock, ref OutBlock, ref Keys);
                    m.Item[0] = OutBlock.Item[0]; m.Item[1] = OutBlock.Item[1]; m.Item[2] = OutBlock.Item[2]; m.Item[3] = OutBlock.Item[3];
                    m.write(bwout);
                    fs -= 8;
                }
                int tempitem = 0;
                while (fs > 1)
                {
                    InBlock.Item[tempitem] = bwin.ReadUInt16();
                    tempitem++;
                    fs -= 2;
                }

                if (fs == 1) { InBlock.Item[tempitem] = bwin.ReadByte(); }
                EncryptBlock(ref InBlock, ref OutBlock, ref Keys);
                m.Item[0] = OutBlock.Item[0]; m.Item[1] = OutBlock.Item[1]; m.Item[2] = OutBlock.Item[2]; m.Item[3] = OutBlock.Item[3];
                m.write(bwout);

            }
            finally
            {
                if (bwout != null) bwout.Close();
                if (fout != null) fout.Close();
                
                if (bwin != null) bwin.Close();
                if (fin != null) fin.Close();
            }


            return 0;
        }
        public int IDEADecrypt(String infilename, String outfilename, String keystr, String errorStr)
        {
            UTkey128 EKey128 = new UTkey128(); EKey128.Item = new ushort[_UTBlock128_Size];
            EKey128 = StringToKey(keystr);
            UTkeyArray Keys = new UTkeyArray(); Keys.Item = new ushort[_UTkeyArray_Size];
            GenerateDeKeys(ref Keys, EKey128);
            int bufferSize = 1024 * 16;
            FileStream fin;
            try
            {
                fin = new FileStream(infilename, FileMode.Open, FileAccess.Read, FileShare.Read, bufferSize);
            }
            catch (Exception)
            { // can't open infile
              //errorStr = e.Message;
                return 1;
            }

            FileStream fout;
            try
            {
                fout = new FileStream(outfilename, FileMode.Create, FileAccess.ReadWrite, FileShare.None, bufferSize);
            }
            catch (Exception)
            { // can't open outfile
              //errorStr = e.Message;
                return 2;
            }

            // Initialise File



            // make header
            FIDEAHeader ID = new FIDEAHeader(1);
            BinaryWriter bwout = new BinaryWriter(fout);
            BinaryReader bwin = new BinaryReader(fin);

            try
            {
                // save id
                ID.read(bwin);
                //fsize = fin->get_Length();
                Int64 fs = fin.Length - 4; //12 is Size of ID
                                           //Int64 fm = fs - (fin->Length-8+ID->offset) ;
                                           //fm = 8 - fm;
                Int64 fm = ID.offset;




                UTBlock64 InBlock = new UTBlock64(); InBlock.Item = new ushort[_UTBlock64_Size];
                UTBlock64 OutBlock = new UTBlock64(); OutBlock.Item = new ushort[_UTBlock64_Size];
                MTBlock64 m = new MTBlock64(1);

                while (fs > 8)
                {
                    m.read(bwin);
                    InBlock.Item[0] = m.Item[0]; InBlock.Item[1] = m.Item[1]; InBlock.Item[2] = m.Item[2]; InBlock.Item[3] = m.Item[3];
                    DecryptBlock(ref InBlock, ref OutBlock, ref Keys);
                    m.Item[0] = OutBlock.Item[0]; m.Item[1] = OutBlock.Item[1]; m.Item[2] = OutBlock.Item[2]; m.Item[3] = OutBlock.Item[3];
                    m.write(bwout);
                    fs -= 8;
                }
                if (fs == 8)
                {
                    m.read(bwin);
                    InBlock.Item[0] = m.Item[0]; InBlock.Item[1] = m.Item[1]; InBlock.Item[2] = m.Item[2]; InBlock.Item[3] = m.Item[3];
                    DecryptBlock(ref InBlock, ref OutBlock, ref Keys);
                    if (fm != 0)
                    {
                        int tempitem = 0;

                        while (fm > 1)
                        {
                            bwout.Write(OutBlock.Item[tempitem]);
                            tempitem++;
                            fm -= 2;
                        }
                        if (fm == 1)
                        {
                            Byte xx = 0;
                            xx = (Byte)((UInt16)OutBlock.Item[tempitem] & 0x00FF);
                            bwout.Write(xx);
                        }
                    }
                    else
                    {
                        m.Item[0] = OutBlock.Item[0]; m.Item[1] = OutBlock.Item[1]; m.Item[2] = OutBlock.Item[2]; m.Item[3] = OutBlock.Item[3];
                        m.write(bwout);
                    }


                }
            }
            finally
            {
                if (bwout != null) bwout.Close();
                if (fout != null) fout.Close();

                if (bwin != null) bwin.Close();
                if (fin != null) fin.Close();
            }




            return 0;
        }

        public int IDEAEncrypt(String infilename, String outfilename, String keystr, String errorStr, CancellationToken _cancellationToken)
        {
            UTkey128 EKey128 = new UTkey128(); EKey128.Item = new ushort[_UTBlock128_Size];
            EKey128 = StringToKey(keystr);
            UTkeyArray Keys = new UTkeyArray(); Keys.Item = new ushort[_UTkeyArray_Size];
            GenerateKeys(ref Keys, EKey128);
            int bufferSize = 1024 * 128;
            FileStream fin;
            try
            {
                fin = new FileStream(infilename, FileMode.Open, FileAccess.Read, FileShare.Read, bufferSize);
            }
            catch (Exception)
            { // can't open infile
              //errorStr = e.Message;
                return 1;
            }

            FileStream fout;
            try
            {
                fout = new FileStream(outfilename, FileMode.Create, FileAccess.ReadWrite, FileShare.None, bufferSize);
            }
            catch (Exception)
            { // can't open outfile
              //errorStr = e.Message;
                return 2;
            }

            BinaryWriter bwout = null;
            BinaryReader bwin = null;

            try
            {
                // Initialise File
                Int64 fs = fin.Length;

                Int64 fs2 = fs;
                int fm = (int)fs % 8;
                // make header
                FIDEAHeader ID = new FIDEAHeader((int)fs);
                bwout = new BinaryWriter(fout);
                // save id
                ID.write(bwout);
                bwin = new BinaryReader(fin);
                UTBlock64 InBlock = new UTBlock64(); InBlock.Item = new ushort[_UTBlock64_Size];
                UTBlock64 OutBlock = new UTBlock64(); OutBlock.Item = new ushort[_UTBlock64_Size];
                MTBlock64 m = new MTBlock64(1);


                while (fs > 8)
                {
                    m.read(bwin);
                    InBlock.Item[0] = m.Item[0]; InBlock.Item[1] = m.Item[1]; InBlock.Item[2] = m.Item[2]; InBlock.Item[3] = m.Item[3];
                    EncryptBlock(ref InBlock, ref OutBlock, ref Keys);
                    m.Item[0] = OutBlock.Item[0]; m.Item[1] = OutBlock.Item[1]; m.Item[2] = OutBlock.Item[2]; m.Item[3] = OutBlock.Item[3];
                    m.write(bwout);
                    fs -= 8;
                    if (_cancellationToken.IsCancellationRequested)
                        _cancellationToken.ThrowIfCancellationRequested();

                }
                int tempitem = 0;
                while (fs > 1)
                {
                    InBlock.Item[tempitem] = bwin.ReadUInt16();
                    tempitem++;
                    fs -= 2;
                }

                if (fs == 1) { InBlock.Item[tempitem] = bwin.ReadByte(); }
                EncryptBlock(ref InBlock, ref OutBlock, ref Keys);
                m.Item[0] = OutBlock.Item[0]; m.Item[1] = OutBlock.Item[1]; m.Item[2] = OutBlock.Item[2]; m.Item[3] = OutBlock.Item[3];
                m.write(bwout);

            }
            finally
            {
                if (bwout != null) bwout.Close();
                if (fout != null) fout.Close();

                if (bwin != null) bwin.Close();
                if (fin != null) fin.Close();
            }


            return 0;
        }
        public int IDEADecrypt(String infilename, String outfilename, String keystr, String errorStr, CancellationToken _cancellationToken)
        {
            UTkey128 EKey128 = new UTkey128(); EKey128.Item = new ushort[_UTBlock128_Size];
            EKey128 = StringToKey(keystr);
            UTkeyArray Keys = new UTkeyArray(); Keys.Item = new ushort[_UTkeyArray_Size];
            GenerateDeKeys(ref Keys, EKey128);
            int bufferSize = 1024 * 16;
            FileStream fin;
            try
            {
                fin = new FileStream(infilename, FileMode.Open, FileAccess.Read, FileShare.Read, bufferSize);
            }
            catch (Exception)
            { // can't open infile
              //errorStr = e.Message;
                return 1;
            }

            FileStream fout;
            try
            {
                fout = new FileStream(outfilename, FileMode.Create, FileAccess.ReadWrite, FileShare.None, bufferSize);
            }
            catch (Exception)
            { // can't open outfile
              //errorStr = e.Message;
                return 2;
            }

            // Initialise File



            // make header
            FIDEAHeader ID = new FIDEAHeader(1);
            BinaryWriter bwout = new BinaryWriter(fout);
            BinaryReader bwin = new BinaryReader(fin);

            try
            {
                // save id
                ID.read(bwin);
                //fsize = fin->get_Length();
                Int64 fs = fin.Length - 4; //12 is Size of ID
                                           //Int64 fm = fs - (fin->Length-8+ID->offset) ;
                                           //fm = 8 - fm;
                Int64 fm = ID.offset;




                UTBlock64 InBlock = new UTBlock64(); InBlock.Item = new ushort[_UTBlock64_Size];
                UTBlock64 OutBlock = new UTBlock64(); OutBlock.Item = new ushort[_UTBlock64_Size];
                MTBlock64 m = new MTBlock64(1);

                while (fs > 8)
                {
                    m.read(bwin);
                    InBlock.Item[0] = m.Item[0]; InBlock.Item[1] = m.Item[1]; InBlock.Item[2] = m.Item[2]; InBlock.Item[3] = m.Item[3];
                    DecryptBlock(ref InBlock, ref OutBlock, ref Keys);
                    m.Item[0] = OutBlock.Item[0]; m.Item[1] = OutBlock.Item[1]; m.Item[2] = OutBlock.Item[2]; m.Item[3] = OutBlock.Item[3];
                    m.write(bwout);
                    fs -= 8;
                    if (_cancellationToken.IsCancellationRequested)
                        _cancellationToken.ThrowIfCancellationRequested();

                }
                if (fs == 8)
                {
                    m.read(bwin);
                    InBlock.Item[0] = m.Item[0]; InBlock.Item[1] = m.Item[1]; InBlock.Item[2] = m.Item[2]; InBlock.Item[3] = m.Item[3];
                    DecryptBlock(ref InBlock, ref OutBlock, ref Keys);
                    if (fm != 0)
                    {
                        int tempitem = 0;

                        while (fm > 1)
                        {
                            bwout.Write(OutBlock.Item[tempitem]);
                            tempitem++;
                            fm -= 2;
                        }
                        if (fm == 1)
                        {
                            Byte xx = 0;
                            xx = (Byte)((UInt16)OutBlock.Item[tempitem] & 0x00FF);
                            bwout.Write(xx);
                        }
                    }
                    else
                    {
                        m.Item[0] = OutBlock.Item[0]; m.Item[1] = OutBlock.Item[1]; m.Item[2] = OutBlock.Item[2]; m.Item[3] = OutBlock.Item[3];
                        m.write(bwout);
                    }


                }
            }
            finally
            {
                if (bwout != null) bwout.Close();
                if (fout != null) fout.Close();

                if (bwin != null) bwin.Close();
                if (fin != null) fin.Close();
            }




            return 0;
        }

        public byte[] IDEAEncrypt(byte[] inputArray, String keystr)
        {
            UTkey128 EKey128 = new UTkey128(); EKey128.Item = new ushort[_UTBlock128_Size];
            EKey128 = StringToKey(keystr);
            UTkeyArray Keys = new UTkeyArray(); Keys.Item = new ushort[_UTkeyArray_Size];
            GenerateKeys(ref Keys, EKey128);

            byte[] result;

            try
            {
                using (MemoryStream memInputStream = new MemoryStream(inputArray))
                using (MemoryStream memOutputStrem = new MemoryStream())
                {
                    // Initialise File
                    Int64 fs = memInputStream.Length;

                    Int64 fs2 = fs;
                    int fm = (int)fs % 8;
                    // make header
                    FIDEAHeader ID = new FIDEAHeader((int)fs);
                    BinaryWriter bwout = new BinaryWriter(memOutputStrem);
                    // save id
                    ID.write(bwout);
                    BinaryReader bwin = new BinaryReader(memInputStream);
                    UTBlock64 InBlock = new UTBlock64(); InBlock.Item = new ushort[_UTBlock64_Size];
                    UTBlock64 OutBlock = new UTBlock64(); OutBlock.Item = new ushort[_UTBlock64_Size];
                    MTBlock64 m = new MTBlock64(1);


                    while (fs > 8)
                    {
                        m.read(bwin);
                        m.Item.CopyTo(InBlock.Item, 0);
                        //InBlock.Item[0] = m.Item[0]; InBlock.Item[1] = m.Item[1]; InBlock.Item[2] = m.Item[2]; InBlock.Item[3] = m.Item[3];
                        EncryptBlock(ref InBlock, ref OutBlock, ref Keys);
                        m.Item[0] = OutBlock.Item[0]; m.Item[1] = OutBlock.Item[1]; m.Item[2] = OutBlock.Item[2]; m.Item[3] = OutBlock.Item[3];
                        m.write(bwout);
                        fs -= 8;
                    }
                    int tempitem = 0;
                    while (fs > 1)
                    {
                        InBlock.Item[tempitem] = bwin.ReadUInt16();
                        tempitem++;
                        fs -= 2;
                    }

                    if (fs == 1) { InBlock.Item[tempitem] = bwin.ReadByte(); }
                    EncryptBlock(ref InBlock, ref OutBlock, ref Keys);
                    m.Item[0] = OutBlock.Item[0]; m.Item[1] = OutBlock.Item[1]; m.Item[2] = OutBlock.Item[2]; m.Item[3] = OutBlock.Item[3];
                    m.write(bwout);

                    result = memOutputStrem.ToArray();


                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }


            return result;
        }
        public byte[] IDEADecrypt(byte[] inputArray, String keystr)
        {
            UTkey128 EKey128 = new UTkey128(); EKey128.Item = new ushort[_UTBlock128_Size];
            EKey128 = StringToKey(keystr);
            UTkeyArray Keys = new UTkeyArray(); Keys.Item = new ushort[_UTkeyArray_Size];
            GenerateDeKeys(ref Keys, EKey128);

            byte[] result = null;
            UTBlock64 InBlock = new UTBlock64();
            UTBlock64 OutBlock = new UTBlock64();
            InBlock.Item = new ushort[_UTBlock64_Size];
            OutBlock.Item = new ushort[_UTBlock64_Size];
            MTBlock64 m = new MTBlock64(1);


            try
            {
                using (MemoryStream memInputStream = new MemoryStream(inputArray))
                using (MemoryStream memOutputStrem = new MemoryStream())
                {
                    // make header
                    FIDEAHeader ID = new FIDEAHeader(1);
                    BinaryWriter bwout = new BinaryWriter(memOutputStrem);
                    BinaryReader bwin = new BinaryReader(memInputStream);
                    // save id
                    ID.read(bwin);
                    //fsize = fin->get_Length();
                    Int64 fs = memInputStream.Length - 4; //12 is Size of ID
                                                          //Int64 fm = fs - (fin->Length-8+ID->offset) ;
                                                          //fm = 8 - fm;
                    Int64 fm = ID.offset;

                    while (fs > 8)
                    {
                        m.read(bwin);
                        InBlock.Item[0] = m.Item[0]; InBlock.Item[1] = m.Item[1]; InBlock.Item[2] = m.Item[2]; InBlock.Item[3] = m.Item[3];
                        DecryptBlock(ref InBlock, ref OutBlock, ref Keys);
                        
                        m.Item[0] = OutBlock.Item[0]; m.Item[1] = OutBlock.Item[1]; m.Item[2] = OutBlock.Item[2]; m.Item[3] = OutBlock.Item[3];
                        m.write(bwout);
                        fs -= 8;
                    }
                    if (fs == 8)
                    {
                        m.read(bwin);
                        InBlock.Item[0] = m.Item[0]; InBlock.Item[1] = m.Item[1]; InBlock.Item[2] = m.Item[2]; InBlock.Item[3] = m.Item[3];
                        DecryptBlock(ref InBlock, ref OutBlock, ref Keys);
                        if (fm != 0)
                        {
                            int tempitem = 0;

                            while (fm > 1)
                            {
                                bwout.Write(OutBlock.Item[tempitem]);
                                tempitem++;
                                fm -= 2;
                            }
                            if (fm == 1)
                            {
                                Byte xx = 0;
                                xx = (Byte)((UInt16)OutBlock.Item[tempitem] & 0x00FF);
                                bwout.Write(xx);
                            }
                        }
                        else
                        {
                            m.Item[0] = OutBlock.Item[0]; m.Item[1] = OutBlock.Item[1]; m.Item[2] = OutBlock.Item[2]; m.Item[3] = OutBlock.Item[3];
                            m.write(bwout);
                        }


                    }

                    result = memOutputStrem.ToArray();
                }


            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }


            return result;
        }


        public void IDEAEncryptV2(String infilename, String outfilename, String keystr, String errorStr)
        {
            UTkey128 EKey128 = new UTkey128(); EKey128.Item = new ushort[_UTBlock128_Size];
            EKey128 = StringToKey(keystr);
            UTkeyArray Keys = new UTkeyArray(); Keys.Item = new ushort[_UTkeyArray_Size];
            GenerateKeys(ref Keys, EKey128);
            int bufferSize = 1024 * 64;

            using (FileStream fin = new FileStream(infilename, FileMode.Open, FileAccess.Read, FileShare.Read, bufferSize))
            using (BinaryReader bwin = new BinaryReader(fin))
            using (FileStream fout = new FileStream(outfilename, FileMode.Create, FileAccess.ReadWrite, FileShare.None, bufferSize))
            using (BinaryWriter bwout = new BinaryWriter(fout))
            {

                // Initialise File
                Int64 fs = fin.Length;

                Int64 fs2 = fs;
                int fm = (int)fs % 8;
                // make header
                FIDEAHeader ID = new FIDEAHeader((int)fs);
                // save id
                ID.write(bwout);
                UTBlock64 InBlock = new UTBlock64(); InBlock.Item = new ushort[_UTBlock64_Size];
                UTBlock64 OutBlock = new UTBlock64(); OutBlock.Item = new ushort[_UTBlock64_Size];
                MTBlock64 m = new MTBlock64(1);


                while (fs > 8)
                {
                    m.read(bwin);
                    InBlock.Item[0] = m.Item[0]; InBlock.Item[1] = m.Item[1]; InBlock.Item[2] = m.Item[2]; InBlock.Item[3] = m.Item[3];
                    EncryptBlock(ref InBlock, ref OutBlock, ref Keys);
                    m.Item[0] = OutBlock.Item[0]; m.Item[1] = OutBlock.Item[1]; m.Item[2] = OutBlock.Item[2]; m.Item[3] = OutBlock.Item[3];
                    m.write(bwout);
                    fs -= 8;
                }
                int tempitem = 0;
                while (fs > 1)
                {
                    InBlock.Item[tempitem] = bwin.ReadUInt16();
                    tempitem++;
                    fs -= 2;
                }

                if (fs == 1) { InBlock.Item[tempitem] = bwin.ReadByte(); }
                EncryptBlock(ref InBlock, ref OutBlock, ref Keys);
                m.Item[0] = OutBlock.Item[0]; m.Item[1] = OutBlock.Item[1]; m.Item[2] = OutBlock.Item[2]; m.Item[3] = OutBlock.Item[3];
                m.write(bwout);

            }
            


            return;
        }

    }

}

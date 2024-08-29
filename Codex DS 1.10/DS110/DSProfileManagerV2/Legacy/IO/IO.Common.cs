using ILG.Codex.CodexR4;
using ILG.Codex.Cryptography;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodexR4.Operations.Update.IO
{
    public class CodexUpdateIOCommon : ICodexUpdateIOCommon
    {
        protected string _TemporaryDir;

        public CodexUpdateIOCommon(String TempDirectory)
        {
            _TemporaryDir = TempDirectory;
        }

        protected string FilterString(string str)
        {
            StringBuilder S = new StringBuilder("");
            for (int i = 0; i <= str.Length - 1; i++)
            {
                if (str[i] >= ' ') S.Append(str[i]);
                if (str[i] == '\n') S.Append(' ');
            }

            return S.ToString();
        }

        protected void GenerateCUFFile(string OutoutPath, UpdateCheckData data,
                                     string Filename_app_zip,
                                     string Filename_app_xml,
                                     string CUFKey,
                                     string FileNamePrefix)
        {
            CodexZip.Zip(Path.Combine(_TemporaryDir, Filename_app_zip), Filename_app_xml, Path.Combine(_TemporaryDir, Filename_app_xml));
            var c = new CodexCryptoIDEAEncryption();

            string FullFilename_app_enc = Path.ChangeExtension(Path.Combine(_TemporaryDir, Filename_app_zip), "zzz");

            c.IDEAEncrypt(Path.Combine(_TemporaryDir, Filename_app_zip),
                          FullFilename_app_enc,
                          CUFKey, "");

            string FullFilename_app_xml = Path.Combine(_TemporaryDir, Filename_app_xml);
            string FullFilename_app_xml2 = Path.ChangeExtension(FullFilename_app_xml, "xml2");

            CodexFile.DeleteIfExists(FullFilename_app_xml);
            CodexFile.DeleteIfExists(FullFilename_app_xml2);

            File.Delete(Path.Combine(_TemporaryDir, Filename_app_zip));

            CUFHeader ch = new CUFHeader(3, (ulong)data.StartFrom, (ulong)data.EndTo, (ulong)data.Quantity, DateTime.Now);
            byte[] buffer;
            FileStream fs = new FileStream(FullFilename_app_enc, FileMode.Open, FileAccess.Read);
            buffer = new byte[fs.Length];
            int buffersize = (int)fs.Length;
            fs.Read(buffer, 0, buffersize);
            fs.Close();
            string fname = FileNamePrefix + "[" + data.StartFrom.ToString() + "-" + data.EndTo.ToString() + "].CUF";

            string ffullname = Path.Combine(OutoutPath, fname);
            int inx = 1;

            while (File.Exists(ffullname) == true)
            {
                ffullname = Path.Combine(OutoutPath, FileNamePrefix + "[" + data.StartFrom.ToString() + "-" + data.EndTo.ToString() + "]_" + inx.ToString() + ".CUF");
                inx++;
            }

            fs = new FileStream(ffullname, FileMode.CreateNew, FileAccess.Write);
            BinaryWriter bw = new BinaryWriter(fs);


            ch.write(bw);
            bw.Write(buffer, 0, buffersize);
            bw.Close();
            fs.Close();

            File.Delete(FullFilename_app_enc);
        }


        protected int PickCUFFile(string FileName,
                                string CUFKey,
                                string Filename_app_xml)
        {

            CodexCryptoIDEAEncryption c = new CodexCryptoIDEAEncryption();
            FileStream fs;
            if (File.Exists(FileName) == false) { return 1; }
            fs = new FileStream(FileName, FileMode.Open, FileAccess.Read);

            int res = 2;

            // Pick File
            byte[] buffer = new byte[1];
            int l = 1;
            int o = 0;
            try
            {
                l = (int)fs.Length - CUFHeader.Lentgh();
                o = CUFHeader.Lentgh();
                buffer = new byte[fs.Length - CUFHeader.Lentgh()];
                fs.Read(buffer, 0, CUFHeader.Lentgh());
                fs.Read(buffer, 0, l);
                res = 0;

            }
            catch //(System.Exception ex)
            { res = 3; }
            finally
            {
                fs.Close();
            }
            if (res != 0) return res;

            string CUFPath = _TemporaryDir;
            string CurDir = _TemporaryDir;

            // Decript File
            String FilenameEnc = Path.Combine(_TemporaryDir, "app.enc");

            CodexFile.DeleteIfExists(FilenameEnc);

            fs = new FileStream(FilenameEnc, FileMode.CreateNew, FileAccess.Write);
            fs.Write(buffer, 0, l);
            fs.Close();

            String FilenameZip = Path.Combine(_TemporaryDir, "app.zip");

            CodexFile.DeleteIfExists(FilenameZip);

            try
            {
                c.IDEADecrypt(FilenameEnc,
                              FilenameZip,
                              CUFKey, "");
            }
            catch //(System.Exception ex)
            { res = 4; }
            finally
            {
                CodexFile.DeleteIfExists(FilenameEnc);
            }
            if (res != 0) return res;



            // Unzip That File

        

            try
            {
                CodexZip.UnZip(Path.Combine(_TemporaryDir, "app.Zip"), Filename_app_xml, Path.Combine(_TemporaryDir, Filename_app_xml));
            }
            catch //(System.Exception ex)
            { res = 5; }
            


            if (res != 0) return res;
            CodexFile.DeleteIfExists(Path.Combine(_TemporaryDir, "app.zip"));

            return 0;


        }



     
     
    }
}

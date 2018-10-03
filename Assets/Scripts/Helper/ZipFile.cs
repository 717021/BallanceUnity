using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using ICSharpCode.SharpZipLib.Zip;

namespace Helper
{
    public class ZipFileReader : IDisposable
    {
        public ZipFileReader(string url)
        {
            if (string.IsNullOrEmpty(url))
                throw new Exception("ZipFile url is null !");
            Url = url;
        }

        public string Url { get; private set; }
        public string LastError { get; private set; }

        private ZipEntry zip = null;
        private ZipInputStream zipInStream = null;

        public ZipInputStream ZipInputStream { get { return zipInStream; } }

        public bool Load()
        {
            if (zipInStream == null)
            {
                if (!File.Exists(Url))
                {
                    LastError = "File not found !";
                    return false;
                }
                Stream stream = File.OpenRead(Url);
                if (stream == null)
                {
                    LastError = "Failed open file !";
                    return false;
                }
                //读取文件流到zipInputStream  
                zipInStream = new ZipInputStream(stream);
                return true;
            }
            return false;
        }
        public bool GetFile(string path, MemoryStream memoryStream)
        {
            LastError = "";
            bool finded = false;
            //循环读取Zip目录下的所有文件  
            while ((zip = zipInStream.GetNextEntry()) != null)
            {
                if (zip.Name == path)
                {
                    finded = true;
                    break;
                }
            }
            if (finded)
            {
                int size = 2048;
                byte[] data = new byte[2048];
                //每次读取2MB  直到把这个内容读完  
                while (true)
                {
                    size = zipInStream.Read(data, 0, data.Length);
                    //小于0， 也就读完了当前的流  
                    if (size > 0)
                    {
                        memoryStream.Write(data, 0, data.Length);
                        return true;
                    }
                    else
                    {
                        break;
                    }
                }
            }
            else LastError = "ZipFile: " + Url + " not find file : " + path;
            return false;
        }
        public string GetText(string path)
        {
            MemoryStream ms = new MemoryStream();
            if (GetFile(path, ms))
            {
                byte[] b = ms.ToArray();
                return Encoding.UTF8.GetString(b, 0, b.Length);
            }
            return null;
        }

        public void Dispose()
        {
            if (zipInStream != null)
            {
                zipInStream.Close();
                zipInStream = null;
            }
        }
    }
}
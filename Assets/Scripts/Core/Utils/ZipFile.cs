using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using ICSharpCode.SharpZipLib.Zip;

/*
 * zip读取类 
 *     coyright c df 2018
 *     
 * 2018.7.2   df
 * 2018.10.3  df checked ok!
 */

namespace Ballance2.Utils
{
    /// <summary>
    /// Zip 读取帮助类（对 <see cref="ICSharpCode.SharpZipLib.Zip.ZipInputStream"/> 的封装）
    /// </summary>
    public class ZipFileReader : IDisposable
    {
        /// <summary>
        /// 使用指定Zip文件的路径初始化 <see cref="ZipFileReader"/> 的新实例
        /// </summary>
        /// <param name="url">指定Zip文件的路径</param>
        public ZipFileReader(string url)
        {
            if (string.IsNullOrEmpty(url))
                throw new Exception("ZipFile url is null !");
            Url = url;
        }

        /// <summary>
        /// 当前Zip文件的路径
        /// </summary>
        public string Url { get; private set; }
        /// <summary>
        /// 上次读取的错误信息
        /// </summary>
        public string LastError { get; private set; }

        private ZipEntry zip = null;
        private ZipInputStream zipInStream = null;

        /// <summary>
        /// Zip流
        /// </summary>
        public ZipInputStream ZipInputStream { get { return zipInStream; } }

        /// <summary>
        /// 加载文件流，必须加载以后才能读取
        /// </summary>
        /// <returns>返回是否成功，错误请读取 <see cref="LastError"/> 查看详细信息</returns>
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
            else
            {
                LastError = "File alreday opened !";
                return false;
            }
        }

        /// <summary>
        /// 读取Zip文件中的指定文件并写入 <see cref="memoryStream"/> 指定的 <see cref="MemoryStream"/>
        /// </summary>
        /// <param name="path">要读取的文件路径或名称</param>
        /// <param name="memoryStream">指定要写入的 <see cref="MemoryStream"/></param>
        /// <returns>返回是否成功，错误请读取 <see cref="LastError"/> 查看详细信息</returns>
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
                LastError = "Success";
            }
            else LastError = "ZipFile: " + Url + " not find file : " + path;
            return false;
        }
        /// <summary>
        /// 读取Zip文件中的 txt 文件并直接返回文本
        /// </summary>
        /// <param name="path">要读取的txt文件路径或名称（如果没有.txt会自动添加.txt，前面加上noendcheck:则不会添加.txt）</param>
        /// <returns>返回txt 文件的文本，返回null为错误，请读取 <see cref="LastError"/> 查看详细信息</returns>
        public string GetText(string path)
        {
            if (!path.EndsWith(".txt") && !path.StartsWith("noendcheck:"))
                path += ".txt";
            MemoryStream ms = new MemoryStream();
            if (GetFile(path, ms))
            {
                byte[] b = ms.ToArray();
                try
                {
                    string s = Encoding.UTF8.GetString(b, 0, b.Length);
                    LastError = "Success";
                    return s;
                }
                catch(Exception e)
                {
                    LastError = e.ToString();
                    return null;
                }
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
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Ballance2.Utils
{

    /*
     * 代码说明：Ballance专用描述文件解析类
     * 
     * 语法：(均为英文输入法的字符)
     *     属性名=属性值1;属性值2;属性值3...
     *     属性名=属性值1:属性值1子2:属性值1子3;属性值2
     *     [注释]
     *     :注释
     * 
     * 2018.5.1   df created coptright c 2018
     * 2018.7.1   df
     * 2018.10.3 df 
     */

    /// <summary>
    /// Ballance专用描述文件解析类
    /// </summary>
    public class BFSReader : IDisposable
    {
        /// <summary>
        /// 初始化 <see cref="BFSReader"/> 的新实例
        /// </summary>
        public BFSReader()
        {

        }
        /// <summary>
        /// 使用初需要解析的文字来始化 <see cref="BFSReader"/> 的新实例
        /// </summary>
        /// <param name="str">需要解析的文字</param>
        public BFSReader(string str)
        {
            if (!string.IsNullOrEmpty(str))
                AnalysisString(str);
        }
        /// <summary>
        /// 使用初需要解析的文本资源 <see cref="TextAsset"/> 来始化 <see cref="BFSReader"/> 的新实例
        /// </summary>
        /// <param name="txt">需要解析的 TextAsset 。</param>
        public BFSReader(TextAsset txt)
        {
            if (txt != null)
                if (!string.IsNullOrEmpty(txt.text))
                    AnalysisString(txt.text);
        }
        /// <summary>
        /// 释放（IDisposable）
        /// </summary>
        public void Dispose()
        {
            dictionaryProps.Clear();
            dictionaryProps = null;
        }

        /// <summary>
        /// 获取存放属性的字典。
        /// </summary>
        public Dictionary<string, string> Props { get { return dictionaryProps; } }
        /// <summary>
        /// 获取存放组的字典。
        /// </summary>
        public Dictionary<string, List<String>> Blocks { get { return dictionaryBlocks; } }

        private Dictionary<string, List<String>> dictionaryBlocks = new Dictionary<string, List<String>>();
        private Dictionary<string, string> dictionaryProps = new Dictionary<string, string>();
        private List<string> lines = new List<string>();
        private bool isReadBlock = false;
        private List<String> readBlock = null;

        protected void AnalysisString(string str)
        {
            //按行（\n）读取
            string[] r = str.Split('\n');
            for (int i = 0; i < r.Length; i++)
            {
                if (r[i].Contains("\r")) r[i] = r[i].Replace("\r", "");
                if (r[i] != "")
                {
                    if (!r[i].StartsWith(":"))
                        if (!r[i].StartsWith("["))
                        {
                            if (isReadBlock)
                                lines.Add(r[i]);
                            else if (readBlock != null)
                                readBlock.Add(r[i]);
                            else
                            {
                                //解析 props
                                if (r[i].Contains("="))
                                {
                                    string[] r1 = r[i].Split('=');
                                    if (!dictionaryProps.ContainsKey(r1[0]))
                                        dictionaryProps.Add(r1[0], r1[1]);
                                    else dictionaryProps[r1[0]] = dictionaryProps[r1[0]] + ";" + r1[1];
                                }
                                /*else if (!r[i].Contains(";"))
                                {
                                    string[] r2 = r[i].Split('\n');
                                    for (int i1 = 0; i1 < r2.Length; i1++)
                                    {
                                        if (r2[i1] != "")
                                        {
                                            if (r2[i1].Contains("="))
                                            {
                                                string[] r3 = r2[i1].Split('=');
                                                if (!dictionaryProps.ContainsKey(r3[0]))
                                                    dictionaryProps.Add(r3[0], r3[1]);
                                            }
                                        }
                                    }
                                }*/
                            }
                        }
                        else
                        {
                            string astr = r[i].Substring(1, r[i].Length - 2);
                            if (astr == "LINEREAD")
                                isReadBlock = true;
                            else if (astr == "ENDLINEREAD")
                                isReadBlock = false;
                            else if (astr.StartsWith("START:"))
                            {
                                readBlock = new List<string>();
                                dictionaryBlocks.Add(astr.Remove(0, 6), readBlock);
                            }
                            else if (astr.StartsWith("END:"))
                                readBlock = null;
                        }
                }

            }
        }

        /// <summary>
        /// 查询文档中是否有定义某个属性。
        /// </summary>
        /// <param name="propname">属性名字。</param>
        /// <returns></returns>
        public bool HasProperty(string propname)
        {
            return dictionaryProps.ContainsKey(propname);
        }
        /// <summary>
        /// 获取某个属性的值。
        /// </summary>
        /// <param name="propname">属性名字。</param>
        /// <returns></returns>
        public string GetPropertyValue(string propname)
        {
            if (dictionaryProps.ContainsKey(propname))
                return dictionaryProps[propname];
            return null;
        }

        /// <summary>
        /// 获取属性值的分割属性。（;分隔的）
        /// </summary>
        /// <param name="propValue">属性值</param>
        /// <returns></returns>
        public string[] GetPropertyValueChildValue(string propValue)
        {
            if (!propValue.Contains(";"))
                return new string[] { propValue };
            return propValue.Split(';');
        }
        /// <summary>
        /// 获取属性值的分割属性2。（:分隔的）
        /// </summary>
        /// <param name="propValue">属性值</param>
        /// <returns></returns>
        public string[] GetPropertyValueChildValue2(string propValue)
        {
            if (!propValue.Contains(":"))
                return new string[] { propValue };
            return propValue.Split(':');
        }

        public string[] GetLineAllItems()
        {
            return lines.ToArray();
        }
        /// <summary>
        /// 获取行组所有项目
        /// </summary>
        /// <param name="blockName">行组名称</param>
        /// <returns>所有项目</returns>
        public string[] GetBlockAllItems(string blockName)
        {
            if (dictionaryBlocks.ContainsKey(blockName))
                return dictionaryBlocks[blockName].ToArray();
            return null;
        }
    }

}
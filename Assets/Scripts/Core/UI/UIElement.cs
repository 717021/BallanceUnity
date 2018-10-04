using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Ballance2.UI
{
    /// <summary>
    /// UI 布局元素
    /// </summary>
    public class UIElement : MonoBehaviour
    {
        private void Start()
        {
            rectTransform = GetComponent<RectTransform>();
            OnInit();
        }

        /// <summary>
        /// 初始化事件
        /// </summary>
        public virtual void OnInit() { }

        private RectTransform rectTransform;

        /// <summary>
        /// 获取 RectTransform
        /// </summary>
        public RectTransform RectTransform
        {
            get
            {
                if(rectTransform==null)
                    rectTransform = GetComponent<RectTransform>();
                return rectTransform;
            }
        }
        /// <summary>
        /// 默认显示
        /// </summary>
        public virtual void Show()
        {
            gameObject.SetActive(true);
        }
        /// <summary>
        /// 默认隐藏
        /// </summary>
        public virtual void Hide()
        {
            gameObject.SetActive(false);
        }
        /// <summary>
        /// 默认获取是否显示
        /// </summary>
        /// <returns></returns>
        public virtual bool IsShowed()
        {
            return gameObject.activeSelf;
        }

        /// <summary>
        /// 布局间隔
        /// </summary>
        public int SpaceStart { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 默认初始化参数
        /// </summary>
        /// <param name="initstr"></param>
        public virtual void StartSet(string initstr)
        {

        }
    }
}

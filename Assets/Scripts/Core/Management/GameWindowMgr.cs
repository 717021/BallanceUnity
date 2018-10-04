using Ballance2.UI.WindowUI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ballance2
{
    /// <summary>
    /// 窗口管理器
    /// </summary>
    public class GameWindowMgr : MonoBehaviour, IGameBasePart
    {
        private List<UIWindow> allWindow = new List<UIWindow>();

        private UIWindow activeWindow = null;

        public GameBulider GameBulider { get; set; }
        public GameObject perfabWindow;
        public GameObject uiHost;
        public void ExitGameClear()
        {
            allWindow.Clear();
            allWindow = null;
        }

        void Start()
        {

        }

        /// <summary>
        /// 创建一个新窗口
        /// </summary>
        /// <param name="title">新窗口的标题</param>
        /// <param name="content">新窗口的内容</param>
        /// <param name="show">是否立即显示窗口</param>
        /// <returns></returns>
        public UIWindow CreateWindow(string title, RectTransform content, bool show = false)
        {
            GameObject newWindow = Instantiate(perfabWindow);
            UIWindow newWindowCls = newWindow.GetComponent<UIWindow>();

            newWindow.transform.SetParent(uiHost.transform);

            content.gameObject.transform.SetParent(newWindowCls.hostRectTransform.gameObject.transform);
            content.anchorMin = Vector2.zero;
            content.anchorMax = new Vector2(1, 1);
            content.offsetMax = Vector2.zero;
            content.offsetMin = Vector2.zero;

            if (show) newWindowCls.Show();

            newWindowCls.clientRectTransform = content;

            allWindow.Add(newWindowCls);

            return newWindowCls;
        }
        /// <summary>
        /// 创建一个新窗口
        /// </summary>
        /// <param name="title">新窗口的标题</param>
        /// <param name="content">新窗口的内容</param>
        /// <param name="offsetMax">right,top</param>
        /// <param name="offsetMin">left,buttom</param>
        /// <param name="show">是否立即显示窗口</param>
        /// <returns></returns>
        public UIWindow CreateWindow(string title, RectTransform content, Vector2 offsetMax, Vector2 offsetMin, bool show = false)
        {
            GameObject newWindow = Instantiate(perfabWindow);
            UIWindow newWindowCls = newWindow.GetComponent<UIWindow>();

            content.gameObject.transform.SetParent(newWindowCls.hostRectTransform.gameObject.transform);
            content.offsetMax = offsetMax;
            content.anchorMin = offsetMin;

            newWindowCls.clientRectTransform = content;

            if (show) newWindowCls.Show();

            allWindow.Add(newWindowCls);

            return newWindowCls;
        }
        /// <summary>
        /// 释放窗口（由 <see cref="UIWindow.Close"/> 自动调用）
        /// </summary>
        /// <param name="w">窗口</param>
        public void DestroyWindow(UIWindow w)
        {
            if (allWindow.Contains(w))
                allWindow.Remove(w);
            Destroy(w.gameObject);
        }
        /// <summary>
        /// 激活窗口
        /// </summary>
        /// <param name="w">窗口</param>
        public void ActiveWindow(UIWindow w)
        {
            if (w != activeWindow)
            {
                w.gameObject.transform.SetAsLastSibling();
                activeWindow = w;
            }
        }
    }
}

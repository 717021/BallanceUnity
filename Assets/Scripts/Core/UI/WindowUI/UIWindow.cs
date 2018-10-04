using Ballance2.UI.Utils;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Ballance2.UI.WindowUI
{
    /// <summary>
    /// UI 窗口
    /// </summary>
    public class UIWindow : MonoBehaviour
    {
        public DUIDragControl dragControl;
        public GameObject closeButton;
        public Text titleText;
        public RectTransform hostRectTransform;
        public RectTransform thisRectTransform;

        private GameWindowMgr wm = null;

        /// <summary>
        /// 获取或设置窗口是否可以拖动
        /// </summary>
        public bool canDrag { get { return dragControl.enabled; } set { dragControl.enabled = value; } }
        /// <summary>
        /// 获取或设置窗口标题
        /// </summary>
        public string title { get { return titleText.text; } set { titleText.text = value; } }
        /// <summary>
        /// 获取或设置窗口是否可以关闭
        /// </summary>
        public bool canClose { get { return closeButton.activeSelf; } set { closeButton.SetActive(value); } }
        /// <summary>
        /// 获取或设置窗口是否显示
        /// </summary>
        public bool isVisible { get { return gameObject.activeSelf; } set { if (value) Show(); else Hide(); } }

        /// <summary>
        /// 设置客户区
        /// </summary>
        public RectTransform clientRectTransform;

        /// <summary>
        /// 关闭窗口
        /// </summary>
        public void Close()
        {
            Hide();
            wm.DestroyWindow(this);
        }
        /// <summary>
        /// 显示窗口
        /// </summary>
        public void Show()
        {
            gameObject.SetActive(true);
            Active();
        }
        /// <summary>
        /// 在指定坐标显示窗口
        /// </summary>
        /// <param name="position">窗口需要显示的坐标</param>
        public void Show(Vector2 position)
        {
            Show();
            thisRectTransform.anchoredPosition = position;
        }
        /// <summary>
        /// 隐藏窗口
        /// </summary>
        public void Hide()
        {
            gameObject.SetActive(false);
        }
        /// <summary>
        /// 激活窗口
        /// </summary>
        public void Active()
        {
            wm.ActiveWindow(this);
        }

        void Start()
        {
            wm = GameBulider.GetGameService<GameWindowMgr>(GameServices.GameWindowMgr);
        }
        private void OnDestroy()
        {
            wm = null;
        }
    }
}

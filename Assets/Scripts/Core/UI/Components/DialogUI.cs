using Ballance2.UI.Utils;
using UnityEngine;
using UnityEngine.UI;

/*
 * 游戏通用 对话框（2个或三个按钮的对话框）管理脚本
 */

namespace Ballance2.UI.Components
{
    /// <summary>
    /// 表示对话框返回值
    /// </summary>
    public enum DialogResult
    {
        /// <summary>
        /// 没有
        /// </summary>
        None,
        /// <summary>
        /// 表示确定按钮（按钮1）被按下
        /// </summary>
        OK,
        /// <summary>
        /// 表示取消按钮（按钮2）被按下
        /// </summary>
        Cancel,
        /// <summary>
        /// 表示第三个按钮被按下
        /// </summary>
        Third
    }
    public class DialogUI : MonoBehaviour
    {
        void Start()
        {
            EventTriggerListener.Get(BtnOK.gameObject).onClick = BtnOK_onClick;
            EventTriggerListener.Get(BtnCancel.gameObject).onClick = BtnCancel_onClick;
            if (TextBtnThird != null) EventTriggerListener.Get(TextBtnThird.gameObject).onClick = BtnTird_onClick;
        }

        public delegate void DialogCallBack(DialogResult r);

        public Text TextTitle;
        public Text TextText;
        public Text TextBtnOK;
        public Text TextBtnCancel;
        public Text TextBtnThird;
        public Button BtnOK;
        public Button BtnCancel;
        public Button BtnClose;
        public Button BtnThird;

        private DialogCallBack c;

        public void Set(string title, string text, string btnoktext, string btncanceltext, string btnthird)
        {
            TextTitle.text = title;
            TextText.text = text;
            TextBtnOK.text = btnoktext;
            TextBtnCancel.text = btncanceltext;
            if (TextBtnThird != null) TextBtnThird.text = btnthird;
            if (btnoktext == "")
                BtnOK.gameObject.SetActive(false);
            else BtnOK.gameObject.SetActive(true);
            if (btncanceltext == "")
            {
                BtnCancel.gameObject.SetActive(false);
                BtnClose.gameObject.SetActive(false);
            }
            else BtnCancel.gameObject.SetActive(true);
            if (btnthird == "" && TextBtnThird != null)
                BtnThird.gameObject.SetActive(false);
            else if (TextBtnThird != null) BtnThird.gameObject.SetActive(true);
        }
        public void Show(DialogCallBack c)
        {
            gameObject.SetActive(true);
            this.c = c;
        }

        void BtnOK_onClick(GameObject g)
        {
            gameObject.SetActive(false);
            c(DialogResult.OK);
        }
        void BtnCancel_onClick(GameObject g)
        {
            gameObject.SetActive(false);
            c(DialogResult.Cancel);
        }
        void BtnTird_onClick(GameObject g)
        {
            gameObject.SetActive(false);
            c(DialogResult.Third);
        }
    }
}

using UnityEngine.UI;

namespace Ballance2.UI.UIElements
{
    /// <summary>
    /// UI 文字
    /// </summary>
    public class UIText : UIElement
    {
        public override void OnInit()
        {
            base.OnInit();
            text = GetComponent<Text>();
        }

        Text text;

        public override void StartSet(string initstr)
        {
            base.StartSet(initstr);


            Text = initstr;

        }
        /// <summary>
        /// 获取或设置文字
        /// </summary>
        public string Text
        {
            get { return text.text; }
            set
            {
                text.text = value;
            }
        }
    }
}

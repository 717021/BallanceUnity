using UnityEngine.UI;

namespace GlobalUI.UIElements
{
    /// <summary>
    /// UI 按钮2
    /// </summary>
    public class UIMulitButton : UIButton
    {
        private void Start()
        {
        
        }
        public override void OnInit()
        {
            base.OnInit();
            text2 = transform.GetChild(1).gameObject.GetComponent<Text>();
        }
        Text text2;

        public override void StartSet(string initstr)
        {
            base.StartSet(initstr);
            string[] s = initstr.Split('@');
            if (s.Length >= 1)
                Text = s[0];
            if (s.Length >= 2)
                RightText = s[1];
        }

        /// <summary>
        /// 获取或设置按钮左边的文字
        /// </summary>
        public string LeftText
        {
            get { return Text; }
            set { Text = value; }
        }
        /// <summary>
        /// 获取或设置按钮右边的文字
        /// </summary>
        public string RightText
        {
            get { return text2.text; }
            set
            {
                text2.text = value;
            }
        }
    }
}

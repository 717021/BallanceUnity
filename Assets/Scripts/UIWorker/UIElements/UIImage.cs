using UnityEngine;
using UnityEngine.UI;

namespace GlobalUI.UIElements
{
    /// <summary>
    /// UI 图片
    /// </summary>
    public class UIImage : UIElement
    {
        public override void OnInit()
        {
            base.OnInit();
            image = gameObject.GetComponent<Image>();
        }
        private Image image;

        /// <summary>
        /// 
        /// </summary>
        public Image Image { get { return image; } }

        /// <summary>
        /// 获取或设置按钮的文字
        /// </summary>
        public Sprite Sprite
        {
            get { return image.sprite; }
            set
            {
                image.sprite = value;
            }
        }
    }
}

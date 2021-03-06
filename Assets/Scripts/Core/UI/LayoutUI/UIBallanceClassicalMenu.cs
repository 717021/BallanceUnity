﻿using Ballance2.UI.LayoutUI;
using UnityEngine;

namespace Ballance2.UI
{
    /// <summary>
    /// Ballance 经典样式菜单
    /// </summary>
    public class UIBallanceClassicalMenu : UIVerticalLayoutMenu
    {
        public override void OnInit()
        {
            base.OnInit();
            innern = transform.GetChild(0).gameObject;
            transformHost = innern.transform;
            rectTransformInnern = innern.GetComponent<RectTransform>();
        }

        private RectTransform rectTransformInnern;
        private GameObject innern;

        public override float DoLayout()
        {
            float h= base.DoLayout(); 
            if(h>0)
            {
                if (rectTransformInnern == null)
                {
                    innern = transform.GetChild(0).gameObject;
                    transformHost = innern.transform;
                    rectTransformInnern = innern.GetComponent<RectTransform>();
                }
                if (h != rectTransformInnern.sizeDelta.y) rectTransformInnern = innern.GetComponent<RectTransform>();
                rectTransformInnern.sizeDelta = new Vector2(rectTransformInnern.sizeDelta.x, h);
            }
            return h;
        }
    }
}

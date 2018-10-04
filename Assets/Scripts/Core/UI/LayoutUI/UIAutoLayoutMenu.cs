using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ballance2.UI.LayoutUI
{
    /// <summary>
    /// 未实现，保留
    /// </summary>
    public class UIAutoLayoutMenu : UIMenu
    {
        public virtual float DoLayout()
        {
            UnLockLayout();
            return -1;
        }
        public virtual void LockLayout()
        {

        }
        public virtual void UnLockLayout()
        {

        }
    }
}

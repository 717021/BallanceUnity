using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/*
 * 主模块接口声明类
 */
namespace Ballance2
{
    /// <summary>
    /// 主模块部件接口
    /// </summary>
    public interface IGameBasePart
    {
        /// <summary>
        /// 游戏加载器接口
        /// </summary>
        GameBulider GameBulider { get; set; }

        /// <summary>
        /// 退出清理事件接口
        /// </summary>
        void ExitGameClear();
    }
}
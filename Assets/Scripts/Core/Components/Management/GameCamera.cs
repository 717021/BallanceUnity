using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * 摄像机管理组件
 */

namespace Ballance2.Management.Components
{
    /// <summary>
    /// 自动摄像机管理（用于主摄像机，防止两个主摄像机在场景中同时显示）
    /// </summary>
    public class GameCamera : MonoBehaviour
    {
        private Camera manageCamera = null;
        private bool enableCtl = false;
        private GameCameraManager mgr = null;

        public Camera Camera { get { return manageCamera; } }

        void Start()
        {
            manageCamera = GetComponent<Camera>();

            if (manageCamera != null)
            {
                mgr = GameBulider.GetGameService<GameCameraManager>(GameServices.GameCameraManager);
                mgr.AddCamera(this);
                enableCtl = true;
            }
        }
        private void OnDestroy()
        {
            if(enableCtl && mgr != null)
                mgr.RemoveCamera(this);
            enableCtl = false;
        }

        private void OnEnable()
        {
            if (mgr != null && enableCtl)
                mgr.OnCameraShow(this);
        }
        private void OnDisable()
        {
            if (mgr != null && enableCtl)
                mgr.OnCameraHide(this);
        }
    }
}

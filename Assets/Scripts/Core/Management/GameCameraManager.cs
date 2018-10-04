using Ballance2;
using Ballance2.Management.Components;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ballance2.Management
{
    /// <summary>
    /// 主摄像机管理器
    /// </summary>
    public class GameCameraManager : MonoBehaviour, IGameBasePart
    {
        public GameBulider GameBulider { get; set; }

        public void ExitGameClear()
        {
            managedCameras.Clear();
            managedCameras = null;
        }

        private List<GameCamera> managedCameras = new List<GameCamera>();
        private GameCamera currentCamera = null;

        public void AddCamera(GameCamera c)
        {
            if (!managedCameras.Contains(c))
                managedCameras.Add(c);
            
        }
        public void RemoveCamera(GameCamera c)
        {
            if (managedCameras.Contains(c))
                managedCameras.Remove(c);
            
        }
        public void CameraShow(GameCamera c)
        {
            if (!c.gameObject.activeSelf)
                c.gameObject.SetActive(true);
        }
        public void CameraHide(GameCamera c)
        {
            if (c.gameObject.activeSelf)
                c.gameObject.SetActive(false);
        }

        internal void OnCameraShow(GameCamera c)
        {
            if (currentCamera != null)
            {
                if (currentCamera.gameObject.activeSelf)
                    currentCamera.gameObject.SetActive(false);
            }
        }
        internal void OnCameraHide(GameCamera c)
        {
            if (c == currentCamera)
                currentCamera = null;
        }
    }
}

using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

/*
 * UI 穿透脚本 
 */

namespace Ballance2.UI.Utils
{
    /// <summary>
    /// UI 穿透脚本 
    /// </summary>
    public class DUIRayIgnore : UIBehaviour, ICanvasRaycastFilter
    {
        private bool isEnabled = true;

        public bool IsRaycastLocationValid(Vector2 screenPoint, Camera eventCamera)
        {
            return !isEnabled;
        }

        protected override void OnDisable()
        {
            isEnabled = false;
        }
        protected override void OnEnable()
        {
            isEnabled = true;
        }
    }
}

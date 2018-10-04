using Ballance2.UI.WindowUI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

/*
 * UI 控件拖动脚本
 * 
 */

namespace Ballance2.UI.Utils
{
    /// <summary>
    /// UI 控件拖动脚本
    /// </summary>
    public class DUIDragControl : UIBehaviour
    {
        public Transform dragTransform;
        public UIWindow window;

        private Vector2 mouseOffest = Vector2.zero;

        protected override void Awake()
        {
            base.Awake();

            if (dragTransform == null) dragTransform = GetComponent<Transform>();

            window = transform.parent.gameObject.GetComponent<UIWindow>();

            EventTrigger trigger = gameObject.AddComponent<EventTrigger>();

            UnityAction<BaseEventData> pointerdownClick = new UnityAction<BaseEventData>(OnPointerDown);
            EventTrigger.Entry myclickDown = new EventTrigger.Entry();
            myclickDown.eventID = EventTriggerType.PointerDown;
            myclickDown.callback.AddListener(pointerdownClick);
            trigger.triggers.Add(myclickDown);

            UnityAction<BaseEventData> pointerupClick = new UnityAction<BaseEventData>(OnPointerUp);
            EventTrigger.Entry myclickUp = new EventTrigger.Entry();
            myclickUp.eventID = EventTriggerType.PointerUp;
            myclickUp.callback.AddListener(pointerupClick);
            trigger.triggers.Add(myclickUp);

            UnityAction<BaseEventData> pointerdragClick = new UnityAction<BaseEventData>(OnDrag);
            EventTrigger.Entry myclickDrag = new EventTrigger.Entry();
            myclickDrag.eventID = EventTriggerType.Drag;
            myclickDrag.callback.AddListener(pointerdragClick);
            trigger.triggers.Add(myclickDrag);
        }

        public void OnPointerDown(BaseEventData data)
        {
            GetComponent<Image>().color = Color.gray;
            if (window != null) window.Active();
            mouseOffest = new Vector2(Input.mousePosition.x - dragTransform.position.x, Input.mousePosition.y - dragTransform.position.y);
        }
        public void OnPointerUp(BaseEventData data)
        {
            GetComponent<Image>().color = Color.white;
            mouseOffest = Vector2.zero;
        }
        public void OnDrag(BaseEventData data)
        {
            dragTransform.position = new Vector3(Input.mousePosition.x - mouseOffest.x, Input.mousePosition.y - mouseOffest.y, Input.mousePosition.z);
        }
    }
}

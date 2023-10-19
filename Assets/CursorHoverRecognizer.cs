using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace TeamBanjo.CursorHover
{
    public class CursorHoverRecognizer : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        public enum InteractMode
        {
            take = 0,
            inspect = 1
        }
        public InteractMode interactMode;
        public event Action OnMouseEnter;
        //public event Action<InteractMode> OnMouseEnter;
        public event Action OnMouseExit;

        public void OnPointerEnter(PointerEventData eventData)
        {
            if ( OnMouseEnter != null )
            {
                OnMouseEnter();
                //OnMouseEnter(interactMode);
            }
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            if ( OnMouseExit != null )
            {
                OnMouseExit();
            }
        }
    }
}

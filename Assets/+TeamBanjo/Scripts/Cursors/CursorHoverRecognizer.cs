using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace TeamBanjo.CursorHover
{
    public class CursorHoverRecognizer : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        [SerializeField] private CursorData cursorSettings;
        public event Action<Texture2D[], Vector2> OnMouseEnter;
        public event Action OnMouseExit;

        public void OnPointerEnter(PointerEventData eventData)
        {
            OnMouseEnter?.Invoke(cursorSettings.CursorTextures, cursorSettings.CursorHotspot);
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            OnMouseExit?.Invoke();
        }
    }
}

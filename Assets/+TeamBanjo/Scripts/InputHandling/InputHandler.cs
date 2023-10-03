using UnityEngine;
using UnityEngine.InputSystem;

namespace TeamBanjo.InputHandling
{
    public class InputHandler : MonoBehaviour
    {
        private Vector3 clickWorldPosition = Vector3.zero;
        public Vector2 ClickWorldPosition => clickWorldPosition;

        public void OnClick()
        {
            Vector3 clickPosition = Mouse.current.position.ReadValue();
            clickPosition.z = Camera.main.nearClipPlane;

            clickWorldPosition = Camera.main.ScreenToWorldPoint(clickPosition);
            Debug.Log($"The world position of the last click is {clickWorldPosition}!");
            Debug.Log(ClickWorldPosition);
        }
    }
}

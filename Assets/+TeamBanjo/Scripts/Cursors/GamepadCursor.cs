using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.LowLevel;
using UnityEngine.InputSystem.Users;

namespace TeamBanjo.GamepadCursor
{
    public class GamepadCursor : MonoBehaviour
    {
        [SerializeField, Tooltip("The PlayerInput component in the scene.")]
        private PlayerInput playerInput;
        [SerializeField]
        private RectTransform cursorRectTransform;
        [SerializeField]
        private RectTransform canvasRectTransform;

        [Space]

        [SerializeField]
        private float gamepadCursorSpeed = 2.5f;
        [SerializeField]
        private float padding = 35f;

        private bool previousMouseState;

        private string currentControlScheme;
        private const string gamepadScheme = "Gamepad";
        private const string mouseScheme = "Mouse";

        private Mouse virtualMouse;
        private Mouse currentMouse;

        private void OnEnable()
        {
            currentMouse = Mouse.current;
            currentControlScheme = playerInput.currentControlScheme;

            if ( virtualMouse == null )
            {
                virtualMouse = (Mouse)InputSystem.AddDevice("VirtualMouse");
            }
            else if ( !virtualMouse.added )
            {
                InputSystem.AddDevice(virtualMouse);
            }

            // Pair the device to the user to use the PlayerInput component with the EventSystem & the VirtualMouse.
            InputUser.PerformPairingWithDevice(virtualMouse, playerInput.user);

            if ( cursorRectTransform != null )
            {
                Vector2 position = cursorRectTransform.anchoredPosition;
                InputState.Change(virtualMouse.position, position);
            }

            InputSystem.onAfterUpdate += UpdateMotion;
        }

        private void OnDisable()
        {
            InputSystem.onAfterUpdate -= UpdateMotion;
            InputSystem.RemoveDevice(virtualMouse);
        }

        private void UpdateMotion()
        {
            if ( virtualMouse == null || Gamepad.current == null )
            {
                return;
            }

            Vector2 stickValue = Gamepad.current.leftStick.ReadValue();
            stickValue *= gamepadCursorSpeed * Time.deltaTime;

            Vector2 currentPosition = virtualMouse.position.ReadValue();
            Vector2 newPosition = currentPosition + stickValue;

            newPosition.x = Mathf.Clamp(newPosition.x, padding, Screen.width - padding);
            newPosition.y = Mathf.Clamp(newPosition.y, padding, Screen.height - padding);

            InputState.Change(virtualMouse.position, newPosition);
            InputState.Change(virtualMouse.delta, stickValue);

            bool southButtonIsPressed = Gamepad.current.aButton.IsPressed();
            if ( previousMouseState != southButtonIsPressed )
            {
                virtualMouse.CopyState<MouseState>(out var mouseState);
                mouseState.WithButton(MouseButton.Left, southButtonIsPressed);
                InputState.Change(virtualMouse, mouseState);
                previousMouseState = southButtonIsPressed;
            }

            AnchorCursor(newPosition);
        }

        private void AnchorCursor(Vector2 position)
        {
            Vector2 anchoredPosition;
            RectTransformUtility.ScreenPointToLocalPointInRectangle(canvasRectTransform, position, Camera.main, out anchoredPosition);
            cursorRectTransform.anchoredPosition = anchoredPosition;
        }

        public void OnControlsChanged(PlayerInput input)
        {
            if ( playerInput.currentControlScheme == mouseScheme && currentControlScheme != mouseScheme )
            {
                Cursor.visible = true;

                if ( virtualMouse != null )
                {
                    currentMouse.WarpCursorPosition(virtualMouse.position.ReadValue());
                }

                currentControlScheme = mouseScheme;
                cursorRectTransform.gameObject.SetActive(false);
            }
            else if ( playerInput.currentControlScheme == gamepadScheme && currentControlScheme != gamepadScheme )
            {
                cursorRectTransform.gameObject.SetActive(true);
                Cursor.visible = false;
                InputState.Change(virtualMouse.position, currentMouse.position.ReadValue());
                AnchorCursor(currentMouse.position.ReadValue());
                currentControlScheme = gamepadScheme;
            }
        }
    }
}

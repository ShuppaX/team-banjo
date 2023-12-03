using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace TeamBanjo.InputHandling
{
    public class KeyboardInputs : MonoBehaviour
    {
        public static event Action OnPause;

        public void Pause(InputAction.CallbackContext context)
        {
            if ( context.performed )
            {
                OnPause?.Invoke();
            }
        }
    }
}

using TeamBanjo.InputHandling;
using UnityEngine;

namespace TeamBanjo.UI
{
    public class UIManager : MonoBehaviour
    {
        enum UIStates
        {
            None,
            MainMenu,
            Options
        }

        [SerializeField] private GameObject mainMenu;
        private UIStates uIState;

        private void Start()
        {
            uIState = UIStates.None;

            UpdateUI();

            KeyboardInputs.OnPause += TogglePause;
        }

        private void OnDisable()
        {
            KeyboardInputs.OnPause -= TogglePause;
        }

        private void TogglePause()
        {
            if ( uIState == UIStates.None )
            {
                uIState = UIStates.MainMenu;
                Time.timeScale = 0.0f;
            }
            else
            {
                uIState = UIStates.None;
                Time.timeScale = 1.0f;
            }

            UpdateUI();
        }

        private void UpdateUI()
        {
            switch ( uIState )
            {
                case UIStates.None:
                    mainMenu.SetActive(false);
                    break;
                case UIStates.MainMenu:
                    mainMenu.SetActive(true);
                    break;
            }
        }
    }
}

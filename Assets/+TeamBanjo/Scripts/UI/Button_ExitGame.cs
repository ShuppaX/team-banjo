using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TeamBanjo
{
    public class Button_ExitGame : MonoBehaviour
    {
        public void OnExitGame()
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace TeamBanjo.UI
{
    public class SetVersionNumberToText : MonoBehaviour
    {
        private TMP_Text text;
        private string prefixText = "Version: ";

        private void Start()
        {
            Setup();
        }

        private void Setup()
        {
            text = GetComponent<TMP_Text>();
            if ( text == null )
            {
                Debug.LogError($"{this} is missing a reference to a TMP Text component!");
            }
            else
            {
                text.text = prefixText + Application.version;
            }
        }

        private void OnValidate()
        {
            Setup();
        }
    }
}

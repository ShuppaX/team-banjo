using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace TeamBanjo
{
    public class ImageSwapper : MonoBehaviour
    {
        [SerializeField] private float imageSwapSpeed = 0.5f;
        [SerializeField] private Sprite[] sprites;
        private Image currentImage;
        private Coroutine imageRoutine;
        private int index = 0;

        private void OnValidate()
        {
            GetReference();
            SetSprite();
        }

        private void Start()
        {
            GetReference();

            if ( currentImage != null )
            {
                StartCoroutine(SwapImage());
            }
        }

        private void OnDisable()
        {
            if ( imageRoutine != null )
            {
                imageRoutine = null;
                StopCoroutine(SwapImage());
            }
        }

        private void GetReference()
        {
            currentImage = GetComponent<Image>();
            if ( currentImage == null )
            {
                Debug.LogError($"{this} is missing reference to a Image component!");
            }
        }

        private IEnumerator SwapImage()
        {
            yield return new WaitForSeconds(imageSwapSpeed);

            index++;
            if ( index >= sprites.Length )
            {
                index = 0;
            }

            SetSprite();

            StartCoroutine(SwapImage());
        }

        private void SetSprite()
        {
            currentImage.sprite = sprites[index];
        }
    }
}

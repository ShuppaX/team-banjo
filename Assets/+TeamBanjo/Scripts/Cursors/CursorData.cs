using UnityEngine;

namespace TeamBanjo.CursorHover
{
   [System.Serializable]
    public class CursorData
    {
        [SerializeField] private Texture2D[] cursorTextures;
        [SerializeField] Vector2 cursorHotspot;

        public Texture2D[] CursorTextures => cursorTextures;
        public Vector2 CursorHotspot => cursorHotspot;
    }
}

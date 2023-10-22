using UnityEngine;

namespace TeamBanjo.CursorHover
{
    public class CursorManager : MonoBehaviour
    {
        [SerializeField] private float frameRate;
        private Vector2 cursorHotspot;
        private int frameCount;
        private int currentFrame;
        private float frameTimer;
        private bool isCursorOnInteractionPoint;
        private CursorHoverRecognizer[] cursorHoverRecognizers;
        private Texture2D[] currentCursorTextures;

        void Start()
        {
            FindReferences();
            AddListeners();
        }

        private void Update()
        {
            if ( isCursorOnInteractionPoint )
            {
                UpdateCursorAnimation();
            }
        }

        private void OnDisable()
        {
            RemoveListeners();
        }

        private void FindReferences()
        {
            cursorHoverRecognizers = FindObjectsOfType<CursorHoverRecognizer>();
        }

        private void AddListeners()
        {
            foreach ( var interactable in cursorHoverRecognizers )
            {
                interactable.OnMouseEnter += SetCursor;
            }

            foreach ( var interactable in cursorHoverRecognizers )
            {
                interactable.OnMouseExit += SetCursorDefault;
            }
        }

        private void RemoveListeners()
        {
            foreach ( var interactable in cursorHoverRecognizers )
            {
                interactable.OnMouseEnter -= SetCursor;
            }

            foreach ( var interactable in cursorHoverRecognizers )
            {
                interactable.OnMouseExit -= SetCursorDefault;
            }
        }

        private void SetCursor(Texture2D[] cursorTextures, Vector2 hotspot)
        {
            isCursorOnInteractionPoint = true;

            // Set immediatelly the first animation frame for the cursor otherwise there might be slight delay in curson change.
            Cursor.SetCursor(cursorTextures[0], hotspot, CursorMode.Auto);

            cursorHotspot = hotspot;
            currentCursorTextures = cursorTextures;
            frameCount = cursorTextures.Length;
        }

        /// <summary>
        /// Sets the cursor to the default one.
        /// </summary>
        private void SetCursorDefault()
        {
            isCursorOnInteractionPoint = false;
            Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
        }

        private void UpdateCursorAnimation()
        {
            frameTimer -= Time.deltaTime;
            if ( frameTimer <= 0.0f )
            {
                frameTimer += frameRate;
                currentFrame = (currentFrame + 1) % frameCount;
                Cursor.SetCursor(currentCursorTextures[currentFrame], cursorHotspot, CursorMode.Auto);
            }
        }
    }
}

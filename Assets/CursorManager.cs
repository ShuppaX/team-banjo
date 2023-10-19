using UnityEngine;

namespace TeamBanjo.CursorHover
{
    public class CursorManager : MonoBehaviour
    {
        [Header("Take Cursor")]
        [SerializeField] private Texture2D[] takeCursorTextures;
        [SerializeField] Vector2 takeCursorHotspot;

        [SerializeField] private float frameRate;

        private Vector2 cursorHotspot;
        private int frameCount;
        private int currentFrame;
        private float frameTimer;
        private bool isCursorOnInteractionPoint;
        private CursorHoverRecognizer[] cursorHoverRecognizers;

        // TODO: Create more flexible way to add new cursor settings

        void Start()
        {
            FindReferences();
            AddListeners();

            frameCount = takeCursorTextures.Length;
        }

        private void Update()
        {
            if ( isCursorOnInteractionPoint )
            {
                frameTimer -= Time.deltaTime;
                if ( frameTimer <= 0.0f )
                {
                    frameTimer += frameRate;
                    currentFrame = (currentFrame + 1) % frameCount;
                    Cursor.SetCursor(takeCursorTextures[currentFrame], cursorHotspot, CursorMode.Auto);
                }
            }
        }

        private void OnDisable()
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

        //private void SetCursor(InteractionMode mode)
        private void SetCursor()
        {
            isCursorOnInteractionPoint = true;
            Cursor.SetCursor(takeCursorTextures[0], cursorHotspot, CursorMode.Auto);
            cursorHotspot = takeCursorHotspot;
        }

        private void SetCursorDefault()
        {
            isCursorOnInteractionPoint = false;
            Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
        }
    }
}

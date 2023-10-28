using UnityEngine;
using TeamBanjo.Interaction;


namespace TeamBanjo.PuzzleSystem
{
    public class PuzzleManager : MonoBehaviour
    {
        [SerializeField, Tooltip("List of puzzle interactables (in puzzle order)")]
        private PuzzleInteractable[] puzzleItems;

        private int currentItemIndex = 0;

        private void Start()
        {
            SetupPuzzle();
        }

        private void OnDisable()
        {
            foreach ( PuzzleInteractable item in puzzleItems )
            {
                item.OnInteraction -= OnPuzzleItemInteraction;
            }
        }

        private void SetupPuzzle()
        {
            SetItemsNonInteractable();
            EnableInteractionWithCurrentItem();
        }

        private void SetItemsNonInteractable()
        {
            foreach ( PuzzleInteractable item in puzzleItems )
            {
                item.SetIsInteractable(false);
                item.OnInteraction += OnPuzzleItemInteraction;
            }
        }

        private void EnableInteractionWithCurrentItem()
        {
            if ( currentItemIndex < puzzleItems.Length )
            {
                puzzleItems[currentItemIndex].SetIsInteractable(true);
            }
        }

        public void OnPuzzleItemInteraction(PuzzleInteractable item)
        {
            if ( item == puzzleItems[currentItemIndex] )
            {
                item.OnInteraction -= OnPuzzleItemInteraction;

                currentItemIndex++;

                if ( currentItemIndex < puzzleItems.Length )
                {
                    EnableInteractionWithCurrentItem();
                }
            }
        }
    }
}

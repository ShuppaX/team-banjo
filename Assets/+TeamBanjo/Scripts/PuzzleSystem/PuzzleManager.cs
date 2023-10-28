using UnityEngine;
using TeamBanjo.Interaction;


namespace TeamBanjo.PuzzleSystem
{
    public class PuzzleManager : MonoBehaviour
    {
        [SerializeField, Tooltip("List of puzzle interactables (in puzzle order)")]
        private PickupAble[] puzzleItems;

        private int currentItemIndex = 0;

        private void Start()
        {
            SetupPuzzle();
        }

        private void OnDisable()
        {
            foreach ( PickupAble item in puzzleItems )
            {
                item.OnPickedUp -= OnPuzzleItemInteraction;
            }
        }

        private void SetupPuzzle()
        {
            SetItemsNonInteractable();
            EnableCurrentItem();
        }

        private void SetItemsNonInteractable()
        {
            foreach ( PickupAble item in puzzleItems )
            {
                item.SetIsInteractable(false);
                item.OnPickedUp += OnPuzzleItemInteraction;
            }
        }

        private void EnableCurrentItem()
        {
            if ( currentItemIndex < puzzleItems.Length )
            {
                puzzleItems[currentItemIndex].SetIsInteractable(true);
            }
        }

        public void OnPuzzleItemInteraction(PickupAble item)
        {
            if ( item == puzzleItems[currentItemIndex] )
            {
                item.OnPickedUp -= OnPuzzleItemInteraction;

                currentItemIndex++;

                if ( currentItemIndex < puzzleItems.Length )
                {
                    EnableCurrentItem();
                }
            }
        }
    }
}

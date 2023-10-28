using UnityEngine;
using System;

namespace TeamBanjo.Interaction
{
    public class PuzzleInteractable : InteractableBase
    {
        public event Action<PuzzleInteractable> OnInteraction;

        public override void Interact()
        {
            if ( isInteractable )
            {
                Debug.Log($"The player was able to interact with {name}!");
                OnInteraction?.Invoke(this);

                AfterInteractionAction();
            }
            else
            {
                Debug.Log($"The player can't interact with {name} yet/anymore.");
            }
        }

        public virtual void AfterInteractionAction()
        {
            isInteractable = false;
        }
    }
}

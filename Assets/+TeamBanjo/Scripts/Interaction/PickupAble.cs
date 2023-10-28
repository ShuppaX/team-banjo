using System;
using UnityEngine;

namespace TeamBanjo.Interaction
{
    public class PickupAble : InteractableBase
    {
        public event Action<PickupAble> OnPickedUp;

        public override void Interact()
        {
            if ( isInteractable )
            {
                Debug.Log($"The player was able to interact with {name}!");
                OnPickedUp?.Invoke(this);

                isInteractable = false;
                gameObject.SetActive(false);
            }
            else
            {
                Debug.Log($"The player can't interact with {name} yet/anymore.");
            }
        }
    }
}

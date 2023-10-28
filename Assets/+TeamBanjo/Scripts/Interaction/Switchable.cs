using UnityEngine;

namespace TeamBanjo.Interaction
{
    public class Switchable : InteractableBase
    {
        [SerializeField, Tooltip("Use this bool to set the switch on/off by default.")]
        private bool switchedOn = true;
        public bool SwitchedOn => switchedOn;

        public override void Interact()
        {
            if ( isInteractable )
            {
                Debug.Log($"The player interacted with {name}!");
                switchedOn = !switchedOn;
                //Debug.Log($"Toggled {name}'s switchedOn value to {switchedOn}!");
            }
            else
            {
                Debug.Log($"The player can't interact with {name} yet.");
            }
        }
    }
}

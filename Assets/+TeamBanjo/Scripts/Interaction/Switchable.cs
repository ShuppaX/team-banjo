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
            base.Interact();
            switchedOn = !switchedOn;
            //Debug.Log($"Toggled {name}'s switchedOn value to {switchedOn}!");
        }
    }
}

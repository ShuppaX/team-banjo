using UnityEngine;

namespace TeamBanjo.Interaction
{
    public class InteractableBase : MonoBehaviour, IInteractable
    {
        [SerializeField, Tooltip("The allowed interaction distance for the interactable. (as a float)")]
        private float interactionDistance = 0.5f;

        [SerializeField, Tooltip("Set <color=#00FF00>true</color> to allow the player to interact with this " +
            "and <color=#FF0000>false</color> to not allow the player to interact with this.")]
        protected bool isInteractable = false;

        public float InteractionDistance => interactionDistance;
        public Vector3 Position => transform.position;
        public bool IsInteractable => IsInteractable;

        public virtual void Interact()
        {
            
        }

        public void SetIsInteractable(bool value)
        {
            isInteractable = value;
        }
    }
}

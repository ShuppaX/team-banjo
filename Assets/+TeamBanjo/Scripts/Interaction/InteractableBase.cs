using UnityEngine;

namespace TeamBanjo.Interaction
{
    public class InteractableBase : MonoBehaviour, IInteractable
    {
        [SerializeField, Tooltip("The allowed interaction distance for the interactable. (as a float)")]
        private float interactionDistance = 0.5f;
        public float InteractionDistance => interactionDistance;
        public Vector3 Position => transform.position;

        public virtual void Interact()
        {
            Debug.Log($"The player interacted with {name}!");
        }
    }
}

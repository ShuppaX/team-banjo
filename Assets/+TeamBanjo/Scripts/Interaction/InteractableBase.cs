using UnityEngine;
using TeamBanjo.Utilities;

namespace TeamBanjo.Interaction
{
    public class InteractableBase : MonoBehaviour, IInteractable
    {
        [SerializeField, Tooltip("Used to toggle the gameObject's Rigidbody kinematic.")]
        protected bool isKinematic = true;
        [SerializeField, Tooltip("Used to toggle gravity for the gameObject's Rigidbody.")]
        protected bool isUsingGravity = false;

        [Space]

        [SerializeField, Tooltip("The allowed interaction distance for the interactable. (as a float)")]
        protected float interactionDistance = 0.5f;

        [SerializeField, Tooltip("Set <color=#00FF00>true</color> to allow the player to interact with this " +
            "and <color=#FF0000>false</color> to not allow the player to interact with this.")]
        protected bool isInteractable = false;

        protected Rigidbody rb;

        #region IInteractable
        public float InteractionDistance => interactionDistance;
        public Vector3 Position => transform.position;
        public bool IsInteractable => IsInteractable;
        #endregion

        protected virtual void Start()
        {   
            SetupRigidbody();
        }

        protected virtual void SetupRigidbody()
        {
            rb = Tools.GetReference<Rigidbody>(gameObject);
            rb.isKinematic = isKinematic;
            rb.useGravity = isUsingGravity;
        }

        public virtual void Interact()
        {

        }

        public void SetIsInteractable(bool value)
        {
            isInteractable = value;
        }
    }
}

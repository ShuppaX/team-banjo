using UnityEngine;
using UnityEngine.InputSystem;
using TeamBanjo.Interaction;
using TeamBanjo.Movement;
using TeamBanjo.Utilities;

namespace TeamBanjo.InputHandling
{
    public class InputHandler : MonoBehaviour
    {
        private Vector3 clickWorldPosition = Vector3.zero;
        public Vector2 ClickWorldPosition => clickWorldPosition;

        private PlayerMovement playerMovement = null;
        private IInteractable currentInteractable = null;

        private void Start()
        {
            playerMovement = Tools.GetReference<PlayerMovement>(gameObject);
        }

        private void Update()
        {
            if ( currentInteractable != null)
            {
                float distance = Vector3.Distance(transform.position, currentInteractable.Position);

                if ( distance <= currentInteractable.InteractionDistance )
                {
                    playerMovement.StopMovement();
                    currentInteractable.Interact();
                    currentInteractable = null;
                }
            }
        }

        public void OnClick()
        {
            Vector3 clickPosition = Mouse.current.position.ReadValue();
            clickPosition.z = Camera.main.nearClipPlane;

            clickWorldPosition = Camera.main.ScreenToWorldPoint(clickPosition);
            //Debug.Log($"The world position of the last click is {clickWorldPosition}!");
            //Debug.Log(ClickWorldPosition);

            InteractWithAnObject();
        }

        private void InteractWithAnObject()
        {
            Ray ray = new Ray(clickWorldPosition, Vector3.forward);
            RaycastHit hit;

            if ( Physics.Raycast(ray, out hit) )
            {
                if ( hit.collider.TryGetComponent(out IInteractable interactable) )
                {
                    //Debug.Log($"The player is trying to interact with {interactable.GetType().Name}");
                    currentInteractable = interactable;
                }
            }
        }
    }
}

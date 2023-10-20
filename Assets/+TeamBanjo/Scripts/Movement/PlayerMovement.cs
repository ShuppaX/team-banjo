using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;
using TeamBanjo.InputHandling;
using TeamBanjo.Utilities;

namespace TeamBanjo.Movement
{
    [RequireComponent(typeof(InputHandler), (typeof(Rigidbody)))]
    public class PlayerMovement : MonoBehaviour
    {
        private NavMeshAgent agent = null;
        private InputHandler inputHandler = null;
        private Rigidbody rb = null;

        // Start is called before the first frame update
        private void Start()
        {
            Setup();
        }

        private void Setup()
        {
            agent = Tools.GetReference<NavMeshAgent>(gameObject);
            agent.updateRotation = false;
            agent.updateUpAxis = false;

            inputHandler = Tools.GetReference<InputHandler>(gameObject);
            rb = Tools.GetReference<Rigidbody>(gameObject);
        }

        public void Move(InputAction.CallbackContext context)
        {
            if ( context.performed )
            {
                inputHandler.OnClick();
                agent.isStopped = false;
                agent.SetDestination(inputHandler.ClickWorldPosition);
            }
        }

        public void StopMovement()
        {
            agent.isStopped = true;
            rb.velocity = Vector3.zero;
        }
    }
}

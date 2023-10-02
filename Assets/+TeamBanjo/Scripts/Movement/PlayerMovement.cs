using UnityEngine;
using UnityEngine.AI;
using TeamBanjo.Utilities;
using TeamBanjo.InputHandling;

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

        // Update is called once per frame
        private void Update()
        {

        }

        private void Move()
        {
            Vector2 currentPosition = transform.position;

            if ( Vector2.Distance(inputHandler.ClickWorldPosition, transform.position) > 1.0f )
            {
                
            }
        }
    }
}

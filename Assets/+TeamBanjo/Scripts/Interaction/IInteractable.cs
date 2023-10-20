using UnityEngine;

namespace TeamBanjo.Interaction
{
    public interface IInteractable
    {
        float InteractionDistance { get; }
        Vector3 Position { get; }
        void Interact();
    }
}

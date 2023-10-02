using UnityEngine;

namespace TeamBanjo.Utilities
{
    public class Tools : MonoBehaviour
    {
        public static T GetReference<T>(GameObject gameObject) where T : Component
        {
            T component = gameObject.GetComponent<T>();
            if ( component == null )
            {
                Debug.LogError($"A component of type {typeof(T).Name} couldn't be found on the {gameObject.name}!");
            }

            return component;
        }
    }
}

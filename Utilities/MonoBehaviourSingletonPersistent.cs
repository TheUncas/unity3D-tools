using UnityEngine;

namespace Utilities
{

    /// <summary>
    /// MonoBehaviourSingletonPersistent class
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class MonoBehaviourSingletonPersistent<T> : MonoBehaviour
where T : Component
    {

        /// <summary>
        /// Instance of the singleton
        /// </summary>
        public static T instance { get; private set; }

        public virtual void Awake()
        {
            if (instance == null)
            {
                instance = this as T;
                DontDestroyOnLoad(this);
            }
            else
            {
                Destroy(gameObject);
            }
        }
    } 
}
using UnityEngine;

namespace Utilities
{
    /// <summary>
    /// MonoBehaviourSingletonNonPersistent class
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class MonoBehaviourSingletonNonPersistent<T> : MonoBehaviour
where T : Component
    {
        /// <summary>
        /// Instance of the singleton
        /// </summary>
        public static T instance { get; private set; }

        public virtual void Awake()
        {
            instance = this as T;
        }
    } 
}
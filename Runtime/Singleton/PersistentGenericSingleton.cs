using UnityEngine;

namespace AAA.Core.Runtime.Singleton
{
    public class PersistentGenericSingleton<T> : GenericSingleton<T> where T : Component
    {
        protected override void Awake()
        {
            if (instance == null)
            {
                instance = this as T;
                InitializeSingleton();
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Debug.LogWarning($"There already exists a {GetType()} in this scene. This instance {gameObject.name} will be deleted.");
                Destroy(gameObject);
            }
        }
    }
}
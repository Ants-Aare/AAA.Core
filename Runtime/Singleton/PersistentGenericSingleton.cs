using UnityEngine;

namespace AAA.Core.Runtime.Singleton
{
    public class PersistentGenericSingleton<T> : GenericSingleton<T> where T : Component
    {
        protected override void Awake()
        {
            if (instance == null || instance == this)
            {
                instance = this as T;
                InitializeSingleton();
                transform.SetParent(null);
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Debug.LogWarning($"There already exists an instance of {GetType()} in this scene: {instance.name}. This instance {gameObject.name} will be deleted.");
                if(DestroyGameObjectOnDuplicate)
                    Destroy(gameObject);
                else
                    Destroy(this);
            }
        }
    }
}
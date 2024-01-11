using UnityEngine;

namespace AAA.Core.Runtime.Singleton
{
    public class GenericSingleton<T> : MonoBehaviour where T : Component
    {
        protected static T instance;
        public static T Instance
        {
            get
            {
                if (instance != null)
                    return instance;
                
                instance = FindObjectOfType<T>();
                if (instance != null)
                    return instance;
                
                var obj = new GameObject();
                obj.name = typeof(T).Name;
                instance = obj.AddComponent<T>();
                (instance as GenericSingleton<T>).InitializeSingleton();
                Debug.LogWarning($"A Singleton of type {instance.GetType().ToString()} was not found. It has been automatically created." +
                                 "You might want to consider having one in the Scene by default.");
                return instance; 
            }
        }

        public virtual void Awake()
        {
            if (instance == null)
            {
                instance = this as T;
                InitializeSingleton();
            }
            else
            {
                Debug.LogWarning($"There already exists a {GetType()} in this scene. This instance {gameObject.name} will be deleted.");
                Destroy(gameObject);
            }
        }

        protected virtual void InitializeSingleton()
        {

        }
    }
}
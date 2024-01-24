using UnityEngine;
using UnityEngine.SceneManagement;

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

#if UNITY_EDITOR
                if (Application.isEditor && !SceneManager.GetActiveScene().isLoaded)
                    return instance;
#endif
                
                var obj = new GameObject();
                obj.name = $"{typeof(T).Name} -AUTOCREATED-";
                instance = obj.AddComponent<T>();
                (instance as GenericSingleton<T>).InitializeSingleton();
                Debug.LogWarning($"A Singleton of type {instance.GetType().ToString()} was not found. It has been automatically created." +
                                 "You might want to consider having one in the Scene by default.");
                return instance; 
            }
        }

        protected virtual void Awake()
        {
            if (instance == null || instance == this)
            {
                instance = this as T;
                InitializeSingleton();
            }
            else
            {
                Debug.LogError($"There already exists an instance of {GetType()} in this scene: {instance.name}. This instance {gameObject.name} will be deleted.");
                Destroy(this);
            }
        }

        protected virtual void InitializeSingleton()
        {

        }
    }
}
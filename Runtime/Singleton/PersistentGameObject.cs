using UnityEngine;

namespace AAA.Core.Runtime.Singleton
{
    public class PersistentGameObject : MonoBehaviour
    {
        private void Awake()
        {
            DontDestroyOnLoad(gameObject);
        }
    }
}
using UnityEngine;

namespace AAA.Core.Runtime.Singleton
{
    public abstract class  ScriptableObjectSingleton<T> : ScriptableObject
        where T : ScriptableObject
    {
        private static bool _initializeCalled = false;
        protected static T _instance = null;

        public static T Instance
        {
            get
            {
                if (_instance == null)
                    _instance = Resources.Load<T>(typeof(T).Name);

                return _instance;
            }
        }


        private void OnEnable()
        {
            // if (_initializeCalled)
            //     return;
            // _initializeCalled = true;
            InitializeSingleton();
        }

        protected virtual void InitializeSingleton()
        {
        }
    }
}
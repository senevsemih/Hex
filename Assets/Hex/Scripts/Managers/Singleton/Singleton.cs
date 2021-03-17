using UnityEngine;

namespace Assets.Hex.Scripts.Managers.Singleton
{
    public abstract class Singleton<T> : MonoBehaviour where T : Component
    {
        private static T _instance;

        public static T Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = FindObjectOfType<T>();

                    if (_instance == null)
                    {
                        var obj = new GameObject();
                        obj.hideFlags = HideFlags.HideAndDontSave;
                        _instance = obj.AddComponent<T>();
                    }
                }

                return _instance;
            }

            set => _instance = value;
        }

        protected virtual void Awake()
        {
            if (_instance == null)
            { 
                _instance = this as T;
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }
}

using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T instance;
    private static object lockObject = new object();
    private static bool applicationIsQuitting = false;

    public static T Instance
    {
        get
        {
            if (applicationIsQuitting)
            {
                Debug.LogWarning("[Singleton] Instance '" + typeof(T) + "' already destroyed on application quit. Won't create again - returning null.");
                return null;
            }

            lock (lockObject)
            {
                if (instance == null)
                {
                    instance = (T)FindObjectOfType(typeof(T));

                    if (instance == null)
                    {
                        GameObject singleton = new GameObject();
                        instance = singleton.AddComponent<T>();
                        singleton.name = typeof(T).ToString() + " (Singleton)";

                        DontDestroyOnLoad(singleton);
                    }
                }

                return instance;
            }
        }
    }

    private void OnDestroy()
    {
        applicationIsQuitting = true;
    }
}

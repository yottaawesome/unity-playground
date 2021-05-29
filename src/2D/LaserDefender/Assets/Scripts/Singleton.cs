using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : UnityEngine.Object
{
    // This is a singleton pattern. Note the canvas has been made
    // a child of this object to also make it a singleton. This
    // functionality could also be implemented as a static object
    // or static variable.
    void Awake()
    {
        if (FindObjectsOfType<T>().Length > 1)
        {
            // There is potential for other objects to try to use
            // this object before it's destroyed (depending on the
            // execution order of the scripts), so set it to
            // inactive so it can't cause any mischief
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
}

using System;
using UnityEngine;

public class SingletonClass<T> : MonoBehaviour where T : MonoBehaviour
{
    [SerializeField] protected bool canLiveSceneOver = false;

    protected static T instance;
    public static T Instance
    {
        get
        {
            if (instance == null)
            {
                Debug.LogError(typeof(T) + "ÇÕÇ†ÇËÇ‹ÇπÇÒÅB");
                return null;
            }

            return instance;
        }
    }

    protected void Awake()
    {
        if (instance == null) instance = this as T;
        else Destroy(this.gameObject);

        if (canLiveSceneOver == true) DontDestroyOnLoad(this.gameObject);
    }
}
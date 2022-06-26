//Lisa Fröhlich Gabra, ER, P6, "HEL: The Human Ecosystem Laboratory"

//Providing a singleton as a scriptable object

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SingletonObject<T> : ScriptableObject where T : ScriptableObject
{
    private static T _instance = null;

    public static T Instance
    {
        get
        {
            if (_instance == null)
            {
                //find all references of the singleton
                T[] results = Resources.FindObjectsOfTypeAll<T>();

                //preventing user error
                if (results.Length == 0) //if there are no results, the singleton has not been created
                {
                    Debug.LogError("SingletonVariable: results length is 0 of " + typeof(T).ToString());
                    return null;
                }
                if (results.Length > 1) //if there is more than one result, there are too many instances of the singleton
                {
                    Debug.LogError("SingletonVariable: results length is greater than 1 of " + typeof (T).ToString());
                    return null;
                }

                _instance = results[0];
                _instance.hideFlags = HideFlags.DontUnloadUnusedAsset;
            }

            return _instance;
        }
    }
}

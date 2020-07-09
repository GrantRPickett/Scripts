using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainComponentManger {

    // init instanced managers
    // Start is called before the first frame update
    private static MainComponentManger instance;
    public static void CreateInstance () {
        if (instance == null) {
            instance = new MainComponentManger ();
            GameObject go = GameObject.Find ("Main");
            if (go == null) {
                go = new GameObject ("Main");
                instance.main = go;
                // important: make game object persistent:
                Object.DontDestroyOnLoad (go);
            }
            // trigger instantiation of other
        }
    }

    GameObject main;

    public static MainComponentManger SharedInstance {
        get {
            if (instance == null) {
                CreateInstance ();
            }
            return instance;
        }
    }

    public static T AddMainComponent <T> () where T : UnityEngine.Component {
        T t = SharedInstance.main.GetComponent<T> ();
        if (t != null) {
            return t;
        }
        return SharedInstance.main.AddComponent <T> ();
    }
}

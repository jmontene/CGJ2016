using UnityEngine;
using System.Collections;

public class UnitySingleton<T> : MonoBehaviour where T : Component {

    // the static variable to hold this instance that will be able to be referenced everywhere
    private static T instance;

    // Custom property that returns the current non destroyable instance
    public static T Instance {
        get {

            // If there is currently no reference to sub class instance...
            if (instance == null) {

                // See if there is already an object of that type in scene, and reference to it
                instance = FindObjectOfType(typeof(T)) as T;

                //IF the search failed and we didn't find anything, make a new game object, 
                // And add a script of subclass T to it, and hide it
                if (instance == null) {
                    GameObject obj = new GameObject();

                    // Object is not visible in the editor ,
                    // And supposedly the garbage collector wont destroy it
                    //obj.hideFlags = HideFlags.HideAndDontSave;
                    instance = obj.AddComponent(typeof(T)) as T;
                }
            }
            return instance;
        }
    }

    public virtual void Awake() {
        if (instance == null) {
            instance = this as T;
        } else {
            Destroy(gameObject);
        }
    }

}

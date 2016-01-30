using UnityEngine;
using System.Collections;

public class DestroyByBoundary : MonoBehaviour
{
    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Professor") {
            GameManager.Instance.setProfAware(false);
        }
        Destroy(other.gameObject);

    }
}

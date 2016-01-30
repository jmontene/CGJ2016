using UnityEngine;
using System.Collections;

public class DestroyByBoundary : MonoBehaviour
{
    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Professor") {
            BattleManager.Instance.setProfAware(false);
        }
        Destroy(other.gameObject);

    }
}

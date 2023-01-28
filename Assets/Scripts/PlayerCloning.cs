using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCloning : MonoBehaviour
{
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Door"))
        {

        }
    }
}

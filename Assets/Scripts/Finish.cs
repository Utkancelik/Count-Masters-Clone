using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Finish : MonoBehaviour
{
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("FinishLine"))
        {
            StartCoroutine(Relocate());
        }
    }

    private IEnumerator Relocate()
    {
        for (int i = 1; i < transform.childCount; i++)
        {
            transform.GetChild(i).GetComponent<Collider>().isTrigger = true;
            transform.GetChild(i).GetComponent<Rigidbody>().useGravity = false;
            transform.GetChild(i).GetComponent<NavMeshAgent>().enabled = false;
            transform.GetChild(i).transform.localPosition = new Vector3(transform.position.x,
                transform.position.y + (i / 5) / 2.0f, transform.position.z + (i / 5) / 2.0f);
            yield return new WaitForSeconds(.1f);
        }

    }
}

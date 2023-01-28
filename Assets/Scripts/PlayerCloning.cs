using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCloning : MonoBehaviour
{
    [SerializeField] private GameObject clonePrefab;
    [SerializeField] private float X, Z;
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Door"))
        {
            Door door = other.GetComponent<Door>();
            if (door != null)
            {
                int cloneNumber = door.cloneNumber;
                ClonePlayer(cloneNumber);
            }
        }
    }

    private void ClonePlayer(int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            float randomX = Random.Range(-X, X);
            float randomZ = Random.Range(-Z, Z);
            Vector3 clonePos = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);
            Instantiate(clonePrefab, clonePos, Quaternion.identity, this.transform);
        }
    }
}

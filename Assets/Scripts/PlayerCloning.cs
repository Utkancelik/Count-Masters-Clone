using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class PlayerCloning : MonoBehaviour
{
    [SerializeField] private GameObject playerPrefab;
    [SerializeField] private float distanceFactor, radius, speed;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Door"))
        {
            // clone here
            Door door = other.GetComponent<Door>();
            ClonePlayer(door.randomCloneNumber);
        }
    }

    private void ClonePlayer(int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            Instantiate(playerPrefab, transform.position, Quaternion.identity, this.transform);
        }

        RelocateTheClones();
    }

    private void RelocateTheClones()
    {
        for (int i = 1; i < transform.childCount; i++)
        {
            float x = distanceFactor * Mathf.Sqrt(i) * Mathf.Cos(i * radius);
            float z = distanceFactor * Mathf.Sqrt(i) * Mathf.Sin(i * radius);

            Vector3 NewPos = new Vector3(x + transform.position.x, transform.position.y, transform.position.z + z);

            Transform child = transform.GetChild(i);

            child.GetComponent<Rigidbody>().MovePosition(NewPos);

        }
    }
}

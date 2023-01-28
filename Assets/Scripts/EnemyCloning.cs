using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EnemyCloning : MonoBehaviour
{
    [SerializeField] private GameObject clonePrefab;
    [SerializeField] private float X, Z;
    [SerializeField] public TextMeshPro bodyCountText;

    public int bodyCount = 0;
    private int randomEnemyClone;
    private void Start()
    {
        randomEnemyClone = Random.Range(5, 16);

        CloneEnemy(randomEnemyClone);
    }

    private void CloneEnemy(int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            float randomX = Random.Range(-X, X);
            float randomZ = Random.Range(-Z, Z);
            Vector3 clonePos = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);
            Instantiate(clonePrefab, clonePos, Quaternion.identity, this.transform);
            bodyCount++;
            bodyCountText.text = bodyCount.ToString();
        }
    }

    
}

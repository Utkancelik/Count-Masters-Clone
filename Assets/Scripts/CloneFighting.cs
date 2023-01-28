using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloneFighting : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            print("ENEMY");
            EnemyCloning enemyCloning = collision.gameObject.transform.parent.GetComponent<EnemyCloning>();
            PlayerCloning playerCloning = gameObject.transform.parent.GetComponent<PlayerCloning>();
            if (enemyCloning != null && playerCloning != null)
            {
                int numberOfEnemy = enemyCloning.bodyCount;
                int numberOfPlayer = playerCloning.bodyCount;
                Destroy(collision.gameObject);
                Destroy(gameObject);
                numberOfEnemy--;
                numberOfPlayer--;
                enemyCloning.bodyCount = numberOfEnemy;
                playerCloning.bodyCount = numberOfPlayer;
                enemyCloning.bodyCountText.text = enemyCloning.bodyCount.ToString();
                playerCloning.bodyCountText.text = playerCloning.bodyCount.ToString();
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("EnemyArea"))
        {
            GetComponent<Rigidbody>().isKinematic = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("EnemyArea"))
        {
            GetComponent<Rigidbody>().isKinematic = true;
        }
    }
}

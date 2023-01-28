using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloneFighting : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            EnemyCloning enemyCloning = collision.gameObject.transform.parent.GetComponent<EnemyCloning>();
            PlayerCloning playerCloning = gameObject.transform.parent.GetComponent<PlayerCloning>();


            if (enemyCloning != null && playerCloning != null)
            {
                Destroy(collision.gameObject);
                Destroy(gameObject);
                enemyCloning.bodyCount--;
                playerCloning.bodyCount--;
                if (enemyCloning.bodyCount < 0)
                {
                    enemyCloning.bodyCountText.text = "0";
                }
                else
                {
                    enemyCloning.bodyCountText.text = enemyCloning.bodyCount.ToString();
                }
                if (playerCloning.bodyCount < 0)
                {
                    playerCloning.bodyCountText.text = "0";
                }
                else
                {
                    playerCloning.bodyCountText.text = playerCloning.bodyCount.ToString();
                }

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

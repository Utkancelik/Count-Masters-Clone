using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private GameObject ground;

    public float horizontalMoveSpeed = 5f, forwardMoveSpeed = 5f, enemyAreaMovementSpeed;

    private Vector3 moveDirection;

    private bool inEnemyArea = false;

    private EnemyCloning enemyScript;
    private void Update()
    {
        if (!inEnemyArea)
            Move();
        else
            EnemyAreaMove(enemyScript);
    }

    private void EnemyAreaMove(EnemyCloning enemyScript)
    {

        moveDirection = (new Vector3(enemyScript.transform.position.x, enemyScript.transform.position.y,
        enemyScript.transform.position.z) - transform.position).normalized;
        transform.position += enemyAreaMovementSpeed * Time.deltaTime * moveDirection;
        ground.transform.Translate(enemyAreaMovementSpeed * Time.deltaTime * -transform.forward);

        if (enemyScript.bodyCount <= 0)
            inEnemyArea = false;



    }

    private void Move()
    {
        if (Input.GetMouseButton(0))
        {
            moveDirection = new Vector3(Input.GetAxisRaw("Mouse X"), 0f, 0f).normalized;
            transform.position += horizontalMoveSpeed * Time.deltaTime * moveDirection;
            ground.transform.Translate(forwardMoveSpeed * Time.deltaTime * -transform.forward);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("EnemyArea"))
        {
            enemyScript = other.GetComponent<EnemyCloning>();

            if (enemyScript != null)
            {
                inEnemyArea = true;
            }
        }
    }
}

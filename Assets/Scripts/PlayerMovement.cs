using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float horizontalMoveSpeed = 5f, forwardMoveSpeed = 5f;

    private Vector3 moveDirection;

    [SerializeField] private GameObject environment;

    
    private void Update()
    {
        Move();
    }

    private void Move()
    {
        if (Input.GetMouseButton(0))
        {
            moveDirection = new Vector3(Input.GetAxisRaw("Mouse X"), 0f, 0f).normalized;
            transform.position += horizontalMoveSpeed * Time.deltaTime * moveDirection;

            environment.transform.Translate(-transform.forward * Time.deltaTime * forwardMoveSpeed);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private GameObject ground;

    public float horizontalMoveSpeed = 5f, forwardMoveSpeed = 5f;

    private Vector3 moveDirection;

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
            ground.transform.Translate(forwardMoveSpeed * Time.deltaTime * -transform.forward);
        }
    }
}

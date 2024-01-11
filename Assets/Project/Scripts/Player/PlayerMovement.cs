using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Stats")]
    [SerializeField]
    private float speed = 5f;

    [Space(10)]

    [Header("Components")]
    [SerializeField]
    private Animator anim;
    [SerializeField]
    private Rigidbody2D rb;
    void FixedUpdate()
    {
        Move();
    }
    void Move()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontalInput, verticalInput, 0f);
        movement = movement.normalized;

        Vector2 newPosition = rb.position + new Vector2(movement.x, movement.y) * speed * Time.deltaTime;
        rb.MovePosition(newPosition);

        SetMoveAnim();
        SetRotation();


        #region internal methods
        void SetRotation()
        {
            if (movement.x > 0)
                transform.rotation = Quaternion.Euler(0, 0, 0);
            else if(movement.x < 0)
                transform.rotation = Quaternion.Euler(0, 180, 0);
        }

        void SetMoveAnim()
        {
            if (movement.magnitude > 0)
                anim.SetBool("Moving", true);
            else
                anim.SetBool("Moving", false);
        }
        #endregion
    }
}

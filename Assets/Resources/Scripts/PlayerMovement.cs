using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed, jumpforce, mouseSens, sphereRadius;
    public string groundName;

    private Rigidbody rb;
    private float x, z, mouseX;
    private bool jumpPressed;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Start is called before the first frame update
    void Update()
    {
        x = Input.GetAxisRaw("Horizontal");
        z = Input.GetAxisRaw("Vertical");
        mouseX = Input.GetAxisRaw("Mouse X");
        if(Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            jumpPressed = true;
        }

        RotatePlayer();

    }

    void RotatePlayer()
    {
        Vector3 rotation = new Vector3(0, mouseX, 0) * mouseSens * Time.deltaTime;
        transform.Rotate(rotation);
    }

    private void FixedUpdate()
    {
        ApplySpeed();

        ApplyJumpForce();
    }

    void ApplySpeed()
    {
        rb.velocity = (transform.forward * speed * z) + (transform.right * speed * x) + new Vector3(0, rb.velocity.y, 0);
    }

    void ApplyJumpForce()
    {
        if (jumpPressed)
        {
            rb.velocity = new Vector3(rb.velocity.x, 0, rb.velocity.z);
            rb.AddForce(transform.up * jumpforce);
            jumpPressed = false;
        }
    }

    private bool IsGrounded()
    {
        RaycastHit[] colliders = Physics.SphereCastAll(new Vector3(transform.position.x, transform.position.y - transform.localScale.y / 2, transform.position.z), sphereRadius, Vector3.up);

        for(int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].collider.gameObject.layer == LayerMask.NameToLayer(groundName))
            {
                return true;
            }
        }

        return false;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(new Vector3(transform.position.x, transform.position.y - transform.localScale.y / 2, transform.position.z), sphereRadius);
    }
}

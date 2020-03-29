using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private LayerMask ground;
    [SerializeField] private float height = 5f;
    private SphereCollider sphCollider;
    private Rigidbody rb;

    private void Start()
    {
        sphCollider = GetComponent<SphereCollider>();
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !isGrounded())
        {
            rb.velocity = Vector3.up * 100f;
        }
    }

    void LateUpdate()
    {
        //Debug.Log(isGrounded());
        Vector3 moveDirection = 
            moveSpeed 
            * Time.deltaTime 
            * new Vector3(Input.GetAxis("Horizontal"), 
                    0, 
                    Input.GetAxis("Vertical")) 
                .normalized;

        transform.position += moveDirection;
    }

    private bool isGrounded()
    {
        Ray ray = new Ray(sphCollider.bounds.center, Vector3.down);
        return Physics.SphereCast(ray, sphCollider.radius, sphCollider.bounds.extents.y + height, ground);
    }
}

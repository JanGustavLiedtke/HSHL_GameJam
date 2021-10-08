using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private Rigidbody2D _rb;
    private CapsuleCollider2D _collider;
    private BoxCollider2D _groundTrigger;
    private float _move;
    private bool _isMassIncreaseRunning;

    [SerializeField] private float moveSpeed = 10f;

    [SerializeField] private float jumpForce = 160f;
    [SerializeField] private float jumpCooldownMS = 200f;
    [SerializeField] private bool canJump = true;
    
    [SerializeField] private float groundCheckDist = .1f;
    [SerializeField] private bool isGrounded = true;
    

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _collider = GetComponent<CapsuleCollider2D>();
        _groundTrigger = GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        if (canJump) 
            isGrounded = _groundTrigger.Cast(Vector2.down, new ContactFilter2D(), new List<RaycastHit2D>(), groundCheckDist) > 0;

        if (!isGrounded && !_isMassIncreaseRunning)
            StartCoroutine(IncreaseMass());
        
        _move = Input.GetAxis("Horizontal");

        if (Input.GetButtonDown("Jump") && canJump && isGrounded)
            Jump();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Jump()
    {
        _rb.velocity *= Vector2.right;
        _rb.AddForce(Vector2.up * jumpForce);
        isGrounded = false;
        StartCoroutine(JumpCooldown());
    }

    private void Move()
    {
        _rb.velocity = _move * moveSpeed * Vector2.right + _rb.velocity.y * Vector2.up;
    }

    private IEnumerator JumpCooldown()
    {
        canJump = false;
        yield return new WaitForSeconds(jumpCooldownMS * 0.001f);
        canJump = true;
    }

    private IEnumerator IncreaseMass()
    {
        _isMassIncreaseRunning = true;
        float startMass = _rb.mass;
        //yield return new WaitForSeconds(jumpCooldownMS * 0.001f);
        while (!isGrounded)
        {
            _rb.mass *= 1.1f;
            yield return new WaitForSeconds(.1f);
        }

        _rb.mass = startMass;
        _isMassIncreaseRunning = false;
    }
}

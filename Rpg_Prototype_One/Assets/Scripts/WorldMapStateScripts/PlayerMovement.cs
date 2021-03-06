﻿using UnityEngine;

public class PlayerMovement : MonoBehaviour, IMove, IUpdatable, IExitable, IEnterable
{
    private Rigidbody2D rb;
    private float speed = 2f;
    private Vector2 moveVector;
    private bool canMove = true;
    private Vector3 lastPos;
    private bool isMoving;

    public bool IsMoving { get { return isMoving; } }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void Move(float vert, float horz)
    {
        if (canMove)
            moveVector = new Vector2(horz * speed, vert * speed);
    }

    public void OnUpdate()
    {
        rb.velocity = moveVector;
        isMoving = (rb.velocity != Vector2.zero);
    }

    public void OnExit()
    {
        isMoving = false;
        canMove = false;
        rb.velocity = Vector2.zero;
        lastPos = rb.transform.position;
    }

    public void OnEnter()
    {
        canMove = true;
        rb.transform.position = lastPos;
    }
}

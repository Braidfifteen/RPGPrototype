using UnityEngine;

public class PlayerMovement : MonoBehaviour, IMove, IUpdatable
{
    private Rigidbody2D rb;
    private float speed = 2f;
    private Vector2 moveVector;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void Move(float vert, float horz)
    {
        moveVector = new Vector2(horz * speed, vert * speed);
    }

    public void OnUpdate()
    {
        rb.velocity = moveVector;
    }
}

using UnityEngine;

public class PlayerMovement : MonoBehaviour, IMove
{
    private Rigidbody2D rb;
    private float speed = 10f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void Move(float vert, float horz)
    {
        rb.velocity = new Vector2(horz * speed, vert * speed);
    }
}

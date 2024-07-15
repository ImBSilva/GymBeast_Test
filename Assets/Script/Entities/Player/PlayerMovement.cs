using UnityEngine;

public class PlayerMovement : MonoBehaviour, IMovable
{
    public float speed = 5f;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    public void Move(Vector3 direction)
    {
        rb.velocity = new Vector3(direction.x * speed, rb.velocity.y, direction.z * speed);
    }
}

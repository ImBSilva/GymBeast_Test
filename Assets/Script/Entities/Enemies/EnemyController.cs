using UnityEngine;

public class EnemyController : MonoBehaviour, IStackable
{
    private Rigidbody rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        rb.isKinematic = true;
    }

    public void Stack()
    {
        rb.isKinematic = true; 
        transform.rotation = Quaternion.Euler(90, 0, 0); 
    }

    public void Unstack()
    {
        rb.isKinematic = false;
    }
}

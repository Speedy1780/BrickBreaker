using UnityEngine;

public class BallMovement : MonoBehaviour
{
    private const int BallLayer = 9;
    private const int IgnorePhysicsLayer = 8;
    [SerializeField] private Rigidbody rb;
    [SerializeField] private float speed = 4;
    Vector3 lastVelocity;
    Transform myTransform;

    void Start()
    {
        if (rb == null)
            rb = GetComponent<Rigidbody>();

        myTransform = transform;
    }

    private void LateUpdate() => lastVelocity = rb.velocity;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            rb.velocity = (myTransform.position - collision.transform.position).normalized * speed;
        }
        else
        {
            Bounce(collision.GetContact(0).normal);


            if (collision.gameObject.CompareTag("Brick"))
                Destroy(collision.gameObject);
        }
    }

    void Bounce(Vector3 normal)
    {
        rb.velocity = Vector3.Reflect(lastVelocity, normal).normalized * speed;

        //Prevent ball being stuck in place
        if (rb.velocity.magnitude == 0)
            rb.velocity = Vector3.up * speed;
    }

    public void Shoot(Vector3 direction)
    {
        rb.velocity = direction * speed;
        Invoke("Active", 0.2f);
    }

    void Active()
    {
        gameObject.layer = BallLayer;

    }
}

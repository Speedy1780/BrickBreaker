using UnityEngine;

public class BallMovement : MonoBehaviour
{
    private const int BallLayer = 9;
    private const int IgnorePhysicsLayer = 8;
    [SerializeField] private Rigidbody rb;
    [SerializeField] private float speed = 4;
    Vector3 lastVelocity;
    Transform myTransform;
    PoolID ID => PoolID.Ball;

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
                PoolManager.Instance.AddToPool(PoolID.Brick, collision.gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Respawn"))
            PoolManager.Instance.AddToPool(ID, gameObject);
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
        Invoke(nameof(Active), 0.2f);
    }

    void Active() => gameObject.layer = BallLayer;
}
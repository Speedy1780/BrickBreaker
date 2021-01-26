using System.Collections;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    private const int maxBalls = 3;
    private const int BallLayer = 9;
    private const int IgnorePhysicsLayer = 8;
    private static int ballCount = 0;
    private static bool isOnFire;

    [SerializeField] private Rigidbody rb;
    [SerializeField] private float speed = 7;
    private Vector3 lastVelocity;
    private Transform myTransform;
    private PoolID ID => PoolID.Ball;

    void Start()
    {
        if (rb == null)
            rb = GetComponent<Rigidbody>();

        myTransform = transform;
    }

    private void OnEnable()
    {
        EventManager.EDoubleBalls += SpawnBalls;
        EventManager.EFireBalls += ActivateFireBalls;
    }

    private void OnDisable()
    {
        EventManager.EDoubleBalls -= SpawnBalls;
        EventManager.EFireBalls -= ActivateFireBalls;
    }

    private void LateUpdate() => lastVelocity = rb.velocity;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
            rb.velocity = (myTransform.position - collision.transform.position).normalized * speed;
        else if (collision.gameObject.CompareTag("Brick"))
        {
            if (!isOnFire)
                Bounce(collision.GetContact(0).normal);
            else
                rb.velocity = lastVelocity;
        }
        else
            Bounce(collision.GetContact(0).normal);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Respawn"))
        {
            Deactivate();

            if (ballCount == 0)
                EventManager.InvokeLifeLost();
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
        Invoke(nameof(Activate), 0.2f);
    }

    void Activate()
    {
        gameObject.layer = BallLayer;
        ballCount++;
    }

    void Deactivate()
    {
        ballCount -= 1;
        PoolManager.Instance.AddToPool(ID, gameObject);
        gameObject.layer = IgnorePhysicsLayer;
        rb.velocity = Vector3.zero;
    }

    void SpawnBalls()
    {
        for (; ballCount < maxBalls; ballCount++)
        {
            GameObject ball = PoolManager.Instance.GetPooledObject(ID);
            ball.transform.SetPositionAndRotation(myTransform.position, Quaternion.identity);
            ball.layer = BallLayer;
            ball.GetComponent<Rigidbody>().velocity = Quaternion.Euler(Vector3.forward * Random.Range(-45, 45f)) * rb.velocity;
        }
    }

    void ActivateFireBalls(float duration)
    {
        if (!isOnFire)
        {
            Debug.Log("Activating on fire");
            isOnFire = true;
            StartCoroutine(DeactivateFireBalls(duration));
        }
    }

    IEnumerator DeactivateFireBalls(float duration)
    {
        yield return new WaitForSeconds(duration);
        isOnFire = false;
        Debug.Log("Deactivating on fire");
    }
}
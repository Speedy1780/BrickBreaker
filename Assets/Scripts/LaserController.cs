using UnityEngine;

public class LaserController : MonoBehaviour
{
    private const int IgnorePhysics = 8;
    private const int LaserLayer = 11;

    [SerializeField] private Rigidbody rb;
    [SerializeField] private float speed;
    private PoolID ID => PoolID.Laser;

    private void OnEnable()
    {
        if (rb == null)
            rb = GetComponent<Rigidbody>();

        rb.velocity = Vector3.up * speed;
        Invoke(nameof(Activate), 0.2f);
    }

    private void OnCollisionEnter(Collision collision)
    {
        PoolManager.Instance.AddToPool(ID, gameObject);
        rb.velocity = Vector3.zero;
        gameObject.layer = IgnorePhysics;
    }

    void Activate() => gameObject.layer = LaserLayer;
}
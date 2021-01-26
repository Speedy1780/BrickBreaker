using UnityEngine;

public class BrickController : MonoBehaviour
{
    [SerializeField] private int score = 100;
    private static PoolID ID => PoolID.Brick;

    private void OnCollisionEnter(Collision collision)
    {
        GameObject power = PoolManager.Instance.GetPooledObject(PoolID.PowerUp);
        power.transform.position = transform.position;
        power.GetComponent<Rigidbody>().velocity = Vector3.down * 5;

        EventManager.InvokeAddScore(score);
        PoolManager.Instance.AddToPool(ID, gameObject);
    }
}
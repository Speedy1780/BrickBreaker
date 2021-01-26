using UnityEngine;

public class BrickController : MonoBehaviour
{
    [SerializeField] private int score = 100;
    private static PoolID ID => PoolID.Brick;

    private void OnCollisionEnter(Collision collision)
    {
        EventManager.InvokeSpawnPower(transform.position);
        EventManager.InvokeAddScore(score);
        PoolManager.Instance.AddToPool(ID, gameObject);
    }
}
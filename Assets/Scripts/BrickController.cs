using UnityEngine;

public class BrickController : MonoBehaviour
{
    [SerializeField] private int powerUpChance = 20;
    [SerializeField] private int score = 100;
    private static PoolID ID => PoolID.Brick;

    private void OnCollisionEnter(Collision collision)
    {
        if (Random.Range(0, 100) < powerUpChance)
            EventManager.InvokeSpawnPower(transform.position);

        EventManager.InvokeAddScore(score);
        PoolManager.Instance.AddToPool(ID, gameObject);
    }
}
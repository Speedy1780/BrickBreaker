using UnityEngine;

public class BrickController : MonoBehaviour
{
    [SerializeField] private int powerUpChance = 20;
    [SerializeField] private int score = 100;
    private bool addedToPool;

    private static PoolID ID => PoolID.Brick;
    private static int brickCount = 0;

    private void OnEnable()
    {
        brickCount += 1;
        addedToPool = false;
    }

    private void OnDisable()
    {
        brickCount -= 1;
    }

    private void Start()
    {
        UIManager.Instance.SetScore(brickCount);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!addedToPool)
        {
            addedToPool = true;

            if (Random.Range(0, 100) < powerUpChance)
                EventManager.InvokeSpawnPower(transform.position);

            EventManager.InvokeAddScore(score);
            PoolManager.Instance.AddToPool(ID, gameObject);
            UIManager.Instance.SetScore(brickCount);

            if (brickCount <= 0)
                EventManager.InvokeGameEnded();
        }
    }
}
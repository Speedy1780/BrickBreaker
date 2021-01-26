using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] private int numberOfLifes = 2;
    [SerializeField] private PlayerShooting player;

    private void OnEnable()
    {
        EventManager.lifeLost += LifeLost;
    }

    private void OnDisable()
    {
        EventManager.lifeLost -= LifeLost;
    }

    private void Start()
    {
        player.StartShoot();
    }

    private void LifeLost()
    {
        numberOfLifes -= 1;

        if (numberOfLifes < 0)
            Debug.Log("Game Over");
        else
            player.StartShoot();
    }
}
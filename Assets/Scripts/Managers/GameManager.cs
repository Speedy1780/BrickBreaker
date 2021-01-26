using System.Collections;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] private int numberOfLifes = 2;
    [SerializeField] private PlayerShooting player;
    [SerializeField] private Transform brickParents;

    private void OnEnable()
    {
        EventManager.ELifeLost += LifeLost;
    }

    private void OnDisable()
    {
        EventManager.ELifeLost -= LifeLost;
    }

    private void Start()
    {
        player.StartShoot();
        StartCoroutine(EndGame());
    }

    private void LifeLost()
    {
        numberOfLifes -= 1;

        if (numberOfLifes < 0)
            Debug.Log("Game Over");
        else
            player.StartShoot();
    }

    IEnumerator EndGame()
    {
        yield return new WaitUntil(() => brickParents.childCount == 0);
        Debug.Log("Game won");
    }
}
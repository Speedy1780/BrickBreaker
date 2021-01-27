using System.Collections;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] private int numberOfLifes = 2;
    [SerializeField] private PlayerShooting player;
    [SerializeField] private float timeTransitionSpeed = 1;
    [SerializeField] private SpawnBricks brickSpawner;

    private float slowMotionDuration;

    private void OnEnable()
    {
        EventManager.ELifeLost += LifeLost;
        EventManager.EGameEnded += GameEnded;
        EventManager.ESlowTime += ActivateSlowMotion;
    }

    private void OnDisable()
    {
        EventManager.ELifeLost -= LifeLost;
        EventManager.EGameEnded -= GameEnded;
        EventManager.ESlowTime -= ActivateSlowMotion;
    }

    private void Start()
    {
        player.StartShoot();
        UIManager.Instance.SetLife(numberOfLifes);
    }

    private void GameEnded()
    {
        UIManager.Instance.ShowEndMenu(numberOfLifes < 0);
    }

    public void PlayAgain()
    {
        if (numberOfLifes >= 0)
        {
            brickSpawner.AddBricks();
            numberOfLifes += 1;
        }
        else
        {
            numberOfLifes = 2;
            ScoringManager.Instance.ResetScore();
        }

        brickSpawner.PlaceBricks();
        player.StartShoot();
        UIManager.Instance.SetLife(numberOfLifes);
        UIManager.Instance.HideEndMenu();
    }

    private void LifeLost()
    {
        numberOfLifes -= 1;
        UIManager.Instance.SetLife(numberOfLifes);

        if (numberOfLifes < 0)
            EventManager.InvokeGameEnded();
        else
            player.StartShoot();
    }

    private void ActivateSlowMotion(float duration, float factor)
    {
        if (slowMotionDuration <= 0)
            StartCoroutine(SlowTime(factor));

        slowMotionDuration += duration;
    }

    IEnumerator SlowTime(float factor)
    {
        yield return StartCoroutine(ScaleTime(factor));

        while (slowMotionDuration > 0)
        {
            slowMotionDuration -= Time.unscaledDeltaTime;
            yield return null;
        }

        slowMotionDuration = 0;
        yield return StartCoroutine(ScaleTime(1));
    }

    IEnumerator ScaleTime(float target)
    {
        while (Time.timeScale != target)
        {
            Time.timeScale = Mathf.MoveTowards(Time.timeScale, target, timeTransitionSpeed * Time.unscaledDeltaTime);
            yield return null;
        }
    }
}
using System.Collections;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] private int numberOfLifes = 2;
    [SerializeField] private PlayerShooting player;
    [SerializeField] private float timeTransitionSpeed;

    private float slowMotionDuration;

    private void OnEnable()
    {
        EventManager.ELifeLost += LifeLost;
        EventManager.ESlowTime += ActivateSlowMotion;
    }

    private void OnDisable()
    {
        EventManager.ELifeLost -= LifeLost;
        EventManager.ESlowTime -= ActivateSlowMotion;
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
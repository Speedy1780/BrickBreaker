using UnityEngine;

public class EventManager
{
    public delegate void AddScore(int points);
    public static event AddScore EAddScore;
    public static void InvokeAddScore(int points) => EAddScore?.Invoke(points);

    public delegate void LifeLost();
    public static event LifeLost ELifeLost;
    public static void InvokeLifeLost() => ELifeLost?.Invoke();

    public delegate void SpawnPowerUp(Vector3 spawnPosition);
    public static event SpawnPowerUp ESpawnPowerUp;
    public static void InvokeSpawnPower(Vector3 spawnPosition) => ESpawnPowerUp?.Invoke(spawnPosition);

    public delegate void DoubleSize(float duration);
    public static event DoubleSize EDoubleSize;
    public static void InvokeDoubleSize(float duration) => EDoubleSize?.Invoke(duration);

    public delegate void SlowTime(float duration, float factor);
    public static event SlowTime ESlowTime;
    public static void InvokeSlowTime(float duration, float factor) => ESlowTime?.Invoke(duration, factor);

    public delegate void DoubleBalls();
    public static event DoubleBalls EDoubleBalls;
    public static void InvokeDoubleBalls() => EDoubleBalls?.Invoke();

    public delegate void FireBalls(float duration);
    public static event FireBalls EFireBalls;
    public static void InvokeFireBalls(float duration) => EFireBalls?.Invoke(duration);

    public delegate void Laser(float duration);
    public static event Laser ELaser;
    public static void InvokeLaser(float duration) => ELaser?.Invoke(duration);

    public delegate void GameEnded();
    public static event GameEnded EGameEnded;
    public static void InvokeGameEnded() => EGameEnded?.Invoke();
}
using UnityEngine;

public class EventManager
{
    public delegate void AddScore(int points);
    public static event AddScore addScore;
    public static void InvokeAddScore(int points) => addScore?.Invoke(points);

    public delegate void LifeLost();
    public static event LifeLost lifeLost;
    public static void InvokeLifeLost() => lifeLost?.Invoke();

    public delegate void SpawnPowerUp(Vector3 spawnPosition);
    public static event SpawnPowerUp spawnPowerUp;
    public static void InvokeSpawnPower(Vector3 spawnPosition) => spawnPowerUp?.Invoke(spawnPosition);
}
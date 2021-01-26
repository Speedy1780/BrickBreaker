public class EventManager
{
    public delegate void AddScore(int points);
    public static event AddScore addScore;
    public static void InvokeAddScore(int points) => addScore?.Invoke(points);
}
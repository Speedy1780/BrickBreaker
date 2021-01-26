public class EventManager
{
    public delegate void AddScore(int points);
    public static event AddScore addScore;
}
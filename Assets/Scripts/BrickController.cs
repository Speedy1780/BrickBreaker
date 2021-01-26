using UnityEngine;

public class BrickController : MonoBehaviour
{
    [SerializeField] private int score = 100;

    private void OnDisable()
    {
        EventManager.InvokeAddScore(score);
    }
}
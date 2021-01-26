using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickController : MonoBehaviour
{
    [SerializeField] private int score = 100;

    private void OnDestroy()
    {
        Debug.Log("Brick destroyed");
        EventManager.InvokeAddScore(score);
    }
}
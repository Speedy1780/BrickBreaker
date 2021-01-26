﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoringManager : Singleton<ScoringManager>
{
    [SerializeField] private int score;
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
    }

    private void OnEnable()
    {
        EventManager.addScore += AddScore;
    }

    private void OnDisable()
    {
        EventManager.addScore -= AddScore;
    }

    void AddScore(int points)
    {
        score += points;
    }
}

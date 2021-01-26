using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : Singleton<UIManager>
{
    [SerializeField] private Text ScoreText;
    [SerializeField] private Text LifeText;

    public void SetScore(int score) => ScoreText.text = $"Score: {score}";
    public void SetLife(int lives) => LifeText.text = $"Life: {lives}";

}

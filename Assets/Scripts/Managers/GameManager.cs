using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] private int numberOfLifes = 3;
    [SerializeField] private PlayerShooting player;
    private void Start()
    {
        player.StartShoot();
    }
}
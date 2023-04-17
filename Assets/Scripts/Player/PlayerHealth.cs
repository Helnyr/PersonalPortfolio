using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class PlayerHealth : NetworkBehaviour
{
    private int lives = 10;
    private Player player;

    private void Start()
    {
        player = GetComponent<Player>();
        player.playerUI.UpdateLives(lives);
    }

    public void LoseLive()
    {
        lives--;
        player.playerUI.UpdateLives(lives);
        if (lives <= 0) Death();
    }

    public void Death()
    {
        MatchManager.instance.FinishGame();
        MatchManager.instance.SetLoser(player);
    }
}

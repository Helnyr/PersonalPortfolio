using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MatchManager : MonoBehaviour
{
    public static MatchManager instance { get; private set; }
    public List<Player> players = new List<Player>();
    public TMP_Text finalText;
    public bool startGame;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else Destroy(gameObject);
    }

    private void Start()
    {
        finalText.gameObject.SetActive(false);
    }

    public void AddPlayer (Player player)
    {
        players.Add(player);
        if (players.Count >= 2) StartGame();
    }

    public void RemovePlayer(Player player)
    {
        players.Remove(player);
        if (players.Count < 2) FinishGame();
    }

    public void StartGame()
    {
        startGame = true;
    }

    public void FinishGame()
    {
        startGame = false;
    }

    public void SetLoser(Player loser)
    {
        finalText.gameObject.SetActive(true);
        finalText.text = loser.playerName + ", you lost.";
    }
}

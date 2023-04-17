using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;
using Mirror;

public class Player : NetworkBehaviour
{
    public string playerName;

    public PlayerUI playerUI;
    public GameObject playerUIPrefab;

    [HideInInspector]public PlayerHealth health;
    [HideInInspector]public PlayerMovement movement;
    [HideInInspector]public PlayerPowerups powerups;

    public override void OnStartClient()
    {
        playerName = FindObjectOfType<RandomName>().GenerateRandomName();
        playerUI = Instantiate(playerUIPrefab, CanvasUI.GetPlayersPanel()).GetComponent<PlayerUI>();
        playerUI.UpdateName(playerName);
        MatchManager.instance.AddPlayer(this);
    }

    private void Start()
    {
        health = GetComponent<PlayerHealth>();
        movement = GetComponent<PlayerMovement>();
        powerups = GetComponent<PlayerPowerups>();
    }

    public override void OnStopClient()
    {
        MatchManager.instance.RemovePlayer(this);
    }
}
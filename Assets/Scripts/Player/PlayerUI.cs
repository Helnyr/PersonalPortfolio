using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using Mirror;
using TMPro;

public class PlayerUI : NetworkBehaviour
{
    public TMP_Text playerName;
    public TMP_Text playerLives;
    public TMP_Text playerPowerupOne;
    public TMP_Text playerPowerupTwo;

    public void UpdateName(string name) { playerName.text = "Name: " + name; }
    public void UpdateLives(int lives) { playerLives.text = "Lives: " + lives.ToString(); }
    public void UpdatePowerupOne(bool value) { playerPowerupOne.text = value.ToString(); }
    public void UpdatePowerupTwo(bool value) { playerPowerupTwo.text = value.ToString(); }
}

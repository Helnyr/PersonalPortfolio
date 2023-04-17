using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class PlayerPowerups : NetworkBehaviour
{
    private Player player;

    public Transform spawnPoint;

    public GameObject shield;
    public Material redShield;
    public Material orangeShield;

    private bool powerupOneActive = false;
    private bool powerupTwoActive = false;

    private bool powerupOne;
    private bool powerupTwo;

    private int collisionCounter;
    private int collisionCounterMax = 3;

    public bool hasPowerupOne
    {
        get { return powerupOne; }
        set
        {
            powerupOne = value;
            UpdateUI();
        }
    }

    public bool hasPowerupTwo
    {
        get { return powerupTwo; }
        set
        {
            powerupTwo = value;
            UpdateUI();
        }
    }

    void Start()
    {
        player = GetComponent<Player>();
        shield.SetActive(false);
        hasPowerupOne = false;
        hasPowerupTwo = false;
    }

    void Update()
    {
        if (isOwned)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1) && hasPowerupOne) UsePowerUpOne();
            if (Input.GetKeyDown(KeyCode.Alpha2) && hasPowerupTwo) UsePowerUpTwo();
        }
    }

    public void GetPowerupOne() { hasPowerupOne = true; }
    public void GetPowerupTwo() { hasPowerupTwo = true; }

    private void UpdateUI()
    {
        player.playerUI.UpdatePowerupOne(hasPowerupOne);
        player.playerUI.UpdatePowerupTwo(hasPowerupTwo);
    }

    public void UsePowerUpOne()
    {
        ActiveShield(redShield);
        hasPowerupOne = false;
        powerupOneActive = true;
        StartCoroutine(PowerupOneTimer());
    }

    public void UsePowerUpTwo()
    {
        ActiveShield(orangeShield);
        hasPowerupTwo = false;
        powerupTwoActive = true;
        collisionCounter = collisionCounterMax;
    }

    public IEnumerator PowerupOneTimer()
    {
        yield return new WaitForSeconds(5);
        powerupOneActive = false;
        DisableShield();
    }

    public void ActiveShield(Material mat)
    {
        shield.GetComponent<MeshRenderer>().material = mat;
        shield.SetActive(true);
    }

    public void DisableShield() { shield.SetActive(false); }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ball")
        {
            Ball ball = collision.transform.GetComponent<Ball>();

            if (powerupOneActive)
            {
                ball.speed *= 1.5f;
            }

            //ARREGLAR AIXO
            if (powerupTwoActive && collisionCounter > 0 && !ball.isDuplicated)
            {
                collisionCounter--;
                ObjectSpawner spawner = FindObjectOfType<ObjectSpawner>();

                Ball newBall = (Instantiate(spawner.ball, spawnPoint.transform.position, Quaternion.identity, spawner.ballParent).GetComponent<Ball>());
                newBall.isDuplicated = true;
                spawner.activeBalls.Add(newBall.gameObject);

                if (collisionCounter <= 0)
                {
                    powerupTwoActive = false;
                    DisableShield();
                }
            }
        }
    }
}
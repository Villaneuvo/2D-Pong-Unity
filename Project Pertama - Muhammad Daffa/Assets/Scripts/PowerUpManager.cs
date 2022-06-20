using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpManager : MonoBehaviour
{
    public Transform spawnArea;
    public int maxPowerUpAmount;
    public int spawnInterval;
    public Vector2 powerUpAreaMin;
    public Vector2 powerUpAreaMax;

    public List<GameObject> powerUpTemplateList;

    private List<GameObject> powerUpList;
    private float timer;

    public GameObject ball;
    public float ballMagnitude;
    float BallSpeedDuration;
    public bool activationBallSpeed;
    public GameObject padelKiri;
    public GameObject padelKanan;

    float timeScaleUpPadLeft;
    float timeSpeedUpPadLeft;
    float timeScaleUpPadRight;
    float timeSpeedUpPadRight;

    public bool isActiveScaleUpPadLeft = false;
    public bool isActiveSpeedUpPadLeft = false;
    public bool isActiveScaleUpPadRight = false;
    public bool isActiveSpeedUpPadRight = false;

    public float DeleteInterval;

    private void Start()
    {
        powerUpList = new List<GameObject>();
        timer = 0;
    }

    private void Update()
    {
        timer += Time.deltaTime;

        if (timer > spawnInterval)
        {
            GenerateRandomPowerUp();
            timer -= spawnInterval;
        }
         //Durasi Buff BallSpeedUp
        if (activationBallSpeed == true)
        {
            if (BallSpeedDuration >= 5)
            {
                ball.GetComponent<BallController>().ResetSpeedBall(ballMagnitude);
                activationBallSpeed = false;
                BallSpeedDuration -= 5;
            }
            BallSpeedDuration += Time.deltaTime;
        }

        // Scale Left Pad Up Buff
        if (isActiveScaleUpPadLeft == true)
        {
            if (timeScaleUpPadLeft >= 5)
            {
                padelKiri.GetComponent<PaddleController>().ScaleDown(padelKiri);
                isActiveScaleUpPadLeft = false;
                timeScaleUpPadLeft -= 5;
            }
            timeScaleUpPadLeft += Time.deltaTime;
        }
        //Durasi Buff SpeedUp padelKiri
        if (isActiveSpeedUpPadLeft == true)
        {
            if (timeSpeedUpPadLeft>= 5)
            {
                padelKiri.GetComponent<PaddleController>().ResetSpeedPadle();
                isActiveSpeedUpPadLeft = false;
                timeSpeedUpPadLeft -= 5;
            }
            timeSpeedUpPadLeft += Time.deltaTime;
        }
        //Durasi Buff ScalepadelKanan
        if (isActiveScaleUpPadRight == true)
        {
            if (timeScaleUpPadRight >= 5)
            {
                padelKanan.GetComponent<PaddleController>().ScaleDown(padelKanan);
                isActiveScaleUpPadRight = false;
                timeScaleUpPadRight -= 5;
            }
            timeScaleUpPadRight += Time.deltaTime;
        }
        //Durasi Buff SpeedUp PadKanan
        if (isActiveSpeedUpPadLeft == true)
        {
            if (timeSpeedUpPadRight >= 5)
            {
                padelKanan.GetComponent<PaddleController>().ResetSpeedPadle();
                isActiveSpeedUpPadRight = false;
                timeSpeedUpPadRight -= 5;
            }
            timeSpeedUpPadRight += Time.deltaTime;
        }
    }

    public void GenerateRandomPowerUp()
    {
        GenerateRandomPowerUp(new Vector2(Random.Range(powerUpAreaMin.x, powerUpAreaMax.x), Random.Range(powerUpAreaMin.y, powerUpAreaMax.y)));
    }

    // Overloading
    public void GenerateRandomPowerUp(Vector2 position)
    {
        if (powerUpList.Count >= maxPowerUpAmount)
        {
            return;
        }

        if (position.x < powerUpAreaMin.x ||
        position.x > powerUpAreaMax.x ||
        position.y < powerUpAreaMin.y ||
        position.y > powerUpAreaMax.y)
        {
            return;
        }

        int randomIndex = Random.Range(0, powerUpTemplateList.Count);

        // Create Object
        // Quaternion.identity for rotation
        GameObject powerUp = Instantiate(powerUpTemplateList[randomIndex], new Vector3(position.x, position.y, powerUpTemplateList[randomIndex].transform.position.z), Quaternion.identity, spawnArea);
        powerUp.SetActive(true);

        powerUpList.Add(powerUp);

    }

    public void RemovePowerUp(GameObject powerUp)
    {
        powerUpList.Remove(powerUp);
        Destroy(powerUp);
    }

    public void RemoveAllPowerUp()
    {
        while (powerUpList.Count > 0)
        {
            RemovePowerUp(powerUpList[0]);
        }
    }
}

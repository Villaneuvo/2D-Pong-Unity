using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PUSpeedUpController : MonoBehaviour
{
    public PowerUpManager manager;
    // Check if its coillded with ball
    public Collider2D ball;
    public float magnitude;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other = ball)
        {
            ball.GetComponent<BallController>().ActivatePUSpeedUp(magnitude);
            manager.RemovePowerUp(gameObject);
        }
    }
}

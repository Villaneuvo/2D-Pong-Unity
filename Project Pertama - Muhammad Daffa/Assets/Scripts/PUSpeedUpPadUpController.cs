using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PUSpeedUpPadUpController : MonoBehaviour
{
    public PowerUpManager manager;
    public Collider2D bola;
    public BallController ball;
    public Collider2D padelKiri;
    public Collider2D padelKanan;
    
    float timer;

    void OnTriggerEnter2D(Collider2D other) {
        if (other == bola)
        {
            //donleft dan doneright digunakan untuk menghentikan penambahan dan mengembalikan value seperti semula pada paddle guna untuk memberikan gameplay yang lebih playable
            if (ball.isLeft && !manager.isActiveSpeedUpPadLeft)
            {
                manager.isActiveSpeedUpPadLeft = true;
                manager.padelKiri.GetComponent<PaddleController>().SpeedUpPadle();
                manager.RemovePowerUp(gameObject);
            }
            if (!ball.isLeft && !manager.isActiveSpeedUpPadRight)
            {
                manager.isActiveSpeedUpPadRight = true;
                manager.padelKanan.GetComponent<PaddleController>().SpeedUpPadle();
                manager.RemovePowerUp(gameObject);
            }
        }
    }

    void Update() {
        timer += Time.deltaTime;
        if (timer >= manager.DeleteInterval)
        {
            manager.RemovePowerUp(gameObject);
        }
    }
}

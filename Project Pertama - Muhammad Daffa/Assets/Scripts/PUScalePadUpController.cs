using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PUScalePadUpController : MonoBehaviour
{
   public PowerUpManager manager;
    public Collider2D bola;
    public BallController ball;
    
    float timer;

    void OnTriggerEnter2D(Collider2D other) {
        if (other == bola)
        {
            //donleft dan doneright digunakan untuk menghentikan penambahan dan mengembalikan value seperti semula pada paddle guna untuk memberikan gameplay yang lebih playable
            if (ball.isLeft && !manager.isActiveScaleUpPadLeft)
            {
                manager.isActiveScaleUpPadLeft = true;
                manager.padelKiri.GetComponent<PaddleController>().ScaleUp(manager.padelKiri);
                manager.RemovePowerUp(gameObject);
            }
            if (!ball.isLeft && !manager.isActiveScaleUpPadRight)
            {
                manager.isActiveScaleUpPadRight = true;
                manager.padelKanan.GetComponent<PaddleController>().ScaleUp(manager.padelKanan);
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

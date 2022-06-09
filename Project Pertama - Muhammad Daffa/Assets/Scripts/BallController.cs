using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public Vector2 speed;
    private Rigidbody2D rig;
    public Vector2 resetPosition;

    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        rig.velocity = speed;
    }

    // Update is called once per frame
    void Update()
    {
        // transform.position = transform.position + (new Vector3(0, 1f, 0) * Time.deltaTime);
        // transform.Translate(speed * Time.deltaTime);
    }

    public void ResetBall()
    {
        transform.position = new Vector3(resetPosition.x, resetPosition.y, 2);
    }
}

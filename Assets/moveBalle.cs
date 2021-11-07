using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveBalle : MonoBehaviour
{
    float gravity = 0f;
    Vector2 speed;
    // Update is called once per frame
    void Start()
    {
        Vector2 speed = new Vector2(1, 1);
        GetComponent<Rigidbody2D>().velocity = speed;
    }
    // Update is called once per frame
    void Update()
    {
        gravity = Input.GetAxis("Vertical");
    }
    void FixedUpdate()
    {
        //le rigidBody de l'objet attaché au script "GetComponent<Rigidbody2D>()"
        GetComponent<Rigidbody2D>().gravityScale = gravity;
    }
}

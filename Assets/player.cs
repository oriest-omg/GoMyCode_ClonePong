using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    Vector2 direction;
    public int x = 2;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Hello World!");
        Debug.Log(x);
        direction.x = 1;
        direction.y = direction.x * 5;
        Debug.Log(direction);
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        Debug.Log(x);
    }
}
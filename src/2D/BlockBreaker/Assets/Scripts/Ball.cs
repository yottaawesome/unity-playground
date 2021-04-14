using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    Paddle paddle;
    Rigidbody2D rigidBody;
    bool attached = true;

    // Start is called before the first frame update
    void Start()
    {
        paddle = FindObjectOfType<Paddle>();
        transform.SetParent(paddle.transform);
        rigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonUp(0))
        {
            if(attached)
            {
                transform.SetParent(null);
                rigidBody.AddForce(transform.up * 600f);
                attached = false;
            }
        }

        //gameObject.transform.position = paddle.transform.position + new Vector3(0, 1f);
    }
}

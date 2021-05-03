using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    float HorizontalSpeed = 10f;
    [SerializeField]
    float VerticalSpeed = 10f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move()
    {
        // Edit > Project Settings > Input Manager > Axes
        float deltaX = Input.GetAxis("Horizontal");
        float deltaY = Input.GetAxis("Vertical");
        // This makes it frame-rate independent
        // https://docs.unity3d.com/ScriptReference/Time-deltaTime.html
        float newXPos = transform.position.x + deltaX * Time.deltaTime * HorizontalSpeed;
        float newYPos = transform.position.y + deltaY * Time.deltaTime * VerticalSpeed;
        transform.position = new Vector3(newXPos, newYPos, transform.position.z);
    }
}

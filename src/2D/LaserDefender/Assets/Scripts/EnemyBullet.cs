using System.Collections;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    [SerializeField]
    float verticalSpeed = 5f;

    [SerializeField]
    float speedOfSpin = 0f;

    Rigidbody2D rigidBody;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        rigidBody.velocity = new Vector3(0, -verticalSpeed, 0);
    }

    void Update()
    {
        //transform.position += new Vector3(0, Time.deltaTime * verticalSpeed, 0);
        if (speedOfSpin > 0)
            transform.Rotate(0, 0, speedOfSpin * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "LaserShredder")
            Destroy(gameObject, 0);
    }
}

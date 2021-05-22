using System.Collections;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    [SerializeField]
    float verticalSpeed = 5f;

    Rigidbody2D rigidBody;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        rigidBody.velocity = new Vector3(0, -verticalSpeed, 0);
    }

    void Update()
    {
        //transform.position += new Vector3(0, Time.deltaTime * verticalSpeed, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "LaserShredder")
            Destroy(gameObject, 0);
    }
}

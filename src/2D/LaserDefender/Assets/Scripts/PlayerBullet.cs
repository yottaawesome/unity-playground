using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    [SerializeField]
    float verticalSpeed = 5f;

    [SerializeField]
    float timeToLiveSeconds = 5;

    Rigidbody2D rigidBody;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        rigidBody.velocity = new Vector3(0, verticalSpeed, 0);
        Destroy(gameObject, timeToLiveSeconds);
    }

    void Update()
    {
        //transform.position += new Vector3(0, Time.deltaTime * verticalSpeed, 0);
    }
}

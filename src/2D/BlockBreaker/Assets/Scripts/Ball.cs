using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField]
    float LaunchForce = 600f;

    Paddle paddle;
    Rigidbody2D rigidBody;
    bool attached = true;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        // Attach the ball to the paddle so it tracks it initially
        paddle = FindObjectOfType<Paddle>();
        transform.SetParent(paddle.transform);
    }

    // Update is called once per frame
    void Update()
    {
        if (attached && Input.GetMouseButtonUp(0))
        {
            int leftOrRight = new System.Random().Next(0, 2) == 1
                ? 1
                : -1;
            transform.SetParent(null);
            rigidBody.AddForce(
                new Vector2(
                    leftOrRight * 40f, 
                    transform.up.y * LaunchForce
                )
            );
            attached = false;
        }
    }
}

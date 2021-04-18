using UnityEngine;

public class Ball : MonoBehaviour
{
    // Config
    [SerializeField] float LaunchForce = 800f;
    [SerializeField] AudioClip[] ballSounds;
    [SerializeField] float SideForce = 40f;

    // State
    Paddle paddle;
    Rigidbody2D rigidBody;
    bool attached = true;
    AudioSource audioPlayer;

    // Start is called before the first frame update
    void Start()
    {
        audioPlayer = GetComponent<AudioSource>();
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
            int leftOrRight = -1 + Random.Range(0, 2) * 2;
            transform.SetParent(null);
            rigidBody.AddForce(
                new Vector2(
                    leftOrRight * SideForce, 
                    transform.up.y * LaunchForce
                )
            );
            attached = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // We can use collision.gameObject.name != "Block" to disable
        // this ball's sounds when hitting a block to avoid double
        // playing sounds
        if (ballSounds.Length > 0)
            audioPlayer.PlayOneShot(ballSounds[Random.Range(0, ballSounds.Length)]);
    }
}

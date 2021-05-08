using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    [SerializeField]
    float verticalSpeed = 5f;

    [SerializeField]
    float timeToLiveSeconds = 5;

    void Start()
    {
        Destroy(gameObject, timeToLiveSeconds);
    }

    void Update()
    {
        transform.position += new Vector3(0, Time.deltaTime * verticalSpeed, 0);
    }
}

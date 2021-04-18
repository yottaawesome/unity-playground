using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField] AudioClip[] destroySounds;

    Level level;

    void Start()
    {
        level = GameObject.FindWithTag("Level").GetComponent<Level>();
        level.AddBlock();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (destroySounds.Length > 0)
        {
            AudioSource.PlayClipAtPoint(
                destroySounds[Random.Range(0, destroySounds.Length)],
                Camera.current.transform.position
            );
        }
        
        level.RemoveBlock();
        Destroy(gameObject);
    }
}

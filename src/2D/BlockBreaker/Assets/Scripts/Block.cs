using UnityEngine;

public class Block : MonoBehaviour
{
    // Config
    [SerializeField] 
    AudioClip[] destroySounds;

    // State
    Level level;
    GameStatus gameStatus;

    #region Lifecycle
    void Start()
    {
        // https://docs.unity3d.com/2021.1/Documentation/ScriptReference/GameObject.Find.html
        level = GameObject.FindWithTag("Level").GetComponent<Level>();
        level.AddBlock();
        gameStatus = GameObject.FindWithTag("GameStatus").GetComponent<GameStatus>();
    }
    #endregion

    #region Events
    private void OnCollisionEnter2D(Collision2D collision)
    {
        DestroyBlock();
    }
    #endregion

    public void DestroyBlock()
    {
        if (destroySounds.Length > 0)
        {
            AudioSource.PlayClipAtPoint(
                destroySounds[Random.Range(0, destroySounds.Length)],
                Camera.current.transform.position
            );
        }

        level.RemoveBlock();
        gameStatus.AddToScore();
        Destroy(gameObject);
    }
}

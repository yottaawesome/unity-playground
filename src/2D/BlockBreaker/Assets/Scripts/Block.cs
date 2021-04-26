using UnityEngine;

public class Block : MonoBehaviour
{
    // Config
    [SerializeField] 
    AudioClip[] destroySounds;

    [SerializeField]
    GameObject destroyParticleEffect;

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
        PlayDestroySound();
        CreateParticleEffect();
        level.RemoveBlock();
        gameStatus.AddToScore();
        Destroy(gameObject);
    }

    private void PlayDestroySound()
    {
        if (destroySounds.Length > 0)
        {
            AudioSource.PlayClipAtPoint(
                destroySounds[Random.Range(0, destroySounds.Length)],
                Camera.current.transform.position
            );
        }
    }
    
    private void CreateParticleEffect()
    {
        if (destroyParticleEffect != null)
        {
            GameObject particleVfx = Instantiate(
                destroyParticleEffect,
                transform.position,
                Quaternion.identity,
                null
            );
            Destroy(particleVfx, 2);
        }
    }
}

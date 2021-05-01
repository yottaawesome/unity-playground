using UnityEngine;

public class Block : MonoBehaviour
{
    // Config
    [SerializeField] 
    AudioClip[] destroySounds;

    [SerializeField]
    GameObject destroyParticleEffect;

    [SerializeField]
    uint maxHits = 3;

    [SerializeField]
    int pointsWorth = 1;

    [SerializeField]
    Sprite[] hitSprites;

    // State
    Level level;
    GameStatus gameStatus;
    uint currentHits = 0;
    SpriteRenderer spriteRenderer;

    #region Lifecycle
    void Start()
    {
        gameStatus = GameObject.FindWithTag("GameStatus").GetComponent<GameStatus>();
        // https://docs.unity3d.com/2021.1/Documentation/ScriptReference/GameObject.Find.html
        level = GameObject.FindWithTag("Level").GetComponent<Level>();
        if (tag == "Breakable")
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
            level.AddBlock();
        }
    }
    #endregion

    #region Events
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (tag != "Breakable")
            return;

        currentHits++;
        if (currentHits >= maxHits)
        {
            DestroyBlock();
        }
        else if (hitSprites.Length > 0)
        {
            // this assumes the sprite order is from least to most
            // damaged
            long index = hitSprites.Length - maxHits + currentHits;
            // clamp the index to prevent an overrun
            index = (long)Mathf.Clamp(index, 0, hitSprites.Length - 1);
            spriteRenderer.sprite = hitSprites[index];
        }
    }
    #endregion

    public void DestroyBlock()
    {
        PlayDestroySound();
        CreateParticleEffect();
        level.RemoveBlock();
        gameStatus.AddToScore(pointsWorth);
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

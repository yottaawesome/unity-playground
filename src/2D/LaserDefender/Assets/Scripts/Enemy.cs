using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Config
    [SerializeField]
    float health = 100;

    [SerializeField]
    float shotCounter;

    [SerializeField]
    float minTimeBetweenShots = 0.2f;
    
    [SerializeField]
    float maxTimeBetweenShots = 3f;

    [SerializeField]
    int pointValue = 50;

    [SerializeField]
    GameObject enemyBullet;

    [SerializeField]
    GameObject explosion;

    [SerializeField]
    AudioClip[] deathSounds;
    [SerializeField]
    [Range(0, 1)]
    float deathSoundVolume = 0.75f;

    [SerializeField]
    AudioClip[] fireSounds;
    [SerializeField]
    [Range(0, 1)]
    float fireSoundsVolume = 0.75f;

    // Constants
    private const int explosionTimeout = 1;

    // State
    SpriteRenderer spriteRenderer;

    GameStatus gameStatus;

    void Start() 
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        shotCounter = Random.Range(minTimeBetweenShots, maxTimeBetweenShots);
        gameStatus = GameObject
            .FindGameObjectWithTag("GameStatus")
            .GetComponent<GameStatus>();
    }

    void Update() 
    {
        CountdownAndShoot();
    }

    private void CountdownAndShoot()
    {
        shotCounter -= Time.deltaTime;
        if(shotCounter <= 0f)
        {
            Fire();
            shotCounter = Random.Range(minTimeBetweenShots, maxTimeBetweenShots);
        }
    }

    private void Fire()
    {
        Instantiate(
            enemyBullet,
            transform.position - new Vector3(0, spriteRenderer.sprite.bounds.extents.y, 0),
            Quaternion.identity
        );
        AudioHelper.PlayRandomSoundAtCamera(fireSounds, fireSoundsVolume);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        DamageDealer damageDealer = other.gameObject.GetComponent<DamageDealer>();
        ProcessHit(damageDealer);
        ProcessDeath();
    }

    private void ProcessHit(DamageDealer damageDealer)
    {
        if (damageDealer == null)
            return;

        damageDealer.Hit();
        health -= damageDealer.GetDamage();
    }

    private void ProcessDeath()
    {
        if (health > 0)
            return;
        
        AudioHelper.PlayRandomSoundAtCamera(deathSounds, deathSoundVolume);
        GameObject explosionVfx = Instantiate(
            explosion,
            transform.position,
            Quaternion.identity
        );
        Destroy(explosionVfx, explosionTimeout);
        gameStatus?.AddToScore(pointValue);

        Destroy(gameObject);
    }
}

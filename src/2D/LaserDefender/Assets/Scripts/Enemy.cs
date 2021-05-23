using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    float health = 100;

    [SerializeField]
    float shotCounter;

    [SerializeField]
    float minTimeBetweenShots = 0.2f;
    
    [SerializeField]
    float maxTimeBetweenShots = 3f;

    [SerializeField]
    GameObject enemyBullet;

    SpriteRenderer spriteRenderer;

    void Start() 
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        shotCounter = Random.Range(minTimeBetweenShots, maxTimeBetweenShots);
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
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        DamageDealer damageDealer = other.gameObject.GetComponent<DamageDealer>();
        ProcessHit(damageDealer);
    }

    private void ProcessHit(DamageDealer damageDealer)
    {
        if (damageDealer == null)
            return;

        damageDealer.Hit();
        health -= damageDealer.GetDamage();
        if (health <= 0)
            Destroy(gameObject);
    }
}

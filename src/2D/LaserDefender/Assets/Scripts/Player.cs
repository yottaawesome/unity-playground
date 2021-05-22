using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Config
    [SerializeField]
    float HorizontalSpeed = 10f;

    [SerializeField]
    float VerticalSpeed = 10f;

    [SerializeField]
    GameObject bullet;

    [SerializeField]
    float projectileFiringPeriod = 0.1f;

    [SerializeField]
    int health = 100;

    // State
    float xMin;
    float xMax;
    float yMin;
    float yMax;
    SpriteRenderer spriteRenderer;
    Coroutine coContinuousFire = null;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        SetupMoveBoundaries();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Shoot();
    }

    private void SetupMoveBoundaries()
    {
        Camera gameCamera = Camera.main;
        xMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x;
        xMax = gameCamera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x;
        yMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).y;
        yMax = gameCamera.ViewportToWorldPoint(new Vector3(0, 1, 0)).y;

        // Include the sprite bounds to prevent it clipping
        // off at the screen extremes
        xMin += spriteRenderer.sprite.bounds.extents.x;
        xMax -= spriteRenderer.sprite.bounds.extents.x;
        yMin += spriteRenderer.sprite.bounds.extents.y;
        yMax -= spriteRenderer.sprite.bounds.extents.y;
    }

    private void Move()
    {
        // Edit > Project Settings > Input Manager > Axes
        // This makes it frame-rate independent
        // https://docs.unity3d.com/ScriptReference/Time-deltaTime.html
        float deltaX = Input.GetAxis("Horizontal") * Time.deltaTime * HorizontalSpeed;
        float deltaY = Input.GetAxis("Vertical") * Time.deltaTime * VerticalSpeed;

        float newXPos = Mathf.Clamp(transform.position.x + deltaX, xMin, xMax);
        float newYPos = Mathf.Clamp(transform.position.y + deltaY, yMin, yMax);

        transform.position = new Vector3(newXPos, newYPos, transform.position.z);
    }

    private void Shoot()
    {
        if (Input.GetButtonDown("Fire1") && coContinuousFire == null)
        {
            coContinuousFire = StartCoroutine(FireContinuously());
        }
        if (Input.GetButtonUp("Fire1") && coContinuousFire != null)
        {
            StopCoroutine(coContinuousFire);
            coContinuousFire = null;
        }
    }

    IEnumerator FireContinuously()
    {
        while (true)
        {
            Instantiate(
                bullet,
                transform.position + new Vector3(0, spriteRenderer.sprite.bounds.extents.y, 0),
                Quaternion.identity
            );
            yield return new WaitForSeconds(projectileFiringPeriod);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag != "EnemyProjectile")
            return;

        DamageDealer damageDealer = other.gameObject.GetComponent<DamageDealer>();
        if (damageDealer == null)
            return;
        ProcessHit(damageDealer);
    }

    private void ProcessHit(DamageDealer damageDealer)
    {
        damageDealer.Hit();
        health -= damageDealer.GetDamage();
        if (health <= 0)
            Destroy(gameObject);
    }
}

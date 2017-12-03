using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public GameObject projectilePrefab;
    public GameObject enemyMiniPrefab;
    public IntegerValue numEnemiesCaptured;

    public float projectileCooldown = 0.5f;
    private float projectileTimer = 0;

    public float dumpCooldown = 0.5f;
    private float dumpTimer = 0;

    public BoolValue gameOver;
    private Rigidbody2D rb;

    private List<GameObject> enemyMinis = new List<GameObject>();
    private GameObject currentDumpedMini;

    private AudioSource audioSource;
    public AudioClip shoot;
    public AudioClip enemyHit;
    public AudioClip wallHit;
    public AudioClip crash;
    public AudioClip dump;

    void Start()
    {
        this.rb = this.GetComponent<Rigidbody2D>();
        this.audioSource = this.GetComponent<AudioSource>();

        projectileTimer = projectileCooldown;
    }

    void Update()
    {
        
        if (!gameOver.Value)
        {
            projectileTimer += Time.deltaTime;
            dumpTimer += Time.deltaTime;

            if (Input.GetAxis("Fire1") == 1 && projectileTimer >= projectileCooldown)
            {
                audioSource.PlayOneShot(shoot);

                projectileTimer = 0;
                Vector3 projectilePosition = new Vector3(projectilePrefab.transform.position.x + 0.2f, this.transform.position.y, 0);
                GameObject projectile = GameObject.Instantiate(projectilePrefab, projectilePosition, projectilePrefab.transform.rotation);

                projectile.GetComponent<Projectile>().OnEnemyHit += PlayerMovement_OnEnemyHit;
                projectile.GetComponent<Projectile>().OnWallHit += PlayerMovement_OnWallHit;

            }
            if (Input.GetAxis("Jump") == 1 && dumpTimer >= dumpCooldown)
            {
                dumpTimer = 0;
                if (numEnemiesCaptured.Value > 0)
                {
                    audioSource.PlayOneShot(dump);
                    numEnemiesCaptured.Value--;
                    if(enemyMinis.Count > 0)
                    {
                        if (currentDumpedMini != null)
                            Destroy(currentDumpedMini);
                        currentDumpedMini = enemyMinis[0];
                        currentDumpedMini.transform.position = new Vector2(-7.2f, transform.position.y);
                        currentDumpedMini.GetComponent<Rigidbody2D>().velocity = new Vector2(-1, 0);

                        enemyMinis.RemoveAt(0);
                    }
                }
            }
        }
    }

    private void PlayerMovement_OnWallHit()
    {
        audioSource.PlayOneShot(wallHit);
    }

    private void PlayerMovement_OnEnemyHit()
    {
        audioSource.PlayOneShot(enemyHit);

        numEnemiesCaptured.Value++;
        GameObject go = GameObject.Instantiate(enemyMiniPrefab, new Vector3(enemyMiniPrefab.transform.position.x, this.transform.position.y, 0), enemyMiniPrefab.transform.rotation);
        go.GetComponent<Rigidbody2D>().velocity = new Vector2(Random.Range(-5.0f, 5.0f), Random.Range(-5.0f, 5.0f));

        enemyMinis.Add(go);
    }

    private void FixedUpdate()
    {
        float movement = Input.GetAxis("Vertical");
        rb.AddForce(new Vector2(0, movement * 10));
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag != "Ignore" && !gameOver.Value)
        {
            audioSource.PlayOneShot(crash);

            this.rb.gravityScale = 1;
            this.rb.constraints = RigidbodyConstraints2D.None;
            gameOver.Value = true;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private GameObject player;
    private Rigidbody rb;
    [SerializeField] ParticleSystem DeathFX;
    [SerializeField] float speed;
    [SerializeField] int enemyScoreReward = 1;
    private bool isGrounded = false;
    private bool isAlive = true;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isGrounded)
            ChasePlayer();
        CheckOutOfBounds();
    }

    private void CheckOutOfBounds()
    {
        if (transform.position.y < -4 && isAlive)
        {
            Die();
        }
    }

    private void Die()
    {
        isAlive = false;
        GetComponent<MeshRenderer>().enabled = false;
        DeathFX.Play();
        GameObject.Find("GameManager").GetComponent<GameManager>().AddScore(enemyScoreReward);
        Destroy(gameObject, .5f);
    }

    private void ChasePlayer()
    {
        if (player == null)
            return;
        Vector3 loodDirection = (player.transform.position - transform.position).normalized;
        rb.AddForce(loodDirection * speed);
        
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 0)
            isGrounded = true;
    }
}

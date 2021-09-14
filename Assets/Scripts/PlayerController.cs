using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] public float speed;
    private Rigidbody rb;
    private GameObject focalPoint;
    internal float pushForce;
    internal bool powerup;
    [SerializeField] GameObject powerIndicator;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("FocalPoint");
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        PoweupCheck();
        CheckOutOfBounds();
    }

    private void CheckOutOfBounds()
    {
        if (transform.position.y < -5)
            Destroy(gameObject);
    }

    private void Move()
    {
        float hMove = Input.GetAxis("Horizontal");
        float vMove = Input.GetAxis("Vertical");

        rb.AddForce(focalPoint.transform.forward * vMove * speed);
    }


    private void PoweupCheck()
    {
        powerIndicator.gameObject.SetActive(powerup);
        powerIndicator.gameObject.transform.position = transform.position + new Vector3(0, -.3f, 0);
        powerIndicator.gameObject.transform.rotation = Quaternion.Euler(Vector3.up);

    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Enemy"))
        {
            collision.gameObject.GetComponent<Rigidbody>().AddForce((collision.gameObject.transform.position - transform.position).normalized * pushForce, ForceMode.Impulse);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupInvincibility : MonoBehaviour
{
    [SerializeField] float multiplier;
    [SerializeField] float duration;
    private GameObject target;

    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Player"))
        {
            GetComponent<MeshRenderer>().enabled = false;
            target = other.gameObject;
            StartCoroutine(Powerup());

        }
    }


    private IEnumerator Powerup()
    {

        target.GetComponent<PlayerController>().pushForce = multiplier;
        target.GetComponent<PlayerController>().powerup = true;
        yield return new WaitForSeconds(duration);
        target.GetComponent<PlayerController>().pushForce = 0;
        target.GetComponent<PlayerController>().powerup = false;
        Destroy(gameObject);
    }
}

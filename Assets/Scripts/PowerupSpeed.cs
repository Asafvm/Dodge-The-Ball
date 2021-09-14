using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupSpeed : MonoBehaviour
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
        PlayerController pc = target.GetComponent<PlayerController>();
        float origin = pc.speed;
        pc.speed = origin*multiplier;
        pc.powerup = true;
        yield return new WaitForSeconds(duration);
        pc.powerup = false;
        pc.speed = origin;
     

        Destroy(gameObject);
    }
}

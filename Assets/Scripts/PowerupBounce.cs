using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupBounce : MonoBehaviour
{
    [SerializeField] float multiplier;
    [SerializeField] float duration;
    private GameObject target;

    private void OnTriggerEnter(Collider other)
    {
        
        if(other.CompareTag("Player"))
        {
            GetComponent<MeshRenderer>().enabled = false;
            target = other.gameObject;
            StartCoroutine(Powerup());
            
        }
    }


    private IEnumerator Powerup()
    {



        target.transform.localScale *= multiplier;
        target.GetComponent<Rigidbody>().mass *= multiplier*100;
        target.GetComponent<PlayerController>().powerup = true;
        yield return new WaitForSeconds(duration);
        target.GetComponent<PlayerController>().powerup = false;
        target.transform.localScale /= multiplier;
        target.GetComponent<Rigidbody>().mass /= multiplier*100;

        Destroy(gameObject);
    }

}

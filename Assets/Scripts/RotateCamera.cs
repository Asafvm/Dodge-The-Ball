using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCamera : MonoBehaviour
{
    [SerializeField] float rotationSpeed;
    // Start is called before the first frame update
    void Start()
    {
            
    }


    // Update is called once per frame
    void Update()
    {
        float hMove = Input.GetAxis("Horizontal");
        transform.Rotate(Vector3.up , hMove * rotationSpeed * Time.deltaTime);
    }
}

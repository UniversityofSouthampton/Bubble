using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;

public class OilBarrel : MonoBehaviour
{
    public float rotationspeed;
    private Rigidbody2D rb;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0f, 0f, -rotationspeed * Time.deltaTime);
        rb.AddForce(-Vector3.up * speed, ForceMode2D.Force );
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Time.timeScale = 0;
        }
    }
}    

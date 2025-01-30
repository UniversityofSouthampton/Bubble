using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Obstacle : MonoBehaviour
{
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        // speed = Random.Range(1f, 3f);
        speed += Timer.elapsedTime / 20;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.down * speed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Time.timeScale = 0;
        }

        if (other.gameObject.tag == "Ground")
        {
            Destroy(this.gameObject);
        }
    }
}

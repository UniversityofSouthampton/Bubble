using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour
{
    public float time;
    private bool ready = true;
    public float MinTime;
    public float MaxTime;
    public GameObject[] prefab;

    public float stage1Time;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (ready == true)
        {
            StartCoroutine(Generate());
            ready = false;
        }

        if (Timer.elapsedTime > stage1Time)
        {
            this.gameObject.SetActive(false);
        }
    }

    IEnumerator Generate()
    {
        time = Random.Range(MinTime - (Timer.elapsedTime/100) , MaxTime - (Timer.elapsedTime/100));
        yield return new WaitForSeconds(time);
        Instantiate(prefab[Random.Range(0, prefab.Length)], transform.position, Quaternion.identity);
        ready = true;
    }
}

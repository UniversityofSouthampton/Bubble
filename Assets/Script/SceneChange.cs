using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneChange : MonoBehaviour
{
    public BackgroundMoveDown bg;
    private Vector3 pos;
    public GameObject[] generators;
    public static bool bossready = false;

    public GameObject boss;

    public Boss boss_script;

    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        pos = new Vector3(0,6,0);
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y <= 14)
        {
            for (int i=0; i< generators.Length; i++)
            {
                generators[i].SetActive(false);
            }
        }
        if (transform.position.y <= 7)
        {
            bg.enabled = false;
            
            boss.SetActive(true);
            // boss.transform.position =
            //     Vector3.MoveTowards(boss.transform.position, new Vector3(0, boss.transform.position.y, 0), speed * Time.deltaTime);
            StartCoroutine(Enabled());

        }
    }

    IEnumerator Enabled()
    {
        yield return new WaitForSeconds(3);
        boss_script.enabled = true;
    }
}

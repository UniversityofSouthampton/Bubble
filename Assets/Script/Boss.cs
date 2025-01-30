using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Video;
using Random = UnityEngine.Random;

public class Boss : MonoBehaviour
{
    private float MinX, MaxX, MinY, MaxY;

    private Vector2 pos;

    public GameObject explosion , missilePref;

    public GameObject player;
    private bool turnleft, turnright;
    private bool skillon = false;

    private bool ready = true;
    private bool skillcomplete = true;
    private int i = 0;
    private int i1 = -1;
    public GameObject[] warning;
    public GameObject[] missileSpawn;

    public GameObject warningPref;
    public GameObject BarrelPref;
    public GameObject BarrelSpawn;

    public float speed;

    private SpriteRenderer sr;
    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (skillcomplete == true)
        {
            i = Random.Range(1,4);
            if (i == 1)
            {
                // JustMove();
                StartCoroutine(Skill1());
                    
            }
            if (i == 2)
            {
                // JustMove();
                StartCoroutine(Skill2());
                    
            }
            if (i == 3)
            {
                // JustMove();
                StartCoroutine(Skill3());
                    
            }
            skillcomplete = false;
        }

        if (skillon == false)
        {
            Debug.Log(skillon);
            Move();
        }
        if (transform.position.x <= -4)
        {
            turnright = true;
            turnleft = false;
        }

        if (transform.position.x >= 8)
        {
            turnright = false;
            turnleft = true;
        }
    }

  
        
    int randomController()
    {
        i = Random.Range (0, 4);
        i1 = i;
        if(i == i1)
            {
                randomController();
            }
            return i;
    }
    

   // IEnumerator SkillCooldown()
    //{
            
    //}
    void Move()
    {
        if (turnright)
        {
            transform.Translate((Vector3.right * speed * Time.deltaTime));
            sr.flipX = false;
        }

        if (turnleft)
        {
            transform.Translate((-Vector3.right * speed * Time.deltaTime));
            sr.flipX = true;
        }

        
    }
    

    IEnumerator Skill1()
    {
        // JustMove();
        // SetMinAndMax();
        SpawnExplosion();
        yield return new WaitForSeconds(1f);
        SpawnExplosion();
        yield return new WaitForSeconds(1f);
        SpawnExplosion();
        yield return new WaitForSeconds(1f);
        Debug.Log("ActivateSkill1");
        
        yield return new WaitForSeconds(5f);
        skillcomplete = true;

    }
    IEnumerator Skill2()
    {
        // JustMove();
        skillon = true;
        Skill2Warning();
        yield return new WaitForSeconds(1f);
        for (int i = 0; i < missileSpawn.Length; i++)
        {
            Instantiate(missilePref, missileSpawn[i].transform);
        }
        Debug.Log("ActivateSkill2");
        yield return new WaitForSeconds(1.5f);
        skillon = false;
        yield return new WaitForSeconds(5f);
        skillcomplete = true;
        
    }
    IEnumerator Skill3()
    {
        // JustMove();
        
        SpawnBarrel();
        yield return new WaitForSeconds(1f);
        SpawnBarrel();
        yield return new WaitForSeconds(1f);
        SpawnBarrel();
        
      
        yield return new WaitForSeconds(5f);
        skillcomplete = true;

    }
    // void SetMinAndMax()
    // {
    //     Vector2 Bounds = player.transform.position;
    //     MinX = -Bounds.x;
    //     MaxX = Bounds.x;
    //     MinY = -Bounds.y;
    //     MaxY = Bounds.y;
    // }

    void SpawnExplosion()
    {
        pos = new Vector2(Random.Range(player.transform.position.x +2, player.transform.position.x -2), Random.Range(player.transform.position.y +2, player.transform.position.y -2));
        GameObject obj = Instantiate(explosion, pos, Quaternion.identity);
        obj.transform.parent = transform.parent;
        ready = true;
       
    }

    void Skill2Warning()
    {
        for (int i = 0; i < missileSpawn.Length; i++)
        {
            Instantiate(warningPref, missileSpawn[i].transform);
        }
    }

   

    // void JustMove()
    // {
    //     Vector3 newPos = transform.position;
    //     transform.position =
    //         Vector3.MoveTowards(newPos, new Vector3(Random.Range(-8, 8), transform.position.y, 0), speed);
    // }

    void SpawnBarrel()
    {
        Instantiate(BarrelPref, BarrelSpawn.transform.position, quaternion.identity);
    }
}

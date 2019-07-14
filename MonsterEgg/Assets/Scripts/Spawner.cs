using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public static int CowRespawn, FishRespawn;
    public GameObject bird,cow,fish,spacecheck;
    public float SummonInterval;//召喚待機時間
    float time;
    public int MaxSimultaneousNum;//同時召喚数
    int Num;
    Vector3 pos,pos2;
    // Start is called before the first frame update
    void Start()
    {
        CowRespawn = 0;
        FishRespawn = 0;
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (time > SummonInterval)
        {
            Num = Random.Range(1, MaxSimultaneousNum + 1);
            SummonBird(Num);
        }
        if(CowRespawn >0)
        {
            
            CowSpawn();
        }
        if(FishRespawn >0)
        {
            FishSpawn();
        }
    }

    void SummonBird(int x)
    {
        for(int i = 0; i<x; i++)
        {
            Instantiate(bird, new Vector3(0, -15, 0), Quaternion.identity);
        }
        time = 0;
    }
    public void CowSpawn()
    {
        pos = new Vector3(Random.Range(-50, 50), 0, Random.Range(-13, 31));
        spacecheck.transform.position = pos;
       /* while (spacecheck.GetComponent<SpaceCheck>().Space == false)
        {
            pos = new Vector3(Random.Range(-50, 50), 0, Random.Range(-13, 31));
            spacecheck.transform.position = pos;
        }
        */
        //Instantiate(cow,pos, Quaternion.identity);
        CowRespawn --;
        StartCoroutine(wait(cow, pos));
    }

    void FishSpawn()
    {
        pos2 = new Vector3(Random.Range(-10, 10), 0, Random.Range(-31, -16));
        spacecheck.transform.position = pos2;
        /*while (spacecheck.GetComponent<SpaceCheck>().Space == false)
        {
            pos2 = new Vector3(Random.Range(-10, 10), 0, Random.Range(-31, -16));
            spacecheck.transform.position = pos2;
        }*/
        //Instantiate(fish, pos2, Quaternion.identity);
        FishRespawn --;
        StartCoroutine(wait(fish, pos2));
    }


    IEnumerator wait(GameObject x,Vector3 a)
    {
        yield return new WaitForSeconds(3);
        Instantiate(x, a, Quaternion.identity);
    }

}

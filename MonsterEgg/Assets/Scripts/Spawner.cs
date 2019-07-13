using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public static bool CowRespawn, FishRespawn;
    public GameObject bird,cow,fish,spacecheck;
    public float SummonInterval;//召喚待機時間
    float time;
    public int MaxSimultaneousNum;//同時召喚数
    int Num;
    Vector3 pos;
    // Start is called before the first frame update
    void Start()
    {
        CowRespawn = false;
        FishRespawn = false;
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
        if(CowRespawn == true)
        {
            CowSpawn();
        }
        if(FishRespawn == true)
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
        while (spacecheck.GetComponent<SpaceCheck>().Space == false)
        {
            pos = new Vector3(Random.Range(-50, 50), 0, Random.Range(-13, 31));
            spacecheck.transform.position = pos;
        }
        Instantiate(cow,pos, Quaternion.identity);
        CowRespawn = false;
    }

    void FishSpawn()
    {
        pos = new Vector3(Random.Range(-10, 10), 0, Random.Range(-31, -16));
        spacecheck.transform.position = pos;
        while (spacecheck.GetComponent<SpaceCheck>().Space == false)
        {
            pos = new Vector3(Random.Range(-10, 10), 0, Random.Range(-31, -16));
            spacecheck.transform.position = pos;
        }
        Instantiate(fish, pos, Quaternion.identity);
        FishRespawn = false;
    }

}

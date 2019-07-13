using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject bird;
    public float SummonInterval;//召喚待機時間
    float time;
    public int MaxSimultaneousNum;//同時召喚数
    int Num;
    // Start is called before the first frame update
    void Start()
    {
        
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
    }

    void SummonBird(int x)
    {
        for(int i = 0; i<x; i++)
        {
            Instantiate(bird, new Vector3(0, -15, 0), Quaternion.identity);
        }
        time = 0;
    }
}

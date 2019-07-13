using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fish : MonoBehaviour
{
    private float time;
    public float MoveInterval, MoveSize,MoveTime;
    private Vector3 vec;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if(time > MoveInterval)
        {
            FishMove();
        }
    }


    void FishMove()
    {
        vec = new Vector3(Random.Range(-MoveSize, MoveSize), 0, Random.Range(-MoveSize, MoveSize));
        transform.LookAt(transform.position +vec);
        time = 0;
        //transform.Translate(vec);
        //transform.position = Vector3.Lerp(transform.position, transform.position+vec, Time.deltaTime * 2);
        StartCoroutine(move(vec));
        

    }
    IEnumerator move(Vector3 vec)
    {
        transform.Translate(vec / 10);
        yield return new WaitForSeconds(MoveTime / 10);
        transform.Translate(vec / 10);
        yield return new WaitForSeconds(MoveTime / 10);
        transform.Translate(vec / 10);
        yield return new WaitForSeconds(MoveTime / 10);
        transform.Translate(vec / 10);
        yield return new WaitForSeconds(MoveTime / 10);
        transform.Translate(vec / 10);
        yield return new WaitForSeconds(MoveTime / 10);
        transform.Translate(vec / 10);
        yield return new WaitForSeconds(MoveTime / 10);
        transform.Translate(vec / 10);
        yield return new WaitForSeconds(MoveTime / 10);
        transform.Translate(vec / 10);
        yield return new WaitForSeconds(MoveTime / 10);
        transform.Translate(vec / 10);
        yield return new WaitForSeconds(MoveTime / 10);
        transform.Translate(vec / 10);
        yield return new WaitForSeconds(MoveTime / 10);
        
    }
}

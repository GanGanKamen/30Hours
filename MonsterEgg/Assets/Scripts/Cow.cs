using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cow : MonoBehaviour
{
    private float time;
    public GameObject serch;
    public float MoveInterval, MoveSize, MoveTime;
    private Vector3 vec;
    Rigidbody rb;
    bool IsMovel;
    Animator anim;
    CowSerch cs;
    public bool IsEscape;
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        cs = serch.GetComponent<CowSerch>();
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (time > MoveInterval&&IsEscape == false)
        {
            CowMove();
        }
        if(IsMovel == true&&IsEscape == false)
        {
            rb.velocity = vec;
        }
    }

    void CowMove()
    {
        vec = new Vector3(Random.Range(-MoveSize, MoveSize), 0, Random.Range(-MoveSize, MoveSize));
        if (vec.x < 0) vec.x -= 0.5f;
        else vec.x += 0.5f;
        if (vec.z< 0) vec.z -= 0.5f;
        else vec.z += 0.5f;
        transform.LookAt(transform.position + vec);
        time = 0;
        //rb.AddForce(vec * 100);
        StartCoroutine(Wark());
    }

    IEnumerator Wark()
    {
        IsMovel = true;
        anim.SetBool("Move", true);
        yield return new WaitForSeconds(MoveTime);
        IsMovel = false;
        anim.SetBool("Move", false);
    }
}

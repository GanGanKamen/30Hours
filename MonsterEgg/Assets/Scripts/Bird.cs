using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    public int B_type;//鳥の初期地点　0=左 1=右　2=上　3=下
    private Vector3 vec,pos;
    public float speed;
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        B_type = Random.Range(0, 4);
        rb = GetComponent<Rigidbody>();
        if (B_type == 0)
        {
            pos = new Vector3(-50, 0, Random.Range(-20, 20));
            vec = new Vector3(speed, 0, Random.Range(-speed+0.2f, speed-0.2f));
            transform.position = pos;
            transform.LookAt(transform.position + vec);

        }
        else if(B_type == 1)
        {
            pos = new Vector3(50, 0, Random.Range(-20, 20));
            vec = new Vector3(-speed, 0, Random.Range(-speed+0.2f, speed-0.2f));
            transform.position = pos;
            transform.LookAt(transform.position + vec);
        }
        else if(B_type == 2)
        {
            pos = new Vector3(Random.Range(-40, 40),0,30);
            vec = new Vector3(Random.Range(-speed+ 0.2f, speed- 0.2f),0,-1);
            transform.position = pos;
            transform.LookAt(transform.position + vec);
        }
        else if(B_type == 3)
        {
            pos = new Vector3(Random.Range(-40, 40), 0, -30);
            vec = new Vector3(Random.Range(-speed+ 0.2f, speed- 0.2f), 0, 1);
            transform.position = pos;
            transform.LookAt(transform.position + vec);
        }

    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = vec;   
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name.StartsWith("Wall"))
        {
            Destroy(gameObject);
        }
    }

}

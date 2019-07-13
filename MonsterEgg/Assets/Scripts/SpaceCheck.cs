using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceCheck : MonoBehaviour
{
    public bool Space;
    private int count;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(count == 0)
        {
            Space = true;
        }
        else
        {
            Space = false;
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        count++;
    }


    private void OnTriggerExit(Collider other)
    {
        count--;
    }
}

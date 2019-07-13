using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CowSerch : MonoBehaviour
{
    public GameObject Body;
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = Body.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            CharacterCtrl cc = other.GetComponent<CharacterCtrl>();
            if(cc.isDush == true)
            {
                Body.GetComponent<Cow>().IsEscape = true;
                rb.AddForce(-(other.transform.position - transform.position)*10);
                Body.transform.LookAt(-(other.transform.position - transform.position));
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Body.GetComponent<Cow>().IsEscape = false;
        }
    }

}

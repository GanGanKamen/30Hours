using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class End : MonoBehaviour
{
    bool waited;
    public GameObject Tex;
    // Start is called before the first frame update
    void Start()
    {
        waited = false;
        StartCoroutine(wait());
    }

    // Update is called once per frame
    void Update()
    {
        if(waited == true)
        {

            if (Dualshock4.CircleDown(0))
            {
                Fader.switchScene("Title");
            }
        }
    }

    IEnumerator wait()
    {
        yield return new WaitForSeconds(2f);
        Tex.SetActive(true);
        waited = true;
    }
}

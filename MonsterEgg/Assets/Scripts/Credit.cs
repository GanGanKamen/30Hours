using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Credit : MonoBehaviour
{
    Text infoT;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Dualshock4.CrossDown(0))
        {
            SceneManager.LoadScene("Title");
        }
    }
}

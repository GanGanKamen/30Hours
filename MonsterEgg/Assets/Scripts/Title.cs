
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Title : MonoBehaviour
{
    private int x;
    public Text startT, creditT;
    Color ActiveColor, other;
    
    // Start is called before the first frame update
    void Start()
    {
        x = 0;
        other = new Color(50/ 255f, 50/ 255f, 50/ 255f);
        ActiveColor = new Color(165/ 255f, 30/ 255f, 30/ 255f);
    }

    // Update is called once per frame
    void Update()
    {
        if(Dualshock4.LeftStick(0).magnitude > 0.3f)
        {
            if (Dualshock4.LeftStick(0).y>0)
            {
                x = 0;
                startActive();
            }
            else
            {
                creditActive();
                x = 1;
            }
        }
        if (Dualshock4.CircleDown(0))
        {
            if(x == 0)
            {
                SceneManager.LoadScene("Main");
            }
            else
            {
                SceneManager.LoadScene("Credit");
            }
        }
    }

    void startActive()
    {
        startT.color = ActiveColor;
        creditT.color = other;
    }

    void creditActive()
    {
        startT.color = other;
        creditT.color = ActiveColor;
    }

}

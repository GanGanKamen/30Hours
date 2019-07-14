using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Fader : MonoBehaviour
{
    public float fadetime;
    float time,fadeParSecond;
    public Image img;
    static int process;
    public static string scenename;
    // Start is called before the first frame update
    static bool existsInstance = false;

    void Awake()
    {
        if (existsInstance)
        {
            Destroy(gameObject);
            return;
        }
        existsInstance = true;
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        fadeParSecond = 255 / fadetime;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(img.color.a);
        time += Time.deltaTime;
        if(process == 1)
        {
            
            fadeIn();
        }else if(process == 2)
        {
            ChangeScene();
        }else if(process == 3)
        {
            fadeOut();
        }
    }

    public static void switchScene(string name)
    {
        scenename = name;
        process = 1;
    }

    void fadeIn()
    {
        img.color += new Color(0, 0, 0, fadeParSecond * Time.deltaTime/255);
        if(img.color.a >= 1)
        {
            process = 2;
        }
    }

    void ChangeScene()
    {
        SceneManager.LoadScene(scenename);
        process = 3;
    }

    void fadeOut()
    {
        img.color -= new Color(0, 0, 0, fadeParSecond * Time.deltaTime/255);
        if (img.color.a <= 0)
        {
            process = 0;
            img.color = new Color(0, 0, 0, 0);
        }
    }


}

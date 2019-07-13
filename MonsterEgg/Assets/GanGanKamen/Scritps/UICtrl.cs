using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UICtrl : MonoBehaviour
{
    static public bool canCtrl;
    static public bool gameStart;
    private EggCtrl egg;
    [SerializeField] private Text cawText;
    [SerializeField] private Text fishText;
    [SerializeField] private Text birdText;
    [SerializeField] private Text heroText;
    [SerializeField] private Text timeText;
    [SerializeField] private int totalTime;
    private float nowTime;
    // Start is called before the first frame update
    void Start()
    {
        egg = GameObject.FindGameObjectWithTag("Egg").GetComponent<EggCtrl>();
        gameStart = true;
        canCtrl = true;
        nowTime = totalTime;
        GetComponent<CriAtomSource>().Play("BGM_Play");
    }

    // Update is called once per frame
    void Update()
    {
        NumText();
        CountDown();
    }

    private void NumText()
    {
        cawText.text = "牛×" + egg.taurosNum.ToString();
        fishText.text = "魚×" + egg.fishNum.ToString();
        birdText.text = "鳥×" + egg.birdNum.ToString();
        heroText.text = "勇者×" + egg.humanNum.ToString();
        timeText.text = ((int)nowTime).ToString();
    }

    private void CountDown()
    {
        if(gameStart == true)
        {
            nowTime -= Time.deltaTime;
        }
        if((int)nowTime == 0)
        {
            gameStart = false;
            canCtrl = false;
        }
    }
}

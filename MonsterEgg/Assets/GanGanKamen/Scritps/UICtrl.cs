﻿using System.Collections;
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
    [SerializeField] private RawImage fadeImage;
    private float nowTime;
    public Transform[] points;
    public GameObject hero;
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
        cawText.text = egg.taurosNum.ToString();
        fishText.text = egg.fishNum.ToString();
        birdText.text = egg.birdNum.ToString();
        heroText.text = egg.humanNum.ToString();
        timeText.text = ((int)nowTime).ToString();
    }

    private void CountDown()
    {
        if(gameStart == true)
        {
            nowTime -= Time.deltaTime;
        }
        if((int)nowTime == 0&&gameStart == true)
        {
            StartCoroutine(GameOver());
        }
        if((int)nowTime % 20 == 0)
        {
            HeroAdvent();
        }
    }

    private IEnumerator GameOver()
    {
        if (gameStart == false)
        {
            yield break;
        }
        gameStart = false;
        canCtrl = false;
        yield return new WaitForSeconds(1f);
    }

    private void HeroAdvent()
    {
        GameObject[] nowHeros = GameObject.FindGameObjectsWithTag("Enemy");
        if(nowHeros.Length == 0)
        {
            for(int i = 0; i < points.Length; i++)
            {
                Instantiate(hero, points[i].position, Quaternion.identity);
            }
        }
    }
}

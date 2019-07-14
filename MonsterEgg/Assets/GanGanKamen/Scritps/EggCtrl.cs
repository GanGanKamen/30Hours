using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EggCtrl : MonoBehaviour
{
    public int taurosNum, birdNum, fishNum, humanNum;
    public int hp;
    public Material mat;
    public Texture t1,t2,t3,t4,t5,t6,t7,t8,t9,t10;
    public GameObject birthObj;
    // Start is called before the first frame update
    void Start()
    {
        mat.SetTexture("_MainTex", t1);
        birthObj.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Delivery(int _taurosNum,int _birdNum,int _fishNum,int _humanNum)
    {
        taurosNum += _taurosNum;
        birdNum += _birdNum;
        fishNum += _fishNum;
        humanNum += _humanNum;
    }

    public void changeTex()
    {
        switch (hp)
        {
            case 10:
                mat.SetTexture("_MainTex", t1);
                break;
            case 9:
                mat.SetTexture("_MainTex", t2);
                break;
            case 8:
                mat.SetTexture("_MainTex", t3);
                break;
            case 7:
                mat.SetTexture("_MainTex", t4);
                break;
            case 6:
                mat.SetTexture("_MainTex", t5);
                break;
            case 5:
                mat.SetTexture("_MainTex", t6);
                break;
            case 4:
                mat.SetTexture("_MainTex", t7);
                break;
            case 3:
                mat.SetTexture("_MainTex", t8);
                break;
            case 2:
                mat.SetTexture("_MainTex", t9);
                break;
            case 1:
                mat.SetTexture("_MainTex", t10);
                break;
        }
    }
}

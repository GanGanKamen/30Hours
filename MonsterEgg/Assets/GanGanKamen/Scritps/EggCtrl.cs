using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EggCtrl : MonoBehaviour
{
    public int taurosNum, birdNum, fishNum, humanNum;
    public int hp;
    // Start is called before the first frame update
    void Start()
    {
        
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
        humanNum += humanNum;
    }
}

﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AttackOnEnemy : MonoBehaviour
{
    public enum Status
    {
        GotoEgg,
        ChasePlayer,
        AttackEgg
    }
    private Enemy enemyMain;
    private EggCtrl egg;
    public Status nowStatus;
    private Status preStatus;
    // Start is called before the first frame update
    void Start()
    {
        enemyMain = GetComponent<Enemy>();
        egg = GameObject.FindGameObjectWithTag("Egg").GetComponent<EggCtrl>();
        preStatus = nowStatus;
    }

    // Update is called once per frame
    void Update()
    {
        ChangeStatus();
    }

    private void ChangeStatus()
    {
        if(preStatus != nowStatus)
        {
            switch (nowStatus)
            {
                case Status.ChasePlayer:
                    break;
                case Status.GotoEgg:
                    break;
                case Status.AttackEgg:
                    break;
            }
            preStatus = nowStatus;
        }
    }
}

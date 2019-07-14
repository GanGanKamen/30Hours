using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AttackEgg : MonoBehaviour
{
    private AttackOnEnemy enemy;
    private NavMeshAgent agent;
    private EggCtrl egg;
    private Vector3 startPos;
    [SerializeField]private float nowAttackCount;
    private float attackInterval;
    // Start is called before the first frame update
    void Start()
    {
        attackInterval = 3;
        enemy = GetComponent<AttackOnEnemy>();
        agent = GetComponent<NavMeshAgent>();
        egg = GameObject.FindGameObjectWithTag("Egg").GetComponent<EggCtrl>();
        startPos = transform.position;
        if (GetComponent<Rigidbody>() != null)
        {
            Destroy(GetComponent<Rigidbody>());
        }
    }

    // Update is called once per frame
    void Update()
    {
        agent.destination = Vector3.Scale(startPos,new Vector3(1,0,1));
        Attack();
        enemy.animator.SetBool("Dash", false);
        if (enemy.nowStatus != AttackOnEnemy.Status.AttackEgg)
        {
            Destroy(this);
        }
    }

    private void Attack()
    {
        if((int)nowAttackCount == attackInterval)
        {
            nowAttackCount = 0;
            egg.hp -= 1;
            egg.changeTex();
            enemy.animator.SetTrigger("Attack");
        }
        else
        {
            nowAttackCount += Time.deltaTime;
        }
    }
}

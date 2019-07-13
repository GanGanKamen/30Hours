using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AttackEgg : MonoBehaviour
{
    private AttackOnEnemy enemy;
    private NavMeshAgent agent;
    private Vector3 startPos;
    // Start is called before the first frame update
    void Start()
    {
        enemy = GetComponent<AttackOnEnemy>();
        agent = GetComponent<NavMeshAgent>();
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
        if (enemy.nowStatus != AttackOnEnemy.Status.AttackEgg)
        {
            Destroy(this);
        }
    }
}

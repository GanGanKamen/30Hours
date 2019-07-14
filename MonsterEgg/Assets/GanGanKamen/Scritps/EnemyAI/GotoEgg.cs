using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GotoEgg : MonoBehaviour
{
    private AttackOnEnemy enemy;
    private NavMeshAgent agent;
    private EggCtrl egg;
    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        enemy = GetComponent<AttackOnEnemy>();
        agent = GetComponent<NavMeshAgent>();
        egg = GameObject.FindGameObjectWithTag("Egg").GetComponent<EggCtrl>();
        if (GetComponent<Rigidbody>() == null)
        {
            gameObject.AddComponent<Rigidbody>();
        }
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    // Update is called once per frame
    void Update()
    {
        agent.destination = new Vector3(egg.transform.position.x, transform.position.y, egg.transform.position.z);
        enemy.animator.SetBool("Dash", true);
        if (enemy.nowStatus != AttackOnEnemy.Status.GotoEgg)
        {
            Destroy(this);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Egg")
        {
            enemy.nowStatus = AttackOnEnemy.Status.AttackEgg;
        }
    }
}

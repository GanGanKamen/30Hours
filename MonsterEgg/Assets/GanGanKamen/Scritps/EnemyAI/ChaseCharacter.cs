using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ChaseCharacter : MonoBehaviour
{
    private AttackOnEnemy enemy;
    private NavMeshAgent agent;
    public CharacterCtrl character;
    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        enemy = GetComponent<AttackOnEnemy>();
        agent = GetComponent<NavMeshAgent>();
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
        agent.destination = Vector3.Scale(character.transform.position, new Vector3(1, 0, 1));
        enemy.animator.SetBool("Dash", true);
        CheckDown();
        if (enemy.nowStatus != AttackOnEnemy.Status.ChasePlayer)
        {
            Destroy(this);
        }
    }

    private void CheckDown()
    {
        if(character.isDown == true)
        {
            enemy.nowStatus = AttackOnEnemy.Status.GotoEgg;
        }
    }
}

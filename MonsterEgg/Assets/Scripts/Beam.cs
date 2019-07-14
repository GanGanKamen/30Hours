using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beam : MonoBehaviour
{

    public GameObject Player;
    private Collected Col;
    // Start is called before the first frame update
    void Start()
    {
        Col = Player.GetComponent<Collected>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Animals")
        {
            string x = other.GetComponent<Nutrition>().N_Type.ToString();
            if (x == "Fish")
            {
                Col.Fish++;
                GetComponent<CriAtomSource>().Play("SE_SakanaShock");
                Destroy(other.gameObject);
                Spawner.FishRespawn ++;
            }
            else if (x == "Cow")
            {
                Col.Cow++;
                GetComponent<CriAtomSource>().Play("SE_UshiShock");
                Destroy(other.gameObject);
                Spawner.CowRespawn ++;
            }
            else if (x == "Bird")
            {
                Col.Bird++;
                GetComponent<CriAtomSource>().Play("SE_ToriShock");
                Destroy(other.gameObject);
            }
            GetComponent<CriAtomSource>().Play("Voice_sinjaYoisyo");
        }
        else if (other.gameObject.tag == "Enemy")
        {
            Enemy en = other.GetComponent<Enemy>();
            en.Life--;
            GetComponent<CriAtomSource>().Play("SE_yuushaShock");
            other.gameObject.GetComponent<CriAtomSource>().Play("Voice_yuushaShock");
            if (other.GetComponent<AttackOnEnemy>().nowStatus != AttackOnEnemy.Status.ChasePlayer)
            {
                other.GetComponent<AttackOnEnemy>().ChangeToChasePlayer(Player.GetComponent<CharacterCtrl>());
            }
            
            if (en.Life < 0)
            {
                Col.Human++;
                GetComponent<CriAtomSource>().Play("Voice_yuushaDown");
                Destroy(other.gameObject);
            }
        }

        else if(other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<CriAtomSource>().Play("Voice_sinjaFukkatu");
            other.gameObject.GetComponent<CharacterCtrl>().isDown = false;
            other.gameObject.GetComponent<CharacterCtrl>().animator.SetBool("Stan", false);
        }
    }

}

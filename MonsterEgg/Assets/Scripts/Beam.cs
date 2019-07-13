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
                Destroy(other.gameObject);
            }
            else if (x == "Cow")
            {
                Col.Cow++;
                Destroy(other.gameObject);
            }
            else if (x == "Bird")
            {
                Col.Bird++;
                Destroy(other.gameObject);
            }
        }
        else if (other.gameObject.tag == "Enemy")
        {
            Enemy en = other.GetComponent<Enemy>();
            en.Life--;
            if (en.Life < 0)
            {
                Col.Human++;
                Destroy(other);
            }
        }
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterCtrl : MonoBehaviour
{
    public float speed;
    public GameObject body;  //モデルオブジェクト
    [SerializeField] private GameObject attack; //発射するもの
    public bool canDelivery;
    private Collected collected;

    // Start is called before the first frame update
    void Start()
    {
        collected = GetComponent<Collected>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CharacterMove(Vector3 direction)
    {
        transform.Translate(direction * Time.deltaTime * speed);
        body.transform.localRotation = Quaternion.LookRotation(direction);
    }

    public void Shoot()
    {
        StartCoroutine(StartShoot());
    }

    private IEnumerator StartShoot()
    {
        if(attack.active == true)
        {
            yield break;
        }
        attack.SetActive(true);
        GetComponent<CriAtomSource>().Play("SE_shot");
        yield return new WaitForSeconds(0.1f);
        attack.SetActive(false);
        yield break;
    }

    public void Delivery()
    {
        if(canDelivery == false)
        {
            return;
        }
        EggCtrl egg = GameObject.FindGameObjectWithTag("Egg").GetComponent<EggCtrl>();
        egg.Delivery(collected.Cow, collected.Bird, collected.Fish, collected.Human);
        collected.Reste();
    }
}

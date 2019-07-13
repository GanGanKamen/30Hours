using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterCtrl : MonoBehaviour
{
    public float speed;
    public GameObject body;  //モデルオブジェクト
    [SerializeField] private GameObject attack; //発射するもの
    public bool canDelivery;

    // Start is called before the first frame update
    void Start()
    {
        
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
        
    }
}

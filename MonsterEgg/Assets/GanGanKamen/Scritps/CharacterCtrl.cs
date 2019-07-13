using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterCtrl : MonoBehaviour
{
    public float speed;
    public float dushSpeed;
    public GameObject body;  //モデルオブジェクト
    [SerializeField] private GameObject attack; //発射するもの
    public bool canDelivery;
    private Collected collected;
    public bool isDown;
    public bool isDush;
    [SerializeField]private float shootCoolTime;
    private bool canShoot;
    // Start is called before the first frame update
    void Start()
    {
        isDown = false;
        canShoot = true;
        collected = GetComponent<Collected>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CharacterMove(Vector3 direction)
    {
        if(isDown == true)
        {
            return;
        }
        if(isDush == false)
        {
            transform.Translate(direction * Time.deltaTime * speed);
            body.transform.localRotation = Quaternion.LookRotation(direction);
        }
        else
        {
            transform.Translate(direction * Time.deltaTime * dushSpeed);
            body.transform.localRotation = Quaternion.LookRotation(direction);
        }
    }

    public void Shoot()
    {
        StartCoroutine(StartShoot());
    }

    private IEnumerator StartShoot()
    {
        if (attack.active == true || isDown == true || isDush == true||canShoot == false)
        {
            yield break;
        }
        attack.SetActive(true);
        canShoot = false;
        GetComponent<CriAtomSource>().Play("SE_shot");
        yield return new WaitForSeconds(0.1f);
        attack.SetActive(false);
        yield return new WaitForSeconds(shootCoolTime);
        canShoot = true;
        yield break;
    }

    public void Delivery()
    {
        if(canDelivery == false || isDown == true || isDush == true)
        {
            return;
        }
        EggCtrl egg = GameObject.FindGameObjectWithTag("Egg").GetComponent<EggCtrl>();
        egg.Delivery(collected.Cow, collected.Bird, collected.Fish, collected.Human);
        collected.Reste();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            StartCoroutine(StartDown());
        }
    }

    private IEnumerator StartDown()
    {
        if(isDown == true)
        {
            yield break;
        }
        isDown = true;
        yield return new WaitForSeconds(5f);
        if(isDown == false)
        {
            yield break;
        }
        else
        {
            isDown = false;
            yield break;
        }
    }
}

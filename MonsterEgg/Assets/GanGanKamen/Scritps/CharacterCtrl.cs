using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterCtrl : MonoBehaviour
{
    public float speed;
    public float dushSpeed;
    public float collectedSpeed;
    public GameObject body;  //モデルオブジェクト
    [SerializeField] private GameObject attack; //発射するもの
    public bool canDelivery;
    private Collected collected;
    public bool isDown;
    public bool isDush;
    public bool isCollected;
    [SerializeField]private float shootCoolTime;
    private bool canShoot;
    public Animator animator;
    [SerializeField] private GameObject bag;
    public GameObject collectMark;
    // Start is called before the first frame update
    void Start()
    {
        isDown = false;
        canShoot = true;
        collected = GetComponent<Collected>();
        collectMark.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        CollectionCheck();
    }
    
    private void CollectionCheck()
    {
        if(collected.Cow + collected.Fish + collected.Bird + collected.Human > 0)
        {
            isCollected = true;
            bag.SetActive(true);
        }
        else
        {
            isCollected = false;
            bag.SetActive(false);
        }
    }

    public void CharacterMove(Vector3 direction)
    {
        if(isDown == true)
        {
            return;
        }
        if(isCollected == false)
        {
            if (isDush == false)
            {
                transform.Translate(direction * Time.deltaTime * speed);
                body.transform.localRotation = Quaternion.LookRotation(direction);
            }
            else
            {
                transform.Translate(direction * Time.deltaTime * dushSpeed);
                body.transform.localRotation = Quaternion.LookRotation(direction);
            }
            animator.SetBool("Dash", true);
        }
        else
        {
            transform.Translate(direction * Time.deltaTime * collectedSpeed);
            body.transform.localRotation = Quaternion.LookRotation(direction);
            animator.SetBool("Walk", true);
        }
    }

    public void CharacterStandby()
    {
        animator.SetBool("Dash", false);
        animator.SetBool("Walk", false);
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
        animator.SetTrigger("Attack");
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
        animator.SetTrigger("Throw");
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
        animator.SetBool("Stan", true);
        yield return new WaitForSeconds(5f);
        if(isDown == false)
        {
            yield break;
        }
        else
        {
            isDown = false;
            animator.SetBool("Stan", false);
            yield break;
        }
    }
}

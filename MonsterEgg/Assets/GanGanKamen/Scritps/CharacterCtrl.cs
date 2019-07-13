using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterCtrl : MonoBehaviour
{
    public float speed;
    public GameObject body;  //モデルオブジェクト
    [SerializeField] private Transform muzzle; //弾を発射する銃口
    [SerializeField] private GameObject attack;
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
        yield return new WaitForSeconds(0.1f);
        attack.SetActive(false);
        yield break;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterCtrl : MonoBehaviour
{
    public float speed;
    public GameObject body;
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
}

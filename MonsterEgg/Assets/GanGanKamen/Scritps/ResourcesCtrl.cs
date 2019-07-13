using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourcesCtrl : MonoBehaviour
{
    static public GameObject bullet;
    // Start is called before the first frame update
    void Start()
    {
        bullet = Resources.Load<GameObject>("Bullet");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

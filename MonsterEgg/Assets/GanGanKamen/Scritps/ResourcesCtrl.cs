using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourcesCtrl : MonoBehaviour
{
    static public GameObject bullet;
    static public GameObject sasageru;
    // Start is called before the first frame update
    void Start()
    {
        bullet = Resources.Load<GameObject>("Bullet");
        sasageru = Resources.Load<GameObject>("sasageru");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : MonoBehaviour
{
    public int dualshock4Num;
    private CharacterCtrl character;
    // Start is called before the first frame update
    void Start()
    {
        character = GetComponent<CharacterCtrl>();
    }

    // Update is called once per frame
    void Update()
    {
        KeyCtrl();
    }

    private void KeyCtrl()
    {
        if (Dualshock4.CircleDown(dualshock4Num))
        {
            character.Shoot();
        }
        CharaMove();
    }

    private void CharaMove()
    {
        if(Dualshock4.LeftStick(dualshock4Num).magnitude != 0)
        {
            var direction = new Vector3(Dualshock4.LeftStick(dualshock4Num).x,0, Dualshock4.LeftStick(dualshock4Num).y);
                //Dualshock4.LeftStick(dualshock4Num);
            character.CharacterMove(direction);
        }
    }
}

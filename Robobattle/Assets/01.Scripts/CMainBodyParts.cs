using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CMainBodyParts : CBaseParts
{
    public Vector3 Center=Vector3.zero;

    public CWeaponParts Weapon;
    public CWheelParts leftWheel;
    public CWheelParts RightWheel;

    public int Player=1;

    PlayerKeys Keys;

    // Start is called before the first frame update
    void Start()
    {
        Init();
        
    }

    void Init()
    {
        if (Player == 1) Keys = CPlayerKeys.Player1;
        else if (Player == 2) Keys = CPlayerKeys.Player2;

        Rb = GetComponent<Rigidbody>();
        Rb.centerOfMass = Center;

        Weapon.AttackKey = Keys.AttackKey;
        leftWheel.UpKey = Keys.LeftWhealUpKey;
        leftWheel.DownKey = Keys.LeftWhealDownKey;
        RightWheel.UpKey = Keys.RightWhealUpKey;
        RightWheel.DownKey = Keys.RightWhealDownKey;

        Weapon.MainBody = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

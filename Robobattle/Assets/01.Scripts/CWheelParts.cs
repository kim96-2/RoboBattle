using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CWheelParts : CBaseParts
{
    public KeyCode UpKey;
    public KeyCode DownKey;

    public float Force;

    public float MaxSpeed = 20f;


    // Start is called before the first frame update
    void Start()
    {
        Init();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Move();
    }

    void Init()
    {
        Rb = GetComponent<Rigidbody>();
        Rb.maxAngularVelocity = MaxSpeed;
    }

    void Move()
    {
        Vector3 WheelDir=Vector3.zero;

        if (Input.GetKey(UpKey) || Input.GetKey(DownKey))
        {

            WheelDir = Vector3.zero;
            if (Input.GetKey(UpKey))
            {
                WheelDir = transform.up;
            }
            if (Input.GetKey(DownKey))
            {
                WheelDir = -transform.up;
            }
            if (Input.GetKey(UpKey) && Input.GetKey(DownKey))
            {
                WheelDir = Vector3.zero;
            }
        }

        Rb.AddTorque(-WheelDir * Force,ForceMode.Impulse);
    }

    public override void HpDamage(float Damage)
    {
        base.HpDamage(Damage);
    }

    protected override void PartsDestroyed()
    {
        Destroy(this.gameObject.GetComponent<HingeJoint>());

        if(Rb.velocity.magnitude>3f)
            Rb.velocity = Rb.velocity.normalized * 3f;

        this.enabled = false;
    }
}

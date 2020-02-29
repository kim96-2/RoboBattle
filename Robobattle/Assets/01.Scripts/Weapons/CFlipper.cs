using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CFlipper : CWeaponParts
{
    List<GameObject> Collisions;

    HingeJoint FlipperJoint;

    public float AttackSpeed;
    public float NonAttackSpeed;

    // Start is called before the first frame update
    void Start()
    {
        Init();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        FlipperMove();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.rigidbody&&IsOn)
        {
            Vector3 dir = (collision.contacts[0].point - Rb.position).normalized;

            collision.rigidbody.AddForce(dir * 200f, ForceMode.Impulse);
            Rb.AddForce(-dir * 50f, ForceMode.Impulse);

            if (collision.gameObject.GetComponent<CBaseParts>())
            {
                if (CheckCollisions(collision.gameObject))
                    collision.gameObject.GetComponent<CBaseParts>().HpDamage(3f);
            }
        }
    }

    void Init()
    {
        Collisions = new List<GameObject>();

        Rb = GetComponent<Rigidbody>();

        FlipperJoint = GetComponent<HingeJoint>();
        FlipperJoint.useMotor = true;

        JointMotor motor = FlipperJoint.motor;
        motor.targetVelocity = NonAttackSpeed;
        FlipperJoint.motor = motor;

        IsOn = false;

        Energy = 0f;
    }

    protected bool CheckCollisions(GameObject Check)
    {
        foreach(GameObject Collision in Collisions)
        {
            if (Collision == Check)
                return false;
        }

        Collisions.Add(Check);

        return true;
    }

    void FlipperMove()
    {
        if (Input.GetKey(AttackKey) && !IsOn && Energy > EnergyUse)
        {
            UseEnergy();
            StartCoroutine("FlipperOn");    
        }
        else
        {
            PlusEnergy();
        }
    }

    IEnumerator FlipperOn()
    {
        IsOn = true;

        JointMotor motor = FlipperJoint.motor;
        motor.targetVelocity = AttackSpeed;
        FlipperJoint.motor = motor;

        yield return new WaitForSeconds(1.2f);

        motor = FlipperJoint.motor;
        motor.targetVelocity = NonAttackSpeed;
        FlipperJoint.motor = motor;

        yield return new WaitForSeconds(0.8f);

        IsOn = false;
        Collisions.Clear();
    }
}

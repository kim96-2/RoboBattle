using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CSpinner : CWeaponParts
{
    public float SpinnerSpeed;
    public float SpinnerMaxSpeed=100f;


    // Start is called before the first frame update
    void Start()
    {

        Debug.Log(transform.forward);
        Init();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        SpinnerMove();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.rigidbody&&IsOn)
        {
            //Debug.Log(collision.gameObject.name);

            Vector3 dir = (collision.contacts[0].point - Rb.position + transform.up).normalized;

            collision.rigidbody.AddForce(dir * 200f, ForceMode.Impulse);
            Rb.AddForce(-dir * 100f, ForceMode.Impulse);

            if (collision.gameObject.GetComponent<CBaseParts>())
            {
                collision.gameObject.GetComponent<CBaseParts>().HpDamage(1f);
            }
        }
    }

    void Init()
    {
        Rb = GetComponent<Rigidbody>();

        IsOn = false;

        Energy = 0f;

        SpinnerSpeed = 0f;
    }

    void SpinnerMove()
    {
        if (Input.GetKey(AttackKey)&& Energy > EnergyUse)
        {
            UseEnergy();

            IsOn = true;

            if (SpinnerSpeed < SpinnerMaxSpeed)
            {
                SpinnerSpeed += SpinnerMaxSpeed / 60f;
            }
            else
            {
                SpinnerSpeed = SpinnerMaxSpeed;
            }
        }
        else
        {

            PlusEnergy();
            IsOn = false;
            if (SpinnerSpeed > 0f)
            {
                SpinnerSpeed -= SpinnerMaxSpeed / 60f;
            }
            else
            {
                SpinnerSpeed = 0f;
            }
        }

        Rb.MoveRotation(Quaternion.Euler(Rb.rotation.eulerAngles.x, Rb.rotation.eulerAngles.y + SpinnerSpeed * Time.fixedDeltaTime, Rb.rotation.eulerAngles.z));
    }
}

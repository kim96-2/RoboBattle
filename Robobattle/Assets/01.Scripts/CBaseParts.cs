using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CBaseParts : MonoBehaviour
{
    public float hp;

    protected Rigidbody Rb;

    public virtual void HpDamage(float Damage)
    {
        if (hp - Damage > 0f)
        {
            hp -= Damage;
        }
        else
        {
            hp = 0;
            PartsDestroyed();
        }

        Debug.Log(this.gameObject.name + " Damage");
    }

    protected virtual void PartsDestroyed()
    {

    }
}

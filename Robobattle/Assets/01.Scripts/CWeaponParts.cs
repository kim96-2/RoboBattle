using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CWeaponParts : CBaseParts
{
    public KeyCode AttackKey;

    protected bool IsOn;

    public float MaxEnergy=100f;
    public float EnergyUse;
    public float Energy=0f;

    public CMainBodyParts MainBody;

    protected void PlusEnergy()
    {
        if (Energy + 10 * Time.fixedDeltaTime < MaxEnergy)
        {
            Energy += 10 * Time.deltaTime;
        }
        else
        {
            Energy = MaxEnergy;
        }
    }

    protected void UseEnergy()
    {
        if (Energy - EnergyUse > 0f)
        {
            Energy -= EnergyUse;
        }
        else
            Energy = 0f;
    }

    public override void HpDamage(float Damage)
    {
        if(MainBody!=null)
            MainBody.HpDamage(Damage);
    }
}

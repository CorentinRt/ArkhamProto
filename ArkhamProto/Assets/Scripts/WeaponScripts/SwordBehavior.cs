using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordBehavior : MeleeWeaponBehavior
{

    // Start is called before the first frame update
    //void Start()
    //{
        
    //}

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void Hit(GameObject target)
    {
        Debug.Log("Start hit");
        StartCoroutine(WaitBeforeHitCooldown(target, WeaponsData.SwordHitCooldown));
    }
    
    public override void ApplyHit(GameObject target)
    {
        if (1 << target.layer == Mask)
        {
            Debug.Log("Hit enemy");
            VfxManager.Instance.PlaySparksParticles(Weapon.position);
        }
    }

    public override void Damage(GameObject target)
    {
        throw new System.NotImplementedException();
    }

}

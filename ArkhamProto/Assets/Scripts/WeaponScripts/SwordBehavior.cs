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
        if ( 1 << target.layer == Mask)
        {
            Debug.Log("Hit enemy");
        }
        
    }

    public override void Damage(GameObject target)
    {
        throw new System.NotImplementedException();
    }
}

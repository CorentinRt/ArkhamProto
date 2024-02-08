using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public abstract class MeleeWeaponBehavior : MonoBehaviour
{
    // Fields

    Transform _weapon;

    LayerMask _mask;
    HitEntity _hitEntity;



    // Properties
    public LayerMask Mask { get => _mask; set => _mask = value; }
    public Transform Weapon { get => _weapon; set => _weapon = value; }
    public HitEntity HitEntity { get => _hitEntity; set => _hitEntity = value; }

    private void Awake()
    {
        
    }
    // Start is called before the first frame update
    void Start()
    {
        _hitEntity._onTriggerEnter += Hit;
    }
    private void OnDestroy()
    {
        _hitEntity._onTriggerEnter -= Hit;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    public abstract void Hit(GameObject target);
    public abstract void Damage(GameObject target);

    IEnumerator WaitBeforeHit()
    {
        yield return new WaitForSeconds(1);

        yield return null;
    }
}

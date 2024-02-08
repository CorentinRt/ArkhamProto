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

    WeaponsData _weaponsData;


    // Properties
    public LayerMask Mask { get => _mask; set => _mask = value; }
    public Transform Weapon { get => _weapon; set => _weapon = value; }
    public HitEntity HitEntity { get => _hitEntity; set => _hitEntity = value; }
    public WeaponsData WeaponsData { get => _weaponsData; set => _weaponsData = value; }

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
    public abstract void ApplyHit(GameObject target);
    public abstract void Damage(GameObject target);

    public IEnumerator WaitBeforeHitCooldown(GameObject target, float seconds)
    {
        yield return new WaitForSeconds(seconds);

        ApplyHit(target);

        yield return null;
    }
}

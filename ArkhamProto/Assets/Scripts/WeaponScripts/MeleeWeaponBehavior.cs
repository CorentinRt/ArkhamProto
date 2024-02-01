using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public abstract class MeleeWeaponBehavior : MonoBehaviour
{
    [SerializeField] LayerMask _mask;
    [SerializeField] HitEntity _hitEntity;

    private CapsuleCollider _capsuleCollider;

    private void Awake()
    {
        _capsuleCollider = GetComponentInChildren<CapsuleCollider>();
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
}

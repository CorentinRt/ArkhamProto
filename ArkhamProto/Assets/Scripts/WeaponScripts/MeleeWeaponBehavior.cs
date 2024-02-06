using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public abstract class MeleeWeaponBehavior : MonoBehaviour
{
    // Fields

    [SerializeField] LayerMask _mask;
    [SerializeField] HitEntity _hitEntity;

    private BoxCollider _boxCollider;


    // Properties
    public LayerMask Mask { get => _mask; set => _mask = value; }

    private void Awake()
    {
        _boxCollider = _hitEntity.gameObject.GetComponent<BoxCollider>();
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

using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class KnightFightController : MonoBehaviour
{

    enum MeleeType
    {
        Sword,
        Spear,
        Axe
    }

    // Fields

    [SerializeField] private InputActionReference _attack;
    [SerializeField] private InputActionReference _withdraw;
    [SerializeField] private Animator _animator;
    [SerializeField] private KnightMainStates _mainStates;

    [Header("Transforms")]
    [SerializeField] private Transform _sword;
    [SerializeField] private Transform _hands;
    [SerializeField] private Transform _hips;

    [Header("Weapon")]
    [SerializeField] private MeleeType _equippedWeapon;
    [SerializeField] private HitEntity _hitEntity;
    [SerializeField] private WeaponsData _weaponsData;

    [Header("Attack combo")]
    private bool _prepareAttack2;
    private float _timeBeforeAttack2;
    [SerializeField] private float _intervalStartAttack2;
    private Coroutine _attack1DurationCoroutine;
    private Coroutine _attack2DurationCoroutine;
    private LittleDashAttack _littleDashAttack;
    [SerializeField] private bool _littleDashActive;

    [Header("Parameters")]
    [SerializeField] private float _unsheatCooldown;
    [SerializeField] private float _sheatCooldown;

    private Coroutine _unsheatCooldownCoroutine;
    private Coroutine _sheatCooldownCoroutine;

    [Space(20)]

    [Header("Defined positions and rotations")]

    [SerializeField] private Vector3 _unsheatRotation;
    [SerializeField] private Vector3 _sheatRotation;


    private Vector3 _sheatPosition;
    [SerializeField] private Vector3 _unsheatPosition;

    private void Awake()
    {
        if (_equippedWeapon == MeleeType.Sword)
        {
            SwordBehavior swordBehavior = transform.parent.gameObject.AddComponent<SwordBehavior>();
            swordBehavior.HitEntity = _hitEntity;
            swordBehavior.Weapon = _sword;
            swordBehavior.Mask = LayerMask.GetMask("Enemy");
            swordBehavior.WeaponsData = _weaponsData;
        }
        
        _littleDashAttack = GetComponent<LittleDashAttack>();
    }

    // Start is called before the first frame update
    void Start()
    {

        _withdraw.action.started += StartWithdraw;
        _withdraw.action.canceled += EndWithdraw;

        _attack.action.started += StartAttack;
        //_attack.action.canceled += EndAttack;

        _sheatPosition = _sword.localPosition;

        _timeBeforeAttack2 = 1.2f;
    }
    private void OnDestroy()
    {
        _withdraw.action.started -= StartWithdraw;
        _withdraw.action.canceled -= EndWithdraw;

        _attack.action.started -= StartAttack;
        //_attack.action.canceled -= EndAttack;
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    private void StartAttack(InputAction.CallbackContext context)
    {
        if (_mainStates.CanAttack)
        {
            if (_littleDashActive)
            {
                _littleDashAttack.LittleDash();
            }

            if (_attack1DurationCoroutine == null)
            {
                _attack1DurationCoroutine = StartCoroutine(CooldownBeforeEndAttack());
            }
            _hitEntity.gameObject.SetActive(true);
            _mainStates.CanAttack = false;
            _animator.SetTrigger("Attack");
        }
        else if (!_prepareAttack2 && _timeBeforeAttack2 < _intervalStartAttack2)
        {
            _prepareAttack2 = true;
        }
    }
    private void EndAttack()
    {
        _hitEntity.gameObject.SetActive(false);

        if (_prepareAttack2)
        {
            StartAttack2();
        }
        else
        {
            _mainStates.CanAttack = true;
        }
    }

    private void StartAttack2()
    {
        if (_littleDashActive)
        {
            _littleDashAttack.LittleDash(); 
        }

        Debug.Log("Attack 2");

        if (_attack2DurationCoroutine == null)
        {
            _attack2DurationCoroutine = StartCoroutine(CooldownBeforeEndAttack2());
        }
        _hitEntity.gameObject.SetActive(true);
        _animator.SetBool("PrepareAttack2", true);
    }
    private void EndAttack2()
    {
        _prepareAttack2 = false;
        _mainStates.CanAttack = true;
        _hitEntity.gameObject.SetActive(false);
        _animator.SetBool("PrepareAttack2", false);
    }

    private void StartWithdraw(InputAction.CallbackContext context)
    {
        if(_mainStates.HasWithdraw)
        {
            if(_unsheatCooldownCoroutine == null)
            {
                SheatSword();
            }
        }
        else if(_sheatCooldownCoroutine == null)
        {
            UnsheatSword();
        }
    }
    private void EndWithdraw(InputAction.CallbackContext context)
    {
        
    }
    private void UnsheatSword()
    {
        _animator.SetTrigger("startWithdraw");
        _mainStates.HasWithdraw = true;
        _unsheatCooldownCoroutine = StartCoroutine(CooldownBeforeUnsheatCoroutine());
    }
    private void SheatSword()
    {
        _animator.SetTrigger("endWithdraw");
        _mainStates.HasWithdraw = false;
        _sheatCooldownCoroutine = StartCoroutine(CooldownBeforeSheatCoroutine());
    }

    private void SwordInHand()
    {
        _sword.parent = _hands;
    }
    private void SwordInHips()
    {
        _sword.parent = _hips;
    }

    IEnumerator CooldownBeforeUnsheatCoroutine()
    {
        yield return new WaitForSeconds(_unsheatCooldown);

        SwordInHand();

        _sword.localRotation = Quaternion.Euler(_unsheatRotation);

        _sword.localPosition = _unsheatPosition;

        _unsheatCooldownCoroutine = null;

        yield return null;
    }

    IEnumerator CooldownBeforeSheatCoroutine()
    {
        yield return new WaitForSeconds(_sheatCooldown);

        SwordInHips();

        _sword.localRotation = Quaternion.Euler(_sheatRotation);

        _sword.localPosition = _sheatPosition;

        _sheatCooldownCoroutine = null;

        yield return null;
    }

    IEnumerator CooldownBeforeEndAttack()
    {
        //yield return new WaitForSeconds(1.7f);

        float tempTime = _timeBeforeAttack2;
        while (_timeBeforeAttack2 > 0f)
        {
            _timeBeforeAttack2 -= Time.deltaTime;

            yield return null;
        }

        _timeBeforeAttack2 = tempTime;

        EndAttack();

        _attack1DurationCoroutine = null;

        yield return null;
    }
    IEnumerator CooldownBeforeEndAttack2()
    {
        yield return new WaitForSeconds(1.3f);

        EndAttack2();

        _attack2DurationCoroutine = null;

        yield return null;
    }

    //IEnumerator AttackLittleDashCoroutine()
    //{
    //    float distance = 5f;

    //    Transform parent = transform.parent;

    //    Vector3 initialPosition = parent.position;

    //    Vector3 targetPosition = parent.position + parent.forward * distance;

    //    float percent = 0f;

    //    float timeToTravel = 0.5f;

    //    while (percent < 1f)
    //    {
    //        Debug.Log("dash");
    //        transform.parent.position = Vector3.Lerp(initialPosition, targetPosition, percent);

    //        percent += Time.deltaTime / timeToTravel;

    //        yield return null;
    //    }

    //    yield return null;
    //}
}

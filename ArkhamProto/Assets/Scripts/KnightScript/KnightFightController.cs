using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class KnightFightController : MonoBehaviour
{
    [SerializeField] private InputActionReference _withdraw;
    [SerializeField] private Animator _animator;

    [SerializeField] private Transform _sword;
    [SerializeField] private Transform _hands;
    [SerializeField] private Transform _hips;

    [SerializeField] private float _unsheatCooldown;
    [SerializeField] private float _sheatCooldown;

    private Coroutine _unsheatCooldownCoroutine;
    private Coroutine _sheatCooldownCoroutine;

    [SerializeField] private Vector3 _unsheatRotation;
    [SerializeField] private Vector3 _sheatRotation;

    private Vector3 _sheatPosition;

    private bool _hasWithdraw;

    // Start is called before the first frame update
    void Start()
    {
        _withdraw.action.started += StartWithdraw;
        _withdraw.action.canceled += EndWithdraw;

        _sheatPosition = _sword.localPosition;
    }
    private void OnDestroy()
    {
        _withdraw.action.started -= StartWithdraw;
        _withdraw.action.canceled -= EndWithdraw;
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    private void StartWithdraw(InputAction.CallbackContext context)
    {
        if(_hasWithdraw)
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
        _hasWithdraw = true;
        _unsheatCooldownCoroutine = StartCoroutine(CooldownBeforeUnsheatCoroutine());
    }
    private void SheatSword()
    {
        _animator.SetTrigger("endWithdraw");
        _hasWithdraw = false;
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

        //Vector3 tempRot = _sword.localRotation.eulerAngles;
        //float percent = 0f;
        //while (percent < 1f)
        //{
        //    tempRot.x = Mathf.Lerp(tempRot.x, _unsheatRotation.x, percent);
        //    tempRot.y = Mathf.Lerp(tempRot.y, _unsheatRotation.y, percent);
        //    tempRot.z = Mathf.Lerp(tempRot.z, _unsheatRotation.z, percent);
        //    _sword.localRotation = Quaternion.Euler(tempRot);

        //    percent += Time.deltaTime;

        //    yield return null;
        //}
        _sword.localRotation = Quaternion.Euler(_unsheatRotation);

        _unsheatCooldownCoroutine = null;

        yield return null;
    }

    IEnumerator CooldownBeforeSheatCoroutine()
    {
        yield return new WaitForSeconds(_sheatCooldown);

        SwordInHips();

        //Vector3 tempRot = _sword.localRotation.eulerAngles;
        //float percent = 0f;
        //while (percent < 1f)
        //{
        //    tempRot.x = Mathf.Lerp(tempRot.x, _sheatRotation.x, percent);
        //    tempRot.y = Mathf.Lerp(tempRot.y, _sheatRotation.y, percent);
        //    tempRot.z = Mathf.Lerp(tempRot.z, _sheatRotation.z, percent);
        //    _sword.localRotation = Quaternion.Euler(tempRot);

        //    percent += 5f * Time.deltaTime;

        //    yield return null;
        //}
        _sword.localRotation = Quaternion.Euler(_sheatRotation);

        _sword.localPosition = _sheatPosition;

        _sheatCooldownCoroutine = null;

        yield return null;
    }
}

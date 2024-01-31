using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class KnightFightController : MonoBehaviour
{
    [SerializeField] private InputActionReference _withdraw;
    [SerializeField] private Animator _animator;

    private bool _hasWithdraw;

    // Start is called before the first frame update
    void Start()
    {
        _withdraw.action.started += StartWithdraw;
        _withdraw.action.canceled += EndWithdraw;
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
            SheatSword();
        }
        else
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
    }
    private void SheatSword()
    {
        _animator.SetTrigger("endWithdraw");
        _hasWithdraw = false;
    }
}

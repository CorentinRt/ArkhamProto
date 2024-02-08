using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class KnightMoveController : MonoBehaviour
{
    [SerializeField] private InputActionReference _move;

    [SerializeField] private KnightMainStates _mainStates;

    private Transform _knightTransform;

    [SerializeField] float _speed;
    private Vector2 _moveDirection;
    private Coroutine _moveCoroutine;

    [SerializeField] private Animator _animator;

    private event Action _onMoveStarted;
    private event Action _onMoveEnded;

    // Start is called before the first frame update
    void Start()
    {
        _knightTransform = transform.parent.GetComponent<Transform>();

        _move.action.started += StartMove;
        _move.action.performed += UpdateMove;
        _move.action.canceled += EndMove;
    }
    private void OnDestroy()
    {
        _move.action.started -= StartMove;
        _move.action.performed -= UpdateMove;
        _move.action.canceled -= EndMove;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void StartMove(InputAction.CallbackContext context)
    {
        _onMoveStarted?.Invoke();
        _moveDirection = context.ReadValue<Vector2>();
        _moveCoroutine = StartCoroutine(MoveCoroutine());
        _animator.SetTrigger("run");
        _animator.SetBool("isRunning", true);
    }
    private void UpdateMove(InputAction.CallbackContext context)
    {
        _moveDirection = context.ReadValue<Vector2>();
        if( MathF.Abs(_moveDirection.y) < MathF.Abs(_moveDirection.x) && _moveDirection.x > 0f )
        {
            _animator.SetBool("strafeFront", true);
        }
        else
        {
            _animator.SetBool("strafeFront", false);
        }
        if (MathF.Abs(_moveDirection.y) < MathF.Abs(_moveDirection.x) && _moveDirection.x < 0f)
        {
            _animator.SetBool("strafeBack", true);
        }
        else
        {
            _animator.SetBool("strafeBack", false);
        }
    }
    private void EndMove(InputAction.CallbackContext context)
    {
        _onMoveEnded?.Invoke();
        _moveDirection = context.ReadValue<Vector2>();
        StopCoroutine( _moveCoroutine );
        _animator.SetBool("isRunning", false);
        _animator.SetBool("strafeFront", false);
        _animator.SetBool("strafeBack", false);
    }

    IEnumerator MoveCoroutine()
    {

        while (true)
        {
            Vector3 tempDir = new Vector3(_moveDirection.x, 0f, _moveDirection.y);

            Vector3 tempMoveHorizontal = transform.right;
            Vector3 tempMoveVertical = transform.forward;
            Vector3 tempMove = tempMoveHorizontal * tempDir.x + tempMoveVertical * tempDir.z;

            _knightTransform.position += tempMove * _speed * Time.deltaTime;

            yield return null;
        }

        yield return null;
    }
}

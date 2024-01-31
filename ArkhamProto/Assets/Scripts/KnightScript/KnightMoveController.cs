using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class KnightMoveController : MonoBehaviour
{
    [SerializeField] private InputActionReference _move;

    [SerializeField] float _speed;
    private Vector2 _moveDirection;
    private Coroutine _moveCoroutine;

    private event Action _onMoveStarted;
    private event Action _onMoveEnded;

    // Start is called before the first frame update
    void Start()
    {
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
    }
    private void UpdateMove(InputAction.CallbackContext context)
    {
        _moveDirection = context.ReadValue<Vector2>();
    }
    private void EndMove(InputAction.CallbackContext context)
    {
        _onMoveEnded?.Invoke();
        _moveDirection = context.ReadValue<Vector2>();
        StopCoroutine( _moveCoroutine );
    }

    IEnumerator MoveCoroutine()
    {

        while (true)
        {
            Vector3 tempDir = new Vector3(_moveDirection.x, 0f, _moveDirection.y);

            transform.position += tempDir * _speed * Time.deltaTime;

            yield return null;
        }

        yield return null;
    }
}

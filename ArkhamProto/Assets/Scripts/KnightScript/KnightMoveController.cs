using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class KnightMoveController : MonoBehaviour
{
    [SerializeField] private InputActionReference _move;

    [SerializeField] float _speed;
    private Vector2 _moveDirection;

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

    }
    private void UpdateMove(InputAction.CallbackContext context)
    {

    }
    private void EndMove(InputAction.CallbackContext context)
    {

    }
}

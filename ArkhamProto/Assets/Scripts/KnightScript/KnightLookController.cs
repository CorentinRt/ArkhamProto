using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class KnightLookController : MonoBehaviour
{
    [SerializeField] private InputActionReference _look;

    [SerializeField] private float _lookSpeed;
    [SerializeField] Transform _lookHandler;
    private Vector2 _lookDirection;
    private Coroutine _lookCoroutine;

    // Start is called before the first frame update
    void Start()
    {
        _look.action.started += StartLook;
        _look.action.performed += UpdateLook;
        _look.action.canceled += EndLook;
    }
    private void OnDestroy()
    {
        _look.action.started -= StartLook;
        _look.action.performed -= UpdateLook;
        _look.action.canceled -= EndLook;
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    private void StartLook(InputAction.CallbackContext context)
    {
        _lookDirection = context.ReadValue<Vector2>();
        _lookCoroutine = StartCoroutine(LookCoroutine());
    }
    private void UpdateLook(InputAction.CallbackContext context)
    {
        _lookDirection = context.ReadValue<Vector2>();
    }
    private void EndLook(InputAction.CallbackContext context)
    {
        _lookDirection = context.ReadValue<Vector2>();
        StopCoroutine(_lookCoroutine);
    }

    IEnumerator LookCoroutine()
    {
        while (true)
        {
            Vector3 tempRot = _lookHandler.rotation.eulerAngles;

            Vector3 tempRot2 = transform.rotation.eulerAngles;

            tempRot2.y += _lookDirection.x;

            tempRot.x += _lookDirection.y;
            
            if(45f < tempRot.x && tempRot.x < 330f) // bloque rotation y dans un angle de 75 degres
            {
                if (Mathf.Abs(tempRot.x - 45f) <= Mathf.Abs(tempRot.x - 330f))
                {
                    tempRot.x = 45f;
                }
                else
                {
                    tempRot.x = 330f;
                }
            }

            _lookHandler.rotation = Quaternion.Euler(tempRot);

            transform.rotation = Quaternion.Euler(tempRot2);

            yield return null;
        }

        yield return null;
    }
}

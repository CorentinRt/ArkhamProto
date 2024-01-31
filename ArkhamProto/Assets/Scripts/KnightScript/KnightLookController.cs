using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class KnightLookController : MonoBehaviour
{
    [SerializeField] private InputActionReference _look;

    [SerializeField] private float _lookSpeed;
    private Vector2 _lookDirection;
    private Coroutine _lookCoroutine;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

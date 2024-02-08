using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnightMainStates : MonoBehaviour
{
    // Fields
    private bool _canAttack;
    private bool _hasWithdraw;
    private bool _isRunning;


    // Properties
    public bool CanAttack { get => _canAttack; set => _canAttack = value; }
    public bool HasWithdraw { get => _hasWithdraw; set => _hasWithdraw = value; }
    public bool IsRunning { get => _isRunning; set => _isRunning = value; }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

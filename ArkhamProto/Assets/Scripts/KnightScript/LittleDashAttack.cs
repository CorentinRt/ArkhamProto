using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LittleDashAttack : MonoBehaviour
{
    [SerializeField] float _distance;
    [SerializeField] float _timeToTravel;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LittleDash()
    {
        StartCoroutine(AttackLittleDashCoroutine());
    }


    IEnumerator AttackLittleDashCoroutine()
    {
        Transform parent = transform.parent;

        Vector3 initialPosition = parent.position;

        Vector3 targetPosition = parent.position + parent.forward * _distance;

        float percent = 0f;

        while (percent < 1f)
        {
            Debug.Log("dash");
            transform.parent.position = Vector3.Lerp(initialPosition, targetPosition, percent);

            percent += Time.deltaTime / _timeToTravel;

            yield return null;
        }

        yield return null;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VfxManager : MonoBehaviour
{
    private static VfxManager _instance;

    [SerializeField] private GameObject _sparksParticles;

    public static VfxManager Instance { get => _instance; set => _instance = value; }

    private void Awake()
    {
        if(_instance != null)
        {
            Destroy(_instance);
        }
        _instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlaySparksParticles(Vector3 position)
    {
        GameObject currentParticles = Instantiate(_sparksParticles, position, Quaternion.identity);
    }
}

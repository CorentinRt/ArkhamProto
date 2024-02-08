using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/WeaponsData", order = 1)]
public class WeaponsData : ScriptableObject
{
    [SerializeField] private float _swordHitCooldown;
    [SerializeField] private float _spearHitCooldown;
    [SerializeField] private float _axeHitCooldown;

    public float SwordHitCooldown { get => _swordHitCooldown; set => _swordHitCooldown = value; }
    public float SpearHitCooldown { get => _spearHitCooldown; set => _spearHitCooldown = value; }
    public float AxeHitCooldown { get => _axeHitCooldown; set => _axeHitCooldown = value; }
}

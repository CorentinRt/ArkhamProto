using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemAssets : MonoBehaviour
{
    private static ItemAssets _instance;

    public static ItemAssets Instance { get => _instance; set => _instance = value; }

    private void Awake()
    {
        if (_instance != null)
        {
            Destroy(_instance);
        }
        _instance = this;
    }

    [SerializeField] private Sprite _swordSprite;
    [SerializeField] private Sprite _healthPotionSprite;
    [SerializeField] private Sprite _manaPotionSprite;

    public Sprite SwordSprite { get => _swordSprite; set => _swordSprite = value; }
    public Sprite HealthPotionSprite { get => _healthPotionSprite; set => _healthPotionSprite = value; }
    public Sprite ManaPotionSprite { get => _manaPotionSprite; set => _manaPotionSprite = value; }
}

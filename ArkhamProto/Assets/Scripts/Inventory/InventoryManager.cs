using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InventoryManager : MonoBehaviour
{
    private Inventory _inventory;
    [SerializeField] private UI_Inventory _uiInventory;

    [SerializeField] private InputActionReference _inventoryInputAction;

    private void Awake()
    {
    }

    // Start is called before the first frame update
    void Start()
    {
        _inventory = new Inventory();
        _uiInventory.SetInventory(_inventory);

        _inventoryInputAction.action.started += ToggleInventory;
    }
    private void OnDestroy()
    {
        _inventoryInputAction.action.started -= ToggleInventory;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void ToggleInventory(InputAction.CallbackContext context)
    {
        if (_uiInventory.gameObject.activeSelf)
        {
            DesactiveInventory();
        }
        else
        {
            ActiveInventory();
        }
    }
    private void ActiveInventory()
    {
        _uiInventory.gameObject.SetActive(true);
    }
    private void DesactiveInventory()
    {
        _uiInventory.gameObject.SetActive(false);
    }
}

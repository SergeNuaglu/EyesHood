using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Quiver : MonoBehaviour
{
    [SerializeField] private int _startCapacity;
    [SerializeField] private PickUpItemsGenerator _pickUpItemsGenerator;

    private int _capacity;

    public int ItemsCount { get; private set; }

    public event UnityAction<int> ItemsCountChanged;

    private void Awake()
    {
        _capacity = _startCapacity;
    }

    private void OnEnable()
    {
        _pickUpItemsGenerator.ItemPickedUp += OnItemPickedUp;
    }

    private void OnDisable()
    {
        _pickUpItemsGenerator.ItemPickedUp -= OnItemPickedUp;
    }

    private void OnItemPickedUp()
    {
        if (ItemsCount < _capacity)
        {
            ItemsCount++;
            ItemsCountChanged?.Invoke(ItemsCount);
        }
    }

    public void UseItem()
    {
        ItemsCount--;
        ItemsCountChanged?.Invoke(ItemsCount);
    }
}

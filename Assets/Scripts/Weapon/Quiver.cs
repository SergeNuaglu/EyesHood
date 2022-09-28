using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class Quiver : MonoBehaviour
{
    [SerializeField] private int _capacity;
    [SerializeField] private PickUpItemsGenerator _pickUpItemsGenerator;
    [SerializeField] private LastLevelData _lastItemsCount;
    [SerializeField] private TMP_Text _countDisplay;

    public int ItemsCount { get; private set; }
    public int CurentCapacity => _capacity;

    public event UnityAction<int> ItemsCountChanged;

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
        AddItem();
    }

    public void AddItem()
    {
        if (ItemsCount < _capacity)
        {
            ItemsCount++;
            _countDisplay.text = ItemsCount.ToString();
            ItemsCountChanged?.Invoke(ItemsCount);
        }
    }

    public void UseItem()
    {
        ItemsCount--;
        _countDisplay.text = ItemsCount.ToString();
        ItemsCountChanged?.Invoke(ItemsCount);
    }

    public void ReturnLastItemCount()
    {
        ItemsCount = _lastItemsCount.Data;
        _countDisplay.text = ItemsCount.ToString();
        ItemsCountChanged?.Invoke(ItemsCount);
    }

    public void SaveLastItemCount()
    {
        _lastItemsCount.Set(ItemsCount);
    }
}

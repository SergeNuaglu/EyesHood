using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PickUpItemsGenerator : ObjectPool
{
    [SerializeField] List<Vector3> _pickUpPoints;
    [SerializeField] private PickUpItem _itemPrefab;

    public event UnityAction ItemPickedUp;

    private void Start()
    {
        Initialize(_itemPrefab.gameObject);

        foreach (var point in _pickUpPoints)
        {
            SetItemToPoint(point);
        }
    }

    private void OnPickedUp(PickUpItem item)
    {
        ItemPickedUp?.Invoke();
        item.PickedUp -= OnPickedUp;
        item.gameObject.SetActive(false);
    }

    public void SetItemToPoint(Vector3 installationPoint)
    {
        if (TryGetObject(out GameObject item))
        {
            item.SetActive(true);
            item.GetComponent<PickUpItem>().PickedUp += OnPickedUp;
            item.transform.position = installationPoint;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ProjectilesCounter : MonoBehaviour
{
    [SerializeField] private Quiver _quiver;
    [SerializeField] private TMP_Text _count;

    private void OnEnable()
    {
        _quiver.ItemsCountChanged += OnItemsCountChanged;
    }

    private void OnDisable()
    {
        _quiver.ItemsCountChanged += OnItemsCountChanged;

    }

    private void OnItemsCountChanged(int count)
    {
        _count.text = count.ToString();
    }
}

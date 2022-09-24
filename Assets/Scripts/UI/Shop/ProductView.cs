using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.Events;

public class ProductView : MonoBehaviour
{
    [SerializeField] private TMP_Text _label;
    [SerializeField] private TMP_Text _price;
    [SerializeField] private Image _icon;
    [SerializeField] private Button _sellButton;

    private Product _product;

    public event UnityAction<Product, ProductView> SellButtonClicked;

    private void OnEnable()
    {
        _sellButton.onClick.AddListener(OnSellButtonClick);
    }

    private void OnDisable()
    {
        _sellButton.onClick.RemoveListener(OnSellButtonClick);
    }

    public void Render(Product product)
    {
        _product = product;

        _label.text = product.Label;
        _price.text = product.Price.ToString();
        _icon.sprite = product.Icon;
        _icon.SetNativeSize();
    }

    private void OnSellButtonClick()
    {
        SellButtonClicked?.Invoke(_product, this);
        //_product.Sell();
    }
}

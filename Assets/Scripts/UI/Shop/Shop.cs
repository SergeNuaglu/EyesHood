using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    [SerializeField] private List<Product> _products;
    [SerializeField] private ProductView _tamplate;
    [SerializeField] private Transform _container;
    [SerializeField] private Button _quitButton;

    private Player _player;
    private Quiver _arrowQuiver;
    private Quiver _spearQuiver;

    public event UnityAction QuitButtonClicked;

    private void OnEnable()
    {
        _quitButton.onClick.AddListener(OnQuitButtonClicked);
    }

    private void OnDisable()
    {
        _quitButton.onClick.RemoveListener(OnQuitButtonClicked);
    }

    private void Start()
    {
        foreach (var product in _products)
        {
            if (product.TryGetComponent<ArrowProduct>(out ArrowProduct arrowProduct))
                arrowProduct.Init(_arrowQuiver);
            else if (product.TryGetComponent<SpearProduct>(out SpearProduct spearProduct))
                spearProduct.Init(_spearQuiver);
            else if (product.TryGetComponent<HealthProduct>(out HealthProduct healthProduct))
                healthProduct.Init(_player);

            AddProduct(product);
        }
    }

    public void Init(Player player, Quiver arrowQuiver, Quiver spearQuiver)
    {
        _player = player;
        _arrowQuiver = arrowQuiver;
        _spearQuiver = spearQuiver;
    }

    private void AddProduct(Product product)
    {
        ProductView view = Instantiate(_tamplate, _container);
        view.SellButtonClicked += OnSellButtonClicked;
        view.Render(product);
    }

    private void OnQuitButtonClicked()
    {
        QuitButtonClicked?.Invoke();
    }

    private void OnSellButtonClicked(Product product, ProductView productView)
    {
        TrySellproduct(product,productView);
    }

    private void TrySellproduct(Product product, ProductView productView)
    {
        if (product.Price <= _player.Money)
        {
            if (product.TryBuy())
                _player.Pay(product.Price);
        }
    }
}

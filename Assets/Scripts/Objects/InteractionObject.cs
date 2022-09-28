using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(HasherAnimationsNames))]

public class InteractionObject : MonoBehaviour
{
    [SerializeField] private int _health;
    [SerializeField] private PickUpItemsGenerator _pickUpItemGenerator;
    [SerializeField] private CoinPoint _coinPoint;

    private Animator _animator;
    private HasherAnimationsNames _animatorNames;
    private Coroutine _showCoinRoutine;
    private WaitForSeconds _timeBeforShowCoin = new WaitForSeconds(0.5f);

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _animatorNames = GetComponent<HasherAnimationsNames>();
    }

    public void ApllyDamage(int damage)
    {
        int _minHealth = 0;

        _health -= damage;

        if (_health <= _minHealth)
            Destruct();
        else
            _animator.Play(_animatorNames.HashApplyDamage);
    }

    private void Destruct()
    {
        _animator.Play(_animatorNames.HashDie);
        _showCoinRoutine = StartCoroutine(ShowCoin());
        DisableObjectAbroadScreen();
    }

    private void DisableObjectAbroadScreen()
    {
        Camera camera = Camera.main;
        Vector3 disableLeftPoint = camera.ViewportToWorldPoint(new Vector3(0, 0.5f, camera.nearClipPlane));
        Vector3 disableRightPoint = camera.ViewportToWorldPoint(new Vector3(1, 0.5f, camera.nearClipPlane));

        if (transform.position.x < disableLeftPoint.x || transform.position.x > disableRightPoint.x)
            Destroy(gameObject);
    }

    private IEnumerator ShowCoin()
    {
        yield return _timeBeforShowCoin;
        _pickUpItemGenerator.SetItemToPoint(_coinPoint.transform.position);
        StopCoroutine(_showCoinRoutine);
        _showCoinRoutine = null;
    }
}

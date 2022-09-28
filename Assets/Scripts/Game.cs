using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
{
    [SerializeField] private Player _player;

    [SerializeField] private StartScreen _startScreen;
    [SerializeField] private StartScreen _restartScreen;
    [SerializeField] private FinalScreen _winScreen;
    [SerializeField] private FinalScreen _gameOverScreen;
    [SerializeField] private Shop _shop;
    [SerializeField] private Quiver _arrowQuiver;
    [SerializeField] private Quiver _spearQuiver;
    [SerializeField] private LastLevelData _lastSceneBuildIndex;
    [SerializeField] private LastLevelData _isRestartIndex;

    private Coroutine _stopGameRoutine;
    private WaitForSeconds _timeBeforGamerStop = new WaitForSeconds(3);

    private void OnEnable()
    {
        _startScreen.StartButtonClicked += OnStartButtonClicked;
        _startScreen.ShopButtonClicked += OnShopButtonClicked;
        _restartScreen.StartButtonClicked += OnRestartButtonClicked;
        _restartScreen.ShopButtonClicked += OnShopButtonClicked;
        _gameOverScreen.StartOverButtonClicked += OnStartOverButtonClicked;
        _gameOverScreen.ExitButtonClicked += OnExitButtonClicked;
        _winScreen.StartOverButtonClicked += OnStartOverButtonClicked;
        _winScreen.ExitButtonClicked += OnExitButtonClicked;
        _shop.QuitButtonClicked += OnQuitButtonClicked;
        _player.GameOver += OnGameOver;
        _player.BossKilled += OnBossKilled;

        _shop.Init(_player, _arrowQuiver, _spearQuiver);
    }

    private void OnDisable()
    {
        _startScreen.StartButtonClicked -= OnStartButtonClicked;
        _startScreen.ShopButtonClicked -= OnShopButtonClicked;
        _restartScreen.StartButtonClicked -= OnStartButtonClicked;
        _restartScreen.ShopButtonClicked -= OnShopButtonClicked;
        _gameOverScreen.StartOverButtonClicked -= OnStartOverButtonClicked;
        _gameOverScreen.ExitButtonClicked -= OnExitButtonClicked;
        _winScreen.StartOverButtonClicked -= OnStartOverButtonClicked;
        _winScreen.ExitButtonClicked -= OnExitButtonClicked;
        _shop.QuitButtonClicked -= OnQuitButtonClicked;
        _player.GameOver -= OnGameOver;
        _player.BossKilled -= OnBossKilled;


        if (Convert.ToBoolean(_isRestartIndex.Data) == false)
        {
            _arrowQuiver.SaveLastItemCount();
            _spearQuiver.SaveLastItemCount();
        }
    }

    private void Start()
    {
        _lastSceneBuildIndex.Set(SceneManager.GetActiveScene().buildIndex);
        _restartScreen.Close();
        _winScreen.Close();
        _gameOverScreen.Close();
        _shop.gameObject.SetActive(false);

        if (Convert.ToBoolean(_isRestartIndex.Data) == false)
        {
            Time.timeScale = 0;
        }
        else
        {
            _startScreen.Close();
            _isRestartIndex.Set(Convert.ToInt32(false));
        }

        _arrowQuiver.ReturnLastItemCount();
        _spearQuiver.ReturnLastItemCount();
    }


    private void OnStartButtonClicked()
    {
        _startScreen.Close();
        StartGame();
    }

    private void OnShopButtonClicked()
    {
        _shop.gameObject.SetActive(true);
    }

    private void OnRestartButtonClicked()
    {
        _isRestartIndex.Set(Convert.ToInt32(true));
        SceneManager.LoadScene(_lastSceneBuildIndex.Data);
        StartGame();
    }

    private void OnQuitButtonClicked()
    {
        _shop.gameObject.SetActive(false);
    }

    private void OnStartOverButtonClicked()
    {
        _gameOverScreen.Close();
        _player.PlayerData.LastHeartCount.Set(_player.PlayerData.MaxHeartCount);
        _lastSceneBuildIndex.Reset();
        _isRestartIndex.Reset();
        SceneManager.LoadScene(_lastSceneBuildIndex.Data);
        StartGameOver();
    }

    private void StartGame()
    {
        Time.timeScale = 1;
    }

    private void StartGameOver()
    {
        _player.ResetLevelData();
        StartGame();
    }

    private void OnGameOver()
    {
        _player.PlayerData.LastHeartCount.Set(_player.PlayerData.LastHeartCount.Data - 1);

        if (_player.PlayerData.LastHeartCount.Data > 0)
            _stopGameRoutine = StartCoroutine(StopGame(_restartScreen));
        else
            _stopGameRoutine = StartCoroutine(StopGame(_gameOverScreen));

        _player.ReturnLastLevelData();
    }

    private void OnBossKilled()
    {
        _stopGameRoutine = StartCoroutine(StopGame(_winScreen));
    }

    private void OnExitButtonClicked()
    {
        Application.Quit();
    }

    private IEnumerator StopGame(Screen openScreen)
    {
        yield return _timeBeforGamerStop;
        Time.timeScale = 0;
        openScreen.Open();
        StopCoroutine(_stopGameRoutine);
        _stopGameRoutine = null;
    }
}

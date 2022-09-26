using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
{
    [SerializeField] private Player _player;

    [SerializeField] private StartScreen _startScreen;
    [SerializeField] private RestartScreen _restartScreen;
    [SerializeField] private WinScreen _winScreen;
    [SerializeField] private GameOverScreen _gameOverScreen;
    [SerializeField] private Shop _shop;
    [SerializeField] private Quiver _arrowQuiver;
    [SerializeField] private Quiver _spearQuiver;
    [SerializeField] private LastLevelData _lastSceneBuildIndex;
    [SerializeField] private LastLevelData _isRestartIndex;

    private WaitForSeconds _timeBeforGamerOver = new WaitForSeconds(3);

    private void OnEnable()
    {
        _startScreen.PlayButtonClicked += OnPlayButtonClicked;
        _startScreen.ShopButtonClicked += OnShopButtonClicked;
        _restartScreen.RestartButtonClicked += OnRestartButtonClicked;
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
        _startScreen.PlayButtonClicked -= OnPlayButtonClicked;
        _startScreen.ShopButtonClicked -= OnShopButtonClicked;
        _restartScreen.RestartButtonClicked -= OnPlayButtonClicked;
        _restartScreen.ShopButtonClicked -= OnShopButtonClicked;
        _gameOverScreen.StartOverButtonClicked -= OnStartOverButtonClicked;
        _gameOverScreen.ExitButtonClicked -= OnExitButtonClicked;
        _winScreen.StartOverButtonClicked -= OnStartOverButtonClicked;
        _winScreen.ExitButtonClicked -= OnExitButtonClicked;
        _shop.QuitButtonClicked -= OnQuitButtonClicked;
        _player.GameOver -= OnGameOver;
        _player.BossKilled -= OnBossKilled;


        if (Convert.ToBoolean(_isRestartIndex) == false)
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

        if (Convert.ToBoolean(_isRestartIndex) == false)
        {
            Time.timeScale = 0;
            _startScreen.Open();
        }
        else
        {
            _startScreen.Close();
            _isRestartIndex.Set(Convert.ToInt32(false));
        }

        _player.ReturnLastLevelData();
        _arrowQuiver.ReturnLastItemCount();
        _spearQuiver.ReturnLastItemCount();
    }


    private void OnPlayButtonClicked()
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
        _isRestartIndex.Set(Convert.ToInt32(true));
        _player.PlayerData.LastHeartCount.Set(_player.PlayerData.MaxHeartCount);
        _lastSceneBuildIndex.Reset();
        SceneManager.LoadScene(_lastSceneBuildIndex.Data);
        StartGameOver();
    }

    private void StartGame()
    {
        Time.timeScale = 1;
    }

    private void StartGameOver()
    {
        _player.ResetPlayer();
        StartGame();
    }

    private void OnGameOver()
    {
        _player.PlayerData.LastHeartCount.Set(_player.PlayerData.LastHeartCount.Data - 1);
        StartCoroutine(StopGame());
    }

    private void OnBossKilled()
    {
        _winScreen.Open();
    }

    private void OnExitButtonClicked()
    {
        Application.Quit();
    }

    private IEnumerator StopGame()
    {
        yield return _timeBeforGamerOver;
        Time.timeScale = 0;
        _player.ReturnLastLevelData();

        if (_player.PlayerData.LastHeartCount.Data > 0)
            _restartScreen.Open();
        else
            _gameOverScreen.Open();

        StopCoroutine(StopGame());
    }
}

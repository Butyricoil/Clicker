using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [Header("UI References")]
    [SerializeField] private TMP_Text clicksTotalText;
    [SerializeField] private TMP_Text autoClickRateText;
    [SerializeField] private Button upgradeButton;

    [Header("Game Settings")]
    [SerializeField] private int autoClicksPerSecond = 1;
    [SerializeField] private int minimumClicksToUnlock = 50;
    [SerializeField] private float upgradeCostMultiplier = 1.5f;

    private float _totalClicks; // Изменено на float для корректной работы авто-кликов
    private bool _hasUpgrade;
    private int _currentUpgradeLevel = 0;
    private int _nextUpgradeCost;

    private void Start()
    {
        LoadGame(); // Загружаем данные при старте
        _nextUpgradeCost = minimumClicksToUnlock;
        upgradeButton.onClick.AddListener(UnlockAutoClick);
        UpdateUI();
    }

    public void AddClicks()
    {
        _totalClicks++;
        UpdateUI();
    }

    public void UnlockAutoClick()
    {
        if (_totalClicks >= _nextUpgradeCost)
        {
            _totalClicks -= _nextUpgradeCost;
            _hasUpgrade = true;
            _currentUpgradeLevel++;
            _nextUpgradeCost = (int)(minimumClicksToUnlock * Mathf.Pow(upgradeCostMultiplier, _currentUpgradeLevel));
            UpdateUI();
        }
    }

    private void Update()
    {
        if (_hasUpgrade)
        {
            _totalClicks += autoClicksPerSecond * _currentUpgradeLevel * Time.deltaTime;
            UpdateUI();
        }
    }

    private void UpdateUI()
    {
        // Изменено на "F0" для отображения без дробной части
        clicksTotalText.text = Mathf.FloorToInt(_totalClicks).ToString();

        if (_hasUpgrade)
        {
            autoClickRateText.text = $"Auto-click: {autoClicksPerSecond * _currentUpgradeLevel}/sec (Level {_currentUpgradeLevel})";
        }
        else
        {
            autoClickRateText.text = "Auto-click: Locked";
        }

        upgradeButton.interactable = _totalClicks >= _nextUpgradeCost;
        upgradeButton.GetComponentInChildren<TMP_Text>().text = $"Upgrade Auto-click\nCost: {_nextUpgradeCost}";
    }

    private void OnApplicationQuit()
    {
        SaveGame();
    }

    private void OnApplicationPause(bool pauseStatus)
    {
        if (pauseStatus)
        {
            SaveGame();
        }
    }

    private void SaveGame()
    {
        PlayerPrefs.SetFloat("TotalClicks", _totalClicks);
        PlayerPrefs.SetInt("UpgradeLevel", _currentUpgradeLevel);
        PlayerPrefs.Save();
    }

    private void LoadGame()
    {
        _totalClicks = PlayerPrefs.GetFloat("TotalClicks", 0);
        _currentUpgradeLevel = PlayerPrefs.GetInt("UpgradeLevel", 0);
        _hasUpgrade = _currentUpgradeLevel > 0;
        _nextUpgradeCost = _hasUpgrade ?
            (int)(minimumClicksToUnlock * Mathf.Pow(upgradeCostMultiplier, _currentUpgradeLevel)) :
            minimumClicksToUnlock;
    }

    // Метод для сброса прогресса (можно вызвать из UI)
    public void ResetProgress()
    {
        _totalClicks = 0;
        _currentUpgradeLevel = 0;
        _hasUpgrade = false;
        _nextUpgradeCost = minimumClicksToUnlock;
        PlayerPrefs.DeleteAll();
        UpdateUI();
    }
}
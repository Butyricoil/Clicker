using TMPro;
using UnityEngine;
using UnityEngine.UI;

// Это скрипт представления, который отвечает за отображение информации об автоклике.
public class AutoClickView : MonoBehaviour
{
    [SerializeField] private Button _upgradeButton;
    [SerializeField] private TMP_Text _levelText;
    [SerializeField] private TMP_Text _rateText;
    [SerializeField] private TMP_Text _costText;

    public Button UpgradeButton => _upgradeButton;

    public void UpdateInfo(int level, int rate, int cost, bool canAfford)
    {
        _levelText.text = $"Level: {level}";
        _rateText.text = $"Rate: {rate}/sec";
        _costText.text = $"Cost: {cost}";
        _upgradeButton.interactable = canAfford;
    }
}
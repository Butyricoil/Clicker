using TMPro;
using UnityEngine;
using UnityEngine.UI;

// Это скрипт представления, который отвечает за отображение информации об обновлении.
public class AddClicks : MonoBehaviour
{
    [SerializeField] private Button _upgradeButton;
    [SerializeField] private TMP_Text _upgradeText;

    public Button UpgradeButton => _upgradeButton;

    public void UpdateUpgradeInfo(int cost, bool canAfford)
    {
        _upgradeText.text = $"Upgrade ({cost})";
        _upgradeButton.interactable = canAfford;
    }
}
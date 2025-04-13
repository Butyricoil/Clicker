using TMPro;
using UnityEngine;
using UnityEngine.UI;

// Управляет кнопкой улучшения, привязан к Button View

public class UpgradeView : MonoBehaviour
{
    [SerializeField] private Button _upgradeButton;
    [SerializeField] private TMP_Text _upgradeButtonText;

    public Button.ButtonClickedEvent OnUpgradeClicked => _upgradeButton.onClick;

    public void SetUpgradeButtonState(bool canUpgrade, int cost)
    {
        _upgradeButton.interactable = canUpgrade;
        _upgradeButtonText.text = $"Upgrade Auto-click\nCost: {cost}";
    }
}
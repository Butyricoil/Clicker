using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

// Это скрипт представления, который отвечает за отображение информации об обновлении.
public class AddClickView : MonoBehaviour
{
    [SerializeField] private Button _addClickButton;
    [SerializeField] private TMP_Text _addClickText;

    public Button AddClickButton => _addClickButton;

    public void UpdateUpgradeInfo(int cost, bool canAfford)
    {
        _addClickText.text = $"Upgrade ({cost})";
        _addClickButton.interactable = canAfford;
    }
}
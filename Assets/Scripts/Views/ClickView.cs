using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ClickerView : MonoBehaviour
{
    [SerializeField] private Button _clickButton;
    [SerializeField] private TMP_Text _clicksText;

    public Button ClickButton => _clickButton;

    public void UpdateClicks(int count)
    {
        _clicksText.text = $"Clicks: {count}";
    }
}
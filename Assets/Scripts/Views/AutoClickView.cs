using TMPro;
using UnityEngine;

// Это скрипт представления, который отвечает за отображение информации об автоматическом клике.
public class AutoClickView : MonoBehaviour
{
    [SerializeField] private TMP_Text _autoClickRateText;

    public void UpdateAutoClickInfo(int level, int clicksPerSecond)
    {
        _autoClickRateText.text = level > 0
            ? $"Auto-click: {clicksPerSecond * level}/sec (Level {level})"
            : "Auto-click: Locked";
    }
}
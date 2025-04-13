using TMPro;
using UnityEngine;

// Показывает уровень и скорость авто-кликов, привязн к View

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
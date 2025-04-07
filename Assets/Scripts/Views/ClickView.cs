using TMPro;
using UnityEngine;

public class ClickView : MonoBehaviour
{
    [SerializeField] private TMP_Text _clicksTotalText;

    public void UpdateClicks(float totalClicks)
    {
        _clicksTotalText.text = Mathf.FloorToInt(totalClicks).ToString();
    }
}
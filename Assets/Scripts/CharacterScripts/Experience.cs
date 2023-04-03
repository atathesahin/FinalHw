using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class Experience : MonoBehaviour
{
    [SerializeField] private Slider slider;
    [SerializeField] private TextMeshProUGUI expText;

    public void UpdateExperience(int current, int target)
    {

        slider.maxValue = target;
        slider.value = current;
    }

    public void SetLevelText(int level)
    {
        expText.text = level.ToString();
    }
}

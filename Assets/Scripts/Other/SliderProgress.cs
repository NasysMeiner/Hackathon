using UnityEngine;
using UnityEngine.UI;

public class SliderProgress : MonoBehaviour
{
    [SerializeField] private Image _image;

    public void ViewProgress(float current, float max)
    {
        _image.fillAmount = current / max;
    }
}

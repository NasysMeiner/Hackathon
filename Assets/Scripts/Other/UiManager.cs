using UnityEngine;

public class UiManager : MonoBehaviour
{
    [SerializeField] private SliderProgress _sliderProgress;

    public void ResetProgressBar()
    {
        _sliderProgress.gameObject.SetActive(false);
    }

    public void ViewProgressBar(float current, float max)
    {
        _sliderProgress.ViewProgress(current, max);

        if (_sliderProgress.gameObject.activeSelf == false)
            _sliderProgress.gameObject.SetActive(true);
    }
}

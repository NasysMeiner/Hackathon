using TMPro;
using UnityEngine;

public class UiManager : MonoBehaviour
{
    [SerializeField] private SliderProgress _sliderProgress;
    [SerializeField] private TMP_Text _textInteractable;

    public void ViewTextInteractable()
    {
        _textInteractable.gameObject.SetActive(true);
    }

    public void CloseTextInteractable()
    {
        _textInteractable.gameObject.SetActive(false);
    }

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

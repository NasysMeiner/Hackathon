using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    public static UiManager instance;
    [SerializeField] private SliderProgress _sliderProgress;
    [SerializeField] private TMP_Text _textInteractable;
    [SerializeField] private TMP_Text _textValveInteractable;
    [SerializeField] private TMP_Text _textAttention;
    [SerializeField] private TMP_Text _textFuel;
    [SerializeField] private TMP_Text _universalText;
    [SerializeField] private GameObject _fuelText;
    [SerializeField] private GameObject _textPanelObj;
    [SerializeField] private TMP_Text _textPanel;
    [SerializeField] private TMP_Text _textName;
    [SerializeField] private int _timeDialog = 10;
    [SerializeField] private Image _image;
    [SerializeField] private Sprite astro_spr;
    [SerializeField] private Sprite robo_spr;

    private void Awake()
    {
        instance = this;
    }

    private bool _isActiveText = false;

    public bool IsActiveText => _isActiveText;

    private void Start()
    {
        _sliderProgress.gameObject.SetActive(false);
        _textInteractable.gameObject.SetActive(false);
        _textInteractable.text = "Press E";
        _textValveInteractable.gameObject.SetActive(false);
        _fuelText.gameObject.SetActive(false);
    }

    public void OpenFuelText()
    {
        _fuelText.gameObject.SetActive(true);
    }

    public void CloseFuelText()
    {
        _fuelText.gameObject.SetActive(false);
    }

    public void ViewText(string text)
    {
        _universalText.text = text;
        _universalText.gameObject.SetActive(true);
    }

    public void CloseText()
    {
        _universalText.gameObject.SetActive(false);
    }

    public void ViewTextInteractable()
    {
        _textInteractable.gameObject.SetActive(true);
        _isActiveText = true;
    }

    public void CloseTextInteractable()
    {
        _textInteractable.gameObject.SetActive(false);
        _isActiveText = false;
    }

    public void ViewTextValve()
    {
        _textValveInteractable.gameObject.SetActive(true);
    }

    public void CloseViewTextValve()
    {
        _textValveInteractable.gameObject.SetActive(false);
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

    public void AtenntionPayalnik()
    {
        _textAttention.gameObject.SetActive(true);
    }

    public void AtenntionPayalnikClose()
    {
        _textAttention.gameObject.SetActive(false);
    }

    public void Fuel(float fuel)
    {
        _textFuel.text = "Топливо в канистре: " + Convert.ToInt32(fuel) + "/100";
    }

    public void Speak(string name, string text/*, Sprite speaker*/)
    {
        if (name == "Робот")
            _image.sprite = robo_spr;
        else if(name == "Капитан")
            _image.sprite = astro_spr;

        _textPanelObj.SetActive(true);
        _textPanel.text = text;
        _textName.text = name;
    }

    public void CloseDialog()
    {
        _textPanelObj.SetActive(false);
    }
}

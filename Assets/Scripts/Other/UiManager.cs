using System;
using System.Collections;
using TMPro;
using Unity.VisualScripting;
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

    private void Awake()
    {
        instance = this;
    }

    public void ViewTextInteractable()
    {
        _textInteractable.gameObject.SetActive(true);
    }

    public void CloseTextInteractable()
    {
        _textInteractable.gameObject.SetActive(false);
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

    public GameObject textPanel;
    public Text mainText;
    public void Speak(string name, string text/*, Sprite speaker*/)
    {
        textPanel.SetActive(true);
        textPanel.GetComponentInChildren<Text>().text = name;
        mainText.text = text;
        //textPanel.GetComponentInChildren<Image>().sprite = speaker;
        StartCoroutine(TextOut());
    }

    IEnumerator TextOut()
    {
        yield return new WaitForSeconds(10);
        textPanel.SetActive(false);
    }
}

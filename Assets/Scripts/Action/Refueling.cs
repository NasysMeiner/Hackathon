using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Refueling : MonoBehaviour, IInteractable
{
    [SerializeField] private bool _isInteractable = true;
    [SerializeField] private string _textFullFuel = "Full fuel";
    [SerializeField] private UiManager _uiManager;

    private string _textPress = "Press E";

    public bool IsInteractable { get { return _isInteractable; } set { } }

    public void Action()
    {
        if(PlayerContoller.Instance.hand == 2 && IsInteractable)
        {
            _uiManager.OpenFuelText();

            if (!PlayerContoller.FuelController.IsMax)
            {
                _uiManager.ViewText(_textPress);

                if (Input.GetKey(KeyCode.E))
                {
                    PlayerContoller.FuelController.FillUp();
                }
            }
            else
            {
                _uiManager.ViewText(_textFullFuel);
            }
        }
        else
        {
            _uiManager.CloseFuelText();
            _uiManager.ViewText("No item");
        }
    }

    public void ActivateView()
    {
        throw new System.NotImplementedException();
    }

    public void DeActivateView()
    {
        throw new System.NotImplementedException();
    }
}

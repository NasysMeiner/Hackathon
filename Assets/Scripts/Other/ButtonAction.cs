using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class ButtonAction : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private Hole _interactable;

    private bool _pressed = false;
    private bool _isPressed = false;

    private void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0) && _pressed == false && _isPressed)
        {
            _pressed = true;
            _interactable.Action();
            _pressed = false;
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        _isPressed = false;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        _isPressed = true;
    }
}

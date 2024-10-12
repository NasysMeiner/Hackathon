using UnityEngine;

[RequireComponent (typeof(BoxCollider))]
public class InteractableRadius : MonoBehaviour
{
    [SerializeField] private float _radius;
    [SerializeField] private UiManager _uiManager;

    private bool _isActive = false;
    private BoxCollider _collider;
    private IInteractable _interactable;

    private void Start()
    {
        _collider = GetComponent<BoxCollider> ();
        _collider.size = new Vector3(0.01f, 0.01f, 1 * _radius);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out IInteractable interactable))
        {
            if (interactable.IsInteractable && !_isActive)
            {
                _isActive = true;
                _interactable = interactable;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out IInteractable interactable))
        {
            if (_isActive)
            {
                _interactable = null;
                _isActive = false;
                _uiManager.AtenntionPayalnikClose();
                _uiManager.CloseTextInteractable();
                _uiManager.CloseViewTextValve();
                _uiManager.ResetProgressBar();
                _uiManager.CloseFuelText();
                _uiManager.CloseText();
            }
        }
    }

    private void Update()
    {
        if(_interactable != null)
        {
            _interactable.Action();
        }

        if (_interactable != null &&!_interactable.IsInteractable)
            _interactable = null;
    }
}

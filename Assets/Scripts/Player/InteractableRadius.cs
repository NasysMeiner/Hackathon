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
        _collider.size = new Vector3(0.1f, 0.1f, 1 * _radius);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out IInteractable interactable))
        {
            if (interactable.IsInteractable && !_isActive)
            {
                _isActive = true;
                _interactable = interactable;
                interactable.Action();
                interactable.ActivateView();
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
                _uiManager.CloseTextInteractable();
                _uiManager.ResetProgressBar();
            }
        }
    }

    private void Update()
    {
        if(_interactable != null)
        {
            _interactable.Action();
        }
    }
}

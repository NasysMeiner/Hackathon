using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
public class InteractableRadius : MonoBehaviour
{
    [SerializeField] private UiManager _uiManager;

    private List<IInteractable> _interactables = new();

    private void OnEnable()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out IInteractable interactable))
        {
            _interactables.Add(interactable);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out IInteractable interactable))
        {
            if (_interactables.Contains(interactable))
            {
                _interactables.Remove(interactable);
                interactable.DeActivateView();
            }
        }
    }

    void FixedUpdate()
    {
        Debug.Log(_interactables.Count);
        if (_interactables.Count > 0 && Physics.Raycast(transform.position, transform.forward * 10, out RaycastHit hit))
        {
            Debug.Log("No222");

            if (hit.collider.gameObject.TryGetComponent(out IInteractable component) && component.IsInteractable)
            {
                Debug.Log("No");
                component.Action();
                component.ActivateView();
            }
        }
        else
        {
            if (_uiManager.IsActiveText)
            {
                _uiManager.CloseTextInteractable();
                _uiManager.ResetProgressBar();
            }
        }

        Debug.DrawRay(transform.position, transform.forward * 10, Color.red);
    }
}

using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using TMPro;
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
            Debug.Log(other.name);
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

    void Update()
    {
        RaycastHit hit;

        if(_interactables.Count > 0 && Physics.Raycast(transform.position, transform.forward, out hit))
        {
            if (hit.collider.gameObject.TryGetComponent(out IInteractable component) && _interactables.Contains(component) && component.IsInteractable)
            {
                _uiManager.ViewTextInteractable();

                if (Input.GetKey(KeyCode.E))
                {
                    component.Action();
                    component.ActivateView();
                }
            }
            else
            {
                _uiManager.CloseTextInteractable();
            }
        }
        else
        {
            _uiManager.CloseTextInteractable();
        }

        Debug.DrawRay(transform.position, transform.forward, Color.red);
    }
}

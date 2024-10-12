using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Pipe : MonoBehaviour, IInteractable
{
    [SerializeField] private MeshRenderer _propts;
    [SerializeField] private bool _isInteractable = true;

    [SerializeField]  private UiManager _manager;
    public float winPosition, winPos;
    public bool isWin = false;

    public bool IsInteractable { get { return _isInteractable; } set { } }

    public void Init(UiManager uiManager)
    {
        _manager = uiManager;
    }

    public void Action()
    {
        _manager.ViewTextValve();

        if (Input.GetKeyDown(KeyCode.E))
        {
            transform.localEulerAngles += new Vector3(0, 0, 90);
            Proverka();
        }
        else if (Input.GetKeyDown(KeyCode.Q))
        {
            transform.localEulerAngles += new Vector3(0, 0, -90);
            Proverka();
        }
    }

    public void ActivateView()
    {
        if (_isInteractable)
            _manager.ViewTextValve();
    }

    public void DeActivateView()
    {
        _manager.CloseViewTextValve();
    }

    void Proverka()
    {
        float z = transform.localRotation.z;

        if (winPosition == 123)
            isWin = true;
        else
        {
            if (winPosition == z || winPos == z)
                isWin = true;
        }
        if (isWin)
        {
            PlusMinus.Instance.isWin(gameObject);
        }
    }
}

public interface IInteractable
{
    public bool IsInteractable { get; set; }
    void Action();
    void ActivateView();
    void DeActivateView();
}

namespace BlazorDialogs.Models.Contexts;

public interface IModalContext
{
    Type ModalType { get; }

    string Id { get; }
}

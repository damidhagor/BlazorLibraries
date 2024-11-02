namespace BlazorDialogs.Extensions;

public static class ModalServiceExtensions
{
    public static async Task<ModalResult<ConfirmationResult>> ShowConfirmation(
        this IModalService modalService,
        string message,
        string? title = null,
        string? confirmText = null,
        string? cancelText = null)
        => await modalService.ShowModal<ConfirmationModalContext, ConfirmationResult>(new(message, title, confirmText, cancelText));

    public static async Task<ModalResult<TextInputResult>> ShowTextInput(
        this IModalService modalService,
        string? title = null,
        string? placeholder = null,
        string? initialText = null,
        bool inputCanBeEmpty = true,
        string? confirmText = null)
        => await modalService.ShowModal<TextInputModalContext, TextInputResult>(new(title, placeholder, initialText, inputCanBeEmpty, confirmText));

    public static async Task<ModalResult<None>> ShowError(
        this IModalService modalService,
        string message,
        string? title = null,
        string? details = null,
        Exception? exception = null,
        string? confirmText = null)
        => await modalService.ShowModal<ErrorModalContext, None>(new(message, title, details, exception, confirmText));
}

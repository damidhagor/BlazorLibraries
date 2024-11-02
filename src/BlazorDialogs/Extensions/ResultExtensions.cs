using System.Diagnostics.CodeAnalysis;

namespace BlazorDialogs.Extensions;

public static class ResultExtensions
{
    public static bool IsConfirmed(this ModalResult<ConfirmationResult> result) => result.IsT0 && result.AsT0.IsT0;

    public static bool IsTextInput(this ModalResult<TextInputResult> result) => result.IsT0 && result.AsT0.IsT0;

    public static bool TryGetText(this ModalResult<TextInputResult> result, [NotNullWhen(true)] out string? text)
    {
        text = null;

        if (result.IsTextInput())
        {
            text = result.AsT0.AsT0.Text;
            return true;
        }

        return text is not null;
    }
}

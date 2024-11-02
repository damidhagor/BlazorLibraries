namespace BlazorDialogs.Components.Modals;

public sealed partial class ConfirmationModal(IJSRuntime jsRuntime)
    : BaseModal<ConfirmationModalContext, ConfirmationResult>(jsRuntime)
{
    private ElementReference _confirmButton = default!;
    private ElementReference _cancelButton = default!;

    private string _confirmText => Context.ConfirmText ?? _localization.OK;

    private string _cancelText => Context.CancelText ?? _localization.Cancel;

    public override async Task OnModalShown()
    {
        await _confirmButton.FocusAsync();
    }

    private async Task OnConfirm()
    {
        Context.SetResult(new Confirmed());
        await Hide();
    }

    private async Task OnCancel()
    {
        Context.SetResult(new Cancelled());
        await Hide();
    }
}

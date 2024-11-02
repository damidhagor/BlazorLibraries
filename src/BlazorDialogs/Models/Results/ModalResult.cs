namespace BlazorDialogs.Models.Results;

[GenerateOneOf]
public sealed partial class ModalResult<T> : OneOfBase<T, ModalCancelled>;

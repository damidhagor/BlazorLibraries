using Microsoft.Extensions.DependencyInjection;

namespace BlazorDialogs.Extensions;

public static class HostingExtensions
{
    public static IServiceCollection AddBlazorDialogServices(this IServiceCollection services)
    {
        services.AddLocalization();
        services.AddScoped<Localization.ILocalizationService, Localization.LocalizationService>();
        services.AddScoped<IModalService, ModalService>();
        return services;
    }
}

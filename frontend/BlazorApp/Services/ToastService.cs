using Microsoft.AspNetCore.Components;

namespace BlazorApp.Services
{
    public class ToastService
    {
        public event Action<string, string>? OnShow;

        public void ShowToast(string message, string cssClass = "text-bg-success")
        {
            OnShow?.Invoke(message, cssClass);
        }
    }
}

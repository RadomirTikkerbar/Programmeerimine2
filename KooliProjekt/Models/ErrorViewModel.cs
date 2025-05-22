using System.Diagnostics.CodeAnalysis;

namespace KooliProjekt.Models
{
    public class ErrorViewModel
    {
        [ExcludeFromCodeCoverage]
        public string? RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}
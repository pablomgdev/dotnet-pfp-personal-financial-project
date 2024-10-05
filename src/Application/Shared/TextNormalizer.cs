using System.Text;

namespace Application.Shared;

public class TextNormalizer
{
    public string Normalize(string? text)
    {
        return text
            ?.Normalize(NormalizationForm.FormD)
            .ToLowerInvariant() ?? string.Empty;
    }
}
using System;

namespace GameReviewSolution.Validators;

public static class UriHelper
{
    public static bool IsValidUri(string uri)
    {
        return Uri.TryCreate(uri, UriKind.Absolute, out var uriCreated)
               && (
                   uriCreated.Scheme == Uri.UriSchemeHttp ||
                   uriCreated.Scheme == Uri.UriSchemeHttps);
    }

}
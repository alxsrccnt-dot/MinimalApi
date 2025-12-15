namespace Application.Users.Authentification;

public record TokenSettings(string Secret, string Issuer, string Audience, int ExpirationInMinutes){ }
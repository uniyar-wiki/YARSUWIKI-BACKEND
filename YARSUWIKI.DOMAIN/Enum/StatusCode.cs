namespace YARSUWIKI.DOMAIN.Enum;

public enum StatusCode
{
    UserNotFound = 0,
    UserAlreadyExists=409,
    OK = 200,
    InternalServerError = 500
}
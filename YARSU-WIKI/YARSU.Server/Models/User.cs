﻿namespace YARSU.Server.Models;

public class User
{
    public User()
    {
        
    }

    public int Id { get; set; }

    public string Username { get; set; }

    public string PasswordHash { get; set; }

    public string Salt { get; set; }

    public string? RefreshToken { get; set; }

    public DateTime? RefreshTokenExpiryTime { get; set; }

    public string Role { get; set; }
}


using System;
using System.Windows;
using System.Windows.Media;
using PasswordManager.Domain.Models;

namespace PasswordManager.WPF.Models;

public class UserRecord 
{
    public int Id { get; set; }
    public Account Account { get; set; }
    public string Title { get; set; }
    public string Website { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
    public string Description { get; set; }
    public DateTime Created { get; set; }
    public bool HasUrl { get; set; }
    public Brush ForegroundColor { get; set; }
    public TextDecorationCollection TextDecoration { get; set; }
    
}
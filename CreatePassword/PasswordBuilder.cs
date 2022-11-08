namespace CreatePassword;

public class PasswordBuilder
{
    private string _password;
    private int _length = 8;
    private bool _lowercase = false;
    private bool _uppercase = false;
    private bool _numbers = false;
    private bool _symbols = false;

    public PasswordBuilder()
    {
        _password = string.Empty;
    }

    public PasswordBuilder Length(int length)
    {
        _length = length;
        return this;
    }

    public PasswordBuilder Lowercase()
    {
        _lowercase = true;
        return this;
    }

    public PasswordBuilder Uppercase()
    {
        _uppercase = true;
        return this;
    }

    public PasswordBuilder Numbers()
    {
        _numbers = true;
        return this;
    }

    public PasswordBuilder Symbols()
    {
        _symbols = true;
        return this;
    }

    public string Build()
    {
        if (!_lowercase && !_uppercase && !_numbers && !_symbols)
            throw new Exception("No character types selected.");

        var random = new Random();
        var chars = new List<char>();

        if (_lowercase)
            chars.AddRange("abcdefghijklmnopqrstuvwxyz");
        if (_uppercase)
            chars.AddRange("ABCDEFGHIJKLMNOPQRSTUVWXYZ");
        if (_numbers)
            chars.AddRange("0123456789");
        if (_symbols)
            chars.AddRange("!@#$%^&*()");

        var password = new char[_length];
        for (int i = 0; i < _length; i++)
            password[i] = chars[random.Next(chars.Count)];

        return new string(password);
    }
}
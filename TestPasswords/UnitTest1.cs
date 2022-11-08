using CreatePassword;
using FluentAssertions;

namespace TestPasswords;

public class Tests
{
    private PasswordBuilder _passwordBuilder;
    
    [SetUp]
    public void Setup()
    {
        _passwordBuilder = new PasswordBuilder();
    }
    
    // test building a password with a length of 8
    [Test]
    public void TestPasswordLength()
    {
        var password = _passwordBuilder
            .Length(8)
            .Lowercase()
            .Uppercase()
            .Numbers()
            .Symbols()
            .Build();
        password.Length.Should().Be(8);
    }
    
    // test building a password without symbols
    [Test]
    public void TestPasswordWithoutSymbols()
    {
        var password = _passwordBuilder
            .Length(8)
            .Lowercase()
            .Uppercase()
            .Numbers()
            .Build();
        password.Should()
            .NotContainAny("!", "@", "#", "$", "%", "^", "&", "*", "(", ")", "-", "_", "+", "=", "[", "]", "{", "}", "|", ";", ":", "'", "\"", ",", "<", ".", ">", "/", "?");
    }
    
    // test building a password with only uppercase and lowercase letters
    [Test]
    public void TestPasswordOnlyLetters()
    {
        var password = _passwordBuilder
            .Length(8)
            .Lowercase()
            .Uppercase()
            .Build();
        password.Should()
            .NotContainAny("1", "2", "3", "4", "5", "6", "7", "8", "9", "0", "!", "@", "#", "$", "%", "^", "&", "*", "(", ")", "-", "_", "+", "=", "[", "]", "{", "}", "|", ";", ":", "'", "\"", ",", "<", ".", ">", "/", "?");
    }
    
    // test building a password with uppercase, lowercase, and symbols
    [Test]
    public void TestPasswordWithSymbols()
    {
        var password = _passwordBuilder
            .Length(8)
            .Lowercase()
            .Uppercase()
            .Symbols()
            .Build();
        password.Should()
            .NotContainAny("1", "2", "3", "4", "5", "6", "7", "8", "9", "0");
    }
    
    // test building a password with uppercase, lowercase, numbers, and specific symbols
    [Test]
    public void TestPasswordWithSpecificSymbols()
    {
        var password = _passwordBuilder
            .Length(8)
            .Lowercase()
            .Uppercase()
            .Numbers()
            .Symbols("!@#")
            .Build();
        password.Should()
            .NotContainAny("$", "%", "^", "&", "*", "(", ")", "-", "_", "+", "=", "[", "]", "{", "}", "|", ";", ":", "'", "\"", ",", "<", ".", ">", "/", "?");
    }
}
using CreatePassword;
using FluentAssertions;

namespace TestPasswords;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void Test1()
    {
        Assert.Pass();
    }
    
    // test building a password with a length of 8
    [Test]
    public void TestPasswordLength()
    {
        var passwordGenerator = new PasswordBuilder();
        var password = passwordGenerator
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
        var passwordGenerator = new PasswordBuilder();
        var password = passwordGenerator
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
        var passwordGenerator = new PasswordBuilder();
        var password = passwordGenerator
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
        var passwordGenerator = new PasswordBuilder();
        var password = passwordGenerator
            .Length(8)
            .Lowercase()
            .Uppercase()
            .Symbols()
            .Build();
        password.Should()
            .NotContainAny("1", "2", "3", "4", "5", "6", "7", "8", "9", "0");
    }
}
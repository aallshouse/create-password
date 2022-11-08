// See https://aka.ms/new-console-template for more information

using CreatePassword;

Console.WriteLine("Let's create a password for you!");

// create a password from a list of characters

var password = new PasswordBuilder()
    .Length(10)
    .Lowercase()
    .Uppercase()
    .Numbers()
    .Symbols()
    .Build();

Console.WriteLine(password);

password = new PasswordBuilder()
    .Length(20)
    .Lowercase()
    .Uppercase()
    .Numbers()
    .Build();

Console.WriteLine(password);

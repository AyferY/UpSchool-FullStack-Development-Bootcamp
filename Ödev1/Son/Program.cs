using System;
using System.Text;
using Son;

Console.WriteLine("***********************************************");
Console.WriteLine("Welcome to the B E S T P A S S W O R D M A N A G E R !");
Console.WriteLine("***********************************************");
Console.WriteLine("Do you want to include number?");

string Char = String.Empty;
if (Console.ReadLine().Contains("y") || Console.ReadLine().Contains("yes"))
{
    Char = "0123456789";
}


Console.WriteLine("OK! How about lowercase characters?");
if (Console.ReadLine().Contains("y") || Console.ReadLine().Contains("yes"))
{
    Char = Char + "abcdefghijklmnopqrstuvwxyz";
}


Console.WriteLine("Very nice! How about uppercase characters?");
if (Console.ReadLine().Contains("y") || Console.ReadLine().Contains("yes"))
{
    Char = Char + "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
}


Console.WriteLine("All right! We are almost done. Would you also want to add special characters?");
if (Console.ReadLine().Contains("y") || Console.ReadLine().Contains("yes"))
{
    Char = Char + "/*-+";
}


Console.WriteLine("Great! Lastly. How long do you want to keep your password length?");
string PassLength = Console.ReadLine();


CreateRandomPassword CRandomPassword = new CreateRandomPassword();

CRandomPassword.chars = Char;


Console.WriteLine($"New Password : {CRandomPassword.GetRandomPassword(Convert.ToInt32(PassLength))}");

Console.ReadLine();
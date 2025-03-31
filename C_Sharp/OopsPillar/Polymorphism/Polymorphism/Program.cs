// See https://aka.ms/new-console-template for more information
// Console.WriteLine("Hello, World!");

using Polymorphism.Email;
using Polymorphism.Implementations;
using Polymorphism.Interfaces;
using Polymorphism.Letter;
using Polymorphism.SMS;


Email email = new(new SendMessage());
email.CreateEmail(message: "This email has to be send!");
email.SendEmail(email: "Email is sent!");

SMS sms = new SMS(new SendMessage());
sms.CreateSms(smsMessage: "This SMS has to be send!");
sms.SendEmail(smsMessage: "This SMS has to be send!");

ISendMessageService letterService = new SendMessage();
Letter letter = new(letterService);
letter.CreateLetter(smsMessage: "This letter has been created!");
letter.SendLetter(smsMessage: "This letter has been sent!");
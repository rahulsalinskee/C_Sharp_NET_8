
using SingletonDP;

Console.WriteLine("----------------- Without Singleton Start ------------------");
WithoutSingleton employee = new();
employee.PrintDetails("Print Details - Detail 1");
employee.PrintDetails("Print Details - Detail 2");

WithoutSingleton student = new();
student.PrintDetails("Print Details - Detail 3");
student.PrintDetails("Print Details - Detail 4");
Console.WriteLine("----------------- Without Singleton End ------------------");



Console.WriteLine("----------------- With Singleton Start ------------------");
WithSingleton teacher = WithSingleton.GetInstance;
teacher.DisplayName("Display Name - Name 1");

WithSingleton doctor = WithSingleton.GetInstance;
doctor.DisplayName("Display Name - Name 2");
Console.WriteLine("----------------- With Singleton End ------------------");



Console.WriteLine("----------------- Why Sealed Base Start ------------------");
WhySealedBase.WhySealedChild whySealedChild1 = new();
whySealedChild1.DisplayClassName("Display Class Name - Class 1");

WhySealedBase.WhySealedChild whySealedChild2 = new();
whySealedChild2.DisplayClassName("Display Class Name - Class 2");
Console.WriteLine("----------------- Why Sealed Base End ------------------");
Console.ReadLine();

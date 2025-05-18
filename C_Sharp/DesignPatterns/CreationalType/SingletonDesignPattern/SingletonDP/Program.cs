
using SingletonDP;

Console.WriteLine("----------------- Without Singleton Start ------------------");
WithoutSingleton employee = new();
employee.PrintDetails("Print Details - Detail 1");
employee.PrintDetails("Print Details - Detail 2");

WithoutSingleton student = new();
student.PrintDetails("Print Details - Detail 3");
student.PrintDetails("Print Details - Detail 4");
Console.WriteLine("----------------- Without Singleton End ------------------");

Console.WriteLine();

Console.WriteLine("----------------- With Singleton Start ------------------");
WithSingleton teacher = WithSingleton.GetInstance;
teacher.DisplayName("Display Name - Name 1");

WithSingleton doctor = WithSingleton.GetInstance;
doctor.DisplayName("Display Name - Name 2");
Console.WriteLine("----------------- With Singleton End ------------------");

Console.WriteLine();

Console.WriteLine("----------------- Why Singleton is Sealed Base Start ------------------");
WhySealedBase.WhySealedChild? whySealedChild1 = new();
whySealedChild1?.DisplayClassName("Display Class Name - Class 1");

WhySealedBase.WhySealedChild? whySealedChild2 = new();
whySealedChild2?.DisplayClassName("Display Class Name - Class 2");
Console.WriteLine("----------------- Why Singleton is Sealed Base End ------------------");

Console.WriteLine();

Console.WriteLine("----------------- Thread Safe Singleton Start ------------------");
Parallel.Invoke(() =>
{
    ThreadSafeSingleton threadSafeSingletonObject1 = ThreadSafeSingleton.GetThreadSafeInstanceUsingStaticConstructor;
    threadSafeSingletonObject1.DisplayName("Display Name - Thread 1");
},
() =>
{
    ThreadSafeSingleton threadSafeSingletonObject2 = ThreadSafeSingleton.GetThreadSafeInstanceUsingStaticConstructor;
    threadSafeSingletonObject2.DisplayName("Display Name - Thread 2");
});

ThreadSafeSingleton threadSafeSingletonInstance1 = ThreadSafeSingleton.GetThreadSafeInstanceUsingStaticConstructor;
threadSafeSingletonInstance1.DisplayName("Thread Safe Singleton Instance 1");

ThreadSafeSingleton threadSafeSingletonInstance2 = ThreadSafeSingleton.GetThreadSafeInstanceUsingStaticConstructor;
threadSafeSingletonInstance2.DisplayName("Thread Safe Singleton Instance 2");
Console.WriteLine("----------------- Thread Safe Singleton End ------------------");

Console.WriteLine();

Console.WriteLine("----------------- Eager Loading Start ------------------");
Parallel.Invoke(() =>
{
    EagerLoadingSingleton eagerLoadingSingletonInstanceObject1 = EagerLoadingSingleton.GetEagerLoadingSingletonInstance;
    eagerLoadingSingletonInstanceObject1.DisplayEagerLoadingName("Eager Loading Object1");
    
},
() =>
{
    EagerLoadingSingleton eagerLoadingSingletonInstanceObject2 = EagerLoadingSingleton.GetEagerLoadingSingletonInstance;
    eagerLoadingSingletonInstanceObject2.DisplayEagerLoadingName("Eager Loading Object 2");
});
EagerLoadingSingleton eagerLoadingSingletonInstance1 = EagerLoadingSingleton.GetEagerLoadingSingletonInstance;
eagerLoadingSingletonInstance1.DisplayEagerLoadingName("Eager Loading Instance 1");

EagerLoadingSingleton eagerLoadingSingletonInstance2 = EagerLoadingSingleton.GetEagerLoadingSingletonInstance;
eagerLoadingSingletonInstance2.DisplayEagerLoadingName("Eager Loading Instance 2");

Console.WriteLine("----------------- Eager Loading End ------------------");

Console.WriteLine();

Console.WriteLine("----------------- Lazy Loading Start ------------------");
Parallel.Invoke(() =>
{
    LazyLoadingSingleton lazyLoadingSingletonInstanceObject1 = LazyLoadingSingleton.GetLazyLoadingSingletonInstance;
    lazyLoadingSingletonInstanceObject1.LazyLoadingDisplayName("Lazy Loading Object1");
    
},
() =>
{
    LazyLoadingSingleton lazyLoadingSingletonInstanceObject2 = LazyLoadingSingleton.GetLazyLoadingSingletonInstance;
    lazyLoadingSingletonInstanceObject2.LazyLoadingDisplayName("Lazy Loading Object2");
});
LazyLoadingSingleton lazyLoadingSingletonInstance1 = LazyLoadingSingleton.GetLazyLoadingSingletonInstance;
lazyLoadingSingletonInstance1.LazyLoadingDisplayName("Lazy Loading Instance1");

LazyLoadingSingleton lazyLoadingSingletonInstance2 = LazyLoadingSingleton.GetLazyLoadingSingletonInstance;
lazyLoadingSingletonInstance2.LazyLoadingDisplayName("Lazy Loading Instance2");

Console.WriteLine("----------------- Lazy Loading End ------------------");
Console.WriteLine();

Console.ReadLine();

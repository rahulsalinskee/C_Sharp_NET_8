
using Singleton;

Logger loggerOne = Logger.GetInstance;

loggerOne.Print("Logger One Print!");

Logger loggerTwo = Logger.GetInstance;
loggerTwo.Print("Logger Two Print!");


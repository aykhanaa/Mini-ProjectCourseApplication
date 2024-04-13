
using MiniProject_CourseApplicaton.Controllers;
using Service.Helpers.Extensions;

EducationController educationController = new EducationController();



//while (true)
//{
//    GetMenues();

//Operation: string operationStr = Console.ReadLine();

//    int opration;

//    bool isCorrectOperationFormat = int.TryParse(operationStr, out opration);




//await educationController.DeleteAsnyc();




//await educationController.CreateAsync();
await educationController.GetAllAsync();









//    GetMenues();




////}
//static void GetMenues()
//{
//    ConsoleColor.Cyan.WriteConsole("Choose one opration: \n 1 - Education GetAll\n 2 - Education GetById\n 3 - Education Delete\n 4 - Education SearchByName\n 5 - Education GetAllWithGroups\n 6 - Education SortWithGroups\n 7 - Education Update");
//}
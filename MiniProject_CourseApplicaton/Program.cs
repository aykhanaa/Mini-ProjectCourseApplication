
using MiniProject_CourseApplicaton.Controllers;
using Service.Helpers.Enums;
using Service.Helpers.Extensions;
using System;

EducationController educationController = new EducationController();
GroupController groupController = new GroupController();



//await educationController.DeleteAsnyc();

//await educationController.CreateAsync();

//await educationController.GetAllAsync();

//await educationController.GetByIdAsync();

//await educationController.SearchByNameAsync()

//await educationController.GetAllWithGroupsAsync();


//await groupController.CreateAsync();

//await groupController.GetAllAsync();,,,

//await groupController.DeleteAsync();,,,

//await groupController.GetByIdAsync();,,,

//await groupController.SearchByNameAsync();,,,


//await groupController.SortWithCapacityAsync();??????
//await groupController.FilterByEducationNameAsync();
//await groupController.GetAllWithEducationIdAsync();


while (true)
{
    GetMenues();
Operation: string operationStr = Console.ReadLine();

    int operation;

    bool isCorrectOperationFormat = int.TryParse(operationStr, out operation);
    if (isCorrectOperationFormat)
    {
        switch (operation)
        {
            case (int)OperationType.EducationCreate:
                await educationController.CreateAsync();
                break;
            case (int)OperationType.EducationDelete:
                await educationController.DeleteAsnyc();
                break;
            case (int)OperationType.EducationGetAll:
                await educationController.GetAllAsync();
                break;

            case (int)OperationType.EducationGetById:
                await educationController.GetByIdAsync();
                break;
            case (int)OperationType.EducationSearchByName:
                await educationController.SearchByNameAsync();
                break;
            case (int)OperationType.EducationGetAllWithGroup:
                await educationController.GetAllWithGroupsAsync();
                break;
            case (int)OperationType.GroupCreate:
                await groupController.CreateAsync();
                break;
            case (int)OperationType.GroupDelete:
                await groupController.DeleteAsync();
                break;
            case (int)OperationType.GroupGetAll:
                await groupController.GetAllAsync();
                break;
            case (int)OperationType.GroupGetById:
                await groupController.GetByIdAsync();
                break;
            case (int)OperationType.GroupSearchByName:
                await groupController.SearchByNameAsync();
                break;
            case (int)OperationType.GroupSortWithCapacity:
                await groupController.SortWithCapacityAsync();
                break;
            case (int)OperationType.GetAllGroupWithEducation:
                await groupController.GetAllWithEducationIdAsync();
                break;
           
            default:
                ConsoleColor.Red.WriteConsole("Operation is wrong, please choose again");
                goto Operation;
        }
    }
    else
    {
        ConsoleColor.Red.WriteConsole("Operation format is wrong, please add operation again");
        goto Operation;
    }
}












GetMenues();





static void GetMenues()
{
    ConsoleColor.Cyan.WriteConsole("Choose one operation :\n" +
                                     
                                      "     Education options:               |" + "Group options:                  \n" +
                                      "    ----------------------------------|" + "--------------------------------\n" +
                                      "     1-Education Create               |" + "7-Group Create                  \n" +
                                      "     2-Education Delete               |" + "8-Group Delete                 \n" +
                                      "     3-Education Get All              |" + "9-Group Get All                \n" +
                                      "     4-Education Get By Id            |" + "10-Group Get By Id              \n" +
                                      "     5-Education Search By Name       |" + "11-Group Search By Name         \n" +
                                      "     6-Education Get All With Group   |" + "                                \n" +
                                      "                                      |" + "                                \n" +
                                      "                                      |" + "                                \n" +
                                      "    ");
}
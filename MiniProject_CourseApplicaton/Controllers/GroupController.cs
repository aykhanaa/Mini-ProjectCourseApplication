using Domain.Models;
using Service.Helpers.Constants;
using Service.Helpers.Extensions;
using Service.Services;
using Service.Services.Interfaces;
using System.Text.RegularExpressions;
using Group = Domain.Models.Group;

namespace MiniProject_CourseApplicaton.Controllers
{
    public class GroupController
    {
        private readonly IGroupServices _groupService;
        private readonly IEducatonServices _educatonServices;

        public GroupController()
        {
            _groupService = new GroupServices();
            _educatonServices = new EducatonServices();
        }

        public async Task CreateAsync()
        {
        GroupName: Console.WriteLine("Add Group name");
            string name = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(name))
            {
                ConsoleColor.Red.WriteConsole("Input can't be empty");
                goto GroupName;
            }
            ConsoleColor.Blue.WriteConsole("Please choose education Id :");
            var response = await _educatonServices.GetAllAsync();
            foreach (var item in response)
            {

                ConsoleColor.Yellow.WriteConsole("Id" + item.Id + " Name" + item.Name);
            }
        EducationName: Console.WriteLine("Choose Education id ");
            string str = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(str))
            {
                ConsoleColor.Red.WriteConsole("Input can't be empty");
                goto EducationName;
            }
            int id;
            bool isCorrectIdFormat = int.TryParse(str, out id);

            if (isCorrectIdFormat)
            {

                Education education = await _educatonServices.GetByIdAsync(id);
                if (education == null)
                {
                    ConsoleColor.Red.WriteConsole("This Education not exist");
                    return;
                }


            Capacity: Console.WriteLine("Add Group Capacity");
                string capacityStr = Console.ReadLine();
                int capacity;
                bool isCorrectCapacityFormat = int.TryParse(capacityStr, out capacity);
                if (isCorrectCapacityFormat)
                {
                    DateTime time = DateTime.Now;


                    await _groupService.CreateAsync(new Domain.Models.Group { Name = name.Trim().ToLower(), EducationId = education.Id, Capacity = capacity, createdDate = time });
                    ConsoleColor.Green.WriteConsole("Data succesfuly added");
                }
                else
                {
                    ConsoleColor.Red.WriteConsole(ResponseMessages.IncorrectFormat);
                    goto Capacity;
                }
            }

        }
        public async Task GetAllAsync()
        {
            var datas = await _groupService.GetAllAsync();
            if (datas.Count == 0)
            {
                ConsoleColor.Red.WriteConsole("Data not found");
            }
            foreach (var item in datas)
            {
                var education = await _educatonServices.GetByIdAsync(item.EducationId);
                ConsoleColor.Cyan.WriteConsole($"Name:{item.Name},Capacity: {item.Capacity},CreatedDate: {item.createdDate}");

            }
        }

        public async Task DeleteAsync()
        {
            ConsoleColor.Yellow.WriteConsole("Add Education id:");
        Id: string idStr = Console.ReadLine();
            int id;
            bool isCorrectIdFormat = int.TryParse(idStr, out id);
            if (isCorrectIdFormat)
                try
                {
                    await _groupService.DeleteAsnyc(id);
                    ConsoleColor.Green.WriteConsole("Data successfully deleted");
                }
                catch (Exception ex)
                {

                    ConsoleColor.Red.WriteConsole(ex.Message);
                    goto Id;
                }
            else
            {
                ConsoleColor.Red.WriteConsole("Id format is wrong, please add again");
                goto Id;
            }

        }

        public async Task GetByIdAsync()
        {
        Id: Console.WriteLine("Add Id");
            string idStr = Console.ReadLine();
            int id;
            bool isCorrectIdFormat = int.TryParse(idStr, out id);
            if (isCorrectIdFormat)
            {
                try
                {
                    var item = await _groupService.GetByIdAsync(id);
                    Console.WriteLine($"Group: {item.Name} , Capacity:{item.Capacity}, CreatedDate: {item.createdDate}");
                }
                catch(Exception ex)
                {
                    ConsoleColor.Red.WriteConsole(ResponseMessages.IncorrectFormat);
                    goto Id;
                } 
            }
        }

        public async Task SearchByNameAsync()
        {
        Byname: Console.WriteLine("Enter search text");
            string searchText = Console.ReadLine();
         
          
            try
            { 
                var data = await _groupService.SearchByNameAsync(searchText);
                foreach (var item in data)
                {
                    Console.WriteLine($"Group: {item.Name},  Capacity: {item.Capacity} , CreatedDate: {item.createdDate}");
                }
            }
            catch (Exception ex)
            {

                ConsoleColor.Red.WriteConsole(ResponseMessages.IncorrectFormat);
                goto Byname;
            }

        }
        public async Task SortWithCapacityAsync()
        {
            //Cap:ConsoleColor.Cyan.WriteConsole("Choose Sort Type\n Asc or Desc");
            //string text = Console.ReadLine();
            //try
            //{

            //    var datas = await _groupService.SortWithCapacityAsync(text);
            //    foreach (var data in datas)
            //    {
            //        Console.WriteLine($"Name {data.Name}, CreateDate {data.Capacity}");
            //    }
            //}
            //catch (Exception ex)
            //{
            //    ConsoleColor.Red.WriteConsole(ex.Message);
            //    goto Cap;
            //}
            Sort: ConsoleColor.Yellow.WriteConsole("Choose Sort Type\n Asc or Desc");
            string name = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(name))
            {
                ConsoleColor.Red.WriteConsole("Input can not input");
                goto Sort;
                
            }
        }

        public async Task FilterByEducationNameAsync()
        {
            ConsoleColor.Yellow.WriteConsole("Add education name'");
        Education: string name  = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(name))
            {
                ConsoleColor.Red.WriteConsole("Input can not input");
                goto Education;
            }
            else
            {
                try
                {
                    var result = await _groupService.FilterByEducationNameAsync(name);
                    if (result.Count !=0)
                    {
                        foreach (var item in result)
                        {
                            string data = $"Group name :{item.Name},Education :{item.Education.Name}";
                            Console.WriteLine(data);
                        }
                    }
                    else
                    {
                        ConsoleColor.Red.WriteConsole("This study could not be found ");
                        goto Education;
                    }
                }

                catch (Exception ex)
                {
                    ConsoleColor.Red.WriteConsole(ex.Message);
                    goto Education;
                }
            }
        }
        public async Task GetAllWithEducationIdAsync(int id)
        {
            ConsoleColor.Yellow.WriteConsole("Add Group education id:");
           Id: string str = Console.ReadLine();

            bool isCorrectIdFormat = int.TryParse(str, out id);

            if(string.IsNullOrWhiteSpace(str) )
            {
                ConsoleColor.Red.WriteConsole("Input can not empty ");
                goto Id;
            }

            if (isCorrectIdFormat)
            {
                try
                {
                    List<Group> response = await _groupService.GetAllWithEducationIdAsync(id);

                    if (response.Count == 0)
                    {
                        ConsoleColor.Red.WriteConsole("Education Id not found");
                        goto Id;
                    }
                    else
                    {
                        foreach (var item in response)
                        {
                            string data = $"Id:{item.Id}, Group name : {item.Name}, Group Capacity : {item.Capacity}, Group educationId :{item.EducationId}";
                            Console.WriteLine(data);
                        }
                    }
                }
                catch(Exception ex)
                {
                    ConsoleColor.Red.WriteConsole(ex.Message);
                    goto Id;
                }
            }
            else
            {
                ConsoleColor.Red.WriteConsole("Education Id not found,please write correct id");
                goto Id;
            }
        







        }





}   }
    


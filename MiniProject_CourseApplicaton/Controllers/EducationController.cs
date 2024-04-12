using Service.Helpers.Extensions;
using Service.Services;
using Service.Services.Interfaces;
using System.Data;

namespace MiniProject_CourseApplicaton.Controllers
{
    public class EducationController
    {
        private readonly IEducatonServices _educationService;

        public EducationController()
        {
            _educationService = new EducatonServices();
        }

        public async Task DeleteAsnyc()
        {
            ConsoleColor.Yellow.WriteConsole("Add Education id:");
        Id: string idStr = Console.ReadLine();
            int id;
            bool isCorrectIdFormat = int.TryParse(idStr, out id);
            if (isCorrectIdFormat)
                try
                {
                    await _educationService.DeleteAsnyc(id);
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

        public async Task GetAllAsync()
        {
            var datas = await _educationService.GetAllAsync();
            if(datas.Count == 0)
            {
                ConsoleColor.Red.WriteConsole("Data not found");
            }
            foreach (var item in datas)
            {
                string data = $"Name:{item.Name},Color: {item.Color}";
                ConsoleColor.Cyan.WriteConsole(data);
            }
        }

        public async Task GetByIdAsync()
        {
            ConsoleColor.Yellow.WriteConsole("Add Education id:");
        Id: string idStr = Console.ReadLine();
            int id;
            bool isCorrectIdFormat = int.TryParse(idStr, out id);
            if (isCorrectIdFormat)
                try
                {
                    var data = await _educationService.GetByIdAsync(id);
                    
                    string result = $"Name:{data.Name},Color: {data.Color}";
                    ConsoleColor.Cyan.WriteConsole(result);

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

        public async Task SearchByNameAsync()
        {
            ConsoleColor.Yellow.WriteConsole("Add Education name;");
            Name: string searchText = Console.ReadLine();

            if (string.IsNullOrEmpty(searchText))
            {
                ConsoleColor.Red.WriteConsole("Input can't be empty");
                goto Name;
            }
            try
            {
                var result = await _educationService.SearchByNameAsync(searchText);

                if (result.Count == 0)
                {
                    ConsoleColor.Red.WriteConsole("Data not found");
                    goto Name;
                }

                foreach (var item in result)
                {
                    string data = $"Education name: {item.Name},Color :{item.Color}";
                    ConsoleColor.Cyan.WriteConsole(data);

                }



            }
            catch (Exception ex)
            {

                ConsoleColor.Red.WriteConsole(ex.Message);
                goto Name;
            }



        }
 







    }
}

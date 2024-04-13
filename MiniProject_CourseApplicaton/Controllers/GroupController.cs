using Service.Services;
using Service.Services.Interfaces;
using System.Text.RegularExpressions;

namespace MiniProject_CourseApplicaton.Controllers
{
    public class GroupController
    {
        private readonly IGroupServices _educationGroup;

        public GroupController()
        {
            _educationGroup = new GroupServices();
        }


    }
}

//using Microsoft.AspNetCore.Mvc;

//namespace Assignment4.Controllers
//{
//    //[Route("NashTech/[controller]")]
//    public class RookiesController : Controller
//    {
//        private readonly IMemberService _memberService;
//        public RookiesController(IMemberService memberService)
//        {
//            _memberService = memberService;
//        }
//        public IActionResult Index()
//        {
//            var listMembers = _memberService.GetMembers();
//            return Content(string.Join("\n", listMembers.ToString()));
//        }
//        [HttpGet("Male")]
//        public IActionResult MaleMembers()
//        {
//            var males = _memberService.GetMaleMembers();
//            return Content(string.Join("\n", males.Select(p => p.ToString())));
//        }
//        [HttpGet("Oldest")]
//        public IActionResult OldestMember()
//        {
//            var oldest = _memberService.GetOldestMember();
//            return Content(oldest.ToString());
//        }
//        [HttpGet("FullNames")]
//        public IActionResult MemberFullNames()
//        {
//            var fullNames = _memberService.GetMemberFullNames();
//            return Content(string.Join("\n", fullNames));
//        }
//        [HttpGet("FilterByBirthYear")]
//        public IActionResult FilterByBirthYear(int year, string comparisonType)
//        {
//            if(string.IsNullOrEmpty(comparisonType))
//            {
//                comparisonType = "Equal";
//            }
//            var members = _memberService.FilterMembersByBirthYear(year, comparisonType);
//            return Content(string.Join("\n", members.Select(p => p.ToString())));
//            //var members = _memberService.FilterMembersByBirthYear(year);
//            //return Content(string.Join("\n", members.Select(p => p.ToString())));
//        }
//        [HttpGet("Download")]
//        public IActionResult Download()
//        {
//            var file = _memberService.GetMembersAsExcelFile();
//            return File(file, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "members.xlsx");
//        }
//    }

//}

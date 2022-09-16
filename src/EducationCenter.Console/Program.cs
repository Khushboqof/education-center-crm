
using EducationCenter.Service.DTOs.Courses;
using EducationCenter.Service.Interfaces;
using EducationCenter.Service.Services;

ICourseService courseService = new CourseService();


//var res = await courseService.CreateAsync(new CourseForCreationDto
//{
//    Name = ".Net",
//    Price = 2200000,
//    Duration = 7,
//    CourseDescription = "Yaxshi"
//});

//var result = await courseService.DeleteAsync(o => o.Id == 1);

//var res = await courseService.UpdateAsync(2, new CourseForCreationDto
//{
//    Name = "JS",
//    Price = 2200000,
//    Duration = 5,
//    CourseDescription = "Bomaydi"
//});

//Console.WriteLine(res.Name);

var res = await courseService.GetAllAsync(o => o.Id <= 3);

foreach (var course in res)
{
    Console.WriteLine(course.Name );
}

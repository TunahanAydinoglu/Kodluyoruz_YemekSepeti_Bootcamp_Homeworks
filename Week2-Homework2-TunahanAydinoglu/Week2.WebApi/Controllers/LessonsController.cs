using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Week2.WebApi.Data.Context;
using Week2.WebApi.Data.Dto;
using Week2.WebApi.Data.Entity;
using Week2.WebApi.Mapping;
using Week2.WebApi.Validation;

namespace Week2.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LessonsController : ControllerBase
    {
        private DatabaseContext _context;

        public LessonsController(DatabaseContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetLessons()
        {
            List<Lesson> lessons = _context.Lessons.ToList();
            List<LessonDto> result = new List<LessonDto>();
            lessons.ForEach(lesson =>
            {
                result.Add(lesson.LessonToLessonDtoExtension());
            });
            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetLessonById(int id)
        {
            Lesson lesson = _context.Lessons.FirstOrDefault(p =>p.Id == id );
            LessonDto result = lesson.LessonToLessonDtoExtension();
            return Ok(lesson);
        }

        [HttpPost]
        public IActionResult PostLesson([FromBody] LessonDto lessonDto)
        {
            var validationResult = new List<ValidationResult>();
            var validTime = new TimeValidation(lessonDto);
            var isValid = validTime.IsValidTime(validationResult);
            if (!isValid)
                return BadRequest(validationResult);

            Lesson newLesson = lessonDto.LessonDtoToLessonExtension();
            _context.Add(newLesson);
            return Ok();
        }

    }
}

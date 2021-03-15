using System.Collections.Generic;
using Week2.WebApi.Data.Dto;
using Week2.WebApi.Data.Entity;

namespace Week2.WebApi.Mapping
{
    public static class MappingExtension
    {

        public static LessonDto LessonToLessonDtoExtension(this Lesson lesson)
        {
            LessonDto result = new LessonDto
                {
                    Id = lesson.Id,
                    Name = lesson.Name,
                    Minute = lesson.Hour*60,
                };

            return result;
        }

        public static Lesson LessonDtoToLessonExtension(this LessonDto lessonDto)
        {
            Lesson result = new Lesson
                {
                    Id = lessonDto.Id,
                    Name = lessonDto.Name,
                    Hour = lessonDto.Minute / 60,
                };
            return result;
        }
    }
}

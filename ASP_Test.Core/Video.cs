using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Xml.Linq;

namespace ASP_Test.Core
{
    public class Video : IValidatableObject
    {
        public int Id { get; set; }
        [Required]
        [DisplayName("Название видео")]
        public string Title { get; set; }
        [DisplayName("Дата выхода")]
        public DateTime ReleaseDate { get; set; }
        [DisplayName("Жанр")]
        public MovieGenre Genre { get; set; }
        [DisplayName("Цена")]
        public double Price { get; set; }
        [DisplayName("LentOut неведомый мне")]
        public bool LentOut { get; set; }
        [DisplayName("LentTo, тоже хрень какая-то заморская")]
        public string? LentTo { get; set; }

        public int Rating { get; set; }
        public string Review { get; set; }
        public string OnlineURL { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var property = new[] { nameof(LentTo) };
            var validationResults = new List<ValidationResult>();
            if (LentOut && string.IsNullOrWhiteSpace(LentTo))
            {
                validationResults.Add(new ValidationResult("LentOut заполни епт !!!!", property));
            }
            return validationResults;
        }
    }
}
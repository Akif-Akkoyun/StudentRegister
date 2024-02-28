using System.ComponentModel.DataAnnotations;

namespace OgrenciBilgi.Api.Data.Entities
{
    public class StudentEntity
    {
        public int Id { get; set; }
        [Required,StringLength(50,MinimumLength =1)]
        public string? FirstName { get; set; }
        [Required, StringLength(50, MinimumLength = 1)]
        public string? LastName { get; set; }
        [Required, StringLength(200)]
        public string? Ardress { get; set; }
        [Required]
        public string? StudentClass { get; set; }



    }
}

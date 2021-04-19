using CinemaApp.Client.DTO.Create;

namespace CinemaApp.Client.DTO.Update
{
    public class FilmUpdateDTO: FilmCreateDTO
    {
        public int Id { get; set; }
    }
}
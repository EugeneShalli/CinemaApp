using CinemaApp.Client.DTO.Create;

namespace CinemaApp.Client.DTO.Update
{
    public class NoteUpdateDTO:NoteCreateDTO
    {
        public int Id { get; set; }
    }
}
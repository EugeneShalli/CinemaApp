using CinemaApp.Client.DTO.Create;

namespace CinemaApp.Client.DTO.Update
{
    public class SessionUpdateDTO:SessionCreateDTO
    {
        public int Id { get; set; }
    }
}
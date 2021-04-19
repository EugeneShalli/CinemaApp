using AutoMapper;
using CinemaApp.Client.DTO;
using CinemaApp.Client.DTO.Create;
using CinemaApp.Client.DTO.Read;
using CinemaApp.Client.DTO.Update;
using CinemaApp.Domain.Models;

namespace CinemaApp.WebAPI
{
    public class AutoMapperProfile:Profile
    {
        public AutoMapperProfile()
        {
            this.CreateMap<DAL.Entity.Visitor, Domain.Visitor>();
            this.CreateMap<Domain.Visitor, VisitorDTO>();
            this.CreateMap<VisitorCreateDTO, VisitorUpdateModel>();
            this.CreateMap<VisitorUpdateDTO, VisitorUpdateModel>();
            this.CreateMap<VisitorUpdateModel, DAL.Entity.Visitor>();
            
            this.CreateMap<DAL.Entity.LoyaltyCard, Domain.LoyaltyCard>();
            this.CreateMap<Domain.LoyaltyCard, LoyaltyCardDTO>();
            this.CreateMap<LoyaltyCardCreateDTO, LoyaltyCardUpdateModel>();
            this.CreateMap<LoyaltyCardUpdateDTO, LoyaltyCardUpdateModel>();
            this.CreateMap<LoyaltyCardUpdateModel, DAL.Entity.LoyaltyCard>();
            
            this.CreateMap<DAL.Entity.Film, Domain.Film>();
            this.CreateMap<Domain.Film, FilmDTO>();
            this.CreateMap<FilmCreateDTO, FilmUpdateModel>();
            this.CreateMap<FilmUpdateDTO, FilmUpdateModel>();
            this.CreateMap<FilmUpdateModel, DAL.Entity.Film>();
            
            this.CreateMap<DAL.Entity.Session, Domain.Session>();
            this.CreateMap<Domain.Session, SessionDTO>();
            this.CreateMap<SessionCreateDTO, SessionUpdateModel>();
            this.CreateMap<SessionUpdateDTO, SessionUpdateModel>();
            this.CreateMap<SessionUpdateModel, DAL.Entity.Session>();
            
            this.CreateMap<DAL.Entity.Note, Domain.Note>();
            this.CreateMap<Domain.Note, NoteDTO>();
            this.CreateMap<NoteCreateDTO, NoteUpdateModel>();
            this.CreateMap<NoteUpdateDTO, NoteUpdateModel>();
            this.CreateMap<NoteUpdateModel, DAL.Entity.Note>();
        }
    }
}
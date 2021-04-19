using System;
using CinemaApp.Domain.Base;
using CinemaApp.Domain.Contracts;

namespace CinemaApp.Domain
{
    public class Note:BaseNote, IVisitorContainer,ISessionContainer
    {
        public int Id { get; set; }
        
        public DateTime DateVisit { get; set; }
    }
}
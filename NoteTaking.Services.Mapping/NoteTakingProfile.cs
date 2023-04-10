using AutoMapper;
using NoteTaking.Data.Models;
using NoteTaking.Web.ViewModels;

namespace NoteTaking.Services.Mapping
{
    /// <summary>
    /// AutoMapper profile
    /// </summary>
    public class NoteTakingProfile : Profile
    {
        public NoteTakingProfile()
        {
            CreateMap<NoteInputViewModel, Note>();

            CreateMap<Note, NoteAllViewModel>();

            CreateMap<DeleteNoteViewModel, Note>();

            CreateMap<Note, EditNoteInputViewModel>();

            CreateMap<Note, DetailsNoteViewModel>();
        }
    }
}

using AutoMapper;
using NoteTaking.Data.Models;
using NoteTaking.Web.ViewModels;

namespace NoteTaking.Services.Mapping
{
    public class NoteTakingProfile : Profile
    {
        public NoteTakingProfile()
        {
            CreateMap<NoteInputViewModel, Note>();

            CreateMap<Note, NoteAllViewModel>();

            CreateMap<DeleteNoteViewModel, Note>();

            CreateMap<Note, EditNoteInputViewModel>();
        }
    }
}

using AutoMapper;
using Show = XprtzSerieApp.Database.ResponseData.Show;
using ShowEntity = XprtzSerieApp.Database.Entities.ShowEntity;

namespace XprtzSerieApp.Extensions
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            _ = CreateMap<ShowEntity, Show>();
            _ = CreateMap<Show, ShowEntity>();
        }
    }
}
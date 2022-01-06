namespace Explorer.WebApi.Models
{
    using AutoMapper;
    using Explorer.Application.Commands.ForFile.AppendContentToFile;
    using Explorer.Application.Commands.ForFile.ChangeFileContent;
    using Explorer.Application.Mappings;

    public class EditFileContentDto
        : IMapWith<AppendContentToFileCommand>,
            IMapWith<ChangeFileContentCommand>
    {
        public string Path { get; set; }

        public string NewContent { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<EditFileContentDto, AppendContentToFileCommand>()
                .ForMember(
                    command => command.ContentToAdd,
                    opt => opt.MapFrom(dto => dto.NewContent))
                .ForMember(
                    command => command.Path,
                    opt => opt.MapFrom(dto => dto.Path));
            profile.CreateMap<EditFileContentDto, ChangeFileContentCommand>()
                .ForMember(
                    command => command.NewContent,
                    opt => opt.MapFrom(dto => dto.NewContent))
                .ForMember(
                    command => command.Path,
                    opt => opt.MapFrom(dto => dto.Path));
        }
    }
}
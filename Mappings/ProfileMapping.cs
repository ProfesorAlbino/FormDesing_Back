using AutoMapper;
using FormDesing.DTOs;
using FormDesing.Models.DB;

namespace FormDesing.Mappings
{
    public class ProfileMapping: Profile
    {
        public ProfileMapping() 
        {
            CreateMap<Usuario, UserDTO>();
            CreateMap<UserDTO, Usuario>();

            CreateMap<TipoInput, InputDTO>();
            CreateMap<InputDTO, TipoInput>();

            CreateMap<Formulario, FormDTO>();
            CreateMap<FormDTO, Formulario>();

            CreateMap<FormularioInput, FormInputDTO>();
            CreateMap<FormInputDTO, FormularioInput>();

            CreateMap<DatoFormulario, FormDataDTO>();
            CreateMap<FormDataDTO, DatoFormulario>();
        }
    }
}
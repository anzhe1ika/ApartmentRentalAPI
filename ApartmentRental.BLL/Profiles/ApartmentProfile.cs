using ApartmentRental.Common;
using ApartmentRental.DAL.Entities;
using AutoMapper;

namespace ApartmentRental.BLL.Profiles
{
    public class ApartmentProfile : Profile
    {
        public ApartmentProfile()
        {
            CreateMap<CreateApartmentDto, Apartment>()
                .ForMember(dest => dest.PublishingDate, opt => opt.MapFrom(src => DateTime.Now))
                .ForMember(dest => dest.Owner, opt => opt.Ignore());

            CreateMap<Apartment, ApartmentDetailsDto>()
                .ForMember(dest => dest.OwnerName, opt => opt.MapFrom(src => src.Owner.OwnerName))
                .ForMember(dest => dest.OwnerNumber, opt => opt.MapFrom(src => src.Owner.PhoneNumber));

            CreateMap<Apartment, ApartmentListDto>()
                .ForMember(dest => dest.Description,
                    opt => opt.MapFrom(src => src.Description.Length > 20
                        ? src.Description.Substring(0, 20)
                        : src.Description));

            CreateMap<UpdateApartmentDto, Apartment>()
                .ForMember(dest => dest.ID, opt => opt.Ignore())
                .ForMember(dest => dest.Owner, opt => opt.Ignore())
                .ForMember(dest => dest.PublishingDate, opt => opt.MapFrom(src => DateTime.Now));

            CreateMap<Apartment, ApartmentSuggestionDto>()
                .ForMember(dest => dest.PhotoUrl, opt => opt.MapFrom(src => src.PhotosUrls.FirstOrDefault()));
        }
    }

    public class OwnerProfile : Profile
    {
        public OwnerProfile()
        {
            CreateMap<OwnerDto, Owner>();

            CreateMap<Owner, OwnerDto>();
        }
    }
}

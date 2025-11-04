using ApartmentRental.Common;

namespace ApartmentRental.BLL.Services.Interfaces
{
    public interface IApartmentService
    {
        Task<ApartmentDetailsDto> CreateApartmentAsync(CreateApartmentDto request);
        Task<bool> DeleteApartmentAsync(int id);
        Task<ApartmentDetailsDto> GetApartmentByIdAsync(int id);
        Task<List<ApartmentListDto>> GetApartmentsAsync(SearchApartmentsRequest request);
        Task<ApartmentDetailsDto> UpdateApartmentAsync(UpdateApartmentDto request); 
    }
}

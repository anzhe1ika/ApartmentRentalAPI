using ApartmentRental.BLL.Services.Interfaces;
using ApartmentRental.Common;
using ApartmentRental.DAL.Entities;
using ApartmentRental.DAL.Repository.Interfaces;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace ApartmentRental.BLL.Services
{
    public class ApartmentService : IApartmentService
    {
        private readonly IRepository<Apartment> _repository;
        private readonly IRepository<Owner> _ownerRepository;
        private readonly IMapper _mapper;

        public ApartmentService(IRepository<Apartment> repository, IMapper mapper, IRepository<Owner> ownerRepository)
        {
            _repository = repository;
            _mapper = mapper;
            _ownerRepository = ownerRepository;
        }

        public async Task<List<ApartmentListDto>> GetApartmentsAsync(SearchApartmentsRequest request)
        {
            var query = _repository.AsNoTracking();

            if (request.MinPrice != null)
            {
                query = query.Where(x => request.MinPrice <= x.Price);
            }

            if (request.MaxPrice != null)
            {
                query = query.Where(x => request.MaxPrice >= x.Price);
            }

            if (request.District != null)
            {
                query = query.Where(x => request.District == x.District);
            }

            if (request.MinRoomsCount != null)
            {
                query = query.Where(x => request.MinRoomsCount <= x.RoomsCount);
            }

            if (request.MaxRoomsCount != null)
            {
                query = query.Where(x => request.MaxRoomsCount >= x.RoomsCount);
            }

            if (request.FurnitureType != null)
            {
                query = query.Where(x => request.FurnitureType == x.FurnitureType);
            }

            if (request.IsPetFriendly != null)
            {
                query = query.Where(x => request.IsPetFriendly == x.IsPetFriendly);
            }

            if (request.IsChildFriendly != null)
            {
                query = query.Where(x => request.IsChildFriendly == x.IsChildFriendly);
            }

            if (request.MinFloor != null)
            {
                query = query.Where(x => request.MinFloor <= x.Floor);
            }

            if (request.MaxFloor != null)
            {
                query = query.Where(x => request.MaxFloor >= x.Floor);
            }

            if (request.MinArea != null)
            {
                query = query.Where(x => request.MinArea <= x.Area);
            }

            if (request.MaxArea != null)
            {
                query = query.Where(x => request.MaxArea >= x.Area);
            }

            if (request.Page != null && request.PageSize != null)
            {
                if (request.Page <= 0 || request.PageSize <= 0)
                {
                    throw new Exception("Error");
                }

                query = query.Skip((request.Page.Value - 1) * request.PageSize.Value).Take(request.PageSize.Value);
            }

            var entities = await query.ToListAsync();

            return _mapper.Map<List<ApartmentListDto>>(entities);
        }

        public async Task<ApartmentDetailsDto> GetApartmentByIdAsync(int id)
        {
            var entity = await _repository.Include(a => a.Owner).FirstOrDefaultAsync(x => x.ID == id);

            if (entity == null)
            {
                throw new Exception("Not found");
            }

            var result = _mapper.Map<ApartmentDetailsDto>(entity);

            var suggestions = await _repository
                .Where(x => (x.District == entity.District ||
                    Math.Abs(x.Price - entity.Price) <= (entity.Price * 0.1m) ||
                    x.Street == entity.Street ||
                    x.FurnitureType == entity.FurnitureType ||
                    x.IsPetFriendly == entity.IsPetFriendly ||
                    x.IsChildFriendly == entity.IsChildFriendly ||
                    Math.Abs(x.Area - entity.Area) <= (entity.Area * 0.25f)) &&
                    x.ID != entity.ID)
                .Take(3)
                .ToListAsync();

            result.Suggestions = _mapper.Map<List<ApartmentSuggestionDto>>(suggestions);

            return result;
        }

        public async Task<ApartmentDetailsDto> CreateApartmentAsync(CreateApartmentDto request)
        {
            var entity = _mapper.Map<Apartment>(request);

            var owner = await _ownerRepository.AsNoTracking().FirstOrDefaultAsync(x => x.PhoneNumber == request.Owner.PhoneNumber);

            if (owner != null)
            {
                entity.OwnerID = owner.ID;
            }
            else
            {
                var newOwner = await _ownerRepository.AddAsync(
                    new Owner {
                        OwnerName = request.Owner.OwnerName,
                        PhoneNumber = request.Owner.PhoneNumber
                    });

                await _ownerRepository.SaveChangesAsync();

                entity.OwnerID = newOwner.ID;
            }

            await _repository.AddAsync(entity);

            await _repository.SaveChangesAsync();

            return _mapper.Map<ApartmentDetailsDto>(entity);
        }

        public async Task<ApartmentDetailsDto> UpdateApartmentAsync(UpdateApartmentDto request)
        {
            var entity = await _repository.FirstOrDefaultAsync(x => x.ID == request.ID);

            _mapper.Map(request, entity);

            var owner = await _ownerRepository.AsNoTracking().FirstOrDefaultAsync(x => x.PhoneNumber == request.Owner.PhoneNumber);

            if (owner != null)
            {
                entity.OwnerID = owner.ID;
            }
            else
            {
                var newOwner = await _ownerRepository.AddAsync(
                    new Owner
                    {
                        OwnerName = request.Owner.OwnerName,
                        PhoneNumber = request.Owner.PhoneNumber
                    });

                await _ownerRepository.SaveChangesAsync();

                entity.OwnerID = newOwner.ID;
            }

            await _repository.SaveChangesAsync();

            return _mapper.Map<ApartmentDetailsDto>(entity);
        }

        public async Task<bool> DeleteApartmentAsync(int id)
        {
            var entity = await _repository.FirstOrDefaultAsync(x => x.ID == id);

            if (entity == null)
            {
                throw new Exception("Not found");
            }

            _repository.Remove(entity);

            var result = await _repository.SaveChangesAsync();

            return result == 1;
        }
    }
}

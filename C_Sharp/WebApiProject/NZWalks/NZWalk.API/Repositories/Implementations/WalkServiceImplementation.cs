using AutoMapper;
using Microsoft.EntityFrameworkCore;
using NZWalk.API.Data;
using NZWalk.API.Models.Domain;
using NZWalk.API.Models.DTO.WalkDto;
using NZWalk.API.Repositories.Interfaces;

namespace NZWalk.API.Repositories.Implementations
{
    public class WalkServiceImplementation : IWalkService
    {
        private readonly NZWalksDbContext _nzWalksDbContext;
        private readonly IMapper _mapper;

        public WalkServiceImplementation(NZWalksDbContext nzWalksDbContext, IMapper mapper)
        {
            this._nzWalksDbContext = nzWalksDbContext;
            this._mapper = mapper;
        }

        public async Task<(WalkDto, Walk)> CreateWalkRequestAsync(AddWalkRequestDto addWalkRequestDto)
        {
            /* Map or Convert Add Request Walk DTO to Model */
            var walkModel = this._mapper.Map<Walk>(source: addWalkRequestDto);

            /* Add Walk Request Data */
            await this._nzWalksDbContext.AddAsync(walkModel);

            /* Save Add Request Data */
            await this._nzWalksDbContext.SaveChangesAsync();

            /* Map or convert back Walk Model to Walk DTO */
            var walkDto = this._mapper.Map<WalkDto>(source: walkModel);

            /* Return DTO and Model */
            return (walkDto, walkModel);
        }

        public async Task<WalkDto?> DeleteWalkRequestByIdAsync(Guid id)
        {
            /* Get the value (Model) based on ID */
            var walkModel = await this._nzWalksDbContext.Walks.FindAsync(id);

            /* Check if the fetched walk model is not null */
            if (walkModel is not null)
            {
                /* Remove the fetched walk model */
                this._nzWalksDbContext.Walks.Remove(walkModel);

                /* Save the changes to database */
                await this._nzWalksDbContext.SaveChangesAsync();

                /* Map or convert Walk model to Walk DTO */
                var walkDto = this._mapper.Map<WalkDto>(source: walkModel);

                /* Return Walk DTO */
                return walkDto;
            }
            else
            {
                return null;
            }
        }

        public async Task<IEnumerable<WalkDto>> GetAllWalksAsync(string? filterOn = null, string? filterQuery = null, string? sortBy = null, bool isAscending = true, int pageNumber = 1, int pageSize = 100)
        {
            /* Get all Walk values (Model) - Previous implementation */
            //var walksModel = await this._nzWalksDbContext.Walks.Include(walk => walk.Difficulty).Include(walk => walk.Region).ToListAsync();

            /* Fetch the walks as Queryable */
            var walkQuery = this._nzWalksDbContext.Walks.Include(walk => walk.Difficulty).Include(walk => walk.Region).AsQueryable();

            /* Filter */
            var walkQueryFiltered = FilterOn(walkQuery: walkQuery, columnName: filterOn, filterKeyWord: filterQuery);

            /* Sorting By Ascending or Descending order on Name and Length In Kilo Meter */
            var walksModelFilteredAndSorted = SortingOn(walkQueryFiltered: walkQueryFiltered, columnName: sortBy, isAscending: isAscending);

            /* Pagination */
            var walksModelFilteredSortedPaginated = Pagination(walksModel: walksModelFilteredAndSorted, pageNumber: pageNumber, pageSize: pageSize);

            /* Convert to walksModel to async */
            var walksModelFilteredSortedPaginateddAsync = await walksModelFilteredSortedPaginated.ToListAsync();

            /* Map or Convert Walk Model to IEnumerable of DTO */
            var walksDto = this._mapper.Map<IEnumerable<WalkDto>>(source: walksModelFilteredSortedPaginateddAsync);

            /* Return IEnumerable of Walk DTO */
            return walksDto;
        }

        private static IQueryable<Walk> FilterOn(IQueryable<Walk> walkQuery, string? columnName = null, string? filterKeyWord = null)
        {
            /* Filter - We need to filter based on column (columnName) and query (filterKeyWord) */
            /* Check if these two incoming values are not NULL or White empty Space */
            if (!string.IsNullOrWhiteSpace(columnName) && !string.IsNullOrWhiteSpace(filterKeyWord))
            {
                /* Need to check - columnName is on which column and ignore the case */
                if (columnName.Equals("Name", StringComparison.OrdinalIgnoreCase))
                {
                    /* Filter Logic - We want filtered result if filterKeyWord has a value */
                    walkQuery = walkQuery.Where(walk => walk.Name.Contains(filterKeyWord));
                }
            }

            /* Return IEnumerable of Walk DTO */
            return walkQuery;
        }

        private static IQueryable<Walk> SortingOn(IQueryable<Walk> walkQueryFiltered, string? columnName = null, bool isAscending = true)
        {
            /* Sorting By Ascending or Descending order on Name and Length In Kilo Meter */
            if (!string.IsNullOrWhiteSpace(columnName))
            {
                /* Check if - column name (Sort By) exists by name of "Name" and ignore its case */
                if (columnName.Equals("Name", StringComparison.OrdinalIgnoreCase))
                {
                    /* Sorting ascending and descending order on Name */
                    walkQueryFiltered = isAscending ? walkQueryFiltered.OrderBy(walk => walk.Name) : walkQueryFiltered.OrderByDescending(walk => walk.Name);
                }
                else if (columnName.Equals("LengthInKiloMeter", StringComparison.OrdinalIgnoreCase))
                {
                    /* Sorting ascending and descending order on Length In Kilo Meter */
                    walkQueryFiltered = isAscending ? walkQueryFiltered.OrderBy(walk => walk.LengthInKiloMeter) : walkQueryFiltered.OrderByDescending(walk => walk.LengthInKiloMeter);
                }
            }

            /* Return IEnumerable of Walk DTO */
            return walkQueryFiltered;
        }

        private static IQueryable<Walk> Pagination(IQueryable<Walk> walksModel, int pageNumber = 1, int pageSize = 100)
        {
            /* Pagination: To show the number [page size] of data on page number [Page Number] - It based on a formula [You have to Skip X number of result and Take Y number of result] */
            /* Calculation for skip result = (Page Number - 1) * Page Size */
            var skipResult = (pageNumber - 1) * pageSize;

            /* Skip(Skip Result) && Take result */
            var walksModelPaginated = walksModel.Skip(skipResult).Take(pageSize);

            /* Return IEnumerable of Walk DTO */
            return walksModelPaginated;
        }

        public async Task<WalkDto?> GetWalkByIdAsync(Guid id)
        {
            /* Get the value (Model) based on ID */
            var walkModel = await this._nzWalksDbContext.Walks.Include(walk => walk.Difficulty).Include(walk => walk.Region).FirstOrDefaultAsync(walk => walk.Id == id);

            /* Check if fetched walk model value is not null */
            if (walkModel is not null)
            {
                /* Map or convert Walk Model to Walk DTO */
                var walkDto = this._mapper.Map<WalkDto>(source: walkModel);

                /* Return Walk DTO */
                return walkDto;
            }
            else
            {
                return null;
            }
        }

        public async Task<WalkDto?> UpdateWalkRequestByIdAsync(Guid id, UpdateWalkRequestDto updateWalkRequestDto)
        {
            /* Get the value (Model) based on ID */
            var walkModel = await this._nzWalksDbContext.Walks.Include(walk => walk.Difficulty).Include(walk => walk.Region).FirstOrDefaultAsync(walk => walk.Id == id);

            /* Check if the fetched value is not null */
            if (walkModel is not null)
            {
                /* Update the fetched model value with incoming updated DTO */
                walkModel.Name = updateWalkRequestDto.Name;
                walkModel.Description = updateWalkRequestDto.Description;
                walkModel.LengthInKiloMeter = updateWalkRequestDto.LengthInKiloMeter;
                walkModel.ImageUrl = updateWalkRequestDto.ImageUrl;

                /* Save the changes to the database */
                await this._nzWalksDbContext.SaveChangesAsync();

                /* Map or convert Walk Model to Walk DTO */
                var walkDto = this._mapper.Map<WalkDto>(source: walkModel);

                /* Return Model DTO */
                return walkDto;
            }
            else
            {
                return null;
            }
        }
    }
}

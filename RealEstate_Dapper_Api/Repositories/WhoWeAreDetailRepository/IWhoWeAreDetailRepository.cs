﻿using RealEstate_Dapper_Api.Dtos.WhoWeAreDetailDtos;

namespace RealEstate_Dapper_Api.Repositories.WhoWeAreDetailRepository
{
    public interface IWhoWeAreDetailRepository
    {
        Task<List<ResultWhoWeAreDetailDto>> GetAllWhoWeAreDetailAsync();
        void CreateWhoWeAreDetail(CreateWhoWeAreDetailDto createWhoWeAreDetail);
        void DeleteWhoWeAreDetail(int id);
        void UpdateWhoWeAreDetail(UpdateWhoWeAreDetailDto updateWhoWeAreDetailDto);
        Task<GetByIDWhoWeAreDetailDto> GetWhoWeAreDetailAsync(int id);
    }
}

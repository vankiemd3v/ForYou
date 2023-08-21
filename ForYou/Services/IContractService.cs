using ForYou.Dtos;

namespace ForYou.Services
{
    public interface IContractService
    {
        Task<PagingResponse<ContractDto>> GetPagingContracts(PagingRequest request);
        Task<List<ContractDto>> GetListContracts();

        Task<ContractDto> GetById(long id);
        Task<long> Create(ContractDto dto);

    }
}

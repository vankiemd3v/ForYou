using ForYou.Dtos;

namespace ForYou.Services
{
    public interface IContractService
    {
        Task<List<ContractDto>> GetContracts();
        Task<ContractDto> GetById(long id);
        Task<long> Create(ContractDto dto);

    }
}

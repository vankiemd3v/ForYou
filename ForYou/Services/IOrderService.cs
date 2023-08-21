using ForYou.Dtos;

namespace ForYou.Services
{
    public interface IOrderService
    {
        Task<PagingResponse<OrderBillDto>> GetOrdersPaymentDue(PagingRequest request); // Lấy những phụ lục đến hạn thanh toán
    }
}

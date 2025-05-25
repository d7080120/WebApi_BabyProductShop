using static System.Runtime.InteropServices.JavaScript.JSType;

namespace DTOEntities
{
    public record OrderDTO(DateTime Date,int Sum, int UserId, ICollection<OrderItemDTO> OrderItems);
    
}

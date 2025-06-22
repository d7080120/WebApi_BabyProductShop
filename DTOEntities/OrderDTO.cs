using static System.Runtime.InteropServices.JavaScript.JSType;

namespace DTOEntities
{
    public record OrderDTO(DateTime Date, int UserId, ICollection<OrderItemDTO> OrderItems);
    
}

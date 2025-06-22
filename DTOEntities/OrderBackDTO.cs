using static System.Runtime.InteropServices.JavaScript.JSType;

namespace DTOEntities
{
    public record OrderBackDTO(DateTime Date, int UserId, ICollection<OrderItemDTO> OrderItems,int Sum);
    
}

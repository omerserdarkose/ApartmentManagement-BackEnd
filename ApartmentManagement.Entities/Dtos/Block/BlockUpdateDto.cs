using ApartmentManagement.Core.Entities;

namespace ApartmentManagement.Entities.Dtos.Block
{
    public class BlockUpdateDto:IDto
    {
        public short Id { get; set; }
        public string Letter { get; set; }
    }
}
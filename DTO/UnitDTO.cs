using System.ComponentModel.DataAnnotations;

namespace DTO
{
    public class UnitDTO
    {
        public int Id { get; set; }
        public string? UnitName { get; set; }

        public string? Comments { get; set; }

        public int? ParentUnitId { get; set; }
        public int? EstimatedHours { get; set; }

     }
}
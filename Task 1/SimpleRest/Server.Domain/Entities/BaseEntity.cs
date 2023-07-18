using System.ComponentModel.DataAnnotations;

namespace Server.Domain.Entities
{
    public abstract class BaseEntity : IEntity
    {
        [Key] public long Id { get; set; }
    }
}
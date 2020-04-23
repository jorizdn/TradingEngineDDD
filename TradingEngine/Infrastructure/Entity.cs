using System.ComponentModel.DataAnnotations;

namespace TradingEngine.Infrastructure
{
    public abstract class Entity
    {
        [Key]
        public virtual int Id { get; set; }
    }
}

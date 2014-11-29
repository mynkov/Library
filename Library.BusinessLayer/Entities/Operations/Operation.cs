using Library.BusinessLayer.Attributes;
using Library.BusinessLayer.Attributes.Validation;

namespace Library.BusinessLayer.Entities.Operations
{
    [Resource(typeof(Properties.Resources.Entities.Operation))]
    public abstract class Operation<TEntity> : BaseOperation
        where TEntity : Entity
    {
        [Required]
        public TEntity Entity { get; set; }
    }
}

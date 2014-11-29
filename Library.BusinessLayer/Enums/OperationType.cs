using Library.BusinessLayer.Attributes;

namespace Library.BusinessLayer.Enums
{
    [Resource(typeof(Properties.Resources.Enums.OperationType))]
    public enum OperationType
    {
        Insert,

        Update,

        Get,

        Delete
    }
}

using System.Collections.Generic;
using System.Data.Entity.Core.Metadata.Edm;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;

namespace Library.DataAccessLayer
{
    public class ForeignKeyNamingConvention : IStoreModelConvention<AssociationType>
    {
        public void Apply(AssociationType association, DbModel model)
        {
            // Identify a ForeignKey properties (including IAs)
            if (association.IsForeignKey)
            {
                // rename FK columns
                var constraint = association.Constraint;
                if (DoPropertiesHaveDefaultNames(constraint.FromProperties, constraint.ToProperties))
                {
                    NormalizeForeignKeyProperties(constraint.FromProperties);
                }
                if (DoPropertiesHaveDefaultNames(constraint.ToProperties, constraint.FromProperties))
                {
                    NormalizeForeignKeyProperties(constraint.ToProperties);
                }
            }
        }

        private bool DoPropertiesHaveDefaultNames(ReadOnlyMetadataCollection<EdmProperty> properties, ReadOnlyMetadataCollection<EdmProperty> otherEndProperties)
        {
            if (properties.Count != otherEndProperties.Count)
            {
                return false;
            }

            return !properties.Where((t, i) => !t.Name.EndsWith("_" + otherEndProperties[i].Name)).Any();
        }

        private void NormalizeForeignKeyProperties(IEnumerable<EdmProperty> properties)
        {
            foreach (EdmProperty property in properties)
            {
                string defaultPropertyName = property.Name;
                int ichUnderscore = defaultPropertyName.IndexOf('_');
                if (ichUnderscore <= 0)
                {
                    continue;
                }
                string navigationPropertyName = defaultPropertyName.Substring(0, ichUnderscore);
                string targetKey = defaultPropertyName.Substring(ichUnderscore + 1);

                string newPropertyName;
                if (targetKey.StartsWith(navigationPropertyName))
                {
                    newPropertyName = targetKey;
                }
                else
                {
                    newPropertyName = navigationPropertyName + targetKey;
                }
                property.Name = newPropertyName;
            }
        }
    }
}

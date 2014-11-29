using System.Data.Entity;
using Library.BusinessLayer.Entities;
using Library.BusinessLayer.Entities.Operations;

namespace Library.DataAccessLayer
{
    public class ModelBuilder
    {
        public void ModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Add(new ForeignKeyNamingConvention());

            modelBuilder.Types<BaseOperation>()
                .Configure(x => x.Property(p => p.Object)
                                    .HasColumnType("XML"));

            modelBuilder.Entity<User>()
                .Ignore(x => x.MembershipUser);
        }
    }
}

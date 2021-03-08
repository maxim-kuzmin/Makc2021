//Author Maxim Kuzmin//makc//

using Makc2021.Layer2.Sources.Sample.ORMs.EF.Entities.DummyMain;
using Makc2021.Layer2.Sources.Sample.ORMs.EF.Entities.DummyMainDummyManyToMany;
using Makc2021.Layer2.Sources.Sample.ORMs.EF.Entities.DummyManyToMany;
using Makc2021.Layer2.Sources.Sample.ORMs.EF.Entities.DummyOneToMany;
using Makc2021.Layer2.Sources.Sample.ORMs.EF.Entities.DummyTree;
using Makc2021.Layer2.Sources.Sample.ORMs.EF.Entities.DummyTreeLink;
using Makc2021.Layer2.Sources.Sample.ORMs.EF.Entities.Role;
using Makc2021.Layer2.Sources.Sample.ORMs.EF.Entities.RoleClaim;
using Makc2021.Layer2.Sources.Sample.ORMs.EF.Entities.User;
using Makc2021.Layer2.Sources.Sample.ORMs.EF.Entities.UserClaim;
using Makc2021.Layer2.Sources.Sample.ORMs.EF.Entities.UserLogin;
using Makc2021.Layer2.Sources.Sample.ORMs.EF.Entities.UserRole;
using Makc2021.Layer2.Sources.Sample.ORMs.EF.Entities.UserToken;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Makc2021.Layer2.Sources.Sample.ORMs.EF.Db
{
    /// <summary>
    /// Источник "Sample". ORM "Entity Framework". Контекст базы данных.
    /// </summary>
    public abstract class SampleEFDbContext : IdentityDbContext
        <
            SampleUserEntityEFObject,
            SampleRoleEntityEFObject,
            long,
            SampleUserClaimEntityEFObject,
            SampleUserRoleEntityEFObject,
            SampleUserLoginEntityEFObject,
            SampleRoleClaimEntityEFObject,
            SampleUserTokenEntityEFObject
        >
    {
        #region Properties        

        /// <summary>
        /// Сущность "DummyMain".
        /// </summary>
        public DbSet<SampleDummyMainEntityEFObject> DummyMain { get; set; }

        /// <summary>
        /// Сущность "DummyManyToMany".
        /// </summary>
        public DbSet<SampleDummyManyToManyEntityEFObject> DummyManyToMany { get; set; }

        /// <summary>
        /// Сущность "DummyMainDummyManyToMany".
        /// </summary>
        public DbSet<SampleDummyMainDummyManyToManyEntityEFObject> DummyMainDummyManyToMany { get; set; }

        /// <summary>
        /// Сущность "DummyOneToMany".
        /// </summary>
        public DbSet<SampleDummyOneToManyEntityEFObject> DummyOneToMany { get; set; }

        /// <summary>
        /// Сущность "DummyTree".
        /// </summary>
        public DbSet<SampleDummyTreeEntityEFObject> DummyTree { get; set; }

        /// <summary>
        /// Сущность "DummyTreeLink".
        /// </summary>
        public DbSet<SampleDummyTreeLinkEntityEFObject> DummyTreeLink { get; set; }

        #endregion Properties

        #region Constructors

        /// <inheritdoc/>
        public SampleEFDbContext(DbContextOptions<SampleEFDbContext> options)
            : base(options)
        {
        }

        #endregion Constructors
    }
}
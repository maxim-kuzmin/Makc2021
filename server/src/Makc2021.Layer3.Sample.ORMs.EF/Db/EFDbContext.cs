//Author Maxim Kuzmin//makc//

using Makc2021.Layer3.Sample.ORMs.EF.Entities.DummyMain;
using Makc2021.Layer3.Sample.ORMs.EF.Entities.DummyMainDummyManyToMany;
using Makc2021.Layer3.Sample.ORMs.EF.Entities.DummyManyToMany;
using Makc2021.Layer3.Sample.ORMs.EF.Entities.DummyOneToMany;
using Makc2021.Layer3.Sample.ORMs.EF.Entities.DummyTree;
using Makc2021.Layer3.Sample.ORMs.EF.Entities.DummyTreeLink;
using Makc2021.Layer3.Sample.ORMs.EF.Entities.Role;
using Makc2021.Layer3.Sample.ORMs.EF.Entities.RoleClaim;
using Makc2021.Layer3.Sample.ORMs.EF.Entities.User;
using Makc2021.Layer3.Sample.ORMs.EF.Entities.UserClaim;
using Makc2021.Layer3.Sample.ORMs.EF.Entities.UserLogin;
using Makc2021.Layer3.Sample.ORMs.EF.Entities.UserRole;
using Makc2021.Layer3.Sample.ORMs.EF.Entities.UserToken;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Makc2021.Layer3.Sample.ORMs.EF.Db
{
    /// <summary>
    /// ORM "Entity Framework". Контекст базы данных.
    /// </summary>
    public abstract class EFDbContext : IdentityDbContext
        <
            UserEntityEFObject,
            RoleEntityEFObject,
            long,
            UserClaimEntityEFObject,
            UserRoleEntityEFObject,
            UserLoginEntityEFObject,
            RoleClaimEntityEFObject,
            UserTokenEntityEFObject
        >
    {
        #region Properties        

        /// <summary>
        /// Сущность "DummyMain".
        /// </summary>
        public DbSet<DummyMainEntityEFObject> DummyMain { get; set; }

        /// <summary>
        /// Сущность "DummyManyToMany".
        /// </summary>
        public DbSet<DummyManyToManyEntityEFObject> DummyManyToMany { get; set; }

        /// <summary>
        /// Сущность "DummyMainDummyManyToMany".
        /// </summary>
        public DbSet<DummyMainDummyManyToManyEntityEFObject> DummyMainDummyManyToMany { get; set; }

        /// <summary>
        /// Сущность "DummyOneToMany".
        /// </summary>
        public DbSet<DummyOneToManyEntityEFObject> DummyOneToMany { get; set; }

        /// <summary>
        /// Сущность "DummyTree".
        /// </summary>
        public DbSet<DummyTreeEntityEFObject> DummyTree { get; set; }

        /// <summary>
        /// Сущность "DummyTreeLink".
        /// </summary>
        public DbSet<DummyTreeLinkEntityEFObject> DummyTreeLink { get; set; }

        #endregion Properties

        #region Constructors

        /// <inheritdoc/>
        public EFDbContext(DbContextOptions<EFDbContext> options)
            : base(options)
        {
        }

        #endregion Constructors
    }
}
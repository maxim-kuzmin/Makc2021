// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using Makc2021.Layer3.Sample.Mappers.EF.Entities.DummyMain;
using Makc2021.Layer3.Sample.Mappers.EF.Entities.DummyMainDummyManyToMany;
using Makc2021.Layer3.Sample.Mappers.EF.Entities.DummyManyToMany;
using Makc2021.Layer3.Sample.Mappers.EF.Entities.DummyOneToMany;
using Makc2021.Layer3.Sample.Mappers.EF.Entities.DummyTree;
using Makc2021.Layer3.Sample.Mappers.EF.Entities.DummyTreeLink;
using Makc2021.Layer3.Sample.Mappers.EF.Entities.Role;
using Makc2021.Layer3.Sample.Mappers.EF.Entities.RoleClaim;
using Makc2021.Layer3.Sample.Mappers.EF.Entities.User;
using Makc2021.Layer3.Sample.Mappers.EF.Entities.UserClaim;
using Makc2021.Layer3.Sample.Mappers.EF.Entities.UserLogin;
using Makc2021.Layer3.Sample.Mappers.EF.Entities.UserRole;
using Makc2021.Layer3.Sample.Mappers.EF.Entities.UserToken;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Makc2021.Layer3.Sample.Mappers.EF.Db
{
    /// <summary>
    /// Контекст базы данных сопоставителя.
    /// </summary>
    public abstract class MapperDbContext : IdentityDbContext
        <
            UserEntityMapperObject,
            RoleEntityMapperObject,
            long,
            UserClaimEntityMapperObject,
            UserRoleEntityMapperObject,
            UserLoginEntityMapperObject,
            RoleClaimEntityMapperObject,
            UserTokenEntityMapperObject
        >
    {
        #region Properties        

        /// <summary>
        /// Сущность "DummyMain".
        /// </summary>
        public DbSet<DummyMainEntityMapperObject> DummyMain { get; set; }

        /// <summary>
        /// Сущность "DummyManyToMany".
        /// </summary>
        public DbSet<DummyManyToManyEntityMapperObject> DummyManyToMany { get; set; }

        /// <summary>
        /// Сущность "DummyMainDummyManyToMany".
        /// </summary>
        public DbSet<DummyMainDummyManyToManyEntityMapperObject> DummyMainDummyManyToMany { get; set; }

        /// <summary>
        /// Сущность "DummyOneToMany".
        /// </summary>
        public DbSet<DummyOneToManyEntityMapperObject> DummyOneToMany { get; set; }

        /// <summary>
        /// Сущность "DummyTree".
        /// </summary>
        public DbSet<DummyTreeEntityMapperObject> DummyTree { get; set; }

        /// <summary>
        /// Сущность "DummyTreeLink".
        /// </summary>
        public DbSet<DummyTreeLinkEntityMapperObject> DummyTreeLink { get; set; }

        #endregion Properties

        #region Constructors

        /// <inheritdoc/>
        public MapperDbContext(DbContextOptions<MapperDbContext> options)
            : base(options)
        {
        }

        #endregion Constructors
    }
}
// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using Makc2021.Layer3.Sql.Sample.Entities;
using Makc2021.Layer3.Sql.Sample.Mappers.EF.Db;
using Makc2021.Layer3.Sql.Sample.Mappers.EF.Entities.DummyMain;
using Makc2021.Layer3.Sql.Sample.Mappers.EF.Entities.DummyMainDummyManyToMany;
using Makc2021.Layer3.Sql.Sample.Mappers.EF.Entities.DummyManyToMany;
using Makc2021.Layer3.Sql.Sample.Mappers.EF.Entities.DummyOneToMany;
using Makc2021.Layer3.Sql.Sample.Mappers.EF.Entities.DummyTree;
using Makc2021.Layer3.Sql.Sample.Mappers.EF.Entities.DummyTreeLink;
using Makc2021.Layer3.Sql.Sample.Mappers.EF.Entities.Role;
using Makc2021.Layer3.Sql.Sample.Mappers.EF.Entities.RoleClaim;
using Makc2021.Layer3.Sql.Sample.Mappers.EF.Entities.User;
using Makc2021.Layer3.Sql.Sample.Mappers.EF.Entities.UserClaim;
using Makc2021.Layer3.Sql.Sample.Mappers.EF.Entities.UserLogin;
using Makc2021.Layer3.Sql.Sample.Mappers.EF.Entities.UserRole;
using Makc2021.Layer3.Sql.Sample.Mappers.EF.Entities.UserToken;

using Microsoft.EntityFrameworkCore;

namespace Makc2021.Layer3.Sql.Sample.Clients.SqlServer.EF.Db
{
    /// <summary>
    /// Контекст базы данных клиента.
    /// </summary>
    public class ClientDbContext : MapperDbContext
    {
        #region Fields

        private readonly EntitiesOptions _entitiesOptions;

        #endregion Fields

        #region Constructors

        /// <inheritdoc/>
        public ClientDbContext()
            : this(ClientDbFactory.Default.Options, ClientDbFactory.Default.EntitiesOptions)
        {
        }

        /// <inheritdoc/>
        public ClientDbContext(DbContextOptions<MapperDbContext> options)
            : this(options, ClientDbFactory.Default.EntitiesOptions)
        {
        }

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="options">Параметры.</param>
        /// <param name="entitiesOptions">Параметры сущностей.</param>
        public ClientDbContext(DbContextOptions<MapperDbContext> options, EntitiesOptions entitiesOptions)
            : base(options)
        {
            _entitiesOptions = entitiesOptions;
        }

        #endregion Constructors

        #region Protected methods

        /// <inheritdoc/>
        protected sealed override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new MapperDummyMainEntitySchema(_entitiesOptions));
            modelBuilder.ApplyConfiguration(new MapperDummyManyToManyEntitySchema(_entitiesOptions));
            modelBuilder.ApplyConfiguration(new MapperDummyMainDummyManyToManyEntitySchema(_entitiesOptions));
            modelBuilder.ApplyConfiguration(new MapperDummyOneToManyEntitySchema(_entitiesOptions));
            modelBuilder.ApplyConfiguration(new MapperDummyTreeEntitySchema(_entitiesOptions));
            modelBuilder.ApplyConfiguration(new MapperDummyTreeLinkEntitySchema(_entitiesOptions));

            modelBuilder.ApplyConfiguration(new MapperRoleEntitySchema(_entitiesOptions));
            modelBuilder.ApplyConfiguration(new MapperRoleClaimEntitySchema(_entitiesOptions));

            modelBuilder.ApplyConfiguration(new MapperUserEntitySchema(_entitiesOptions));
            modelBuilder.ApplyConfiguration(new MapperUserClaimEntitySchema(_entitiesOptions));
            modelBuilder.ApplyConfiguration(new MapperUserLoginEntitySchema(_entitiesOptions));
            modelBuilder.ApplyConfiguration(new MapperUserRoleEntitySchema(_entitiesOptions));
            modelBuilder.ApplyConfiguration(new MapperUserTokenEntitySchema(_entitiesOptions));
        }

        #endregion Protected methods
    }
}

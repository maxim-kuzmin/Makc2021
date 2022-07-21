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

        private readonly EntitiesOptions _entitiesSettings;

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
        /// <param name="options">Опции.</param>
        /// <param name="entitiesSettings">Настройки сущностей.</param>
        public ClientDbContext(DbContextOptions<MapperDbContext> options, EntitiesOptions entitiesSettings)
            : base(options)
        {
            _entitiesSettings = entitiesSettings;
        }

        #endregion Constructors

        #region Protected methods

        /// <inheritdoc/>
        protected sealed override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new MapperDummyMainEntitySchema(_entitiesSettings));
            modelBuilder.ApplyConfiguration(new MapperDummyManyToManyEntitySchema(_entitiesSettings));
            modelBuilder.ApplyConfiguration(new MapperDummyMainDummyManyToManyEntitySchema(_entitiesSettings));
            modelBuilder.ApplyConfiguration(new MapperDummyOneToManyEntitySchema(_entitiesSettings));
            modelBuilder.ApplyConfiguration(new MapperDummyTreeEntitySchema(_entitiesSettings));
            modelBuilder.ApplyConfiguration(new MapperDummyTreeLinkEntitySchema(_entitiesSettings));

            modelBuilder.ApplyConfiguration(new MapperRoleEntitySchema(_entitiesSettings));
            modelBuilder.ApplyConfiguration(new MapperRoleClaimEntitySchema(_entitiesSettings));

            modelBuilder.ApplyConfiguration(new MapperUserEntitySchema(_entitiesSettings));
            modelBuilder.ApplyConfiguration(new MapperUserClaimEntitySchema(_entitiesSettings));
            modelBuilder.ApplyConfiguration(new MapperUserLoginEntitySchema(_entitiesSettings));
            modelBuilder.ApplyConfiguration(new MapperUserRoleEntitySchema(_entitiesSettings));
            modelBuilder.ApplyConfiguration(new MapperUserTokenEntitySchema(_entitiesSettings));
        }

        #endregion Protected methods
    }
}

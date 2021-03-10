//Author Maxim Kuzmin//makc//

using System.Collections.Generic;

namespace Makc2021.Layer2
{
    /// <summary>
    /// Загрузчик сущности.
    /// </summary>
    /// <typeparam name="TEntity">Тип сущности.</typeparam>
    public abstract class EntityLoader<TEntity>
    {
        #region Properties

        /// <summary>
        /// Загружаемые свойства сущности.
        /// </summary>
        protected HashSet<string> LoadableEntityProperties { get; set; }

        /// <summary>
        /// Сущность.
        /// </summary>
        public TEntity Entity { get; set; }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="entity">Сущность.</param>
        public EntityLoader(TEntity entity)
        {
            Entity = entity;
        }

        #endregion Constructors

        #region Protected methods

        /// <summary>
        /// Гарантировать ненулевое значение.
        /// </summary>
        /// <param name="props">Загружаемые свойства.</param>
        /// <returns>Ненулевое значение.</returns>
        protected HashSet<string> EnsureNotNullValue(HashSet<string> props)
        {
            if (props != null)
            {
                return props;
            }
            else
            {
                if (LoadableEntityProperties == null)
                {
                    LoadableEntityProperties = CreateLoadableEntityProperties();
                }

                return LoadableEntityProperties;
            }
        }

        /// <summary>
        /// Создать загружаемые свойства.
        /// </summary>
        /// <returns>Загружаемые свойства.</returns>
        protected virtual HashSet<string> CreateLoadableEntityProperties()
        {
            return null;
        }

        #endregion Protected methods
    }
}
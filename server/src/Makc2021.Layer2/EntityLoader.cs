﻿//Author Maxim Kuzmin//makc//

using System.Collections.Generic;

namespace Makc2021.Layer2
{
    /// <summary>
    /// Загрузчик сущности.
    /// </summary>
    /// <typeparam name="TEntityObject">Тип объекта сущности.</typeparam>
    public abstract class EntityLoader<TEntityObject>
    {
        #region Properties

        /// <summary>
        /// Загружаемые свойства.
        /// </summary>
        protected HashSet<string> LoadableProperties { get; set; }

        /// <summary>
        /// Объект сущности.
        /// </summary>
        public TEntityObject EntityObject { get; set; }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="entityObject">Объект сущности.</param>
        public EntityLoader(TEntityObject entityObject)
        {
            EntityObject = entityObject;
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
                if (LoadableProperties == null)
                {
                    LoadableProperties = CreateLoadableProperties();
                }

                return LoadableProperties;
            }
        }

        /// <summary>
        /// Создать загружаемые свойства.
        /// </summary>
        /// <returns>Загружаемые свойства.</returns>
        protected virtual HashSet<string> CreateLoadableProperties()
        {
            return null;
        }

        #endregion Protected methods
    }
}
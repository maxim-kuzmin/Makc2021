// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Makc2021.Layer4.Domains.DummyMain.Queries.List.Get
{
    /// <summary>
    /// Интерфейс ресурса запроса на получение списка в домене.
    /// </summary>
    public interface IListGetQueryDomainResource
    {
        #region Methods

        /// <summary>
        /// Получить имя запроса.
        /// </summary>
        /// <returns>Имя.</returns>
        string GetQueryName();

        #endregion Methods
    }
}

// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Makc2021.Layer4.Domains.DummyMain.Resources.Names
{
    /// <summary>
    /// Интерфейс ресурса имён в домене.
    /// </summary>
    public interface INamesDomainResource
    {
        #region Methods

        /// <summary>
        /// Получить для запроса на получение элемента.
        /// </summary>
        /// <returns>Имя.</returns>
        string GetForItemGetQuery();

        #endregion Methods
    }
}

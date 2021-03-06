//Author Maxim Kuzmin//makc//

namespace Makc2021.Layer1.Base.Data.Trigger
{
    /// <summary>
    ///  Основа. Действие триггера.
    /// </summary>
    public enum BaseTriggerAction
    {
        /// <summary>
        /// Отсутствует.
        /// </summary>
        None = 0,
        /// <summary>
        /// Удаление.
        /// </summary>
        Delete = 1,
        /// <summary>
        /// Вставка.
        /// </summary>
        Insert = 2,
        /// <summary>
        /// Обновление.
        /// </summary>
        Update = 3
    }
}

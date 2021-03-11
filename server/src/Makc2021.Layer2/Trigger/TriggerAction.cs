//Author Maxim Kuzmin//makc//

namespace Makc2021.Layer2.Trigger
{
    /// <summary>
    /// Действие триггера.
    /// </summary>
    public enum TriggerAction
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

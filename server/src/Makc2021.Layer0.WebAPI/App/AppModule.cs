//Author Maxim Kuzmin//makc//

namespace Makc2021.Layer0.WebAPI.App
{
    /// <summary>
    /// Модуль приложения.
    /// </summary>
    public class AppModule
    {
        #region Properties

        /// <summary>
        /// ORM "Sample".
        /// </summary>
        public Layer3.Sample.Mappers.EF.MapperModule SampleMapper { get; } = new();

        /// <summary>
        /// Клиент "Sample".
        /// </summary>
        public Layer3.Sample.Clients.SqlServer.EF.ClientModule SampleClient { get; } = new();

        #endregion Properties
    }
}

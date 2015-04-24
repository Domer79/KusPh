using System.Data.Entity;
using SystemTools;
using DataRepository;
using KusPh.Data.Models;

namespace KusPh.Data
{
    public class KusPhContext : RepositoryDataContext
    {
        /// <summary>
        /// Создает новый экземпляр контекста с использованием соглашений для создания имени базы данных,     с которой будет установлено соединение.Имя по соглашению представляет собой полное имя (пространство имен + имя класса) производного класса контекста.Как это используется при создании соединения, см. в примечаниях к классу.
        /// </summary>
        public KusPhContext()
            : base(ApplicationSettings.ConnectionString)
        {
        }

        public DbSet<Kus> Kus { get; set; }
        public DbSet<Error> Error { get; set; }
        public DbSet<Settings> Settings { get; set; }
    }
}

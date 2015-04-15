using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemTools;
using KusPh.Data.Models;

namespace KusPh.Data
{
    public class KusPhContext : DbContext
    {
        /// <summary>
        /// Создает новый экземпляр контекста с использованием соглашений для создания имени базы данных,     с которой будет установлено соединение.Имя по соглашению представляет собой полное имя (пространство имен + имя класса) производного класса контекста.Как это используется при создании соединения, см. в примечаниях к классу.
        /// </summary>
        public KusPhContext()
            : base(ApplicationSettings.ConnectionString)
        {
        }

        public DbSet<Kus> Kus { get; set; }
    }
}

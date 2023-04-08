using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity; // представляет собой спец класс, который позволяет работать с СУБД

namespace UserAPP
{
    internal class ApplicationContext : DbContext
    {
        public DbSet<User> Users { get; set; } //представляет собой класс, содержащий список,
                     //в котором находятся элементы, которые могут быть вытянуты из таблицы
        public ApplicationContext() : base("DefaultConnection") { }

    }
}

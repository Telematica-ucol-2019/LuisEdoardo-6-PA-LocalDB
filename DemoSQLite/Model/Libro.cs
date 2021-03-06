using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace DemoSQLite.Model
{
    [Table("Libros")]
    public class Libro
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Editorial { get; set; }
        public string Autor { get; set; }
        public string Descripcion { get; set; }

        [ForeignKey(typeof(FechaPublicacion))]
        public int FKFechaPublicacionId { get; set; }

        [OneToOne(CascadeOperations = CascadeOperation.All)]
        public FechaPublicacion FechaPublicacion { get; set; }
    }
}

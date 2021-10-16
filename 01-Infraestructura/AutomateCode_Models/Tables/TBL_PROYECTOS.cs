using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AutomateCode_Models.Tables
{
    [Table("TBL_PROYECTOS")]
    [Serializable()]
    public partial class TBL_PROYECTOS
    {
        [Key]
        [Column(Order = 0)]
        public int ID { get; set; }

        [Required()]
        [StringLength(50)]
        [Column(Order = 1)]
        public string NOMBRE { get; set; }

        [Required()]
        [StringLength(4000)]
        [Column(Order = 2)]
        public string TEXTO { get; set; }

        [Required()]
        [Column(Order = 3)]
        public DateTime FECHALTA { get; set; }

        [Required()]
        [StringLength(100)]
        [Column(Order = 4)]
        public string NOMBRE_PROYECTO { get; set; }

        [Required()]
        [StringLength(255)]
        [Column(Order = 5)]
        public string PATH { get; set; }

        [Column(Order = 6)]
        public bool MODELO_DATOS { get; set; }

        [Column(Order = 7)]
        public bool INTERFACES { get; set; }

        [Column(Order = 7)]
        public bool CAPA_SERVICIOS { get; set; }

        [Required()]
        [Column(Order = 8)]
        public int LENGUAJE_SERVICIO { get; set; }

        /// <summary>
        /// Crea un objeto de tipo TBL_PROYECTOS con los elementos a añadir / actualizar
        /// </summary>
        /// <param name="_NOMBRE"></param>
        /// <param name="_TEXTO"></param>
        /// <param name="_FECHAALTA"></param>
        /// <param name="_NOMBRE_PROYECTO"></param>
        /// <param name="_PATH"></param>
        /// <param name="_MODELO_DATOS"></param>
        /// <param name="_INTERFACES"></param>
        /// <param name="_CAPA_SERVICIOS"></param>
        /// <param name="_LENGUAJE_SERVICIO"></param>
        /// <param name="_ID"></param>
        /// <returns></returns>
        public static TBL_PROYECTOS Create(string _NOMBRE, string _TEXTO, DateTime _FECHAALTA, string _NOMBRE_PROYECTO, string _PATH, Boolean _MODELO_DATOS, Boolean _INTERFACES, Boolean _CAPA_SERVICIOS, int _LENGUAJE_SERVICIO, int _ID = 0)
        {
            TBL_PROYECTOS objectReturn;

            objectReturn = new TBL_PROYECTOS
            {
                ID = _ID,
                NOMBRE = _NOMBRE.Trim(),
                TEXTO = _TEXTO.Trim(),
                FECHALTA = _FECHAALTA,
                NOMBRE_PROYECTO = _NOMBRE_PROYECTO.Trim(),
                PATH = _PATH.Trim(),
                MODELO_DATOS = _MODELO_DATOS,
                INTERFACES = _INTERFACES,
                CAPA_SERVICIOS = _CAPA_SERVICIOS,
                LENGUAJE_SERVICIO = _LENGUAJE_SERVICIO
            };

            return objectReturn;
        }
    }
}

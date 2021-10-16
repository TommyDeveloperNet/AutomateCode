using System;
using AutomateCode_Models.Tables;
using System.Collections.Generic;
using ConnBBDD;
using System.Linq;

namespace AutomateCode_Interface
{
    /// <summary>
    /// Clase interfaz con la tabla TBL_PROYECTOS
    /// </summary>
    public class Interface_Proyectos: Interface_Base
    {
        //--------------------------------------------------------------------
        #region Variables
        private string _Nombre;
        private string _Texto;
        private DateTime _FechaAlta;
        private string _Nombre_Proyecto;
        private string _Path;
        private bool _Modelo_Datos;
        private bool _Interfaces;
        private bool _Capa_Servicios;
        private int _Lenguaje_Servicio;
        private List<TBL_PROYECTOS> _ListProy;
        #endregion
        //--------------------------------------------------------------------

        //--------------------------------------------------------------------
        #region Propiedades
        public string Nombre { get => _Nombre; }
        public string Texto { get => _Texto; }
        public DateTime FechaAlta { get => _FechaAlta; }
        public string Nombre_Proyecto { get => _Nombre_Proyecto; }
        public string Path { get => _Path; }
        public bool Modelo_Datos { get => _Modelo_Datos; }
        public bool Interfaces { get => _Interfaces; }
        public bool Capa_Servicios { get => _Capa_Servicios; }
        public int Lenguaje_Servicio { get => _Lenguaje_Servicio; }
        public List<TBL_PROYECTOS> ListProy { get => _ListProy; }
        #endregion
        //--------------------------------------------------------------------

        //--------------------------------------------------------------------
        #region Constructores y destructores de la clase
        public Interface_Proyectos(string _ConnectionMode, string _BBDD, ConnectionBBDD.TypeConn _TypeConn) : base(_ConnectionMode, _BBDD, _TypeConn)
        {
            if (bConnOKtoBBDD)
            {
                _ListProy = objConection.Search<TBL_PROYECTOS>(typeof(TBL_PROYECTOS)).OrderBy(I => I.ID).ToList();
            }
            else
            {
                _ListProy = new List<TBL_PROYECTOS>();
            }
        }

        public Interface_Proyectos(string _ConnectionMode, string _BBDD, ConnectionBBDD.TypeConn _TypeConn, string _SqlCommand) : base(_ConnectionMode, _BBDD, _TypeConn)
        {
            if (bConnOKtoBBDD)
            {
                _ListProy = objConection.Search<TBL_PROYECTOS>(typeof(TBL_PROYECTOS), _SqlCommand).OrderBy(I => I.ID).ToList();
            }
            else
            {
                _ListProy = new List<TBL_PROYECTOS>();
            }
        }

        #endregion
        //--------------------------------------------------------------------

        //--------------------------------------------------------------------
        #region Acciones
        /// <summary>
        /// Crea un nuevo proyecto en la BBDD
        /// </summary>
        /// <param name="_NOMBRE"></param>
        /// <param name="_TEXTO"></param>
        /// <param name="_FECHALTA"></param>
        /// <param name="_NOMBRE_PROYECTO"></param>
        /// <param name="_PATH"></param>
        /// <param name="_MODELO_DATOS"></param>
        /// <param name="_INTERFACES"></param>
        /// <param name="_CAPA_SERVICIOS"></param>
        /// <param name="_LENGUAJE_SERVICIO"></param>
        /// <returns></returns>
        public bool Insert(string _NOMBRE, string _TEXTO, DateTime _FECHALTA, string _NOMBRE_PROYECTO, string _PATH, bool _MODELO_DATOS, bool _INTERFACES, bool _CAPA_SERVICIOS, int _LENGUAJE_SERVICIO)
        {
            return objConection.Insert<TBL_PROYECTOS>(typeof(TBL_PROYECTOS), TBL_PROYECTOS.Create(_NOMBRE, _TEXTO, _FECHALTA, _NOMBRE_PROYECTO, _PATH, _MODELO_DATOS, _INTERFACES, _CAPA_SERVICIOS, _LENGUAJE_SERVICIO));
        }

        /// <summary>
        /// Edita / modifica un proyecto en la BBDD
        /// </summary>
        /// <param name="_ID"></param>
        /// <param name="_NOMBRE"></param>
        /// <param name="_TEXTO"></param>
        /// <param name="_FECHALTA"></param>
        /// <param name="_NOMBRE_PROYECTO"></param>
        /// <param name="_PATH"></param>
        /// <param name="_MODELO_DATOS"></param>
        /// <param name="_INTERFACES"></param>
        /// <param name="_CAPA_SERVICIOS"></param>
        /// <param name="_LENGUAJE_SERVICIO"></param>
        /// <returns></returns>
        public bool Update(int _ID, string _NOMBRE, string _TEXTO, DateTime _FECHALTA, string _NOMBRE_PROYECTO, string _PATH, bool _MODELO_DATOS, bool _INTERFACES, bool _CAPA_SERVICIOS, int _LENGUAJE_SERVICIO)
        {
            return objConection.Update<TBL_PROYECTOS>(typeof(TBL_PROYECTOS), TBL_PROYECTOS.Create(_NOMBRE, _TEXTO, _FECHALTA, _NOMBRE_PROYECTO, _PATH, _MODELO_DATOS, _INTERFACES, _CAPA_SERVICIOS, _LENGUAJE_SERVICIO), _ID);
        }

        /// <summary>
        /// Elimina un proyecto de la BBDD
        /// </summary>
        /// <param name="_ID"></param>
        /// <returns></returns>
        public bool Delete(int _ID)
        {
            return objConection.Delete<TBL_PROYECTOS>(typeof(TBL_PROYECTOS), _ID);
        }
        #endregion
        //--------------------------------------------------------------------
    }
}

using System;
using ConnBBDD;

namespace AutomateCode_Interface
{
    /// <summary>
    /// Clase de la que heredan los objetos de conexión a usar en la aplicacion
    /// </summary>
    public class Interface_Base : IDisposable
    {
        //--------------------------------------------------------------------
        #region variables y constantes (privadas)
        bool disposed = false;
        const string modeConnACCESS = "ACCESS";
        const string modeConnODBC = "ODBC";
        #endregion
        //--------------------------------------------------------------------

        //----------------------------------------------------------------------
        #region Estructuras y tipos enumerados
        /// <summary>
        /// Indica si se va a trabajar / cargar con el contenido de una tabla o de una vista
        /// </summary>
        public enum TypeLoadInfo { type_Table = 0, type_View = 1 };
        #endregion
        //----------------------------------------------------------------------

        //----------------------------------------------------------------------
        #region Propiedades
        public string TypeConnection { get; set; } = "";
        #endregion
        //----------------------------------------------------------------------

        //--------------------------------------------------------------------
        #region variables y constantes (protected)
        /// <summary>
        /// Objeto de conexión a la base de datos
        /// </summary>
        protected ConnectionBBDD objConection;

        /// <summary>
        /// Indica si la conexión a BBDD se ha realizado ok (TRUE) o no (FALSE)
        /// </summary>
        protected bool bConnOKtoBBDD = false;
        #endregion
        //--------------------------------------------------------------------

        //----------------------------------------------------------------------
        #region Constructores y destructores Interface_Base
        /// <summary>
        /// 
        /// </summary>
        /// <param name="_ConnectionMode"></param>
        /// <param name="_sBBDD"></param>
        /// <param name="_TypeConn"></param>
        public Interface_Base(string _ConnectionMode, string _BBDD, ConnectionBBDD.TypeConn _TypeConn)
        {
            string ConnectionMode = _ConnectionMode.Trim();
            string BBDD = _BBDD.Trim();
            ConnectionBBDD.TypeConn TypeConn = _TypeConn;

            switch (ConnectionMode)
            {
                case modeConnACCESS:
                    BBDD = AppDomain.CurrentDomain.BaseDirectory + @"Data\" + BBDD;
                    TypeConn = ConnectionBBDD.TypeConn.type_Access;
                    break;
                case modeConnODBC:
                    TypeConn = ConnectionBBDD.TypeConn.type_ODBC;
                    break;
                default:
                    BBDD = AppDomain.CurrentDomain.BaseDirectory + @"Data\" + BBDD;
                    TypeConn = ConnectionBBDD.TypeConn.type_Access;
                    break;
            }

            objConection = new ConnectionBBDD(TypeConn, BBDD.Trim());
            bConnOKtoBBDD = objConection.Open();

            TypeConnection = "";
            if (bConnOKtoBBDD)
            {
                switch (objConection.tipoConnectionBD)
                {
                    case ConnectionBBDD.TypeConn.type_Access:
                        TypeConnection = modeConnACCESS;
                        break;
                    case ConnectionBBDD.TypeConn.type_XML:
                        TypeConnection = "XML";
                        break;
                    case ConnectionBBDD.TypeConn.type_ODBC:
                        TypeConnection = modeConnODBC;
                        break;
                }
            }
            else
            {
                TypeConnection = "ERROR! Conexión no establecida con ninguna BBDD";
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
                return;

            if (disposing)
            {
                //Objetos a liberar / eliminar
                objConection.Dispose();
            }

            disposed = true;
        }
        #endregion
        //--------------------------------------------------------------------
    }
}

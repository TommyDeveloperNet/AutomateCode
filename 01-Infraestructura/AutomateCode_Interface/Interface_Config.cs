using AutomateCode_Models.Tables;
using System.Collections.Generic;
using ConnBBDD;
using System.Linq;

namespace AutomateCode_Interface
{
    /// <summary>
    /// Clase interfaz con la tabla TBL_CONFIG
    /// </summary>
    public class Interface_Config: Interface_Base
    {
        //--------------------------------------------------------------------
        #region Variables
        private int _Form_Width;
        private int _Form_Height;
        private bool _Form_Maximized;
        private List<TBL_CONFIG> _ListConfig;
        #endregion
        //--------------------------------------------------------------------

        //--------------------------------------------------------------------
        #region propiedades
        public int Form_Widh { get => _Form_Width; }
        public int Form_Height { get => _Form_Height; }
        public bool Form_Maximized { get => _Form_Maximized; }
        public List<TBL_CONFIG> ListConfig { get => _ListConfig; }
        #endregion
        //--------------------------------------------------------------------

        //--------------------------------------------------------------------
        #region Constructores y destructores de la clase"
        public Interface_Config(string _ConnectionMode, string _BBDD, ConnectionBBDD.TypeConn _TypeConn) : base(_ConnectionMode, _BBDD, _TypeConn)
        {
            //Valores por defecto - 1) Configuración visual del formulario
            const int IDConfig_visual_form = 1;
            _Form_Maximized = false;
            _Form_Width = 1170;
            _Form_Height = 675;

            if (bConnOKtoBBDD)
            {
                _ListConfig = objConection.Search<TBL_CONFIG>(typeof(TBL_CONFIG)).OrderByDescending(i => i.ID).ToList();

                TBL_CONFIG objData = _ListConfig.Where(i => i.ID == IDConfig_visual_form).FirstOrDefault();

                if (objData != null)
                {
                    _Form_Maximized = objData.PANTALLA_COMPLETA;
                    _Form_Width = objData.WIDTH;
                    _Form_Height = objData.HEIGHT;
                }
            }
            else
            {
                _ListConfig = new List<TBL_CONFIG>();
            }
        }
        #endregion
        //--------------------------------------------------------------------

        //--------------------------------------------------------------------
        #region Acciones
        /// <summary>
        /// Actualiza un item de la configuración de la aplicación
        /// </summary>
        /// <param name="_ID"></param>
        /// <param name="_Width"></param>
        /// <param name="_Height"></param>
        /// <param name="_FullScreen"></param>
        /// <returns></returns>
        public bool Update(int _ID, int _Width, int _Height, bool _FullScreen)
        {
            bool _Result = false;

            TBL_CONFIG objData = ListConfig.Where(i => i.ID == _ID).SingleOrDefault();

            if (objData != null)
            {
                TBL_CONFIG objUpdate = TBL_CONFIG.Create(objData.DEFINICION, _Width, _Height, _FullScreen, _ID);
                if (objConection.Update<TBL_CONFIG>(typeof(TBL_CONFIG), objUpdate, objData.ID))
                {
                    _Result = true;
                }
            }

            return _Result;
        }
        #endregion
        //--------------------------------------------------------------------
    }
}

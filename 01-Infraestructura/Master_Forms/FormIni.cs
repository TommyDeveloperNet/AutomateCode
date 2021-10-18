using System.Windows.Forms;
using System.Threading;
using System.Globalization;

namespace Master_Forms
{
    /// <summary>
    /// Formulario primario del que heredan el resto de formularios
    /// </summary>
    public partial class FormIni : Form
    {
        public FormIni()
        {
            InitializeCulture();
        }

        //----------------------------------------------------------------------
        #region Propiedades
        public bool DebugModeApp { get; set; }
        #endregion
        //----------------------------------------------------------------------

        //----------------------------------------------------------------------
        #region Procedimientos y funciones (Protected)
        protected void OnLoad()
        {
            DebugModeApp = false;
#if DEBUG
            DebugModeApp = true;
#endif
        }

        /// <summary>
        /// Inicializa / establece el idioma de la aplicación
        /// </summary>
        protected void InitializeCulture()
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("es-ES");
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("es-ES");
        }
        #endregion
        //----------------------------------------------------------------------
    }
}

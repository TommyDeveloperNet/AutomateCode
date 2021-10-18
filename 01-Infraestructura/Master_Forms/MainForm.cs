using System;
using System.Drawing;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Globalization;

namespace Master_Forms
{
    public partial class MainForm : InitForm
    {
        public MainForm()
        {
            InitializeComponent();
            InitializeComponent_MainForm();
        }

        //--------------------------------------------------------------------
        #region Funcionalidades del formulario - Diseño visual
        private void InitializeComponent_MainForm()
        {
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            this.DoubleBuffered = true;
        }

        /*[DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);*/
        #endregion
        //--------------------------------------------------------------------

        //----------------------------------------------------------------------
        #region Propiedades a establecer en el hijo del form
        public string CultureAPP { get; set; }
        public string NameAPP { get; set; }
        public string IconAPP { get; set; }
        #endregion
        //----------------------------------------------------------------------

        //----------------------------------------------------------------------
        #region Variables y constantes al form
        /// <summary>
        /// Indica si se puede cerrar la aplicacíon con confirmacion (FALSE) o con confirmación (TRUE)
        /// </summary>
        protected bool CloseAppWithoutConfirm = false;
        #endregion
        //----------------------------------------------------------------------

        //----------------------------------------------------------------------
        #region PROTECTED - Eventos del formulario a invocar en los hijos
        private void MainForm_Load(object sender, EventArgs e)
        {
            OnLoad();

            this.Text = GetInfoApp();

            InitializeForm();

            InitializeToolTip();

            lEstado.Text = "";
            if (DebugModeApp)
            {
                lEstado.Text = "DEBUG MODE!";
            }
        }

        private void MainForm_Shown(object sender, EventArgs e)
        {
            if ((((InitForm)sender).Visible == true) && (!string.IsNullOrWhiteSpace(IconAPP)))
            {
                this.Icon = new System.Drawing.Icon(IconAPP);
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (CloseAppWithoutConfirm == false)
            {
                if (!ConfirmCloseApp())
                {
                    e.Cancel = true;
                }
            }

            GC.Collect();
        }
        #endregion
        //----------------------------------------------------------------------

        //----------------------------------------------------------------------
        #region Timer
        private void timer_Tick(object sender, EventArgs e)
        {
            DateTime localDate = DateTime.Now;
            var culture = new CultureInfo(CultureAPP);
            lInfoSystem.Text = string.Format("{0} - Fecha y hora: {1}", NameAPP, localDate.ToString(culture));
        }
        #endregion
        //----------------------------------------------------------------------

        //----------------------------------------------------------------------
        #region Procedimientos y funciones varios
        /// <summary>
        /// Devuelve el identificador único del control (que se corresponde con el name) - (SOBREESCRIBIR EN EL HIJO)
        /// </summary>
        /// <returns></returns>
        protected virtual string GetInfoApp()
        {
            return "";
        }

        /// <summary>
        /// Inicializa el formulario, estado de los controles, clases y demás para su funcionamiento - (SOBREESCRIBIR EN EL HIJO)
        /// </summary>
        protected virtual void InitializeForm()
        {

        }

        /// <summary>
        /// Inicializa y establece los tooltips en los controles del form - (SOBREESCRIBIR EN EL HIJO)
        /// </summary>
        protected virtual void InitializeToolTip()
        {

        }

        /// <summary>
        /// Indica si se ha cerrar la aplicación o no - (SOBREESCRIBIR EN EL HIJO)
        /// </summary>
        /// <returns></returns>
        protected virtual bool ConfirmCloseApp()
        {
            return true;
        }
        #endregion
        //----------------------------------------------------------------------
    }
}

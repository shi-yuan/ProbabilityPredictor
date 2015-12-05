using DevExpress.XtraEditors;
using System;
using System.Windows.Forms;

namespace ProbabilityPredictor
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            try
            {
                DevExpress.UserSkins.BonusSkins.Register();
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                if (!DevExpress.Skins.SkinManager.AllowFormSkins)
                {
                    DevExpress.Skins.SkinManager.EnableFormSkins();
                }
                DevExpress.LookAndFeel.UserLookAndFeel.Default.SetSkinStyle("Office 2010 Blue");
                Application.Run(new MainForm(new J48Predictor()));
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex + "", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

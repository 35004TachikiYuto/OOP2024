using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarReportSystem {
    public partial class fmVersion : Form {
        public fmVersion() {
            InitializeComponent();
        }

        private void btVersionOk_Click(object sender, EventArgs e) {
            Close();
        }

        private void fmVersion_Load(object sender, EventArgs e) {
            FileVersionInfo fileVersionInfo = FileVersionInfo.GetVersionInfo(Assembly.GetExecutingAssembly().Location);
            var asm = Assembly.GetExecutingAssembly();
            var ver = asm.GetName().Version;
            lbVersion.Text = "Ver." + ver.ToString();
            

            var cr = fileVersionInfo.LegalCopyright;
            lbCopyRight.Text = "copyright(c)" + cr.ToString();

            var cn = fileVersionInfo.CompanyName;
            lbAuthor.Text = cn.ToString();
        }
    }
}

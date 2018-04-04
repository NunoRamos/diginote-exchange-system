using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace diginote_exchange_system
{
    public partial class SystemForm : MaterialForm
    {
        private readonly FormManager formManager;

        public SystemForm(FormManager formManager)
        {
            this.formManager = formManager;
            InitializeComponent();
        }

        private void signOutButton_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}

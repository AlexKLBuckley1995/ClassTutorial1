using System;
using System.Windows.Forms;

namespace Version_1_C
{
    [Serializable()] 
    public class clsSculpture : clsWork
    {
        private float _Weight;
        private string _Material;

        [NonSerialized()]
        private static frmSculpture sculptureDialog;

        public float Weight
        {
            get
            {
                return _Weight;
            }

            set
            {
                _Weight = value;
            }
        }

        public string Material
        {
            get
            {
                return _Material;
            }

            set
            {
                _Material = value;
            }
        }

        public static frmSculpture SculptureDialog
        {
            get
            {
                return sculptureDialog;
            }

            set
            {
                sculptureDialog = value;
            }
        }

        public override void editDetails()
        {
            if (SculptureDialog == null)
                SculptureDialog = new frmSculpture();
            SculptureDialog.SetDetails(this);
        }
    }
}

using System;
using System.Windows.Forms;

namespace Version_1_C
{
    [Serializable()] 
    public class clsPainting : clsWork
    {
        private float _Width;
        private float _Height;
        private string _Type;

        [NonSerialized()]
        private static frmPainting paintDialog;

        public float Width
        {
            get
            {
                return _Width;
            }

            set
            {
                _Width = value;
            }
        }

        public float Height
        {
            get
            {
                return _Height;
            }

            set
            {
                _Height = value;
            }
        }

        public string Type
        {
            get
            {
                return _Type;
            }

            set
            {
                _Type = value;
            }
        }

        public static frmPainting PaintDialog
        {
            get
            {
                return paintDialog;
            }

            set
            {
                paintDialog = value;
            }
        }

        public override void editDetails()
        {
            if (PaintDialog == null)
                PaintDialog = new frmPainting();
            PaintDialog.SetDetails(this);
        }
    }
}

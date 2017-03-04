using System;
using System.Windows.Forms;

namespace Version_1_C
{
    [Serializable()]
    public class clsPhotograph : clsWork
    {
        private float _Width;
        private float _Height;
        private string _Type;

        [NonSerialized()]
        private static frmPhotograph photoDialog;

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

        public static frmPhotograph PhotoDialog
        {
            get
            {
                return photoDialog;
            }

            set
            {
                photoDialog = value;
            }
        }

        public override void editDetails()
        {
            if (PhotoDialog == null)
                PhotoDialog = new frmPhotograph();
            PhotoDialog.SetDetails(this);
       }
    }
}

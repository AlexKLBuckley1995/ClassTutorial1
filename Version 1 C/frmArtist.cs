using System;
//using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Version_1_C
{
    public partial class frmArtist : Form
    {
        public frmArtist()
        {
            InitializeComponent();
        }

        private clsWorksList _WorksList;
        private byte _SortOrder; // 0 = Name, 1 = Date
        private clsArtist _Artist;

        private void updateDisplay()
        {
            txtName.Enabled = txtName.Text == "";
            if (_SortOrder == 0)
            {
                _WorksList.SortByName();
                rbByName.Checked = true;
            }
            else
            {
                _WorksList.SortByDate();
                rbByDate.Checked = true;
            }

            lstWorks.DataSource = null;
            lstWorks.DataSource = _WorksList;
            lblTotal.Text = Convert.ToString(_WorksList.GetTotalValue());
        }

        private void updateForm()
        {
            txtName.Text = _Artist.Name;
            txtSpeciality.Text = _Artist.Speciality;
            txtPhone.Text = _Artist.Phone;
            _WorksList = _Artist.WorksList;
        }

        private void pushData()
        {
            _Artist.Name = txtName.Text;
            _Artist.Speciality = txtSpeciality.Text;
            _Artist.Phone = txtPhone.Text;
        }

        public void SetDetails(clsArtist prArtist)
        {
            _Artist = prArtist;
            updateForm();
            updateDisplay();
            ShowDialog();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (lstWorks.SelectedIndex >= 0 && lstWorks.SelectedIndex < _WorksList.Count)
            {
                if (MessageBox.Show("Are you sure?", "Deleting work", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    _WorksList.RemoveAt(lstWorks.SelectedIndex);
                }
            }
            updateDisplay();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            char lcReply;
            InputBox inputBox = new InputBox("Enter P for Painting, S for Sculpture and H for Photograph");
            //inputBox.ShowDialog();
            //if (inputBox.getAction() == true)
            if (inputBox.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                lcReply = Convert.ToChar(inputBox.getAnswer());
                _WorksList.AddWork(lcReply);
                updateDisplay();
            }
            else
            {
                inputBox.Close();
            }
}

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (isValid())
            {
                pushData();
                DialogResult = DialogResult.OK;
            }
        }

        public virtual Boolean isValid()
        {
            if (txtName.Enabled && txtName.Text != "")
                if (_Artist.IsDuplicate(txtName.Text))
                {
                    MessageBox.Show("Artist with that name already exists!");
                    return false;
                }
                else
                    return true;
            else
                return true;
        }

        private void lstWorks_DoubleClick(object sender, EventArgs e)
        {
            int lcIndex = lstWorks.SelectedIndex;
            if (lcIndex >= 0 && lcIndex < _WorksList.Count)
            {
                _WorksList.EditWork(lcIndex);
            
            }
            else
            {
                MessageBox.Show("Sorry no work selected #" + Convert.ToString(lcIndex));
            }
            updateDisplay();
        }

        private void rbByDate_CheckedChanged(object sender, EventArgs e)
        {
            _SortOrder = Convert.ToByte(rbByDate.Checked);
            updateDisplay();
        }

    }
}
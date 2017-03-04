using System;

namespace Version_1_C
{
    [Serializable()] 
    public class clsArtist
    {
        private string _Name;
        private string _Speciality;
        private string _Phone;
        
        private decimal _TotalValue;

        private clsWorksList _WorksList;
        private clsArtistList _ArtistList;
        
        private static frmArtist artistDialog = new frmArtist();

        public string Name
        {
            get
            {
                return _Name;
            }

            set
            {
                _Name = value;
            }
        }

        public string Speciality
        {
            get
            {
                return _Speciality;
            }

            set
            {
                _Speciality = value;
            }
        }

        public string Phone
        {
            get
            {
                return _Phone;
            }

            set
            {
                _Phone = value;
            }
        }

        public decimal TotalValue
        {
            get
            {
                return _TotalValue;
            }

          //  set
            //{
              //  _TotalValue = value;
           // }
        }

        public clsWorksList WorksList
        {
            get
            {
                return _WorksList;
            }

           // set
           // {
             //   _WorksList = value;
           // }
        }

        public clsArtistList ArtistList
        {
            get
            {
                return _ArtistList;
            }

            //set
            //{
              //  _ArtistList = value;
            //}
        }

        public clsArtist(clsArtistList prArtistList)
        {
            _WorksList = new clsWorksList();
            _ArtistList = prArtistList;
            EditDetails();
        }
        
        public void EditDetails()
        {
            artistDialog.SetDetails(this);
            if (artistDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                _TotalValue = WorksList.GetTotalValue();
            }
        }

        public bool IsDuplicate(string prArtistName)
        {
            return _ArtistList.ContainsKey(prArtistName);
        }

       // public string GetKey()
       // {
         //   return Name;
      //  }

        //public decimal GetWorksValue()
       // {
         //   return TotalValue;
       /// }
    }
}

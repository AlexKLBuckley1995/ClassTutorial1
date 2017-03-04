using System;
using System.Collections.Generic;
using System.Windows.Forms;


namespace Version_1_C
{
    [Serializable()] 
    public class clsArtistList : SortedList<string, clsArtist>
    {
        private const string _FileName = "gallery.xml";
        public void EditArtist(string prKey)
        {
            clsArtist lcArtist;
            lcArtist = this[prKey];
            if (lcArtist != null)
                lcArtist.EditDetails();
            else
                MessageBox.Show("Sorry no artist by this name");
        }
       
        public void NewArtist()
        {
            clsArtist lcArtist = new clsArtist(this);
            try
            {
                if (lcArtist.Name != "")
                {
                    Add(lcArtist.Name, lcArtist);
                    MessageBox.Show("Artist added!");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Duplicate Key!");
            }
        }
        
        public decimal GetTotalValue()
        {
            decimal lcTotal = 0;
            foreach (clsArtist lcArtist in Values)
            {
                lcTotal += lcArtist.TotalValue;
            }
            return lcTotal;
        }

        public void Save()
        {
            try
            {
                System.IO.FileStream lcFileStream = new System.IO.FileStream(_FileName, System.IO.FileMode.Create);
                System.Runtime.Serialization.Formatters.Binary.BinaryFormatter lcFormatter =
                    new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();

                lcFormatter.Serialize(lcFileStream, this);
                lcFileStream.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "File Save Error");
            }
        }

        public clsArtistList Retrieve()
        {
            clsArtistList lcArtistList;

            try
            {
                System.IO.FileStream lcFileStream = new System.IO.FileStream(_FileName, System.IO.FileMode.Open);
                System.Runtime.Serialization.Formatters.Binary.BinaryFormatter lcFormatter =
                    new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();

                lcArtistList = (clsArtistList)lcFormatter.Deserialize(lcFileStream); //Not sure if it should be lcArtistList here 
                lcFileStream.Close();
            }

            catch (Exception e)
            {
                lcArtistList = new Version_1_C.clsArtistList();
                MessageBox.Show(e.Message, "File Retrieve Error");
            }
            return lcArtistList;
        }
    }
}

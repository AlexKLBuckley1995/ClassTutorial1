using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Version_1_C
{
    [Serializable()] 
    public class clsWorksList : List<clsWork>
    {
        private static clsNameComparer _NameComparer = new clsNameComparer();
        private static clsDateComparer _DateComparer = new clsDateComparer();
        private byte _SortOrder;

        public byte SortOrder
        {
            get
            {
                return _SortOrder;
            }

            set
            {
                _SortOrder = value;
            }
        }

        public void AddWork(char prReply)
        {
            clsWork lcWork = clsWork.NewWork(prReply);
            if (lcWork != null)
            {
                Add(lcWork);
            }
        }
       
        public void DeleteWork(int prIndex)
        {
                this.RemoveAt(prIndex);
        }
        
        public void EditWork(int prIndex)
        {
                clsWork lcWork = (clsWork)this[prIndex];
                lcWork.editDetails();
        }

        public decimal GetTotalValue()
        {
            decimal lcTotal = 0;
            foreach (clsWork lcWork in this)
            {
                lcTotal += lcWork.Value;
            }
            return lcTotal;
        }

         public void SortByName()
         {
             Sort(_NameComparer);
         }
    
        public void SortByDate()
        {
            Sort(_DateComparer);
        }
    }
}

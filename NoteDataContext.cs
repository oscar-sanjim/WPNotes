using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPNotes.ViewModels;

namespace WPNotes
{
    public class NoteDataContext : DataContext
    {
        public Table<NoteModel> WPNotes;

        private NoteDataContext(string connectingString) : base(connectingString) {

        }

        static NoteDataContext dataContext = null;

        public static NoteDataContext Current {

            get {
                if (dataContext == null)
                {
                    dataContext = new NoteDataContext("isostore:/notemodel.sdf");

                    if (!dataContext.DatabaseExists()) {
                        dataContext.CreateDatabase();
                    }
                }

                return dataContext;
            }
        }
    }
}

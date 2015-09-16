using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPNotes.ViewModels;

namespace WPNotes
{
    public class Lista
    {
        ObservableCollection<NoteModel> notes = null;

        public ObservableCollection<NoteModel> WPNotes{
            get {
                if (notes == null) {
                    notes = new ObservableCollection<NoteModel>();
                    notes.Add(new NoteModel() { });
                    Cargar();
                }
                return notes;
            }

            set {
                notes = value;
            }
        }

        public void Cargar() {
            var query = from notes in NoteDataContext.Current.WPNotes orderby notes.Id select notes;
            WPNotes = new ObservableCollection<NoteModel>(query.ToList());                         
        }

        public void Agregar(NoteModel note) {
            var query = (from notes in NoteDataContext.Current.WPNotes
                         where notes.Id == note.Id
                         select notes).FirstOrDefault();

            NoteModel nt = new NoteModel();
            nt = query;

            if (nt == null) {
                this.WPNotes.Add(note);

                NoteDataContext.Current.WPNotes.InsertOnSubmit(note);
                NoteDataContext.Current.SubmitChanges();
            }
        }
    }
}

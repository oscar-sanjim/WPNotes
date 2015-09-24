using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPNotes.ViewModels;

namespace WPNotes
{
    public class DBController
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
            var query = from notes in NoteDataContext.Current.WPNotes orderby notes.Date select notes;
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
            else
            {
                NoteDataContext.Current.WPNotes.DeleteOnSubmit(nt);
                NoteDataContext.Current.SubmitChanges();
                NoteDataContext.Current.WPNotes.InsertOnSubmit(note);
                NoteDataContext.Current.SubmitChanges();
            }
        }

        public List<NoteModel> GetCategoryNotes(string category)
        {
            var query = from notes in NoteDataContext.Current.WPNotes orderby notes.Date where notes.Category == category select notes;
            return query.ToList();
        }

        public List<NoteModel> GetFeaturedNotes()
        {
            var query = from notes in NoteDataContext.Current.WPNotes orderby notes.Date where notes.Featured == true select notes;
            return query.ToList();
        }

        public NoteModel GetNoteInfo(string id)
        {
            var query = from notes in NoteDataContext.Current.WPNotes orderby notes.Date where notes.Id == id select notes;
            return query.Single();
        }

        public void DeleteNote(string id)
        {
            var query = from notes in NoteDataContext.Current.WPNotes where notes.Id == id select notes;
            NoteDataContext.Current.WPNotes.DeleteOnSubmit(query.Single());
            NoteDataContext.Current.SubmitChanges();
        }
    }
}

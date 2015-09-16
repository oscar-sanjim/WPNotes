using System;
using System.ComponentModel;
using System.Data.Linq.Mapping;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPNotes.ViewModels
{
    [Table]
    public class NoteModel : INotifyPropertyChanged
    {

        
        /*
            Attributes
        */
        private string id, title, category, body, preview;
        private DateTime date;
        private Boolean featured;

        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged(string propertyname) {
            if (PropertyChanged != null) {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyname));
            }
        }

        [Column(IsPrimaryKey =true)]
        public String Id {
            get { return id;  }
            set { id = value; }
        }

        [Column]
        public String Title
        {
            get { return title; }
            set { title = value; }
        }

        [Column]
        public String Body
        {
            get { return body; }
            set { body = value; }
        }

        [Column]
        public String Category
        {
            get { return category; }
            set { category = value; }
        }

        [Column]
        public String Preview
        {
            get { return preview; }
            set { preview = value; }
        }

        [Column]
        public DateTime Date
        {
            get { return date; }
            set { date = value; }
        }

        [Column]
        public Boolean Featured
        {
            get { return featured; }
            set { featured = value; }
        }

        /*To create a new note*/
        public NoteModel(string title, string category, string body, DateTime date, Boolean featured) {
            this.id = Guid.NewGuid().ToString("N");
            this.title = title;
            this.category = category;
            this.body = body;
            this.date = date;
            this.featured = featured;
            if (body.Length > 40)
                this.preview = body.Substring(0, 36) + "...";
            else {
                this.preview = body;
            }
        }

        /*To create the node when filling the list*/
        public NoteModel(string id, string title, string category, string body, DateTime date, Boolean featured)
        {
            this.id = id;
            this.title = title;
            this.category = category;
            this.body = body;
            this.date = date;
            this.featured = featured;
            if (body.Length > 40)
                this.preview = body.Substring(0, 36) + "...";
            else
            {
                this.preview = body;
            }
        }

        public NoteModel() {

        }

        
    }
}

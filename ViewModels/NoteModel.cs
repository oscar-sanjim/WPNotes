using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPNotes.ViewModels
{
    class NoteModel
    {
        /*
            Attributes
        */
        private string id, title, category, body, preview;
        private DateTime date;
        private Boolean featured;

        public String Id {
            get { return id;  }
            set { id = value; }
        }

        public String Title
        {
            get { return title; }
            set { title = value; }
        }

        public String Body
        {
            get { return body; }
            set { body = value; }
        }

        public String Category
        {
            get { return category; }
            set { category = value; }
        }

        public String Preview
        {
            get { return preview; }
            set { preview = value; }
        }

        public DateTime Date
        {
            get { return date; }
            set { date = value; }
        }

        public Boolean Featured
        {
            get { return featured; }
            set { featured = value; }
        }

        public NoteModel(string title, string category, string body, DateTime date, Boolean featured) {
            //Missing id
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

        public NoteModel() {

        }
    }
}

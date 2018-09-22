using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace helloworld.Models
{
     public class NoteFunctions : IRepo {

        efmodel database = null;

        public NoteFunctions(efmodel  obj)
        {
            this.database=obj;
        }


        public List<Notes> GetAllNotes(){
            using (database){
                return database.notes.Include(n=>n.checklist).Include(n=>n.label).ToList();
            }
        
        }
            
        public Notes GetNotesById(int id){
            using (database){
                return database.notes.Include(n=>n.checklist).Include(n=>n.label).FirstOrDefault(n => n.id == id);
            }
        }


        public List<Notes> GetNotesByLabelortitle(string label,string type){
            using(database)
            {
                // IEnumerable<Notes> get= new List<Notes>();
                if(type=="title"){
                var getbytitle= database.notes.Include(n=>n.checklist).Include(n=>n.label).Where(n => n.title==label);
                return getbytitle.ToList();
            }
                else if(type=="label"){
                    var getbylabel= database.notes.Include(n=>n.checklist).Include(n=>n.label).Where(n => n.label.text==label);
                return getbylabel.ToList();
                }
                return null;

            }

        }
        public IEnumerable<Notes> GetNotesByPinned(bool pinned){
            using(database)
            {
                var getbypinned=database.notes.Include(n=>n.checklist).Include(n=>n.label).Where(n=> n.pinned==pinned);
                return getbypinned.ToList();
            }
        }

        public bool PostNotes(Notes notes){
            using (database)
            {
                if(database.notes.FirstOrDefault(n => n.id == notes.id) == null){
                    foreach(var check in notes.checklist)
                     {
                        database.checklist.Add(check);
                    }
                    
                    database.labels.Add(notes.label);
                    database.notes.Add(notes);
                    
                    database.SaveChanges();
                    return true;
                }
                else{
                    return false;
                }
            }
        }

        public bool PutNotes(int id, Notes notes){
            using (database){
                Notes putnotes = database.notes.FirstOrDefault(n => n.id == id);
                if(putnotes != null){
                  //  notes.id=id;
                //    putnotes.id=id;
                    //putnotes=notes;
                    database.notes.Remove(putnotes);
                    database.notes.Add(notes);
                    database.SaveChanges();
                    return true;
                }
                else{
                    return false;
                }
            }
        }

        public bool DeleteNotes(int id){
            using (database){
             var  deletenotes = database.notes.FirstOrDefault(n => n.id == id);

                if(deletenotes != null){
                    database.Remove(deletenotes);
                    database.SaveChanges();
                    return true;
                }
                else{
                    return false;
                }
            }
        }


    }
}


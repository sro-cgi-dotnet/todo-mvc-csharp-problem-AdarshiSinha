using System.Collections.Generic;

namespace helloworld.Models
{
    public interface IRepo
    {
        List<Notes> GetAllNotes();
        Notes GetNotesById(int id);

        List<Notes> GetNotesByLabelortitle(string label,string type);

        IEnumerable<Notes> GetNotesByPinned(bool pinned);

        bool PostNotes(Notes notes);

        bool PutNotes(int id, Notes notes);

        bool DeleteNotes(int id);
    }

}
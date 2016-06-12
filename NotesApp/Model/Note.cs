using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace NotesApp.Model{
[DataContract]
public class Note
{
    [DataMember]
    public Guid Id { get; set; }
    [DataMember]
    public DateTime DateCreated { get; set; }
    [DataMember]
    public DateTime DateModified { get; set; }
    [DataMember]
    public string Title { get; set; }
    [DataMember]
    public string Text { get; set; }
}
}
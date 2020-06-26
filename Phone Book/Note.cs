using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Runtime.Serialization;

namespace Phone_Book
{
    [Serializable]
    [DataContract]
    public class Note
    {
        [DataMember]
        public string LastName;
        [DataMember]
        public string Name;
        [DataMember]
        public string Patronymic;
        [DataMember]
        public string Street;
        [DataMember]
        public ushort House;
        [DataMember]
        public ushort Flat;
        [DataMember]
        public string Phone;

        public override bool Equals(object obj)
        {
            Note note = (Note)obj;
            return (this.Name == note.Name)&&
                    (this.Patronymic == note.Patronymic)&&
                    (this.Flat == note.Flat)&&
                    (this.Street== note.Street)&&
                    (this.LastName== note.LastName)&&
                    (this.Phone == note.Phone);
        }
    }
}


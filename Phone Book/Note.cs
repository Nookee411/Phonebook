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
    }
}


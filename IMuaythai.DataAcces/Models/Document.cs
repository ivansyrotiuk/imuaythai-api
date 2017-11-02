using System;
using System.Collections.Generic;

namespace IMuaythai.DataAccess.Models
{
    public class Document
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public DateTime ExpirationDate { get; set; }
        public string Number { get; set; }
        public int Type { get; set; }

        public ICollection<UserDocumentsMapping> UserDocumentsMappings { get; set; }
        public ICollection<InstitutionDocumentsMapping> InstitutionDocumentsMappings { get; set; }
        public ICollection<ContestDocumentsMapping> ContestDocumentsMappings { get; set; }
    }
}
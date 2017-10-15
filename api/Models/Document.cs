using System;

namespace MuaythaiSportManagementSystemApi.Models
{
    public class Document
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public DateTime ExpirationDate { get; set; }
        public string Number { get; set; }
        public int Type { get; set; }

        public UserDocumentsMapping[] UserDocumentsMappings { get; set; }
        public InstitutionDocumentsMapping[] InstitutionDocumentsMappings { get; set; }
        public ContestDocumentsMapping[] ContestDocumentsMappings { get; set; }
    }
}
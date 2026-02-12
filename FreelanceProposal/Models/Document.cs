using System;

namespace FreelanceProposal.Models
{
    public class Document
    {
        public Guid Id { get; set; }
        public string UserId { get; set; } // Para identificar al usuario (Identity)

        public string ClientName { get; set; }
        public string ProjectTitle { get; set; }
        public string BusinessDescription { get; set; }
        public string Goals { get; set; }

        public string ScopeJson { get; set; } // Para guardar checkbox de servicios seleccionados

        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        public decimal TotalPrice { get; set; }
        public int DepositPercentage { get; set; }

        public DateTime CreatedAt { get; set; } // Fecha de creación
    }
}


using FreelanceProposal.Models;
using QuestPDF.Fluent;
using QuestPDF.Infrastructure;
using System.IO;

namespace FreelanceProposal.Services
{
    public static class PDFService
    {
        public static byte[] GeneratePdf(FreelanceProposal.Models.Document model)
        {
            using var stream = new MemoryStream();

            QuestPDF.Fluent.Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.Margin(20);
                    page.Content().Column(col =>
                    {
                        col.Item().Text($"Proposal for {model.ClientName}").FontSize(20).Bold();
                        col.Item().Text($"Project: {model.ProjectTitle}");
                        col.Item().Text($"Total: ${model.TotalPrice}");
                        col.Item().Text($"Scope: {model.ScopeJson}");
                        col.Item().Text($"Goals: {model.Goals}");
                        col.Item().Text($"Business Description: {model.BusinessDescription}");
                    });
                });
            }).GeneratePdf(stream);

            return stream.ToArray();
        }
    }
}

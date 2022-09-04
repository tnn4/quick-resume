using QuestPDF.Drawing;
using QuestPDF.Infrastructure;
using QuestPDF.Helpers;
using QuestPDF.Fluent;
using IContainer = QuestPDF.Infrastructure.IContainer;
using IComponent = QuestPDF.Infrastructure.IComponent;

using System.ComponentModel;

using qpdf.Resume;

namespace pdf_test1;

internal class Resume_Template
{
}

public partial class ResumeDoc : IDocument
{
    public ResumeModel Model { get; }

    // CONSTRUCTOR
    public ResumeDoc(ResumeModel model)
    {
        Model = model;
    }

    public DocumentMetadata GetMetadata() => DocumentMetadata.Default;
    
    public void Compose(IDocumentContainer container)
    {
        compose_resume_example(container);
    }
}

public partial class ResumeDoc : IDocument
{
    public void compose_resume_example(IDocumentContainer container)
    {
        container
            .Page(page =>
            {
                page.Margin(20);
                // page.Header().Element(compose_contact);
                // page.Content().Element(compose_content_example);

            });
    }


    #region component_functions

    public void CreateColumn(ColumnDescriptor column, IComponent component)
    {
        column.Item().Row(row =>
        {
            row.RelativeItem().Component(component);
        });
    }
}
    #endregion
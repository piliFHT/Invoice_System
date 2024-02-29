using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using QuestPDF.Previewer;

namespace Invoice_System;

public partial class MainPage : ContentPage
{


    public MainPage()
    {
        InitializeComponent();
        
    }

    private void BTN_Clicked_1(object sender, EventArgs e)
    {
        QuestPDF.Settings.License = LicenseType.Community;

        Document.Create(container =>
        {
            container.Page(page =>
            {
                page.Size(PageSizes.A4);
                page.Margin(2, Unit.Centimetre);
                page.PageColor("#fff");
                page.DefaultTextStyle(x => x.FontSize(20));

                page.Header()
                    .Text("Bum Prdel!")
                    .SemiBold().FontSize(36).FontColor("#0f0");

                page.Content()
                    .PaddingVertical(1, Unit.Centimetre)
                         .Column(column =>
                         {
                             column.Spacing(10);

                             // Invoice details
                             column.Item().Text($"Name: {Input1.Text}");
                             column.Item().Text($"Surname: {Input2.Text}");
                             column.Item().Text($"Address: {Input3.Text}");
                             column.Item().Text($"City: {Input4.Text}");
                             column.Item().Text($"ZIP Code: {Input5.Text}");
                             column.Item().Text($"Country: {Input6.Text}");
                             column.Item().Text($"ICO: {Input7.Text}");
                             column.Item().Text($"DIC: {Input8.Text}");

                         });



                             page.Footer()
                    .AlignCenter()
                    .Text(x =>
                    {
                        x.Span("Page ");
                        x.CurrentPageNumber();
                    });
            });
        }).GeneratePdf("C:\\Users\\21ic25_hanout\\Downloads\\hello.pdf");
    }

}
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
                    .Column(x =>
                    {
                        x.Spacing(20);

                        x.Item().Text(Input1.Text);
                        x.Item().Text(Input2.Text);
                        x.Item().Text(Input3.Text);
                        x.Item().Text(Input4.Text);
                        x.Item().Text(Input5.Text);
                        x.Item().Text(Input6.Text);
                        x.Item().Text(Input7.Text);
                        x.Item().Text(Input8.Text);
                        x.Item().Image(Placeholders.Image(200, 100));
                    });

                page.Footer()
                    .AlignCenter()
                    .Text(x =>
                    {
                        x.Span("Page ");
                        x.CurrentPageNumber();
                    });
            });
        }).GeneratePdf("C:\\Users\\21ic25_hanout\\Downloads\\nebr/hello.pdf");
    }

}
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using QuestPDF.Previewer;
using System.Diagnostics;
using System.Data.SQLite;

namespace Invoice_System;

public partial class MainPage : ContentPage
{
    const string databaseFileName = "C:\\Temp/InvoiceData.db";
    const string tableName = "Users";
    const string connectionString = $"Data Source={databaseFileName};Version=3;";


    public MainPage()
    {
        InitializeComponent();
        InitializeDatabase();
        
    }

    private void InitializeDatabase()
    {
        using (SQLiteConnection connection = new SQLiteConnection(connectionString))
        {
            connection.Open();
            SQLiteCommand command = new SQLiteCommand($"CREATE TABLE IF NOT EXISTS {tableName} (Id INTEGER PRIMARY KEY, Name VARCHAR(30), Surname VARCHAR(30), Address VARCHAR(30), City VARCHAR(30), Zip INTEGER, Country TEXT, CIN INTEGER, VAT_ID INTEGER",connection);
            command.ExecuteNonQuery();
        }
    }

    private void InsertData(int id, string name, string surname, string address, string city, int zip, string country, int cin, int vat_id)
    {
        using (SQLiteConnection connection = new SQLiteConnection(connectionString))
        {
            connection.Open();
            SQLiteCommand command = new SQLiteCommand($"INSERT INTO {tableName} * VALUES ('{id}', '{name}', '{surname}', '{address}', '{city}', '{zip}', '{country}' '{cin}', '{vat_id}", connection);
            command.ExecuteNonQuery();
        }
    }

    //private List<string> GetData()
    //{
    //    List<string> data = new List<string>();

    //    using(SQLiteConnection connection = new SQLiteConnection(connectionString))
    //    {
    //        connection.Open();
    //        SQLiteCommand command = new SQLiteCommand($"SELECT * FROM {tableName}", connection);
    //        using (SQLiteDataReader reader = command.ExecuteReader())
    //        {
    //            while(reader.Read())
    //            {
    //                data.Add(reader.GetString(0));
    //            }
    //        }
    //    }
    //}




    private async void BTN_Clicked_1(object sender, EventArgs e)
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
                    .Text("Faktura")
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
                             column.Item().Text($"DIC: CZ{Input8.Text}");

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

        await DisplayAlert("Úspěch", "Dokument úspěně generován!", "Potvrzuji");
    }

}
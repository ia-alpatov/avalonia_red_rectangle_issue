using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using Avalonia.Data;
using Avalonia.Input;
using Avalonia.Layout;
using Avalonia.Markup.Xaml;
using Avalonia.Media;

namespace DataGridScroll
{
    public class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
#if DEBUG
            this.AttachDevTools();
#endif

            this.Get<Button>("Open_Button").Click += (s, e) =>
            {
                
                var popup = new Popup();
                popup.PlacementTarget = this;
                popup.Topmost = true;
                popup.StaysOpen = true;
                popup.PlacementMode = PlacementMode.AnchorAndGravity;

                var main_grid = this.Get<Grid>("Main_Grid");

                popup.Width = main_grid.Bounds.Width;
                popup.Height = main_grid.Bounds.Height;
                
                
                
                 var popupGrid = new Grid();
                popupGrid.Background = new SolidColorBrush(Colors.White);


                var popupInnerGrid = new Grid();
                popupInnerGrid.Background = new SolidColorBrush(Colors.Transparent);
                popupInnerGrid.Margin = new Thickness(24);
                popupInnerGrid.RowDefinitions.Add(new RowDefinition(48, GridUnitType.Pixel));
                popupInnerGrid.RowDefinitions.Add(new RowDefinition(1, GridUnitType.Star));
                popupInnerGrid.RowDefinitions.Add(new RowDefinition(48, GridUnitType.Pixel));


                var popupTitle = new TextBlock
                {
                    Foreground = new SolidColorBrush(Colors.Black), FontWeight = FontWeight.Bold, FontSize = 18,
                    HorizontalAlignment = HorizontalAlignment.Left, VerticalAlignment = VerticalAlignment.Center
                };
                popupTitle.Text = "Popup";
                Grid.SetRow(popupTitle, 0);
                popupInnerGrid.Children.Add(popupTitle);

                var popupTable = new DataGrid
                {
                    AutoGenerateColumns = true, FontSize = 14, RowHeight = 40,
                    AlternatingRowBackground = new SolidColorBrush(Colors.Transparent),
                    RowBackground = new SolidColorBrush(Colors.Transparent),
                    Background = new SolidColorBrush(Colors.Transparent), BorderThickness = new Thickness(0),
                    BorderBrush = new SolidColorBrush(Colors.Transparent), Margin = new Thickness(-6, -16, -6, 0)
                };

                List<ExampleRow> rows = new List<ExampleRow>();
                for (int i = 0; i < 100; i++)
                {
                    rows.Add(new ExampleRow() { } );
                }


                popupTable.Items = rows;
               
              
                
                
                Grid.SetRow(popupTable, 1);
                popupInnerGrid.Children.Add(popupTable);


                var popupSaveButton = new Button
                {
                    HorizontalContentAlignment = HorizontalAlignment.Left, BorderThickness = new Thickness(2),
                    Background = new SolidColorBrush(Colors.Transparent),
                    BorderBrush = new SolidColorBrush(Color.Parse("#00B2A5")),
                    Foreground = new SolidColorBrush(Color.Parse("#545454")),
                    HorizontalAlignment = HorizontalAlignment.Stretch, VerticalAlignment = VerticalAlignment.Stretch
                };
                popupSaveButton.Content = "SAVE";
                popupSaveButton.Click += (r, m) =>
                {
                   
                    popup.Close();
                };
                Grid.SetRow(popupSaveButton, 2);
                popupInnerGrid.Children.Add(popupSaveButton);


                popupGrid.Children.Add(popupInnerGrid);


                popup.Child = popupGrid;
                main_grid.Children.Add(popup);
                popup.Open();
            };
        }
        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
        private static Random random = new Random();
        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }
   
}

    public class ExampleRow
    {
        public string Field1 => MainWindow.RandomString(10);
        public string Field2  => MainWindow.RandomString(14);
        public string Field3  => MainWindow.RandomString(14);
        public string Field4  => MainWindow.RandomString(12);
        public string Field5  => MainWindow.RandomString(11);
        
        public bool Field6 { get; set; }
    }
    
   
}

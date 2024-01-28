using Microsoft.Maui.Controls.Shapes;
using System.Collections.ObjectModel;
using System.Data;
using System.Diagnostics;
using System.Globalization;

namespace CollectionViewTest2
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();

            Device.StartTimer(TimeSpan.FromMilliseconds(500), () =>
            {
                if (animationstopped)
                    return false;

                if (scaled)
                    lbl_indicator.ScaleTo(1F, 500);
                else
                    lbl_indicator.ScaleTo(0.7F, 500);
                scaled = !scaled;
                return true;
            });


        }

        protected override void OnDisappearing()
        {
            animationstopped = true;
            base.OnDisappearing();
        }

        bool scaled = false;
        bool animationstopped = false;

        public class ROW
        {
            public bool CHECKED { get; set; } = false;
            public string FIELD0 { get; set; }
            public string FIELD1 { get; set; }
            public string FIELD2 { get; set; }
            public string FIELD3 { get; set; }
            public string FIELD4 { get; set; }
            public string FIELD5 { get; set; }
            public string FIELD6 { get; set; }
            public string FIELD7 { get; set; }
            public string FIELD8 { get; set; }
            public string FIELD9 { get; set; }

        }

        public ObservableCollection<ROW> ROWS = new ObservableCollection<ROW>();

        private void btn_fill_Clicked(object sender, EventArgs e)
        {
            CreatedGridCount = 0;


            for (int i = 0; i < 1000; i++)
                ROWS.Add(new ROW()
                {
                    CHECKED = false,
                    FIELD0 = Guid.NewGuid().ToString(),
                    FIELD1 = Guid.NewGuid().ToString(),
                    FIELD2 = Guid.NewGuid().ToString(),
                    FIELD3 = Guid.NewGuid().ToString(),
                    FIELD4 = Guid.NewGuid().ToString(),
                    FIELD5 = Guid.NewGuid().ToString(),
                    FIELD6 = Guid.NewGuid().ToString(),
                    FIELD7 = Guid.NewGuid().ToString(),
                    FIELD8 = Guid.NewGuid().ToString(),
                    FIELD9 = Guid.NewGuid().ToString(),

                });


            view.ItemTemplate = new DataTemplate(() =>
            {
                return GetGrid();
            });

            view.ItemsSource = ROWS;
        }

        int CreatedGridCount = 0;

        private Grid GetGrid()
        {
            //creating a 11 cols 1 rows grid here

            Grid g = new Grid();
            g.RowDefinitions.Add(new RowDefinition(new GridLength(30)));        
            g.ColumnDefinitions.Add(new ColumnDefinition(new GridLength(50)));          //column for checkbox
            for (int i = 0; i < 10; i++)
                g.ColumnDefinitions.Add(new ColumnDefinition(new GridLength(250)));

            //adding a checkbox at col 0

            CheckBox c = new CheckBox();
            c.SetBinding(CheckBox.IsCheckedProperty, "CHECKED", BindingMode.TwoWay);
            g.Add(c, 0, 0);

            //adding 10 labels

            for (int i = 0; i < 10; i++)
            {
                Label l = new Label() { FontSize = 11F,VerticalTextAlignment=TextAlignment.Center };
                l.SetBinding(Label.TextProperty, "FIELD" + i);
                g.Add(l, i + 1, 0);
            }

            CreatedGridCount++;
            Debug.WriteLine("CreatedGridCount:" + CreatedGridCount);

            return g;

        }




    }
}

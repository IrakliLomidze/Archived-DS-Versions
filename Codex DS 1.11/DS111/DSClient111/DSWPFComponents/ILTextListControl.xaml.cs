using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ILG.DS.Controls.WPF
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class ILTextListControl : UserControl
    {
        public ILTextListControl()
        {
            InitializeComponent();
        }

        public class MyControlEventArgs : EventArgs
        {
            private String _Str;

            public String Str
            {
                get { return _Str; }
                set { _Str = value; }
            }
            private int _CurrentPosition;

            public int CurrentPosition
            {
                get { return _CurrentPosition; }
                set { _CurrentPosition = value; }
            }
            public MyControlEventArgs(
                             String Str,
                             int CurrentPosition
                                     )
            {
                _Str = Str;
                _CurrentPosition = CurrentPosition;
            }


        }

        public delegate void ILTextListControlEventHandle(object sender, MyControlEventArgs args);
        public event ILTextListControlEventHandle OnTXListSelectedItemChanged;


        private void TXListSelectedItemChanged(object sender, RoutedEventArgs e)
        {
            MyControlEventArgs retvals = new MyControlEventArgs(MyListBox.SelectedItem.ToString(),
                                                                MyListBox.SelectedIndex
                                                                );

            if (OnTXListSelectedItemChanged != null)
                OnTXListSelectedItemChanged(this, retvals);
        }


        public string current;

        public int ItemCount()
        {
            if (MyListBox.Items == null) return 0;
            return MyListBox.Items.Count;
        }

        public int CurrentIndex()
        {
            return MyListBox.SelectedIndex;
        }

        public void addStr(String str)
        {
            this.MyListBox.Items.Add(str);
        }

        string Function1(String str)
        {
            return str.Replace("\n", "").Replace("\r", "");
        }
        public void addILItem(string Left_Text, string Text, string Right_Text)
        {

            TextBlock textBlock1 = new TextBlock();
            textBlock1.TextWrapping = TextWrapping.Wrap;
            textBlock1.Inlines.Add(new Run(Function1(Left_Text).Trim()));
            textBlock1.Inlines.Add(new Bold(new Run(Function1(Text).Trim())));
            textBlock1.Inlines.Add(new Run(Function1(Right_Text).Trim()));

            this.MyListBox.Items.Add(textBlock1);
        }

        public void Up_Click()
        {
            if (MyListBox.SelectedIndex > 0) MyListBox.SelectedIndex--;
        }

        public void Down_Click()
        {
            if (MyListBox.SelectedIndex < (MyListBox.Items.Count - 1)) MyListBox.SelectedIndex++;
        }
        public void ClearItems()
        {
            this.MyListBox.Items.Clear();
        }
        public void addText(String str)
        {
            TextBlock textBlock1 = new TextBlock();
            textBlock1.TextWrapping = TextWrapping.Wrap;
            textBlock1.Inlines.Add(new Run("My Text "));
            textBlock1.Inlines.Add(new Bold(new Run("Bolded Text")));
            textBlock1.Inlines.Add(new Run(" Final Text "));

            this.MyListBox.Items.Add(textBlock1);
        }
        public void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (this.MyListBox.Items.Count == 0) return;
            current = MyListBox.Items[MyListBox.SelectedIndex].ToString();
            TXListSelectedItemChanged(null, null);
        }
    }
}

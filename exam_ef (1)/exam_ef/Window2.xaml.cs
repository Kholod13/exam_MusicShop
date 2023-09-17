using exam_ef.Repositories;
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
using System.Windows.Shapes;

namespace exam_ef
{
    /// <summary>
    /// Interaction logic for Window2.xaml
    /// </summary>
    /// 

    //private IUoW unitOfWork = new UnitOfWork();
    //private AddBook addBook = new AddBook();
    public partial class Window2 : Window
    {
        private IUoW unitOfWork = new UnitOfWork();
        public Window2()
        {
            InitializeComponent();
        }
        private void LoadDataDisk()
        {
            tableView.ItemsSource = unitOfWork.DiskRepo.Get().Select(x => new
            {
                x.Id,
                x.Name,
                x.CollectionId,
                x.AuthorId,
                x.Genre,
                x.Year,
                x.Price,
                x.PriceForSale,
            });
        }
        private void LoadDataCollection()
        {
            tableView.ItemsSource = unitOfWork.DiskRepo.Get().Select(x => new
            {
                x.Id,
                x.Name
            });
        }

        private void LoadDataAuthor()
        {
            tableView.ItemsSource = unitOfWork.AuthorRepo.Get().Select(x => new
            {
                x.Id,
                x.Name,
                x.Country,
            });
        }
       
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            LoadDataDisk();
            /*
            if (CB.SelectedIndex == 0) LoadDataAuthor();
            else if (CB.SelectedIndex == 1) LoadDataDisk();
            else if (CB.SelectedIndex == 2) LoadDataCollection();
            else return;
            */
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            unitOfWork.Save();
        }
       
    }
}
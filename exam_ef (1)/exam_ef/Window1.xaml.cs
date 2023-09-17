using exam_ef.Data;
using exam_ef.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
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
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
        }

        public Disk FillInfo()
        {
            string diskName = textBox_Name.Text;

            string collectionName = textBox_Collection.Text;
            int collectionId;
            string authorName = textBox_Author.Text;
            int authorId;
            string authorCountry = textBox_AuthorCountry.Text;
            int year = int.Parse(textBox_Year.Text);
            int price = int.Parse(textBox_Price.Text);
            int priceForSale = int.Parse(textBox_PriceForSale.Text);

            using (MusicShopDbContext dbContext = new MusicShopDbContext())
            {
                Collection collection = dbContext.Collections.SingleOrDefault(c => c.Name == collectionName);

                if (collection != null)
                {
                    
                    collectionId = collection.Id;
                }
                else
                {
                    Collection clct = new Collection 
                    { 
                        Name= collectionName,
                    };

                    using (MusicShopDbContext dbContext1 = new MusicShopDbContext())
                    {
                        dbContext.Collections.Add(clct);
                        dbContext.SaveChanges();
                    }
                    textBox_Collection.Clear();

                    collectionId = clct.Id;
                    MessageBox.Show("Колекцію не знайдено за введеним ім'ям. Створено нову колекцію.");
                }
            }

            using (MusicShopDbContext dbContext = new MusicShopDbContext())
            {
                Author author = dbContext.Authors.SingleOrDefault(c => c.Name == authorName);

                if (author != null)
                {

                    authorId = author.Id;
                }
                else
                {
                    Author athr = new Author
                    {
                        Name = authorName,
                        Country = authorCountry,
                    };

                    using (MusicShopDbContext dbContext1 = new MusicShopDbContext())
                    {
                        dbContext.Authors.Add(athr);
                        dbContext.SaveChanges();
                    }
                    textBox_Author.Clear();

                    authorId = athr.Id;
                    MessageBox.Show("Автоора за введеним ім'ям не знайдено. Було створено нового автора.");
                }
            }

            

            Disk newDisk = new Disk
            {
                Name = diskName,
                CollectionId = collectionId,
                AuthorId = authorId,
                Genre = textBox_Genre.Text,
                Year = year,
                Price = price,
                PriceForSale = priceForSale,
            };

            // Очистити значення
            textBox_PriceForSale.Clear();
            textBox_Price.Clear();
            textBox_Year.Clear();
            textBox_Genre.Clear();
            textBox_AuthorCountry.Clear();
            textBox_Author.Clear();
            textBox_Name.Clear();
            textBox_Collection.Clear();
            textBox_Name.Clear();

            return newDisk;
            /*
            using (MusicShopDbContext dbContext = new MusicShopDbContext())
            {
                dbContext.Disks.Add(newDisk);
                dbContext.SaveChanges();
            }
            */
        }

        //add
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Disk disk = new Disk { };

            disk = FillInfo();

            using (MusicShopDbContext dbContext = new MusicShopDbContext())
            {
                dbContext.Disks.Add(disk);
                dbContext.SaveChanges();
            }
        }

        //delete
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            string diskName = textBox_Name.Text;

            using (MusicShopDbContext dbContext = new MusicShopDbContext())
            {
                Disk disk = dbContext.Disks.SingleOrDefault(c => c.Name == diskName);

                if (disk.Name == diskName)
                {
                    dbContext.Disks.Remove(disk);
                    dbContext.SaveChanges();
                }
                else
                {
                    MessageBox.Show("Disk незнайдено! Неправильне ім'я.");
                }
            }
        }

        //edit
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {

        }
        //blacklist
        private void Button_Click_3(object sender, RoutedEventArgs e)
        {

        }
        //discount
        private void Button_Click_4(object sender, RoutedEventArgs e)
        {

        }
    }
}

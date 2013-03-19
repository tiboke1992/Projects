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


namespace MagOOkWelWeg
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Model1Container container;
        public MainWindow()
        {
            InitializeComponent();
            container = new Model1Container();
            dgvData.ItemsSource = container.CarSet.Local;
            SetDataSource(dvgGrid2);
            SetDataSource(dgvData);
            dgData2();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            dvgGrid2.Items.Refresh();
            Car car = new Car();
            car.Brand = "Honda";
            car.Type = "Civic";
            car.MaxSpeed = 234;

            Car car2 = new Car();
            car2.Brand = "Subaru";
            car2.Type = "WRX";
            car2.MaxSpeed = 240;

            Person p = new Person();
            p.Name = "Joske";
            p.PreName = "Vermeulen";
            p.Age = 35;

            p.Car.Add(car);
            p.Car.Add(car2);

            //Create
            container.CarSet.Add(car);
            container.CarSet.Add(car2);
            container.PersonSet.Add(p);
            container.SaveChanges();

            //Update
            Car cars = container.CarSet.First(i => i.Brand == "Subaru");
            cars.Brand = "Suubaruuu";
            container.SaveChanges();

            //Delete
            Car deletecar = container.CarSet.First(i => i.Type == "Civic");
            container.CarSet.Remove(deletecar);
            container.SaveChanges();

            List<Car> lijst = container.CarSet.ToList();
            SetDataSource(dvgGrid2);
            SetDataSource(dgvData);
            dgData2();

        }

        private void dgData2()
        {
            List<Car> lijst = container.CarSet.ToList();
            dgData.DataContext = lijst;
        }



        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            dvgGrid2.Items.Refresh();
            List<Car> lijst = container.CarSet.ToList();

            foreach (Car f in lijst)
            {
                container.CarSet.Remove(f);
            }
            lijst.Clear();

            List<Person> lijst2 = container.PersonSet.ToList();
            foreach (Person p in lijst2)
            {
                container.PersonSet.Remove(p);
            }
            container.SaveChanges();
            lblLabel.Content = "All content deleted";
            SetDataSource(dgvData);
            SetDataSource(dvgGrid2);
            dgData2();
        }

        private void SetDataSource(DataGrid d)
        {
            List<Car> lijst = container.CarSet.ToList();
            d.DataContext = lijst;
            dvgGrid2.Items.Refresh();
        }

        private void btnCustom_Click(object sender, RoutedEventArgs e)
        {
            lblError.Content = "";
            string brand = txtBrand.Text;
            string type = txtType.Text;
            string speed = txtSpeed.Text;
            int iSpeed;
            Boolean gut = int.TryParse(speed, out iSpeed);
            if (!gut || txtBrand.Text == "" || txtType.Text == "")
            {
                lblError.Content = "Error some of the values are not correct";
            }
            else
            {
                Car car = new Car();
                car.Brand = brand;
                car.Type = type;
                car.MaxSpeed = (Int16)iSpeed;
                Person p = new Person();
                p.Name = "Watson";
                p.PreName = "Emma";
                p.Age = 20;
                car.Person = p;
                container.CarSet.Add(car);
                container.SaveChanges();
                lblError.Content = "We have added your car to the db";
                txtBrand.Text = "";
                txtType.Text = "";
                txtSpeed.Text = "";
                List<Car> lijst = container.CarSet.ToList();
                SetDataSource(dvgGrid2);
                SetDataSource(dgvData);
                dgData2();
            }

        }

      

       


    }
}

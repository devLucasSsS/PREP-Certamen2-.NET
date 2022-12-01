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
using BLL;
using DAL;
namespace PL
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ComandaBLL cbll = new ComandaBLL();
        public MainWindow()
        {
            InitializeComponent();
            for (int i = 1; i < 26; i++)
            {
                cmbMesa.Items.Add(i.ToString());
                
            }
            //cmbPplato.ItemsSource = idk.getAll();
        }

        private void BtnActivar_Click(object sender, RoutedEventArgs e)
        {
            lbMesa.Visibility = Visibility.Visible;
            cmbMesa.Visibility = Visibility.Visible;
            lbCantCom.Visibility = Visibility.Visible;
            txtCantComensales.Visibility = Visibility.Visible;
            btnActivarC.Visibility = Visibility.Visible;
        }

        private void BtnIngresarPedido_Click(object sender, RoutedEventArgs e)
        {
            lbPmesa.Visibility = Visibility.Visible;
            lbPplato.Visibility = Visibility.Visible;
            lbPcant.Visibility = Visibility.Visible;
            cmbPmesa.Visibility = Visibility.Visible;
            cmbPplato.Visibility = Visibility.Visible;
            btnPReg.Visibility = Visibility.Visible;
            txtPcant.Visibility = Visibility.Visible;
            ListarMesasActivas();
            ListarPlatos();
        }


            private void ListarPlatos()
        {
            cmbPplato.ItemsSource = cbll.getPlatos();
        }

        private void ListarMesasActivas()
        {
            cmbPmesa.ItemsSource = cbll.getMesas();
        }

        private void BtnVerComandas_Click(object sender, RoutedEventArgs e)
        {
            DGVClista.Visibility = Visibility.Visible;
        }
        private void BtnActivarC_Click(object sender, RoutedEventArgs e)
        {
            try
            {


                int Cant = int.Parse(txtCantComensales.Text);

                if (Cant < 1 || Cant > 9)
                {
                    MessageBox.Show("Error, la cantidad de comensales tiene que ser entre 1 y 9");
                }
                int Mesa = int.Parse(cmbMesa.SelectedValue.ToString());
                cbll.AddComanda(Mesa, Cant);
                MessageBox.Show("Comanda agregada", "Nueva Comanda", MessageBoxButton.OK, MessageBoxImage.Information);
            }catch(ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Nueva Comanda", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void BtnPReg_Click(object sender, RoutedEventArgs e)
        {
            Plato plato = new Plato();
            Comanda comanda = new Comanda();
            string mesa = cmbPmesa.SelectedItem.ToString();
            string Splato = cmbPplato.SelectedItem.ToString();
            plato = cbll.GetIdPlato(Splato);
            int idplato = plato.Id;
            int mes = int.Parse(mesa);
            comanda = cbll.Get(mes);
            int idComanda = comanda.Id;
            string cant = txtPcant.Text;
            int cant1 = int.Parse(cant);
            cbll.AddPedido(idComanda, idplato, cant1);

            MessageBox.Show("Plato Agregado Correctamente");
        }
    }
}

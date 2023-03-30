using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace OOP2
{
    /// <summary>
    /// Логика взаимодействия для WorkWindow.xaml
    /// </summary>
    public partial class WorkWindow : Window
    {
        private readonly string path = System.IO.Path.GetFullPath(@"..\..\..\db");
        private Worker currentWorker;
        private Repository data;
        private Repository dataReserve;
        private List<Client> withNewClient = new List<Client>();

        public WorkWindow(object someWorker)
        {
            InitializeComponent();
            ReadData(path);
            cbDepartment.ItemsSource = data.DepartmentsDb;
                
            if (someWorker.GetType() == typeof(Consultant))
                currentWorker = new Consultant();
            else
            if (someWorker.GetType() == typeof(Manager))
                currentWorker = new Manager();
            data.ClientsDb = currentWorker.ShowData(data.ClientsDb);
            AvailabilityData(currentWorker);
        }

        private void BtnSortBy(object sender, RoutedEventArgs e)
        {
            data.ClientsDb.Sort(Client.SortedBy(SortedCriterion.Surname));
            lvClients.ItemsSource = data.ClientsDb.Where(Find);
            withNewClient = data.ClientsDb.Where(Find).ToList();
        }

        private void BtnRef(object sender, RoutedEventArgs e)
        {
            cbDepartment.Items.Refresh();
            lvClients.Items.Refresh();   
        }

        private void BtnAddClient(object sender, RoutedEventArgs e)
        {
            withNewClient.Add(new Client());
            lvClients.ItemsSource = string.Empty;
            lvClients.ItemsSource = withNewClient;
            data.ClientsDb.Where(Find).ToList().Add(new Client());
        }

        private void BtnDeleteClient(object sender, RoutedEventArgs e)
        {
            if (FindNumberSelectedClient(withNewClient) > 0)
            {
                withNewClient = currentWorker.DeleteData(withNewClient, FindNumberSelectedClient(withNewClient));
                lvClients.ItemsSource = string.Empty;
                lvClients.ItemsSource = withNewClient;
            }
        }

        private void SaveDataInSelectedDepartment(string path)
        {
            int emptySpaces = 0;
                for (int i = 0; i < withNewClient.Count; i++)
                {
                    withNewClient[i].DepartamentName = (cbDepartment.SelectedItem as Department).DepartmentName;
                    string[] subs = withNewClient[i].ClientInfo().Split('#');

                    foreach (string s in subs)
                    {
                        if (s == string.Empty)
                            emptySpaces++;
                    }
                }
                if (emptySpaces != 0 && currentWorker.GetType() == typeof(Manager))
                    System.Windows.MessageBox.Show("Чтобы сохранить изменения, заполни пустые ячейки!");
                else
                {
                    File.WriteAllText(path, string.Empty);

                    for (int i = 0; i < withNewClient.Count; i++)
                    {
                        if (currentWorker.GetType() == typeof(Consultant))
                            withNewClient[i].Passport = dataReserve.ClientsDb.Where(Find).ToList()[i].Passport;
                        withNewClient[i].RecToFile(path);
                    }
                    data.ClientsDb = currentWorker.ShowData(data.ClientsDb);
                    System.Windows.MessageBox.Show("Изменения сохранены.");
            }
        }

        private void BtnSave(object sender, RoutedEventArgs e)
        {
            string nameFileChanges = (cbDepartment.SelectedItem as Department).DepartmentName;
            string pathChanges = $"{path}\\{nameFileChanges}";
            if (withNewClient.Count == 0)
            {
                if (System.Windows.Forms.MessageBox.Show("Вы удалили все данные из департамента! Хотите удалить файл департамента?", "",
                    System.Windows.Forms.MessageBoxButtons.YesNo,
                    System.Windows.Forms.MessageBoxIcon.Question) 
                    == System.Windows.Forms.DialogResult.Yes)
                {
                    File.Delete(pathChanges);
                    System.Windows.MessageBox.Show($"Вы удалили департамент {nameFileChanges}.");
                    // обновить список департаментов
                    //только такое решение нашел
                    this.Close();
                    WorkWindow workWindow = new WorkWindow(new Manager());
                    workWindow.ShowDialog();
                }
                else
                {
                    SaveDataInSelectedDepartment(pathChanges);
                    System.Windows.MessageBox.Show($"Вы сохранили пустой департамент {nameFileChanges}.");
                }
            }
            else
                SaveDataInSelectedDepartment(pathChanges);
        }

        private void CbDepartment_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ReadData(path);
            btnUpdate.IsEnabled = true;
            btnSaveChanges.IsEnabled = true;
            btnSort.IsEnabled = true;
            if (currentWorker.GetType() == typeof(Manager))
            {
                btnCreatNew.IsEnabled = true;
                btnDelete.IsEnabled = true;
            }
            lvClients.ItemsSource = data.ClientsDb.Where(Find);
            withNewClient = data.ClientsDb.Where(Find).ToList();
            if (currentWorker.GetType() == typeof(Consultant))
                data.ClientsDb = currentWorker.ShowData(data.ClientsDb);
        }
        
        private bool Find(Client arg)
        {
            return arg.DepartamentName == (cbDepartment.SelectedItem as Department).DepartmentName;
        }
        /// <summary>
        /// Доступность полей с данными
        /// </summary>
        private void AvailabilityData(object currentWorker)
        {
            if (currentWorker.GetType() == typeof(Consultant))
            {
                textSurname.IsEnabled = false;
                textName.IsEnabled = false;
                textPatronymic.IsEnabled = false;
                textPassport.IsEnabled = false;
            }
        }
        
        private void ReadData(string path)
        {
            dataReserve = Repository.CreateRepository(path);
            data = Repository.CreateRepository(path);
        }

        private int FindNumberSelectedClient(List<Client> clients)
        {
            int numb = 0;
            if (lvClients.SelectedIndex != -1)
                for (int i = 0; i < clients.Count; i++)
                {
                    if (clients[i] == lvClients.SelectedItem)
                    {
                        numb = i + 1;
                        break;
                    }
                }
            return numb;
        }
    }
}

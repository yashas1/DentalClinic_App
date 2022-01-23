using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

using DentalCareBackend;

namespace DentalCareFrontend
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        PatientList patientList;
        ObservableCollection<Patient> patients;
        SlotList slots;

        Custom custom = new Custom();

        public PatientList PatientList { get => patientList; set => patientList = value; }
        public ObservableCollection<Patient> Patients { get => patients; set => patients = value; }
        public SlotList Slots { get => slots; set => slots = value; }
        public Custom Custom { get => custom; set => custom = value; }

        public MainWindow()
        {
            InitializeComponent();
            InitializeApp();

            DataContext = this;
        }

        private void InitializeApp()
        {
            FileHandlerService.Initialize();

            Patients = new ObservableCollection<Patient>();
            Slots = new SlotList();
            Program program = new Program();
            program.GenerateAppointmentSlots(Slots);

            PopulateSlots();

            patientList = FileHandlerService.ReadAppointmentDetails();

            treatments.Items.Add("RootCanalPatient");
            treatments.Items.Add("BracesPatient");
            treatments.Items.Add("FillingCleaningPatient");
            treatments.Items.Add("ExtractionPatient");

            foreach (IPatient patient in patientList)
            {
                int index = availableSlots.Items.IndexOf(patient.ApptTime);
                if (index >= 0)
                {
                    availableSlots.Items.RemoveAt(index);
                }
            }

            foreach(Patient patient in patientList)
            {
                Patient newPatient = null;
                if (patient.PatientType == PatientType.RootCanalPatient)
                {
                    newPatient = new RootCanalPatient()
                    {
                        Id = patient.Id,
                        Name = patient.Name,
                        Gender = patient.Gender,
                        Age = patient.Age,
                        ApptTime = patient.ApptTime,
                        CreditCardNum = patient.CreditCardNum,
                        NextCheckInDays = patient.NextCheckInDays,
                        Morbidity = patient.Morbidity,
                        PatientType = patient.PatientType
                    };
                } 
                else if (patient.PatientType == PatientType.BracesPatient)
                {
                    newPatient = new BracesPatient()
                    {
                        Id = patient.Id,
                        Name = patient.Name,
                        Gender = patient.Gender,
                        Age = patient.Age,
                        ApptTime = patient.ApptTime,
                        CreditCardNum = patient.CreditCardNum,
                        NextCheckInDays = patient.NextCheckInDays,
                        Morbidity = patient.Morbidity,
                        PatientType = patient.PatientType
                    };
                } 
                else if (patient.PatientType == PatientType.FillingCleaningPatient)
                {
                    newPatient = new FillingCleaningPatient()
                    {
                        Id = patient.Id,
                        Name = patient.Name,
                        Gender = patient.Gender,
                        Age = patient.Age,
                        ApptTime = patient.ApptTime,
                        CreditCardNum = patient.CreditCardNum,
                        NextCheckInDays = patient.NextCheckInDays,
                        Morbidity = patient.Morbidity,
                        PatientType = patient.PatientType
                    };
                } 
                else if (patient.PatientType == PatientType.ExtractionPatient)
                {
                    newPatient = new ExtractionPatient()
                    {
                        Id = patient.Id,
                        Name = patient.Name,
                        Gender = patient.Gender,
                        Age = patient.Age,
                        ApptTime = patient.ApptTime,
                        CreditCardNum = patient.CreditCardNum,
                        NextCheckInDays = patient.NextCheckInDays,
                        Morbidity = patient.Morbidity,
                        PatientType = patient.PatientType
                    };
                }
                patients.Add(newPatient);
            }
        }

        private void PopulateSlots()
        {
            foreach (ISlot slot in Slots)
            {
                availableSlots.Items.Add(slot.DateTime);
            }
        }

        private void SubmitBtnClicked(object sender, RoutedEventArgs e)
        {
            bool result = ValidateFields();

            if (result)
            {
                Patient patient = null;
                string serviceType = string.Empty;

                if (treatments.SelectedItem.ToString() == PatientType.RootCanalPatient.ToString())
                {
                    patient = new RootCanalPatient()
                    {
                        Id = "001",
                        Name = tbName.Text,
                        Gender = GetGender(),
                        Age = int.Parse(tbAge.Text),
                        ApptTime = availableSlots.SelectedItem.ToString(),
                        CreditCardNum = tbCreditCard.Text,
                        NextCheckInDays = int.Parse(tbNextCheckup.Text),
                        Morbidity = GetMorbidity(),
                        PatientType = PatientType.RootCanalPatient
                    };
                }
                else if (treatments.SelectedItem.ToString() == PatientType.BracesPatient.ToString())
                {
                    patient = new BracesPatient()
                    {
                        Id = "001",
                        Name = tbName.Text,
                        Gender = GetGender(),
                        Age = int.Parse(tbAge.Text),
                        ApptTime = availableSlots.SelectedItem.ToString(),
                        CreditCardNum = tbCreditCard.Text,
                        NextCheckInDays = int.Parse(tbNextCheckup.Text),
                        Morbidity = GetMorbidity(),
                        PatientType = PatientType.BracesPatient
                    };
                }
                else if (treatments.SelectedItem.ToString() == PatientType.FillingCleaningPatient.ToString())
                {
                    patient = new FillingCleaningPatient()
                    {
                        Id = "001",
                        Name = tbName.Text,
                        Gender = GetGender(),
                        Age = int.Parse(tbAge.Text),
                        ApptTime = availableSlots.SelectedItem.ToString(),
                        CreditCardNum = tbCreditCard.Text,
                        NextCheckInDays = int.Parse(tbNextCheckup.Text),
                        Morbidity = GetMorbidity(),
                        PatientType = PatientType.FillingCleaningPatient
                    };
                }
                else if (treatments.SelectedItem.ToString() == PatientType.ExtractionPatient.ToString())
                {
                    patient = new ExtractionPatient()
                    {
                        Id = "001",
                        Name = tbName.Text,
                        Gender = GetGender(),
                        Age = int.Parse(tbAge.Text),
                        ApptTime = availableSlots.SelectedItem.ToString(),
                        CreditCardNum = tbCreditCard.Text,
                        NextCheckInDays = int.Parse(tbNextCheckup.Text),
                        Morbidity = GetMorbidity(),
                        PatientType = PatientType.ExtractionPatient
                    };
                }

                int selectedIndex = availableSlots.SelectedIndex;

                patientList.Add(patient);
                patients.Add(patient);

                availableSlots.Items.RemoveAt(selectedIndex);

                FileHandlerService.WriteAppointmentDetails(patientList);

                ResetForm();
            }
        }

        private string GetGender()
        {
            if (rbMale.IsChecked == true)
            {
                return "Male";
            } 
            else if (rbFemale.IsChecked == true)
            {
                return "Female";
            } 
            else
            {
                return "Other";
            }
        }

        private List<string> GetMorbidity()
        {
            List<string> morbidity = new List<string>();
            if (cbDiabetes.IsChecked == true)
            {
                morbidity.Add("Diabetes");
            }
            if (cbCholesterol.IsChecked == true)
            {
                morbidity.Add("Cholesterol");
            }
            if (cbHighBP.IsChecked == true)
            {
                morbidity.Add("High BP");
            }
            return morbidity;
        }

        private void SearchBtnClicked(object sender, RoutedEventArgs e)
        {
            string searchText = tbSearch.Text;

            var result = patientList.Where
                   (patient => patient.Name.Contains(searchText));
            appointmentsGrid.ItemsSource = result;
        }

        private void TxtPhotosFocused(object sender, RoutedEventArgs e)
        {
            //whenever photos field focused then changing it's color to black
            tbName.Foreground = Brushes.Black;
        }

        private void TxtCreditCardFocused(object sender, RoutedEventArgs e)
        {
            //whenever credit card field focused then changing it's color to black
            tbCreditCard.Foreground = Brushes.Black;
        }
        private void TxtDaysFocused(object sender, RoutedEventArgs e)
        {
            //whenever days field focused then changing it's color to black
            tbNextCheckup.Foreground = Brushes.Black;
        }

        private void myDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private bool ValidateFields()
        {
            bool isValid = true;

            return isValid;
        }

        private void ResetForm()
        {
            tbName.Text = "";
            tbNextCheckup.Text = "";
            tbAge.Text = "";
            tbCreditCard.Text = "";
        }

        private void deleteBtnClicked(object sender, RoutedEventArgs e)
        {

        }

        private void DisplayBtnClicked(object sender, RoutedEventArgs e)
        {

        }
    }
}

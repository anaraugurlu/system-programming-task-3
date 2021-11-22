using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using system_programming_task_3.Command;
using system_programming_task_3.Helper;

namespace system_programming_task_3.ViewModel
{
    class MainViewModel : BaseViewModel
    {

        public RelayCommand StartButton { get; set; }
        public RelayCommand ProgressBar { get; set; }
        public RelayCommand CancelButton { get; set; }
        public RelayCommand FileButton { get; set; }
        public RelayCommand DecRadioButton { get; set; }
        public RelayCommand EncRadioButton { get; set; }
        private bool encrypt;

        public bool Encrypt
        {
            get { return encrypt; }
            set { encrypt = value; OnPropertyChanged(); }
        }

        private bool decrypt;

        public bool Decrypt
        {
            get { return encrypt; }
            set { encrypt = value; OnPropertyChanged(); }
        }


        public string filePathFrom { get; set; }
        public string fileStreamv { get; set; }
        public string fileTextFrom { get; set; }
        public string fileStream { get; set; }
        public MainViewModel(MainWindow mainWindow)
        {
            FileButton = new RelayCommand((sender) =>
            {

                using (System.Windows.Forms.OpenFileDialog openFileDialog = new System.Windows.Forms.OpenFileDialog())
                {

                    openFileDialog.InitialDirectory = "c:\\";

                    openFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";

                    openFileDialog.FilterIndex = 2;

                    openFileDialog.RestoreDirectory = true;







                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {


                        filePathFrom = openFileDialog.FileName;
                        mainWindow.txtf.Text = filePathFrom;
                        fileStreamv = openFileDialog.OpenFile().ToString();




                    }

                }
            });

            StartButton = new RelayCommand((sender) =>
            {
                using (StreamReader reader = new StreamReader(filePathFrom))
                {
                    var text = reader.ReadLine();
                    if (Encrypt == true)
                    {
                        EncryptAndDecrypt.Encrypt(text);
                        mainWindow.prog.Value = 100;
                        MessageBox.Show("encryption completed successfully");
                    }
                   
                }

            });

        }

    }
}

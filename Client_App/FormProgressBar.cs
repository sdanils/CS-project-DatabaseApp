using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab_Three_WinAdd
{
    public partial class FormProgressBar : Form
    {
        public ProgressBar progressBarSearchReturn;
        //Поток для получения прогресса
        NetworkStream stream;
        int numberVeh;
        public FormProgressBar(int numberVeh, NetworkStream stream)
        {
            InitializeComponent();
            this.stream = stream;
            this.numberVeh = numberVeh;
            this.progressBarSearch.Maximum = numberVeh;
            GetProgress();
        }

        private async void GetProgress() 
        {
            while (true)
            {
                // Асинхронно читаем данные от сервера
                byte[] numberData = new byte[4];
                int bytesRead = await stream.ReadAsync(numberData, 0, numberData.Length);

                if (bytesRead == 0)
                {
                    continue;
                }

                string mStr = Encoding.UTF8.GetString(numberData, 0, bytesRead);
                int numberSearch = int.Parse(mStr);
                this.progressBarSearch.Value = numberSearch + 1;

                if(progressBarSearch.Value == progressBarSearch.Maximum)
                {
                    break;
                }
            }

            this.Close();
        }

    }
}

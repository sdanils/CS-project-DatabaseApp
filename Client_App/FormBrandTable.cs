using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Tracing;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Reflection;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using Newtonsoft.Json;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Tab;
using System.Collections.Specialized;

namespace Lab_Three_WinAdd
{
    public partial class FormBrandTable : Form
    {
        List<Model> models;
        BindingSource source;
        bool menuVisiable;

        public FormBrandTable()
        {
            models = new List<Model>();
            models.Add(null); //для пустой строки в таблице

            this.source = new BindingSource { DataSource = models };

            InitializeComponent();

            this.labelSeriolizeInfo.Visible = false;
            this.dataGridViewBrands.CurrentCell = null;
            this.dataGridViewBrands.DataSource = this.source;
            this.dataGridViewBrands.Columns["Type"].ReadOnly = true;
            this.menuVisiable = false;
        }
        private void dataGridViewBrands_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            for (int i = 0; i <= e.RowCount - 1; i++)
            {
                if (models[e.RowIndex + i] != null)
                {
                    if (models[e.RowIndex + i] is Truck)
                    {
                        dataGridViewBrands.Rows[e.RowIndex + i].Cells["Type"].Value = "Truck";
                        dataGridViewBrands.Rows[e.RowIndex + i].DefaultCellStyle.BackColor = Color.FromArgb(160, 160, 160);
                    }
                    else if (models[e.RowIndex + i] is Car)
                    {
                        dataGridViewBrands.Rows[e.RowIndex + i].Cells["Type"].Value = "Car";
                        dataGridViewBrands.Rows[e.RowIndex + i].DefaultCellStyle.BackColor = Color.FromArgb(210, 210, 210);
                    }
                    dataGridViewBrands.Rows[e.RowIndex + i].Cells["Type"].ReadOnly = true;
                }
                else if (models[e.RowIndex + i] == null)
                {
                    dataGridViewBrands.Rows[e.RowIndex + i].Cells["Type"].ReadOnly = false;
                }
            } 
            /*if (models[e.RowIndex] != null)
            {
                if (models[e.RowIndex] is Truck && dataGridViewBrands.Rows[e.RowIndex].Cells["Type"].Value.ToString() == null)
                {
                    dataGridViewBrands.Rows[e.RowIndex].Cells["Type"].Value = "Truck";
                    dataGridViewBrands.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.FromArgb(160, 160, 160);
                }
                else if (models[e.RowIndex] is Car && dataGridViewBrands.Rows[e.RowIndex].Cells["Type"].Value == null)
                {
                    dataGridViewBrands.Rows[e.RowIndex].Cells["Type"].Value = "Car";
                    dataGridViewBrands.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.FromArgb(210, 210, 210);
                }
            }
            else 
            {
                dataGridViewBrands.Rows[e.RowIndex].Cells["Type"].ReadOnly = false;
            }
            con++;*/

        }
        private void dataGridViewBrands_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == source.Count - 1 && e.RowIndex != -1 && e.ColumnIndex == Type.Index)
            {
                if (dataGridViewBrands.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() == "Truck")
                {
                    source[e.RowIndex] = new Truck();
                    dataGridViewBrands.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.FromArgb(160, 160, 160);
                    dataGridViewBrands.Rows[e.RowIndex].Cells["Type"].ReadOnly = true;
                    source.Add(null);
                }
                else if (dataGridViewBrands.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() == "Car")
                {
                    source[e.RowIndex] = new Car();
                    dataGridViewBrands.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.FromArgb(210, 210, 210);
                    dataGridViewBrands.Rows[e.RowIndex].Cells["Type"].ReadOnly = true;
                    source.Add(null);
                }
            }
        }
        private void dataGridViewBrands_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            if (e.RowIndex != source.Count - 1)
            {
                if (e.ColumnIndex == 3)
                {
                        dataGridViewBrands.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = models[e.RowIndex].PowerEngine;
                }
                else if (e.ColumnIndex == 4)
                {
                    dataGridViewBrands.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = models[e.RowIndex].MaxSpeed;
                }
            }
            else
            {
                dataGridViewBrands.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = null;
            }
        }
        private void dataGridViewBrands_SelectionChanged(object sender, EventArgs e)
        {
            dataGridViewCars.Visible = false;
            dataGridViewBrands.DefaultCellStyle.SelectionBackColor = Color.FromArgb(120, 120, 180);

            this.labelSelection.Visible = false;
            this.textBoxSelection.Visible = false;

            if (dataGridViewBrands.SelectedRows.Count == 1 && dataGridViewBrands.CurrentRow.Index != source.Count - 1 && dataGridViewBrands.CurrentRow.Cells["Brand"].Value.ToString() != "brand" && dataGridViewBrands.CurrentRow.Cells["Model"].Value.ToString() != "model")
            {
                dataGridViewCars.Rows.Clear();
                this.OpenGridCars();
            }
        }
        private void OpenGridCars()
        {
            if (dataGridViewBrands.SelectedRows[0].Cells["Type"].Value != null)
            {

                Model CurrentModel = (Model)source[dataGridViewBrands.SelectedRows[0].Index];

                if (dataGridViewBrands.SelectedRows[0].Cells["Type"].Value.ToString() == "Truck")
                {
                    dataGridViewCars.Columns[1].HeaderText = "Number Wheels";
                    dataGridViewCars.Columns[2].HeaderText = "Voluem body";

                    int typeVeh = 1;

                    if (CurrentModel.vehicles == null || CurrentModel.vehicles.Count == 0)
                    {
                        LoadWithControl(typeVeh, CurrentModel);
                    }

                    for (int i = 0; i < CurrentModel.vehicles.Count - 1; i++)
                    {
                        this.dataGridViewCars.Rows.Add(CurrentModel.vehicles[i].NumberVechicle, ((VehicleTruck)(CurrentModel.vehicles[i])).NumberWheels, ((VehicleTruck)(CurrentModel.vehicles[i])).VoluemBody);
                    }
                }
                else if (dataGridViewBrands.SelectedRows[0].Cells["Type"].Value.ToString() == "Car")
                {
                    dataGridViewCars.Columns[1].HeaderText = "Name multimedia";
                    dataGridViewCars.Columns[2].HeaderText = "Number airbags";
                    
                    int typeVeh = 2;

                    if (CurrentModel.vehicles == null || CurrentModel.vehicles.Count == 0)
                    {
                        LoadWithControl(typeVeh, CurrentModel);
                    }

                    for (int i = 0; i < CurrentModel.vehicles.Count - 1; i++)
                    {
                        this.dataGridViewCars.Rows.Add(CurrentModel.vehicles[i].NumberVechicle, ((VehicleCar)(CurrentModel.vehicles[i])).NameMultimedia, ((VehicleCar)(CurrentModel.vehicles[i])).NumberAirbags);
                    }
                }

                this.labelSelection.Visible = true;
                this.textBoxSelection.Visible = true;

                dataGridViewCars.Visible = true;
            }
        }
        private void dataGridViewBrands_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if(dataGridViewBrands.CurrentRow.Index == source.Count - 1)
            {
                if(dataGridViewBrands.CurrentCell.OwningColumn.Name == "Type" && e.Control is ComboBox comboBox)
                {
                    comboBox.SelectedIndexChanged -= ComboBox_SelectedIndexChanged;
                    comboBox.SelectedIndexChanged += ComboBox_SelectedIndexChanged;
                }
            }

        }
        private void ComboBox_SelectedIndexChanged(object sender, EventArgs e)// событие изменения SelectIndex в ComboBoxColumn
        {
            // Обработка изменений в ComboBox
            ComboBox comboBox = (ComboBox)sender;

            if (comboBox.SelectedIndex != -1)
            {
                if (comboBox.SelectedIndex == 0)
                {
                    dataGridViewBrands.DefaultCellStyle.SelectionBackColor = Color.FromArgb(120, 120, 180);
                }
                else if (comboBox.SelectedIndex == 1)
                {
                    dataGridViewBrands.DefaultCellStyle.SelectionBackColor = Color.FromArgb(90, 90, 130);
                }
            }
        }
        private void dataGridViewCars_SelectionChanged(object sender, EventArgs e)
        {
            dataGridViewCars.DefaultCellStyle.SelectionBackColor = Color.FromArgb(120, 120, 180);
        }
        private void FormBrandTable_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                if (!menuVisiable)
                {
                    this.menuVisiable = true;
                    this.dataGridViewBrands.Width -= 200;
                    this.dataGridViewCars.Width -= 200;
                    this.groupBoxMenu.Location = new Point(this.dataGridViewBrands.Width + 3, 0);
                    this.groupBoxMenu.Size = new Size(200, this.Height);
                    this.Controls.Add(this.groupBoxMenu);
                }
                else if (menuVisiable)
                {
                    this.menuVisiable = false;
                    this.Controls.Remove(this.groupBoxMenu);
                    this.dataGridViewBrands.Width += 200;
                    this.dataGridViewCars.Width += 200;
                    this.ReloadMenu();
                }
            }
        }
        private void buttonFile_Click(object sender, EventArgs e)
        {
            this.buttonSave.Visible = true;
            this.buttonLoad.Visible = true;
            this.buttonExit.Visible = true;
            this.buttonFile.Visible = false;
            this.labelTitleMenu.Text = "File";
            this.labelTitleMenu.Visible = true;
        }
        private void ReloadMenu()
        {
            this.labelTitleMenu.Visible = false;
            this.buttonSave.Visible = false;
            this.buttonLoad.Visible = false;
            this.buttonExit.Visible = false;
            this.buttonFile.Visible = true;
        }
        private void buttonSave_Click(object sender, EventArgs e)
        {
            this.labelSeriolizeInfo.Text = "Saving...";
            this.labelSeriolizeInfo.Visible = true;
            this.labelSeriolizeInfo.Refresh();
            SerializeToXml(this.models, "models.xml");
            Thread.Sleep(500);
            this.labelSeriolizeInfo.Visible = false;
        }
        static void SerializeToXml(List<Model> models, string fileName)
        {
            // Создаем объект XmlSerializer для типа данных
            XmlSerializer serializerModels = new XmlSerializer(typeof(List<Model>));

            // Создаем поток для записи в файл
            using (TextWriter writer = new StreamWriter(fileName))
            {
                // Сериализуем объекты в XML и записываем в файл
                serializerModels.Serialize(writer, models);
            }
        }
        static List<Model> DeserializeFromXml(string fileName)
        {
            // Создаем объект XmlSerializer для типа данных
            XmlSerializer serializerModels = new XmlSerializer(typeof(List<Model>));

            // Создаем поток для чтения из файла
            using (FileStream stream = new FileStream(fileName, FileMode.Open))
            {
                // десериализуем объекты из XML формата и возвращает список
                return (List<Model>)serializerModels.Deserialize(stream);
            }
        }
        private void buttonLoad_Click(object sender, EventArgs e)
        {
            this.labelSeriolizeInfo.Text = "Loading...";
            this.labelSeriolizeInfo.Visible = true;
            this.labelSeriolizeInfo.Refresh();
            Thread.Sleep(500);
            this.models = DeserializeFromXml("models.xml");
            this.source.DataSource = this.models;
            this.dataGridViewBrands.Refresh();
            this.labelSeriolizeInfo.Visible = false;

        }
        private void buttonExit_Click(object sender, EventArgs e)
        {
            ReloadMenu();
        }
        private void LoadWithControl(int typeVeh, Model CurrentModel)
        {
            //Переменная для хранения числа найденных машин.
            int numberVeh = -1;
            CurrentModel.vehicles = new List<IVehicle>();
            //Создаем запрос на сервер
            Task loadProcess = Task.Run(async () => {

                IPAddress serverIP = IPAddress.Parse("IP");

                // Подключение к серверу для команд и прогресса
                using (TcpClient commandClient = new TcpClient())
                {
                    try
                    {
                        await commandClient.ConnectAsync(serverIP, 8888);
                        NetworkStream stream = commandClient.GetStream();

                        //Определяем порт подключения
                        int myPort = ((IPEndPoint)commandClient.Client.LocalEndPoint).Port;

                        // Отправка типа серверу
                        string sendType = Convert.ToString(typeVeh); 
                        byte[] data = Encoding.UTF8.GetBytes(sendType);
                        stream.Write(data, 0, data.Length);

                        //получение числа машин
                        data = new byte[256];
                        int bytesRead = stream.Read(data, 0, data.Length);
                        numberVeh = int.Parse(Encoding.UTF8.GetString(data, 0, bytesRead));

                        Task controlProc = Task.Run(() => ControlProcess(numberVeh, stream));
                        Task getData = Task.Run(() => GetData(CurrentModel, numberVeh, typeVeh, myPort));

                        Task.WaitAll(controlProc, getData);
                    }
                    finally
                    {
                        commandClient.Close();
                    }
                }
                numberVeh = 1;
            });
            Task.WaitAny(loadProcess);
        }
        private void TextBoxSelection_TextChanged(object sender, EventArgs e)
        {
            if (dataGridViewBrands.CurrentRow.Cells["Type"] != null)
            {
                int indexRow = dataGridViewBrands.CurrentRow.Index;
                List<IVehicle> dataVicles = this.Where(this.textBoxSelection.Text, models[indexRow].vehicles);
                //List<IVehicle> dat1 = models[indexRow].vehicles.Where(x => x.NumberVechicle.StartsWith(textBoxSelection.Text)).ToList();


                int numVehciles = dataVicles.Count;
                this.dataGridViewCars.Rows.Clear();
                for (int i = 0; i < numVehciles; i++)
                {
                    string one = dataVicles[i].NumberVechicle.ToString();
                    if (models[indexRow] is Truck)
                    {
                        string onet = ((VehicleTruck)(dataVicles[i])).NumberWheels.ToString();
                        string onef = ((VehicleTruck)(dataVicles[i])).VoluemBody.ToString();
                        dataGridViewCars.Rows.Add(one, onet, onef);
                    }
                    else if (models[indexRow] is Car)
                    {
                        string onet = ((VehicleCar)(dataVicles[i])).NameMultimedia.ToString();
                        string onef = ((VehicleCar)(dataVicles[i])).NumberAirbags.ToString();
                        dataGridViewCars.Rows.Add(one, onet, onef);
                    }
                }
            }
        }
        private List<IVehicle> Where (string str, List<IVehicle> vehicles)
        {
            List<IVehicle> returnList = new List<IVehicle>();

            for (int i = 0; i < vehicles.Count; i++)
            {
                if ((vehicles[i].NumberVechicle).StartsWith(str))
                {
                    returnList.Add(vehicles[i]);
                }
            
            }

            return returnList;
        }
        private void ControlProcess(int numberVeh, NetworkStream stream)
        {
            FormProgressBar formForProgress = new FormProgressBar(numberVeh, stream);
            formForProgress.ShowDialog();
        } 
        private void GetData(Model CurrentModel, int numberVeh, int typeVeh, int myPort)
        {
            // Create socket for data
            string localIpAddress = GetLocalIpAddress();
            int port = myPort + 10;
            IPEndPoint clientDataAdr = new IPEndPoint(IPAddress.Parse(localIpAddress), port);
            TcpListener listener = new TcpListener(clientDataAdr);

            listener.Start();

            AcceptData(listener, numberVeh, typeVeh, CurrentModel);
        }
        private string GetLocalIpAddress()
        {
            try
            {
                    // Получение имени хоста
                string hostName = Dns.GetHostName();

                    // Получение IP-адресов по имени хоста
                IPAddress[] addresses = Dns.GetHostEntry(hostName).AddressList;

                    // Возвращение первого IPv4 адреса (если такой есть)
                foreach (IPAddress address in addresses)
                {
                    if (address.AddressFamily == AddressFamily.InterNetwork)
                    {
                        return address.ToString();
                    }
                }

                return "IP-адрес не найден";
            }
            catch (Exception ex)
            {
                throw new Exception($"Ошибка при получении локального IP: {ex.Message}");
            }
        }
        private async void AcceptData(TcpListener listener, int numberVeh, int typeVeh, Model CurrentModel)
        {
            TcpClient dataServer = await listener.AcceptTcpClientAsync();
            // Обработка полученных данных
            HandleCommandsAndProgress(dataServer, numberVeh, typeVeh, CurrentModel);
            listener.Stop();
        }
        private void HandleCommandsAndProgress(TcpClient dataServer, int numberVeh, int typeVeh, Model CurrentModel)
        {
            try
            {
                NetworkStream stream = dataServer.GetStream();

                for (int i = 0; i < numberVeh; i++)
                {
                    //Получение данных о длине файла
                    byte[] lengthBytes = new byte[4];
                    stream.Read(lengthBytes, 0, lengthBytes.Length);
                    int jsonLength = BitConverter.ToInt32(lengthBytes, 0);

                    // Чтение JSON-объекта
                    byte[] jsonData = new byte[jsonLength];
                    stream.Read(jsonData, 0, jsonData.Length);

                    // Десериализация JSON-объекта
                    string jsonString = Encoding.UTF8.GetString(jsonData);

                    lock (CurrentModel.vehicles)
                    {
                        if (typeVeh == 1)
                        {
                            VehicleTruck receivedTruck = JsonConvert.DeserializeObject<VehicleTruck>(jsonString);
                            CurrentModel.vehicles.Add(receivedTruck);
                        }
                        else if (typeVeh == 2)
                        {
                            VehicleCar receivedCar = JsonConvert.DeserializeObject<VehicleCar>(jsonString);
                            CurrentModel.vehicles.Add(receivedCar);
                        }
                    }
                }
            }
            finally
            {
                dataServer.Close();
            }
        }
    }
}

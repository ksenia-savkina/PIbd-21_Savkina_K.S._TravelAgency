using System;
using System.Collections.Generic;
using System.Windows.Forms;
using TravelAgencyBusinessLogic.BindingModels;
using TravelAgencyBusinessLogic.BusinessLogics;
using TravelAgencyBusinessLogic.ViewModels;
using Unity;

namespace TravelAgencyView
{
    public partial class FormCreateOrder : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }

        private readonly TravelLogic _logicT;

        private readonly OrderLogic _logicO;

        private readonly ClientLogic _logicC;

        public int Id { set { id = value; } }

        private int? id;

        public FormCreateOrder(TravelLogic logicT, OrderLogic logicO, ClientLogic logicC)
        {
            InitializeComponent();
            _logicT = logicT;
            _logicO = logicO;
            _logicC = logicC;
        }

        private void comboBoxTravel_SelectedIndexChanged(object sender, EventArgs e)
        {
            CalcSum();
        }

        private void textBoxCount_TextChanged(object sender, EventArgs e)
        {
            CalcSum();
        }

        private void FormCreateOrder_Load(object sender, EventArgs e)
        {
            try
            {
                List<TravelViewModel> listTravels = _logicT.Read(null);
                List<ClientViewModel> listClients = _logicC.Read(null);
                if (listTravels != null)
                {
                    comboBoxTravel.DisplayMember = "TravelName";
                    comboBoxTravel.ValueMember = "Id";
                    comboBoxTravel.DataSource = listTravels;
                    comboBoxTravel.SelectedItem = null;
                }
                if (listClients != null)
                {
                    comboBoxClient.DisplayMember = "ClientFIO";
                    comboBoxClient.ValueMember = "Id";
                    comboBoxClient.DataSource = listClients;
                    comboBoxClient.SelectedItem = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CalcSum()
        {
            if (comboBoxTravel.SelectedValue != null && !string.IsNullOrEmpty(textBoxCount.Text))
            {
                try
                {
                    int id = Convert.ToInt32(comboBoxTravel.SelectedValue);
                    TravelViewModel travel = _logicT.Read(new TravelBindingModel { Id = id })?[0];
                    int count = Convert.ToInt32(textBoxCount.Text);
                    textBoxSum.Text = (count * travel?.Price ?? 0).ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxCount.Text))
            {
                MessageBox.Show("Заполните поле Количество", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (comboBoxTravel.SelectedValue == null)
            {
                MessageBox.Show("Выберите путёвку", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (comboBoxClient.SelectedValue == null)
            {
                MessageBox.Show("Выберите клиента", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                _logicO.CreateOrder(new CreateOrderBindingModel
                {
                    ClientId = Convert.ToInt32(comboBoxClient.SelectedValue),
                    TravelId = Convert.ToInt32(comboBoxTravel.SelectedValue),
                    Count = Convert.ToInt32(textBoxCount.Text),
                    Sum = Convert.ToDecimal(textBoxSum.Text)
                });
                MessageBox.Show("Сохранение прошло успешно", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
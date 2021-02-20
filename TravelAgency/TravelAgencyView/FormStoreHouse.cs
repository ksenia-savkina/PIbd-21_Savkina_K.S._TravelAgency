using System;
using System.Collections.Generic;
using System.Windows.Forms;
using TravelAgencyBusinessLogic.BindingModels;
using TravelAgencyBusinessLogic.BusinessLogics;
using TravelAgencyBusinessLogic.ViewModels;
using Unity;

namespace TravelAgencyView
{
    public partial class FormStoreHouse : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }

        public int Id { set { id = value; } }

        private readonly StoreHouseLogic logic;

        private int? id;

        private Dictionary<int, (string, int)> storeHouseComponents;

        public FormStoreHouse(StoreHouseLogic service)
        {
            InitializeComponent();
            this.logic = service;
        }

        private void FormStoreHouse_Load(object sender, EventArgs e)
        {
            if (id.HasValue)
            {
                try
                {
                    StoreHouseViewModel view = logic.Read(new StoreHouseBindingModel { Id = id.Value })?[0];
                    if (view != null)
                    {
                        textBoxName.Text = view.StoreHouseName;
                        textBoxResponsiblePersonFullName.Text = view.ResponsiblePersonFullName;
                        storeHouseComponents = view.StoreHouseComponents;
                        LoadData();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                storeHouseComponents = new Dictionary<int, (string, int)>();
            }
        }

        private void LoadData()
        {
            try
            {
                if (storeHouseComponents != null)
                {
                    dataGridView.Rows.Clear();
                    foreach (var sc in storeHouseComponents)
                    {
                        dataGridView.Rows.Add(new object[] { sc.Key, sc.Value.Item1, sc.Value.Item2 });
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxName.Text))
            {
                MessageBox.Show("Заполните название", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(textBoxResponsiblePersonFullName.Text))
            {
                MessageBox.Show("Заполните ФИО ответственного", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                logic.CreateOrUpdate(new StoreHouseBindingModel
                {
                    Id = id,
                    StoreHouseName = textBoxName.Text,
                    ResponsiblePersonFullName = textBoxResponsiblePersonFullName.Text,
                    StoreHouseComponents = storeHouseComponents
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
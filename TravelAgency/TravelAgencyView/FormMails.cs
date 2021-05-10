using System;
using System.Linq;
using System.Windows.Forms;
using TravelAgencyBusinessLogic.BusinessLogics;
using TravelAgencyBusinessLogic.ViewModels;
using Unity;

namespace TravelAgencyView
{
    public partial class FormMails : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }

        private readonly MailLogic logic;

        private readonly IndexViewModel index;

        public FormMails(MailLogic logic)
        {
            InitializeComponent();
            this.logic = logic;
            index = new IndexViewModel();
        }

        private void FormMails_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData(int page = 1)
        {
            try
            {
                var list = logic.Read(null);
                if (list != null)
                {
                    int pageSize = 13;
                    index.Messages = list.Skip((page - 1) * pageSize).Take(pageSize);
                    index.PageViewModel = new PageViewModel(list.Count, page, pageSize);
                    Program.ConfigGrid(index.Messages.ToList(), dataGridView);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonPrev_Click(object sender, EventArgs e)
        {
            if (index.PageViewModel.HasPreviousPage)
            {
                LoadData(index.PageViewModel.PageNumber - 1);
            }
            else
            {
                MessageBox.Show("Первая страница", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void buttonNext_Click(object sender, EventArgs e)
        {
            if (index.PageViewModel.HasNextPage)
            {
                LoadData(index.PageViewModel.PageNumber + 1);
            }
            else
            {
                MessageBox.Show("Последняя страница", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
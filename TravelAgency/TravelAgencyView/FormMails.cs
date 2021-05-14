using System;
using System.Linq;
using System.Windows.Forms;
using TravelAgencyBusinessLogic.BindingModels;
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

        private PageViewModel pageViewModel;

        public FormMails(MailLogic logic)
        {
            InitializeComponent();
            this.logic = logic;
        }

        private void FormMails_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData(int page = 1)
        {
            try
            {
                int pageSize = 13;
                var list = logic.GetMessagesForPage(new MessageInfoBindingModel
                {
                    Page = page,
                    PageSize = pageSize
                });
                if (list != null)
                {
                    pageViewModel = new PageViewModel(logic.Count(), page, pageSize, list);
                    dataGridView.DataSource = list;
                    dataGridView.Columns[0].Visible = false;
                    dataGridView.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }
                int pageStart = page < 3 ? 1 : page - 2;
                Button[] buttons = { buttonPage1, buttonPage2, buttonPage3, buttonPage4, buttonPage5 };
                for (int i = 0; i < buttons.Length; ++i)
                {
                    buttons[i].Show();
                    SetButtonPagetext(buttons[i], pageStart + i, pageViewModel.TotalPages);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonPrev_Click(object sender, EventArgs e)
        {
            if (pageViewModel.HasPreviousPage)
            {
                LoadData(pageViewModel.PageNumber - 1);
            }
            else
            {
                MessageBox.Show("Первая страница", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void buttonNext_Click(object sender, EventArgs e)
        {
            if (pageViewModel.HasNextPage)
            {
                LoadData(pageViewModel.PageNumber + 1);
            }
            else
            {
                MessageBox.Show("Последняя страница", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void SetButtonPagetext(Button button, int pageNumber, int totalPages)
        {
            if (pageNumber <= totalPages)
            {
                button.Text = pageNumber.ToString();
            }
            else
            {
                button.Hide();
            }
        }

        private void buttonPage_Click(object sender, EventArgs e)
        {
            LoadData(Convert.ToInt32(((Button)sender).Text));
        }

    }
}
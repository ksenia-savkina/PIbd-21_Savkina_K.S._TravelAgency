using System;
using System.Linq;
using System.Windows.Forms;
using TravelAgencyBusinessLogic.BindingModels;
using TravelAgencyBusinessLogic.BusinessLogics;
using Unity;

namespace TravelAgencyView
{
    public partial class FormMails : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }

        private readonly MailLogic logic;

        private readonly int messagesOnPage = 13;

        private int currentPage = 0;

        private bool hasNext = false;

        public FormMails(MailLogic logic)
        {
            InitializeComponent();
            this.logic = logic;
            if (messagesOnPage < 1)
            {
                messagesOnPage = 5;
            }
        }

        private void FormMails_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                var messages = logic.Read(new MessageInfoBindingModel
                {
                    SkippingMessages = currentPage * messagesOnPage,
                    TakingMessages = messagesOnPage + 1
                });
                hasNext = !(messages.Count() <= messagesOnPage);
                if (hasNext)
                {
                    buttonNext.Text = "Следующая " + (currentPage + 2);
                    buttonNext.Enabled = true;
                }
                else
                {
                    buttonNext.Text = "Следующая";
                    buttonNext.Enabled = false;
                }
                if (messages != null)
                {
                    Program.ConfigGrid(messages.Take(messagesOnPage).ToList(), dataGridView);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonPrev_Click(object sender, EventArgs e)
        {
            if ((currentPage - 1) >= 0)
            {
                currentPage--;
                textBoxPage.Text = (currentPage + 1).ToString();
                buttonNext.Enabled = true;
                buttonNext.Text = "Следующая " + (currentPage + 2);
                if (currentPage == 0)
                {
                    buttonPrev.Enabled = false;
                    buttonPrev.Text = "Предыдущая";
                }
                else
                {
                    buttonPrev.Text = "Предыдущая " + (currentPage);
                }
                LoadData();
            }
        }

        private void buttonNext_Click(object sender, EventArgs e)
        {
            if (hasNext)
            {
                currentPage++;
                textBoxPage.Text = (currentPage + 1).ToString();
                buttonPrev.Enabled = true;
                buttonPrev.Text = "Предыдущая " + (currentPage);
                LoadData();
            }
        }
    }
}
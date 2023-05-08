using Services.ServicesImp;

namespace DiaryApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            GroupServices service = new GroupServices(new Repository.Imp.GroupDAL());
            var v= service.GetAll();
        }
    }
}
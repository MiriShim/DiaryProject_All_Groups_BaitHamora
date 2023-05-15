using Services.ServiceAPI;
using Services.ServicesImp;

namespace DiaryApp
{
    public partial class Form1 : Form
    {
      
        private  readonly  IGroupService service; 
        public Form1(IGroupService gService)
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
          //   GroupServices service = new GroupServices(new Repository.Imp.GroupDAL() );
           // GroupServices service = new GroupServices(new Repository.Imp.GroupDAL());

            var v= service.GetAll();
        }
    }
}
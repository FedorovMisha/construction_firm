using System;
using System.Linq;
using System.Windows.Forms;
using ConstructionFirm.Bl;
using ConstructionFirm.Bl.Services;

namespace ConstructionFirm.Forms
{
    public partial class LoginForm : Form
    {
        private readonly ClientService _userService;

        public LoginForm(ClientService userService)
        {
            _userService = userService;
            InitializeComponent();

            Enum.GetValues(typeof(UserTypes)).Cast<UserTypes>().ToList().ForEach(x => comboBox1.Items.Add(x));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var types = comboBox1.SelectedItem as UserTypes?;
            switch (types)
            {
                case UserTypes.Client:
                {
                    var client = new Client {UserName = textBox1.Text};

                    if (!_userService.UserExists(textBox1.Text)) _userService.CreateNewUser(client);

                    var service = new OrderService();
                    GlobalState.Client = _userService.GetUser(textBox1.Text);
                    GlobalState.Client.OrderService = service;

                    new ClientForm(service).Show();

                    Hide();
                    break;
                }
                case UserTypes.Manager:
                {
                    var client = new Client {UserName = textBox1.Text};

                    if (!_userService.UserExists(textBox1.Text)) _userService.CreateNewUser(client);

                    var service = new OrderService();
                    GlobalState.Client = _userService.GetUser(textBox1.Text);
                    GlobalState.Client.OrderService = service;
                    
                    new ManagerForm(service).Show();
                    
                    Hide();
                    break;
                }
            }
        }
    }
}
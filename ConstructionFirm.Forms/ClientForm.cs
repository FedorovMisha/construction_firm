using System;
using System.Windows.Forms;
using ConstructionFirm.Bl;
using ConstructionFirm.Bl.Services;

namespace ConstructionFirm.Forms
{
    public partial class ClientForm : Form
    {
        public Client Client = GlobalState.Client;
        private OrderService _orderService;
        public ClientForm(OrderService orderService)
        {
            _orderService = orderService;
            InitializeComponent();
            Client.Load();
            label2.Text = Client.UserName;
            Client.Orders.ForEach(x => listBox1.Items.Add(x));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var order = new Order();
            order.Start = DateTime.Now;
            order.UserId = Client.Id;
            if (new OrderCreationForm(order).ShowDialog() == DialogResult.OK)
            {
                MessageBox.Show("ok");
                // _orderService.CreateOrder(order);
                Client.AddOrder(order);
                Update();
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBox2.Items.Clear();
            var item = listBox1.SelectedItem as Order;
            if (item == null) return;
            item.Phases.ForEach(x => listBox2.Items.Add(x));
            label3.Text = $"Order: {item.Id} \n {item.Start} - {item.End}";
        }

        private void Update()
        {
            listBox1.Items.Clear();
            listBox2.Items.Clear();
            label3.Text = "";
            label4.Text = "";
            Client.Orders.ForEach(x => listBox1.Items.Add(x));
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            var phase = listBox2.SelectedItem as Phase;

            if (phase == null) return;

            label4.Text = $"Phase: {phase.Id}\n - {phase.Start} - {phase.End}";
        }
    }
}
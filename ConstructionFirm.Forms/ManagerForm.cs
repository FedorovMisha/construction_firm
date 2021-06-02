using System;
using System.Windows.Forms;
using ConstructionFirm.Bl;
using ConstructionFirm.Bl.Services;

namespace ConstructionFirm.Forms
{
    public partial class ManagerForm : Form
    {

        private readonly OrderService _orderService;
        public ManagerForm(OrderService orderService)
        {
            _orderService = orderService;
            InitializeComponent();
            _orderService.GetAll().ForEach(x => listBox1.Items.Add(x));
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var order = listBox1.SelectedItem as Order;

            if (order == null) return;
            listBox2.Items.Clear();
            order.Phases.ForEach(x => listBox2.Items.Add(x));
            
            label1.Text = $"Order: {order.Id} \n {order.Start} - {order.End}";
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            var phase = listBox2.SelectedItem as Phase;
            
            if(phase == null) return;
            
            label2.Text = $"Phase: {phase.Id}\n - {phase.Start} - {phase.End}";
        }

        private void Update()
        {
            listBox1.Items.Clear();
            listBox2.Items.Clear();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var order = listBox1.SelectedItem as Order;

            if (order == null) return;
            
            var price = order.GetMaterialPrice();

            MessageBox.Show("Материалы заказаны: на сумму " + price);
        }
    }
}
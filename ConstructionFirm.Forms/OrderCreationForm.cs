using System;
using System.Windows.Forms;
using ConstructionFirm.Bl;

namespace ConstructionFirm.Forms
{
    public partial class OrderCreationForm : Form
    {
        private readonly Client _client = GlobalState.Client;
        private readonly Order _order;
        public OrderCreationForm(Order order)
        {
            _order = order;
            InitializeComponent();
        }

        private void Update()
        {
            listBox1.Items.Clear();
            listBox2.Items.Clear();
            
            _order.Materials.ForEach(x => listBox1.Items.Add(x));
            _order.Phases.ForEach(x => listBox2.Items.Add(x));
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _order.Phases.Add(new Phase(){Start = DateTime.Now, End = DateTime.Now.AddDays(new Random().Next()%210)});
            Update();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            _order.Materials.Add(new Material()
            {
                MaterialType = new MaterialType(){Body = "Тип-материала", Price = new Random().Next() % 2000},
                Count = 200,
            });
            
            Update();
        }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Vulcan
{
    public partial class Form1 : Form
    {
        private List<Product> Menu;
        private List<string> Cart;

        public Form1()
        {
            Menu = new List<Product>();
            Cart = new List<string>();
            InitializeComponent();
            Menu.Add(new Product { Name = "Pizza", Options = new List<string> { "vegetarian", "bianca" }, Price = 15.00 });
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox2.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox3.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox4.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox4.Items.Add("0894562789");
            comboBox4.Items.Add("Дупница");
            comboBox4.Items.Add("Долно нанагорнище 3");

            foreach (var item in Menu)
            {
                comboBox1.Items.Add(item.Name);
            }
        }

        // menu
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedText != "")
            {
                return;
            }
            else
            {
                comboBox2.Items.Clear();
                var selectedIndex = comboBox1.SelectedIndex;
                var options = Menu[selectedIndex].Options;
                foreach (var item in options)
                {
                    comboBox2.Items.Add(item);
                }
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            var selectedProduct = Menu[comboBox1.SelectedIndex];
            var selectedOption = Menu[comboBox1.SelectedIndex].Options[comboBox2.SelectedIndex];
            var result = selectedProduct.Name + " " + selectedOption + " " + selectedProduct.Price + "BGN";
            Cart.Add(result);
            comboBox3.Items.Add(result);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var selectedIndex = comboBox3.SelectedIndex;
            Cart.RemoveAt(selectedIndex);
            comboBox3.Items.RemoveAt(selectedIndex);
        }
    }
    public class Product
    {
        public string Name { get; set; }

        public double Price { get; set; }

        public List<string> Options { get; set; }
    }
}

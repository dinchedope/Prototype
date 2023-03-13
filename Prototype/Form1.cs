using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AirPlane;

namespace Prototype
{
    public partial class Form1 : Form
    {
        List<AirPlane.AirPlane> airplanes = new List<AirPlane.AirPlane>();
        List<BindingObj> bindings = new List<BindingObj>();
        List<TextBox> textBoxes;
        List<Label> labels = new List<Label>();
        dynamic currentAirPlane;
        public Form1()
        {
            InitializeComponent();
            AirPlane.AirPlane airplane = new AirPlane.AirPlane(2, 2, 2);
            airplanes.Add(airplane);
            bindings.Add(new BindingObj(airplane, "Deafault AirPlane"));


            ArmyAirPlane armyplane = new ArmyAirPlane(3, 3, 3);
            armyplane.ammo = new Ammo("aboba", 3);
            airplanes.Add(armyplane);
            bindings.Add(new BindingObj(armyplane, "Army AirPlane"));


            CargoAirPlane cargoplane = new CargoAirPlane(4, 4, 4);
            cargoplane.cargo = new Cargo(5, 5);
            airplanes.Add(cargoplane);
            bindings.Add(new BindingObj(cargoplane, "Cargo AirPlane"));

            textBoxes = new List<TextBox>();
            textBoxes.Add(textBox2);
            textBoxes.Add(textBox3);
            textBoxes.Add(textBox4);
            textBoxes.Add(textBox5);
            textBoxes.Add(textBox6);

            labels.Add(label1);
            labels.Add(label2);
            labels.Add(label3);
            labels.Add(label4);
            labels.Add(label5);

            label4.Enabled = false;
            textBox5.Enabled = false;
            label5.Enabled = false;
            textBox6.Enabled = false;

            RefreshComboBox(comboBox1, bindings);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            RefreshComboBox(comboBox1, bindings);
            PrintAllPlanes();
        }

        private void PrintAllPlanes()
        {
            textBox1.Text = "";
            foreach (var airplane in airplanes)
            {
                textBox1.Text += airplane.ToString() + Environment.NewLine; 
            }

        }

        private void RefreshComboBox(ComboBox cb, List<BindingObj> bindings)
        {
            cb.Items.Clear();
            foreach (var elem in bindings)
            {
                cb.Items.Add(elem.description);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            /*Type type = typeof(ArmyAirPlane);*/

            if (bindings[comboBox1.SelectedIndex].airPlane.GetType() == typeof(ArmyAirPlane))
            {
                currentAirPlane = (ArmyAirPlane)bindings[comboBox1.SelectedIndex].airPlane;
                textBox2.Text = currentAirPlane.clientPlaceCount.ToString();
                textBox3.Text = currentAirPlane.planeSize.ToString();
                textBox4.Text = currentAirPlane.fuelSize.ToString();

                label4.Text = "Ammo Desr.";
                textBox5.Text = currentAirPlane.ammo.Description;
                label5.Text = "Count";
                textBox6.Text = currentAirPlane.ammo.count.ToString();
                label4.Enabled = true;
                textBox5.Enabled = true;
                label5.Enabled = true;
                textBox6.Enabled = true;
            }
            else if (bindings[comboBox1.SelectedIndex].airPlane.GetType() == typeof(CargoAirPlane))
            {
                currentAirPlane = (CargoAirPlane)bindings[comboBox1.SelectedIndex].airPlane;
                textBox2.Text = currentAirPlane.clientPlaceCount.ToString();
                textBox3.Text = currentAirPlane.planeSize.ToString();
                textBox4.Text = currentAirPlane.fuelSize.ToString();

                label4.Text = "Weight";
                textBox5.Text = currentAirPlane.cargo.Weight.ToString();
                label5.Text = "Size";
                textBox6.Text = currentAirPlane.cargo.Size.ToString();
                label4.Enabled = true;
                textBox5.Enabled = true;
                label5.Enabled = true;
                textBox6.Enabled = true;
            }
            else
            {
                currentAirPlane = bindings[comboBox1.SelectedIndex].airPlane;
                textBox2.Text = currentAirPlane.clientPlaceCount.ToString();
                textBox3.Text = currentAirPlane.planeSize.ToString();
                textBox4.Text = currentAirPlane.fuelSize.ToString();
                label4.Text = "";
                label5.Text = "";
                label4.Enabled = false;
                textBox5.Enabled = false;
                label5.Enabled = false;
                textBox6.Enabled = false;
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            airplanes.Add(bindings[comboBox1.SelectedIndex].airPlane.ShallowCopy());
            bindings.Add(new BindingObj(airplanes[airplanes.Count - 1], $"{bindings[comboBox1.SelectedIndex].description} + shallowCopy"));
        }

        private void button2_Click(object sender, EventArgs e)
        {
            airplanes.Add(bindings[comboBox1.SelectedIndex].airPlane.DeepCopy());
            bindings.Add(new BindingObj(airplanes[airplanes.Count-1], $"{bindings[comboBox1.SelectedIndex].description} + copy"));
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            currentAirPlane.clientPlaceCount = Convert.ToInt32(textBox2.Text);
            currentAirPlane.planeSize = Convert.ToDouble(textBox3.Text);
            currentAirPlane.fuelSize = Convert.ToDouble(textBox4.Text);
            

            if (currentAirPlane.GetType() == typeof(ArmyAirPlane))
            {
                currentAirPlane.ammo.Description = textBox5.Text;
                currentAirPlane.ammo.count = Convert.ToInt32(textBox6.Text);
            }
            if (currentAirPlane.GetType() == typeof(CargoAirPlane))
            {
                currentAirPlane.cargo.Weight = Convert.ToDouble(textBox5.Text);
                currentAirPlane.cargo.Size = Convert.ToDouble(textBox6.Text);
            }
        }
    }
}

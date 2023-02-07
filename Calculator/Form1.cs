using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Calculator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button17_Click(object sender, EventArgs e)
        {

        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            this.screen.Text = "0";
        }

        private void AddNumber_Click(object sender, EventArgs e)
        {
            //pega o texto do botao
            Button buttonPressed = sender as Button;

            String currentText = this.screen.Text;


            //concatena com o já existente
            if (currentText == "0")
                currentText = "";
            
            this.screen.Text = currentText + buttonPressed.Text;

            if (currentText.Length >= 10)
                this.screen.Text = currentText;
        }

        private void RemoveLastNumber_Click(object sender, EventArgs e)
        {
            String currentText = this.screen.Text;
            if (currentText.Length == 1)
                this.screen.Text = "0";
            else
                this.screen.Text = currentText.Substring(0, currentText.Length - 1);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void AddOperation_Click(object sender, EventArgs e)
        {

            //definir operação atual
            Button buttonOperation = sender as Button;

            this.operator_label.Text = buttonOperation.Text;

            //passar numero atual para segundo plano

            this.backScreen.Text = this.screen.Text;
            this.screen.Text = "0";

        }

        private void EvaluateEquation_Click(object sender, EventArgs e) 
        {
            //computa a expressao
            String expression = this.backScreen.Text + " " +
                this.operator_label.Text + " " + 
                this.screen.Text;

            DataTable dt = new DataTable();
            var result = dt.Compute(expression, "");


            //escreve resultado

            this.screen.Text = result.ToString();
            this.backScreen.Text = string.Empty;
            this.operator_label.Text = string.Empty;


        }
    }
}

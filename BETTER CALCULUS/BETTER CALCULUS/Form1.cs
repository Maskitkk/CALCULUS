using System;

using System.Data;

using System.Windows.Forms;



namespace BETTER_CALCULUS
{

    public partial class CALCULUS : Form
    {
        private string currentCalculation = "";
        public CALCULUS()
        {
            KeyPreview = true;
            InitializeComponent();

        }


        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.NumPad0)
            {
                button0.PerformClick();
                return true;
            }
            else if (keyData == Keys.NumPad1) 
            { 
                 button1.PerformClick();
                return true;
            }
            else if (keyData == Keys.NumPad2)
            {
                button2.PerformClick();
                return true;
            }
            else if (keyData == Keys.NumPad3)
            {
                button3.PerformClick();
                return true;
            }
            else if (keyData == Keys.NumPad4)
            {
                button4.PerformClick();
                return true;
            }
            else if (keyData == Keys.NumPad5)
            {
                button5.PerformClick();
                return true;
            }
            else if (keyData == Keys.NumPad6)
            {
                button6.PerformClick();
                return true;
            }
            else if (keyData == Keys.NumPad7)
            {
                button7.PerformClick();
                return true;
            }
            else if (keyData == Keys.NumPad8)
            {
                button8.PerformClick();
                return true;
            }
            else if (keyData == Keys.NumPad9)
            {
                button9.PerformClick();
                return true;
            }
            else if (keyData == Keys.Decimal)
            {
                buttonDecimal.PerformClick();
                return true;
            }
            else if (keyData == Keys.Enter)
            {
                buttonEquals.PerformClick();
                return true;
            }
            else if (keyData == Keys.Divide)
            {
                buttonDivision.PerformClick();
                return true;
            }
            else if (keyData == Keys.Add)
            {
                buttonAdd.PerformClick();
                return true;
            }
            else if (keyData == Keys.Subtract)
            {
                buttonSubtraction.PerformClick();
                return true;
            }
            else if (keyData == Keys.Multiply)
            {
                buttonMultiplication.PerformClick();
                return true;
            }
            else if (keyData == Keys.Back)
            {
                buttonClearEntry.PerformClick();
                return true;
            }
            else if (keyData == Keys.Delete)
            {
                buttonClear.PerformClick();
                return true;
            }
            else if (keyData == Keys.D9)
            {
                buttonLeftBracket.PerformClick();
                return true;
            }
            else if (keyData == Keys.D0)
            {
                buttonRightBracket.PerformClick();
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button_Click (object sender, EventArgs e) 
        {
            //Добавляет число или оператор к вычислению
            currentCalculation += (sender as Button).Text;
            //Выводит вычисление пользователю
            textBoxOutput.Text = currentCalculation;
        }

        private void button_Equals_Click (object sender, EventArgs e) 
        {
            //Заменяет Х на * и ÷ на / для вычислений
            string formattedCalculation = currentCalculation.ToString().Replace("x", "*").ToString().Replace("÷", "/").ToString().Replace("–", "-");
            
           //Этот блок непосредственно осуществляет вычисление с помощью функции Compute
            try
            {
                textBoxOutput.Text = new DataTable().Compute(formattedCalculation, null).ToString();
                currentCalculation = textBoxOutput.Text;
            }
            //Этот блок выведет 0 в случае, если пользователь введёт некорректное вычисление
            catch (Exception)  
            {
                textBoxOutput.Text = "0";
                currentCalculation = "";
            }
        }
        private void button_Clear_Click (object sender, EventArgs e) 
        {
            //Сбрасывает вычисление и чистит поле
            textBoxOutput.Text = "0";
            currentCalculation = "";
        }

        private void button_Clear_Entry_Click(object sender, EventArgs e)
        {
            //Если поле не пустое - удаляет последнюю введённую цифру или оператор
            if (currentCalculation.Length > 0) 
            {
                
                currentCalculation = currentCalculation.Remove(currentCalculation.Length - 1, 1);
                
                //Снова выводит вычисление на экран
                textBoxOutput.Text = currentCalculation;
            }
        }

        //Блок вычисления квадратного корня      
        private void buttonSquareRoot_Click(object sender, EventArgs e)
        {
            //Получение числа из поля 
            if (double.TryParse(textBoxOutput.Text, out double num))
            { 
            //Проверка не отрицательное ли оно
                if (num >= 0) 
                { 
                //Вычисление квадратного корня и вывод вычисления
                    double squareRoot = Math.Sqrt(num);
                    textBoxOutput.Text = squareRoot.ToString();
                }
            else 
                {   
                 textBoxOutput.Text = "0";
                 currentCalculation = "";
                
                }
            }
            else
            { 
                textBoxOutput.Text = "0";
                currentCalculation = "";
            
            }
        }

        //Блок возведения в квадратный корень (всё по аналогии с вычислением кк) 
        private void buttonSquaring_Click(object sender, EventArgs e) 
        {
            if (double.TryParse(textBoxOutput.Text, out double num))
            { 
            double squaring = Math.Pow(num, 2);
             textBoxOutput.Text = squaring.ToString();
            }
            else 
            { 
                textBoxOutput.Text = "0";
                currentCalculation = "";
            
            }
        }
      

    }
}

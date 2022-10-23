using System;
using System.Windows;
using System.Windows.Controls;

namespace WPF_Calculator;

public partial class MainWindow : Window
{
	byte countCommand, countAdd, countNegative, countMultiply, countDivide, countMinus, countSqrt = 0;

	Calculator calculator = new Calculator();

	public MainWindow()
	{
		InitializeComponent();
	}

	private void Button_Click(object sender, RoutedEventArgs e)
	{
		if (txtB_result.Text == "Invalid input")
		{
			btn_divide.IsEnabled = true;
			btn_minus.IsEnabled = true;
			btn_multi.IsEnabled = true;
			btn_sqrt.IsEnabled = true;
			btn_operation.IsEnabled = true;
			btn_comman.IsEnabled = true;
			btn_negative.IsEnabled = true;
			btn_doublemulti.IsEnabled = true;
			btn_fraction.IsEnabled = true;
		}

		if (calculator.Visual)
			txtB_result.Text = null;
		
		if (sender is Button btn)
		{
			if (txtB_result.Text == "0" || txtB_result.Text == "-0") 
				txtB_result.Text = btn.Content.ToString();
			else
				txtB_result.Text += btn.Content;
		}
		
		if (calculator.Visual)
			calculator.X = Convert.ToDouble(txtB_result.Text);

		calculator.Visual = false;
	}

	private void btn_comman_Click(object sender, RoutedEventArgs e)
	{
		if (countCommand == 0)
		{
			txtB_result.Text += ".";
			++countCommand;
		}
	}

	private void btn_removeall_Click(object sender, RoutedEventArgs e)
	{
		if (txtB_result.Text == "Invalid input")
		{
			btn_divide.IsEnabled = true;
			btn_minus.IsEnabled = true;
			btn_multi.IsEnabled = true;
			btn_sqrt.IsEnabled = true;
			btn_operation.IsEnabled = true;
			btn_comman.IsEnabled = true;
			btn_negative.IsEnabled = true;
			btn_doublemulti.IsEnabled = true;
			btn_fraction.IsEnabled = true;
		}

		txtB_result.Text = null;
		countCommand = 0;
		countNegative = 0;
	}

	private void btn_deleteone_Click(object sender, RoutedEventArgs e)
	{
		if (txtB_result.Text.Length == 1)
			txtB_result.Text = "0";
		else
		{
			txtB_result.Text = txtB_result.Text.Remove(txtB_result.Text.Length - 1, 1);

			if (txtB_result.Text[txtB_result.Text.Length - 1] == '.')
			{
				txtB_result.Text = txtB_result.Text.Remove(txtB_result.Text.Length - 1, 1);
				countCommand = 0;
			}
			if (txtB_result.Text[txtB_result.Text.Length - 1] == '-')
			{
				txtB_result.Text = txtB_result.Text.Remove(txtB_result.Text.Length - 1, 1);
				countCommand = 0;
			}
		}
	}

	private void btn_negative_Click(object sender, RoutedEventArgs e)
	{
		if (countCommand == 0)
		{
			txtB_result.Text = txtB_result.Text.Insert(0, "-");
			++countCommand;
		}
		else if (countNegative == 1)
		{
			txtB_result.Text = txtB_result.Text.Remove(0, 1);
			countNegative = 0;
		}
	}

	private void btn_operation_Click(object sender, RoutedEventArgs e)
	{
		if (sender is Button btn)
		{
			if (btn.Content.ToString() == "+")
			{
				calculator.ResultCopy = Convert.ToDouble(txtB_result.Text);
				calculator.Symbol = "+";
				calculator.Visual = true;
				countCommand = 0;
				countNegative = 0;
				countAdd = 0;
			}
			else if (btn.Content.ToString() == "-")
			{
				calculator.ResultCopy = Convert.ToDouble(txtB_result.Text);
				calculator.Symbol = "-";
				calculator.Visual = true;
				countCommand = 0;
				countNegative = 0;
				countMinus = 0;
			}
			else if (btn.Content.ToString() == "x")
			{
				calculator.ResultCopy = Convert.ToDouble(txtB_result.Text);
				calculator.Symbol = "x";
				calculator.Visual = true;
				countCommand = 0;
				countNegative = 0;
				countMultiply = 0;

			}
			else if (btn.Content.ToString() == "÷")
			{
				calculator.ResultCopy = Convert.ToDouble(txtB_result.Text);
				calculator.Symbol = "÷";
				calculator.Visual = true;
				countCommand = 0;
				countNegative = 0;
				countDivide = 0;
			}
			else if (btn.Content.ToString() == "x²")
			{
				calculator.Visual = true;
				countCommand = 0;
				countNegative = 0;
				calculator.ResultCopy = Convert.ToDouble(txtB_result.Text);

				txtB_result.Text = (calculator.ResultCopy * calculator.ResultCopy).ToString();
			}
			else if (btn.Content.ToString() == "√х")
			{
				calculator.Visual = true;
				countCommand = 0;
				countNegative = 0;

				calculator.ResultCopy = Convert.ToDouble(txtB_result.Text);

				if (calculator.ResultCopy > 0)
					txtB_result.Text = Math.Sqrt(calculator.ResultCopy).ToString();
				else if (calculator.ResultCopy < 0)
				{
					txtB_result.Text = "Invalid input";
					btn_divide.IsEnabled = false;
					btn_minus.IsEnabled = false;
					btn_multi.IsEnabled = false;
					btn_sqrt.IsEnabled = false;
					btn_operation.IsEnabled = false;
					btn_comman.IsEnabled = false;
					btn_negative.IsEnabled = false;
					btn_doublemulti.IsEnabled = false;
					btn_fraction.IsEnabled = false;
				}
			}
		}
	}

	private void Result_Click(object sender, RoutedEventArgs e)
	{
		if (txtB_result.Text == "Invalid input")
		{
			btn_divide.IsEnabled = true;
			btn_minus.IsEnabled = true;
			btn_multi.IsEnabled = true;
			btn_sqrt.IsEnabled = true;
			btn_operation.IsEnabled = true;
			btn_comman.IsEnabled = true;
			btn_negative.IsEnabled = true;
			btn_doublemulti.IsEnabled = true;
			btn_fraction.IsEnabled = true;
			txtB_result.Text = "0";
		}

		++countAdd;
		++countMinus;
		++countMultiply;
		++countDivide;
		++countSqrt;

		calculator.Result = Convert.ToDouble(txtB_result.Text);

		if (calculator.Symbol == "+")
		{
			if (countAdd == 1)
				txtB_result.Text = (calculator.ResultCopy + calculator.Result).ToString();
			else if (countAdd != 1)
				txtB_result.Text = (calculator.X + calculator.Result).ToString();
		}
		else if (calculator.Symbol == "-")
		{
			if (countMinus == 1)
				txtB_result.Text = (calculator.ResultCopy - calculator.Result).ToString();
			else if (countMinus != 1)
				txtB_result.Text = (calculator.Result - calculator.X).ToString();
		}
		else if (calculator.Symbol == "x")
		{
			if (countMultiply == 1)
				txtB_result.Text = (calculator.ResultCopy * calculator.Result).ToString();
			else if (countMultiply != 1)
				txtB_result.Text = (calculator.X * calculator.Result).ToString();
		}
		else if (calculator.Symbol == "÷")
		{
			if (countDivide == 1)
			{
				if (calculator.Result == 0)
					MessageBox.Show("Error...", "", MessageBoxButton.OK, MessageBoxImage.Error);
				else 
					txtB_result.Text = (calculator.ResultCopy / calculator.Result).ToString();
			}
			else if (countDivide != 1)
			{
				if (calculator.X == 0)
					MessageBox.Show("Error...", "", MessageBoxButton.OK, MessageBoxImage.Error);
				else 
					txtB_result.Text = (calculator.Result / calculator.X).ToString();
			}
		}
	}
}
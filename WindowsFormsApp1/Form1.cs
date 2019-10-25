using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        #region khai bao bien
        double giatri1 ;
        private string temp;
        double kq;
        string text = "";
        bool check = false;
        double value;
        int Opt = 0;
        
        public System.Globalization.CultureInfo culture = new System.Globalization.CultureInfo("en-US");
        #endregion

        #region cac ham tao
        public void FormatText()
        {

            if (txtKetQua.Text != null)
            {
                value = double.Parse(txtKetQua.Text);
                txtKetQua.Text = String.Format(culture, "{0:#,##0.#########}", value);
                txtKetQua.Text.ToString();
            }
        }
        public void DkZero()
        {
            txtKetQua.ReadOnly = false;
            btncong.Enabled = true;
            btntru.Enabled = true;
            btnnhan.Enabled = true;
            btnchia.Enabled = true;
            btnbang.Enabled = true;
            btnNegative.Enabled = true;
            btnDot.Enabled = true;
            txtKetQua.Clear();
            lblgiatri.Text = "0";
        }
        #endregion
        public Form1()
        {
            InitializeComponent();

        }
        

        #region Tinh
        private void setOperator(int operation)
        {
            if(giatri1 != 0 || giatri1 >= 0 || giatri1 <= 0)
            {
                btnbang.PerformClick();
               
            }
            giatri1 = double.Parse(txtKetQua.Text);
            temp = string.Format(culture, "{0:#,0.#########}", giatri1);
            lblgiatri.Text = temp;
            txtKetQua.Text = "0";

            btnbang.Select();

            check = false;
            Opt = operation;
            
        }
       
        private void btnbang_Click(object sender, EventArgs e)
        {
            ketqua();
            
        }
        public void ketqua()
        {
           
            switch (Opt)
            {
                case 1:
                    kq = (giatri1 + double.Parse(txtKetQua.Text));
                    FormatKQ();
                    break;
                case 2:
                    kq = (giatri1 - double.Parse(txtKetQua.Text));
                    FormatKQ();
                    break;
                case 3:
                    kq = (giatri1 * double.Parse(txtKetQua.Text));
                    FormatKQ();
                    break;
                case 4:
                    if (txtKetQua.Text != "0")
                    {
                        kq = (giatri1 / double.Parse(txtKetQua.Text));
                        FormatKQ();                        
                    }
                    else
                    {
                        txtKetQua.Text = "Can't div zero";
                        txtKetQua.ReadOnly = true;
                        btncong.Enabled = false;
                        btntru.Enabled = false;
                        btnnhan.Enabled = false;
                        btnchia.Enabled = false;
                        btnbang.Enabled = false;
                        btnNegative.Enabled = false;
                        btnDot.Enabled = false;
                    }
                    break;
            }
            Opt = 0;
        }
        public void FormatKQ()
        {
            giatri1 = 0;
            lblgiatri.Text = giatri1.ToString();
            txtKetQua.Text = string.Format(culture, "{0:#,0.#########}", kq);
            kq.ToString();
        }

        private void btncong_Click(object sender, EventArgs e)
        {
            setOperator(1);
        }
        private void btnchia_Click(object sender, EventArgs e)
        {
            setOperator(4);
        }

        private void btnnhan_Click(object sender, EventArgs e)
        {
            setOperator(3);
        }

        private void btntru_Click(object sender, EventArgs e)
        {
            setOperator(2);
        }


        #endregion
        
        #region SCkey
        private void keycode(object sender, KeyPressEventArgs e)
        {
            int code = e.KeyChar;
            switch (code)
            {

                case 48:
                    btn0_Click(sender, e);
                    break;
                case 49:
                    btn1_Click(sender, e);
                    break;
                case 50:
                    btn2_Click(sender, e);
                    break;
                case 51:
                    btn3_Click(sender, e);
                    break;
                case 52:
                    btn4_Click(sender, e);
                    break;
                case 53:
                    btn5_Click(sender, e);
                    break;
                case 54:
                    btn6_Click(sender, e);
                    break;
                case 55:
                    btn7_Click(sender, e);
                    break;
                case 56:
                    btn8_Click(sender, e);
                    break;
                case 57:
                    btn9_Click(sender, e);
                    break;
                case 46:
                    btnDot_Click(sender, e);
                    break;
                case 8:
                    btnBackspace_Click(sender, e);
                    break;
                case 27:
                    btnClear_Click(sender, e);
                    break;
                case 43:
                    btncong_Click(sender, e);
                    break;
                case 45:
                    btntru_Click(sender, e);
                    break;
                case 42:
                    btnnhan_Click(sender, e);
                    break;
                case 47:
                    btnchia_Click(sender, e);
                    break;
                case 32:
                    btnCE_Click(sender, e);
                    break;

            }
        }

        #endregion

        #region Number
        public void setText(string textset)
        {
            if(txtKetQua.Text == "Can't div zero")
            {
                DkZero();                
            }

            if (txtKetQua.Text == "0")
            {
                txtKetQua.Clear();
            }

            check = false;

            if (textset == ".")
            {
                if (!txtKetQua.Text.Contains("."))
                {
                    txtKetQua.Text = txtKetQua.Text +  textset;
                }                
            }
            
            else if (txtKetQua.Text.Length < 17)
            {
                txtKetQua.Text += textset;
                //FormatText();
            }            
            
            btnbang.Select();
        }

       
        private void btn8_Click(object sender, EventArgs e)
        {
            setText("8");
        }

        private void btn9_Click(object sender, EventArgs e)
        {
            setText("9");
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            setText("5");
        }

        private void btn6_Click(object sender, EventArgs e)
        {
            setText("6");
        }

        private void btn7_Click(object sender, EventArgs e)
        {
            setText("7");
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            setText("4");
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            setText("3");
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            setText("2");
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            setText("1");
        }

        private void btn0_Click(object sender, EventArgs e)
        {
            setText("0");
        }

        private void btnDot_Click(object sender, EventArgs e)
        {
            setText(".");
        }

        #endregion

        #region Xoa
        private void btnBackspace_Click(object sender, EventArgs e)
        {
            if(txtKetQua.Text == "Can't div zero")
            {
                DkZero();
                lblgiatri.Text = "0";
                txtKetQua.Text = "0";
            }

            else if (txtKetQua.Text.Length != 0)
            {
                if (txtKetQua.Text != "0")
                {
                    txtKetQua.Text = txtKetQua.Text.Remove(txtKetQua.Text.Length - 1, 1);
                }
               
            }

            else
            {
                txtKetQua.Text = "0";
            }

            
            btnBackspace.Select();
            
        }
        private void btnClear_Click(object sender, EventArgs e)
        {
            giatri1 = 0;
            txtKetQua.Clear();
            txtKetQua.Text = giatri1.ToString();
            lblgiatri.Text = giatri1.ToString();
            Opt = 0;
            DkZero();
            btnClear.Select();
        }
        private void btnCE_Click(object sender, EventArgs e)
        {
            if(txtKetQua.Text == "Can't div zero")
            {
                DkZero();
            }
            txtKetQua.Clear();
            txtKetQua.Text = "0";
            DkZero();
            btnCE.Select();
        }
        #endregion

        #region changeNumber

        private void btnNegative_Click(object sender, EventArgs e)
        {
            if (txtKetQua.Text.Length != 0)
            {
                value = double.Parse(txtKetQua.Text);
                value *= -1;
                txtKetQua.Text = string.Format(culture, "{0:#,0.#########}", value).ToString();
            }
            btnbang.Select();
        }
        
        #endregion

        #region Textbox
        private void txtKetQua_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
            
        }
        
        private void txtKetQua_KeyUp(object sender, KeyEventArgs e)
        {
            
            if (!string.IsNullOrEmpty(txtKetQua.Text))
            {                
                try
                {
                    value = Double.Parse(txtKetQua.Text);
                    txtKetQua.Text = String.Format(culture, "{0:#,0.#########}", value);
                    txtKetQua.Select(txtKetQua.Text.Length, 0);
                }
                catch
                {
                    txtKetQua.Text = String.Format(culture, "{0:#,0.#########}", value);
                    txtKetQua.Select(txtKetQua.Text.Length, 0);
                }
            }
        }


        #endregion

        private void txtKetQua_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

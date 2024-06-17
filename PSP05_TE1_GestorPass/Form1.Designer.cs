namespace PSP05_TE1_GestorPass
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            textBox1 = new TextBox();
            label3 = new Label();
            label4 = new Label();
            checkBox1 = new CheckBox();
            checkBox2 = new CheckBox();
            label1 = new Label();
            textBox2 = new TextBox();
            label2 = new Label();
            label5 = new Label();
            button3 = new Button();
            label6 = new Label();
            comboBox1 = new ComboBox();
            button4 = new Button();
            label7 = new Label();
            textBox3 = new TextBox();
            label8 = new Label();
            textBox4 = new TextBox();
            groupBox1 = new GroupBox();
            groupBox2 = new GroupBox();
            button5 = new Button();
            groupBox3 = new GroupBox();
            comboBox2 = new ComboBox();
            button6 = new Button();
            label10 = new Label();
            checkBox3 = new CheckBox();
            openFileDialog1 = new OpenFileDialog();
            groupBox4 = new GroupBox();
            label9 = new Label();
            textBox5 = new TextBox();
            button1 = new Button();
            radioButton2 = new RadioButton();
            radioButton1 = new RadioButton();
            saveFileDialog1 = new SaveFileDialog();
            button2 = new Button();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox3.SuspendLayout();
            groupBox4.SuspendLayout();
            SuspendLayout();
            // 
            // textBox1
            // 
            textBox1.Location = new Point(109, 35);
            textBox1.Margin = new Padding(3, 2, 3, 2);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(205, 27);
            textBox1.TabIndex = 2;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 254);
            label3.Location = new Point(32, 40);
            label3.Name = "label3";
            label3.Size = new Size(64, 17);
            label3.TabIndex = 5;
            label3.Text = "Usuario";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 254);
            label4.Location = new Point(28, 26);
            label4.Name = "label4";
            label4.Size = new Size(227, 34);
            label4.TabIndex = 6;
            label4.Text = "El usuario indicado no existe: \r\n¿desea registrarlo?";
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Enabled = false;
            checkBox1.Location = new Point(36, 80);
            checkBox1.Margin = new Padding(4, 5, 4, 5);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(172, 24);
            checkBox1.TabIndex = 7;
            checkBox1.Text = "Visualizar Contraseña";
            checkBox1.UseVisualStyleBackColor = true;
            checkBox1.CheckedChanged += checkBox1_CheckedChanged;
            // 
            // checkBox2
            // 
            checkBox2.AutoSize = true;
            checkBox2.Enabled = false;
            checkBox2.Location = new Point(36, 115);
            checkBox2.Margin = new Padding(4, 5, 4, 5);
            checkBox2.Name = "checkBox2";
            checkBox2.Size = new Size(168, 24);
            checkBox2.TabIndex = 8;
            checkBox2.Text = "Registrar Contraseña";
            checkBox2.UseVisualStyleBackColor = true;
            checkBox2.CheckedChanged += checkBox2_CheckedChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(76, 135);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(151, 20);
            label1.TabIndex = 9;
            label1.Text = "Esta es su contraseña:";
            // 
            // textBox2
            // 
            textBox2.Location = new Point(237, 131);
            textBox2.Margin = new Padding(4, 5, 4, 5);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(483, 27);
            textBox2.TabIndex = 10;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(44, 82);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(191, 20);
            label2.TabIndex = 11;
            label2.Text = "Registre el fichero de clave:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(100, 40);
            label5.Margin = new Padding(4, 0, 4, 0);
            label5.Name = "label5";
            label5.Size = new Size(136, 20);
            label5.TabIndex = 12;
            label5.Text = "Elija la descripción:";
            // 
            // button3
            // 
            button3.Location = new Point(237, 79);
            button3.Margin = new Padding(3, 2, 3, 2);
            button3.Name = "button3";
            button3.Size = new Size(133, 32);
            button3.TabIndex = 13;
            button3.Text = "Fichero";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(383, 79);
            label6.Margin = new Padding(4, 5, 4, 5);
            label6.Name = "label6";
            label6.Size = new Size(152, 20);
            label6.TabIndex = 14;
            label6.Text = "Ubicación del Fichero";
            // 
            // comboBox1
            // 
            comboBox1.AccessibleRole = AccessibleRole.None;
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(237, 28);
            comboBox1.Margin = new Padding(4, 5, 4, 5);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(483, 28);
            comboBox1.TabIndex = 15;
            comboBox1.DropDown += comboBox1_DroppedDown;
            // 
            // button4
            // 
            button4.Location = new Point(321, 35);
            button4.Margin = new Padding(3, 2, 3, 2);
            button4.Name = "button4";
            button4.Size = new Size(144, 32);
            button4.TabIndex = 16;
            button4.Text = "Registrar";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(145, 34);
            label7.Margin = new Padding(4, 0, 4, 0);
            label7.Name = "label7";
            label7.Size = new Size(90, 20);
            label7.TabIndex = 17;
            label7.Text = "Descripción:";
            // 
            // textBox3
            // 
            textBox3.Location = new Point(237, 34);
            textBox3.Margin = new Padding(4, 5, 4, 5);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(483, 27);
            textBox3.TabIndex = 18;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(145, 100);
            label8.Margin = new Padding(4, 0, 4, 0);
            label8.Name = "label8";
            label8.Size = new Size(86, 20);
            label8.TabIndex = 19;
            label8.Text = "Contraseña:";
            // 
            // textBox4
            // 
            textBox4.Location = new Point(237, 95);
            textBox4.Margin = new Padding(4, 5, 4, 5);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(483, 27);
            textBox4.TabIndex = 20;
            textBox4.UseSystemPasswordChar = true;
            // 
            // groupBox1
            // 
            groupBox1.BackColor = SystemColors.ActiveCaption;
            groupBox1.Controls.Add(comboBox1);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(button3);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(textBox2);
            groupBox1.Controls.Add(label1);
            groupBox1.Enabled = false;
            groupBox1.Location = new Point(16, 205);
            groupBox1.Margin = new Padding(4, 5, 4, 5);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(4, 5, 4, 5);
            groupBox1.Size = new Size(749, 181);
            groupBox1.TabIndex = 21;
            groupBox1.TabStop = false;
            groupBox1.Text = "Visualizar";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(button5);
            groupBox2.Controls.Add(textBox4);
            groupBox2.Controls.Add(label8);
            groupBox2.Controls.Add(textBox3);
            groupBox2.Controls.Add(label7);
            groupBox2.Enabled = false;
            groupBox2.Location = new Point(16, 395);
            groupBox2.Margin = new Padding(4, 5, 4, 5);
            groupBox2.Name = "groupBox2";
            groupBox2.Padding = new Padding(4, 5, 4, 5);
            groupBox2.Size = new Size(749, 200);
            groupBox2.TabIndex = 22;
            groupBox2.TabStop = false;
            groupBox2.Text = "Registrar";
            // 
            // button5
            // 
            button5.Location = new Point(237, 146);
            button5.Margin = new Padding(3, 2, 3, 2);
            button5.Name = "button5";
            button5.Size = new Size(133, 32);
            button5.TabIndex = 23;
            button5.Text = "Guardar";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(comboBox2);
            groupBox3.Controls.Add(button6);
            groupBox3.Controls.Add(label10);
            groupBox3.Enabled = false;
            groupBox3.Location = new Point(16, 605);
            groupBox3.Margin = new Padding(4, 5, 4, 5);
            groupBox3.Name = "groupBox3";
            groupBox3.Padding = new Padding(4, 5, 4, 5);
            groupBox3.Size = new Size(749, 131);
            groupBox3.TabIndex = 22;
            groupBox3.TabStop = false;
            groupBox3.Text = "Borrar";
            // 
            // comboBox2
            // 
            comboBox2.FormattingEnabled = true;
            comboBox2.Location = new Point(237, 29);
            comboBox2.Margin = new Padding(4, 5, 4, 5);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(483, 28);
            comboBox2.TabIndex = 15;
            comboBox2.DropDown += comboBox2_DroppedDown;
            // 
            // button6
            // 
            button6.Location = new Point(237, 80);
            button6.Margin = new Padding(3, 2, 3, 2);
            button6.Name = "button6";
            button6.Size = new Size(133, 32);
            button6.TabIndex = 13;
            button6.Text = "Borrar";
            button6.UseVisualStyleBackColor = true;
            button6.Click += button6_Click;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(100, 41);
            label10.Margin = new Padding(4, 0, 4, 0);
            label10.Name = "label10";
            label10.Size = new Size(136, 20);
            label10.TabIndex = 12;
            label10.Text = "Elija la descripción:";
            // 
            // checkBox3
            // 
            checkBox3.AutoSize = true;
            checkBox3.Enabled = false;
            checkBox3.Location = new Point(36, 152);
            checkBox3.Margin = new Padding(4, 5, 4, 5);
            checkBox3.Name = "checkBox3";
            checkBox3.Size = new Size(150, 24);
            checkBox3.TabIndex = 7;
            checkBox3.Text = "Borrar Contraseña";
            checkBox3.UseVisualStyleBackColor = true;
            checkBox3.CheckedChanged += checkBox3_CheckedChanged;
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            // 
            // groupBox4
            // 
            groupBox4.Controls.Add(label9);
            groupBox4.Controls.Add(textBox5);
            groupBox4.Controls.Add(button1);
            groupBox4.Controls.Add(radioButton2);
            groupBox4.Controls.Add(radioButton1);
            groupBox4.Controls.Add(label4);
            groupBox4.Enabled = false;
            groupBox4.Location = new Point(485, 0);
            groupBox4.Margin = new Padding(4, 5, 4, 5);
            groupBox4.Name = "groupBox4";
            groupBox4.Padding = new Padding(4, 5, 4, 5);
            groupBox4.Size = new Size(293, 195);
            groupBox4.TabIndex = 23;
            groupBox4.TabStop = false;
            groupBox4.Text = "Registro Usuario";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(8, 118);
            label9.Margin = new Padding(4, 0, 4, 0);
            label9.Name = "label9";
            label9.Size = new Size(49, 20);
            label9.TabIndex = 16;
            label9.Text = "Email:";
            // 
            // textBox5
            // 
            textBox5.Location = new Point(64, 115);
            textBox5.Margin = new Padding(3, 2, 3, 2);
            textBox5.Name = "textBox5";
            textBox5.Size = new Size(193, 27);
            textBox5.TabIndex = 25;
            // 
            // button1
            // 
            button1.Location = new Point(52, 155);
            button1.Margin = new Padding(3, 2, 3, 2);
            button1.Name = "button1";
            button1.Size = new Size(133, 32);
            button1.TabIndex = 16;
            button1.Text = "Aceptar";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // radioButton2
            // 
            radioButton2.AutoSize = true;
            radioButton2.Checked = true;
            radioButton2.Location = new Point(120, 81);
            radioButton2.Margin = new Padding(4, 5, 4, 5);
            radioButton2.Name = "radioButton2";
            radioButton2.Size = new Size(50, 24);
            radioButton2.TabIndex = 25;
            radioButton2.TabStop = true;
            radioButton2.Text = "No";
            radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            radioButton1.AutoSize = true;
            radioButton1.Location = new Point(67, 81);
            radioButton1.Margin = new Padding(4, 5, 4, 5);
            radioButton1.Name = "radioButton1";
            radioButton1.Size = new Size(42, 24);
            radioButton1.TabIndex = 24;
            radioButton1.Text = "Si";
            radioButton1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            button2.Location = new Point(668, 745);
            button2.Margin = new Padding(4, 5, 4, 5);
            button2.Name = "button2";
            button2.Size = new Size(139, 35);
            button2.TabIndex = 24;
            button2.Text = "Guardar y Cerrar";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(823, 799);
            Controls.Add(button2);
            Controls.Add(groupBox4);
            Controls.Add(groupBox3);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(checkBox3);
            Controls.Add(button4);
            Controls.Add(checkBox2);
            Controls.Add(label3);
            Controls.Add(textBox1);
            Controls.Add(checkBox1);
            Margin = new Padding(3, 2, 3, 2);
            Name = "Form1";
            Text = "UD05 Gestor Password";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            groupBox4.ResumeLayout(false);
            groupBox4.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.CheckBox checkBox3;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.Label label9;
    }
}

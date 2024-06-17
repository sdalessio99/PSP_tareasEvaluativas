namespace PSP04__TE1_PeliculasBirt
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btn_FTP = new Button();
            label3 = new Label();
            tb_servidor = new TextBox();
            tb_usuario = new TextBox();
            label4 = new Label();
            tb_pwd = new TextBox();
            label5 = new Label();
            btn_FTP_Mail = new Button();
            label6 = new Label();
            tb_respuesta_ftp = new TextBox();
            tb_respuesta_mail = new TextBox();
            label7 = new Label();
            btn_busqueda = new Button();
            dataGridView1 = new DataGridView();
            Numero = new DataGridViewTextBoxColumn();
            Titulo = new DataGridViewTextBoxColumn();
            Año = new DataGridViewTextBoxColumn();
            label1 = new Label();
            tb_busqueda = new TextBox();
            label2 = new Label();
            textBox2 = new TextBox();
            pictureBox1 = new PictureBox();
            panel1 = new Panel();
            panel2 = new Panel();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // btn_FTP
            // 
            btn_FTP.Location = new Point(10, 606);
            btn_FTP.Name = "btn_FTP";
            btn_FTP.Size = new Size(154, 53);
            btn_FTP.TabIndex = 7;
            btn_FTP.Text = "Activar Envio FTP";
            btn_FTP.UseVisualStyleBackColor = true;
            btn_FTP.Click += btn_FTP_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(8, 30);
            label3.Name = "label3";
            label3.Size = new Size(64, 20);
            label3.TabIndex = 8;
            label3.Text = "Servidor";
            // 
            // tb_servidor
            // 
            tb_servidor.Location = new Point(78, 27);
            tb_servidor.Name = "tb_servidor";
            tb_servidor.Size = new Size(207, 27);
            tb_servidor.TabIndex = 9;
            // 
            // tb_usuario
            // 
            tb_usuario.Location = new Point(78, 78);
            tb_usuario.Name = "tb_usuario";
            tb_usuario.Size = new Size(207, 27);
            tb_usuario.TabIndex = 11;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(13, 81);
            label4.Name = "label4";
            label4.Size = new Size(59, 20);
            label4.TabIndex = 10;
            label4.Text = "Usuario";
            // 
            // tb_pwd
            // 
            tb_pwd.Location = new Point(379, 80);
            tb_pwd.Name = "tb_pwd";
            tb_pwd.Size = new Size(209, 27);
            tb_pwd.TabIndex = 13;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(303, 81);
            label5.Name = "label5";
            label5.Size = new Size(70, 20);
            label5.TabIndex = 12;
            label5.Text = "Password";
            // 
            // btn_FTP_Mail
            // 
            btn_FTP_Mail.Location = new Point(602, 79);
            btn_FTP_Mail.Name = "btn_FTP_Mail";
            btn_FTP_Mail.Size = new Size(256, 29);
            btn_FTP_Mail.TabIndex = 14;
            btn_FTP_Mail.Text = "Enviar FTP y Email";
            btn_FTP_Mail.UseVisualStyleBackColor = true;
            btn_FTP_Mail.Click += btn_FTP_Mail_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(875, 20);
            label6.Name = "label6";
            label6.Size = new Size(162, 20);
            label6.TabIndex = 15;
            label6.Text = "Respuesta Servidor FTP";
            // 
            // tb_respuesta_ftp
            // 
            tb_respuesta_ftp.Location = new Point(875, 44);
            tb_respuesta_ftp.Name = "tb_respuesta_ftp";
            tb_respuesta_ftp.ReadOnly = true;
            tb_respuesta_ftp.Size = new Size(340, 27);
            tb_respuesta_ftp.TabIndex = 16;
            // 
            // tb_respuesta_mail
            // 
            tb_respuesta_mail.Location = new Point(875, 105);
            tb_respuesta_mail.Name = "tb_respuesta_mail";
            tb_respuesta_mail.ReadOnly = true;
            tb_respuesta_mail.Size = new Size(340, 27);
            tb_respuesta_mail.TabIndex = 18;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(875, 82);
            label7.Name = "label7";
            label7.Size = new Size(176, 20);
            label7.TabIndex = 17;
            label7.Text = "Respuesta Servidor Email";
            // 
            // btn_busqueda
            // 
            btn_busqueda.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btn_busqueda.Location = new Point(11, 43);
            btn_busqueda.Name = "btn_busqueda";
            btn_busqueda.Size = new Size(638, 27);
            btn_busqueda.TabIndex = 0;
            btn_busqueda.Text = "Botón busqueda";
            btn_busqueda.UseVisualStyleBackColor = true;
            btn_busqueda.Click += btn_busqueda_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { Numero, Titulo, Año });
            dataGridView1.Location = new Point(11, 76);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(638, 424);
            dataGridView1.TabIndex = 1;
            // 
            // Numero
            // 
            Numero.HeaderText = "Numero";
            Numero.MinimumWidth = 6;
            Numero.Name = "Numero";
            Numero.Width = 125;
            // 
            // Titulo
            // 
            Titulo.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Titulo.HeaderText = "Titulo";
            Titulo.MinimumWidth = 6;
            Titulo.Name = "Titulo";
            // 
            // Año
            // 
            Año.HeaderText = "Año";
            Año.MinimumWidth = 6;
            Año.Name = "Año";
            Año.Width = 125;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 13);
            label1.Name = "label1";
            label1.Size = new Size(107, 20);
            label1.TabIndex = 2;
            label1.Text = "Texto a buscar:";
            // 
            // tb_busqueda
            // 
            tb_busqueda.Location = new Point(125, 10);
            tb_busqueda.Name = "tb_busqueda";
            tb_busqueda.Size = new Size(525, 27);
            tb_busqueda.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label2.Location = new Point(681, 17);
            label2.Name = "label2";
            label2.Size = new Size(285, 20);
            label2.TabIndex = 4;
            label2.Text = "Informacion de la pelicula seleccionada:";
            // 
            // textBox2
            // 
            textBox2.Location = new Point(681, 54);
            textBox2.Multiline = true;
            textBox2.Name = "textBox2";
            textBox2.ReadOnly = true;
            textBox2.Size = new Size(349, 446);
            textBox2.TabIndex = 5;
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(1036, 54);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(350, 446);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 6;
            pictureBox1.TabStop = false;
            // 
            // panel1
            // 
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(pictureBox1);
            panel1.Controls.Add(textBox2);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(tb_busqueda);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(dataGridView1);
            panel1.Controls.Add(btn_busqueda);
            panel1.Location = new Point(10, 12);
            panel1.Name = "panel1";
            panel1.Size = new Size(1402, 524);
            panel1.TabIndex = 19;
            // 
            // panel2
            // 
            panel2.BorderStyle = BorderStyle.FixedSingle;
            panel2.Controls.Add(label6);
            panel2.Controls.Add(tb_respuesta_mail);
            panel2.Controls.Add(label7);
            panel2.Controls.Add(tb_respuesta_ftp);
            panel2.Controls.Add(btn_FTP_Mail);
            panel2.Controls.Add(tb_pwd);
            panel2.Controls.Add(label5);
            panel2.Controls.Add(tb_usuario);
            panel2.Controls.Add(label4);
            panel2.Controls.Add(tb_servidor);
            panel2.Controls.Add(label3);
            panel2.Enabled = false;
            panel2.Location = new Point(182, 551);
            panel2.Name = "panel2";
            panel2.Size = new Size(1230, 171);
            panel2.TabIndex = 20;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1424, 734);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Controls.Add(btn_FTP);
            Name = "Form1";
            Text = "Buscador de Péliculas BirtLH";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private Button btn_FTP;
        private Label label3;
        private TextBox tb_servidor;
        private TextBox tb_usuario;
        private Label label4;
        private TextBox tb_pwd;
        private Label label5;
        private Button btn_FTP_Mail;
        private Label label6;
        private TextBox tb_respuesta_ftp;
        private TextBox tb_respuesta_mail;
        private Label label7;
        private Button btn_busqueda;
        private DataGridView dataGridView1;
        private Label label1;
        private TextBox tb_busqueda;
        private Label label2;
        private TextBox textBox2;
        private PictureBox pictureBox1;
        private Panel panel1;
        private Panel panel2;
        private DataGridViewTextBoxColumn Numero;
        private DataGridViewTextBoxColumn Titulo;
        private DataGridViewTextBoxColumn Año;
    }
}

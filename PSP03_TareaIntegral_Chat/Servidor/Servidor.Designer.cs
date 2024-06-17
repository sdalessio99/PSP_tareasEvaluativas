namespace Servidor
{
    partial class Servidor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Servidor));
            btn_arrancar = new Button();
            btn_parar = new Button();
            tb_chat = new TextBox();
            pictureBox1 = new PictureBox();
            lb_clientes = new ListBox();
            label1 = new Label();
            tb_total = new TextBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // btn_arrancar
            // 
            btn_arrancar.Location = new Point(26, 20);
            btn_arrancar.Name = "btn_arrancar";
            btn_arrancar.Size = new Size(182, 87);
            btn_arrancar.TabIndex = 0;
            btn_arrancar.Text = "Arrancar Server";
            btn_arrancar.UseVisualStyleBackColor = true;
            btn_arrancar.Click += btn_arrancar_Click;
            // 
            // btn_parar
            // 
            btn_parar.Enabled = false;
            btn_parar.Location = new Point(214, 20);
            btn_parar.Name = "btn_parar";
            btn_parar.Size = new Size(182, 87);
            btn_parar.TabIndex = 1;
            btn_parar.Text = "Parar Server";
            btn_parar.UseVisualStyleBackColor = true;
            btn_parar.Click += btn_parar_Click;
            // 
            // tb_chat
            // 
            tb_chat.Enabled = false;
            tb_chat.Location = new Point(26, 122);
            tb_chat.Multiline = true;
            tb_chat.Name = "tb_chat";
            tb_chat.ReadOnly = true;
            tb_chat.ScrollBars = ScrollBars.Vertical;
            tb_chat.Size = new Size(370, 297);
            tb_chat.TabIndex = 2;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(532, 20);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(158, 132);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 3;
            pictureBox1.TabStop = false;
            // 
            // lb_clientes
            // 
            lb_clientes.BackColor = SystemColors.Control;
            lb_clientes.Enabled = false;
            lb_clientes.FormattingEnabled = true;
            lb_clientes.Location = new Point(518, 227);
            lb_clientes.Name = "lb_clientes";
            lb_clientes.Size = new Size(186, 164);
            lb_clientes.TabIndex = 4;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Enabled = false;
            label1.Location = new Point(518, 192);
            label1.Name = "label1";
            label1.Size = new Size(122, 20);
            label1.TabIndex = 5;
            label1.Text = "Numero Clientes:";
            // 
            // tb_total
            // 
            tb_total.Enabled = false;
            tb_total.Location = new Point(646, 189);
            tb_total.Name = "tb_total";
            tb_total.ReadOnly = true;
            tb_total.Size = new Size(58, 27);
            tb_total.TabIndex = 6;
            // 
            // Servidor
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(tb_total);
            Controls.Add(label1);
            Controls.Add(lb_clientes);
            Controls.Add(pictureBox1);
            Controls.Add(tb_chat);
            Controls.Add(btn_parar);
            Controls.Add(btn_arrancar);
            Name = "Servidor";
            Text = "Servidor";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btn_arrancar;
        private Button btn_parar;
        private TextBox tb_chat;
        private PictureBox pictureBox1;
        private ListBox lb_clientes;
        private Label label1;
        private TextBox tb_total;
    }
}

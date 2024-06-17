namespace Cliente
{
    partial class Cliente
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
            btn_conectar = new Button();
            btn_desconectar = new Button();
            label1 = new Label();
            tb_IP = new TextBox();
            tb_usuario = new TextBox();
            label2 = new Label();
            groupBox1 = new GroupBox();
            btn_enviar = new Button();
            tb_chat = new TextBox();
            tb_mensaje = new TextBox();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // btn_conectar
            // 
            btn_conectar.Location = new Point(140, 30);
            btn_conectar.Name = "btn_conectar";
            btn_conectar.Size = new Size(191, 65);
            btn_conectar.TabIndex = 0;
            btn_conectar.Text = "Conectar al Servidor";
            btn_conectar.UseVisualStyleBackColor = true;
            btn_conectar.Click += btn_conectar_Click;
            // 
            // btn_desconectar
            // 
            btn_desconectar.Enabled = false;
            btn_desconectar.Location = new Point(375, 30);
            btn_desconectar.Name = "btn_desconectar";
            btn_desconectar.Size = new Size(191, 65);
            btn_desconectar.TabIndex = 1;
            btn_desconectar.Text = "Desconectar Cliente";
            btn_desconectar.UseVisualStyleBackColor = true;
            btn_desconectar.Click += btn_desconectar_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(117, 142);
            label1.Name = "label1";
            label1.Size = new Size(83, 20);
            label1.TabIndex = 2;
            label1.Text = "IP Servidor:";
            // 
            // tb_IP
            // 
            tb_IP.Location = new Point(206, 139);
            tb_IP.Name = "tb_IP";
            tb_IP.Size = new Size(125, 27);
            tb_IP.TabIndex = 3;
            // 
            // tb_usuario
            // 
            tb_usuario.Location = new Point(448, 139);
            tb_usuario.Name = "tb_usuario";
            tb_usuario.Size = new Size(125, 27);
            tb_usuario.TabIndex = 5;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(375, 142);
            label2.Name = "label2";
            label2.Size = new Size(67, 20);
            label2.TabIndex = 4;
            label2.Text = "Nombre:";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btn_enviar);
            groupBox1.Controls.Add(tb_chat);
            groupBox1.Controls.Add(tb_mensaje);
            groupBox1.Enabled = false;
            groupBox1.Location = new Point(47, 189);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(587, 382);
            groupBox1.TabIndex = 6;
            groupBox1.TabStop = false;
            groupBox1.Text = "Chat";
            // 
            // btn_enviar
            // 
            btn_enviar.Location = new Point(93, 282);
            btn_enviar.Name = "btn_enviar";
            btn_enviar.Size = new Size(426, 65);
            btn_enviar.TabIndex = 2;
            btn_enviar.Text = "Enviar";
            btn_enviar.UseVisualStyleBackColor = true;
            btn_enviar.Click += btn_enviar_Click;
            // 
            // tb_chat
            // 
            tb_chat.Location = new Point(6, 81);
            tb_chat.Multiline = true;
            tb_chat.Name = "tb_chat";
            tb_chat.ReadOnly = true;
            tb_chat.ScrollBars = ScrollBars.Vertical;
            tb_chat.Size = new Size(575, 169);
            tb_chat.TabIndex = 1;
            // 
            // tb_mensaje
            // 
            tb_mensaje.Location = new Point(6, 38);
            tb_mensaje.Name = "tb_mensaje";
            tb_mensaje.Size = new Size(575, 27);
            tb_mensaje.TabIndex = 0;
            // 
            // Cliente
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(688, 610);
            Controls.Add(groupBox1);
            Controls.Add(tb_usuario);
            Controls.Add(label2);
            Controls.Add(tb_IP);
            Controls.Add(label1);
            Controls.Add(btn_desconectar);
            Controls.Add(btn_conectar);
            Name = "Cliente";
            Text = "Cliente";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btn_conectar;
        private Button btn_desconectar;
        private Label label1;
        private TextBox tb_IP;
        private TextBox tb_usuario;
        private Label label2;
        private GroupBox groupBox1;
        private Button btn_enviar;
        private TextBox tb_chat;
        private TextBox tb_mensaje;
    }
}

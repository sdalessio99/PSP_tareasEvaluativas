namespace CarreraCaballos
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
            btnEmpezar = new Button();
            btnReiniciar = new Button();
            pbrCaballo1 = new ProgressBar();
            pbrCaballo2 = new ProgressBar();
            pbrCaballo3 = new ProgressBar();
            pbrCaballo4 = new ProgressBar();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            lblGanador = new Label();
            lblResultados = new Label();
            SuspendLayout();
            // 
            // btnEmpezar
            // 
            btnEmpezar.Location = new Point(12, 12);
            btnEmpezar.Name = "btnEmpezar";
            btnEmpezar.Size = new Size(136, 64);
            btnEmpezar.TabIndex = 0;
            btnEmpezar.Text = "Empezar";
            btnEmpezar.UseVisualStyleBackColor = true;
            btnEmpezar.Click += btnEmpezar_Click;
            // 
            // btnReiniciar
            // 
            btnReiniciar.Location = new Point(154, 12);
            btnReiniciar.Name = "btnReiniciar";
            btnReiniciar.Size = new Size(136, 64);
            btnReiniciar.TabIndex = 1;
            btnReiniciar.Text = "Reiniciar";
            btnReiniciar.UseVisualStyleBackColor = true;
            btnReiniciar.Click += btnReiniciar_Click;
            // 
            // pbrCaballo1
            // 
            pbrCaballo1.Location = new Point(202, 109);
            pbrCaballo1.Name = "pbrCaballo1";
            pbrCaballo1.Size = new Size(512, 88);
            pbrCaballo1.TabIndex = 2;
            // 
            // pbrCaballo2
            // 
            pbrCaballo2.Location = new Point(202, 215);
            pbrCaballo2.Name = "pbrCaballo2";
            pbrCaballo2.Size = new Size(512, 88);
            pbrCaballo2.TabIndex = 3;
            // 
            // pbrCaballo3
            // 
            pbrCaballo3.Location = new Point(202, 322);
            pbrCaballo3.Name = "pbrCaballo3";
            pbrCaballo3.Size = new Size(512, 88);
            pbrCaballo3.TabIndex = 4;
            // 
            // pbrCaballo4
            // 
            pbrCaballo4.Location = new Point(202, 429);
            pbrCaballo4.Name = "pbrCaballo4";
            pbrCaballo4.Size = new Size(512, 88);
            pbrCaballo4.TabIndex = 5;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(116, 143);
            label1.Name = "label1";
            label1.Size = new Size(68, 20);
            label1.TabIndex = 6;
            label1.Text = "Caballo1";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(116, 250);
            label2.Name = "label2";
            label2.Size = new Size(68, 20);
            label2.TabIndex = 7;
            label2.Text = "Caballo2";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(116, 356);
            label3.Name = "label3";
            label3.Size = new Size(68, 20);
            label3.TabIndex = 8;
            label3.Text = "Caballo3";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(116, 465);
            label4.Name = "label4";
            label4.Size = new Size(68, 20);
            label4.TabIndex = 9;
            label4.Text = "Caballo4";
            // 
            // lblGanador
            // 
            lblGanador.AutoSize = true;
            lblGanador.Location = new Point(751, 220);
            lblGanador.Name = "lblGanador";
            lblGanador.Size = new Size(75, 20);
            lblGanador.TabIndex = 10;
            lblGanador.Text = "Resultado";
            // 
            // lblResultados
            // 
            lblResultados.AutoSize = true;
            lblResultados.Location = new Point(751, 250);
            lblResultados.Name = "lblResultados";
            lblResultados.Size = new Size(0, 20);
            lblResultados.TabIndex = 11;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(944, 549);
            Controls.Add(lblResultados);
            Controls.Add(lblGanador);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(pbrCaballo4);
            Controls.Add(pbrCaballo3);
            Controls.Add(pbrCaballo2);
            Controls.Add(pbrCaballo1);
            Controls.Add(btnReiniciar);
            Controls.Add(btnEmpezar);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnEmpezar;
        private Button btnReiniciar;
        private ProgressBar pbrCaballo1;
        private ProgressBar pbrCaballo2;
        private ProgressBar pbrCaballo3;
        private ProgressBar pbrCaballo4;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label lblGanador;
        private Label lblResultados;
    }
}

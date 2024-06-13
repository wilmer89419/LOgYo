namespace Presentacion
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txt_cancelar = new System.Windows.Forms.Button();
            this.txt_entrar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_usuario = new System.Windows.Forms.TextBox();
            this.txt_clave = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txt_cancelar
            // 
            this.txt_cancelar.Location = new System.Drawing.Point(450, 100);
            this.txt_cancelar.Name = "txt_cancelar";
            this.txt_cancelar.Size = new System.Drawing.Size(75, 23);
            this.txt_cancelar.TabIndex = 0;
            this.txt_cancelar.Text = "Cancelar";
            this.txt_cancelar.UseVisualStyleBackColor = true;
            // 
            // txt_entrar
            // 
            this.txt_entrar.Location = new System.Drawing.Point(450, 143);
            this.txt_entrar.Name = "txt_entrar";
            this.txt_entrar.Size = new System.Drawing.Size(75, 23);
            this.txt_entrar.TabIndex = 1;
            this.txt_entrar.Text = "Entrar";
            this.txt_entrar.UseVisualStyleBackColor = true;
            this.txt_entrar.Click += new System.EventHandler(this.txt_entrar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(236, 102);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Usuario";
            // 
            // txt_usuario
            // 
            this.txt_usuario.Location = new System.Drawing.Point(277, 102);
            this.txt_usuario.Name = "txt_usuario";
            this.txt_usuario.Size = new System.Drawing.Size(139, 20);
            this.txt_usuario.TabIndex = 3;
            // 
            // txt_clave
            // 
            this.txt_clave.Location = new System.Drawing.Point(277, 143);
            this.txt_clave.Name = "txt_clave";
            this.txt_clave.Size = new System.Drawing.Size(139, 20);
            this.txt_clave.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(236, 153);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Clave";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txt_clave);
            this.Controls.Add(this.txt_usuario);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txt_entrar);
            this.Controls.Add(this.txt_cancelar);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button txt_cancelar;
        private System.Windows.Forms.Button txt_entrar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_usuario;
        private System.Windows.Forms.TextBox txt_clave;
        private System.Windows.Forms.Label label2;
    }
}


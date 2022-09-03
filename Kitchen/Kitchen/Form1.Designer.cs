namespace Kitchen
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
            this.txt_orders = new System.Windows.Forms.TextBox();
            this.lbl_orders = new System.Windows.Forms.Label();
            this.txt_completed = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_completed = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txt_orders
            // 
            this.txt_orders.Location = new System.Drawing.Point(113, 51);
            this.txt_orders.Multiline = true;
            this.txt_orders.Name = "txt_orders";
            this.txt_orders.ReadOnly = true;
            this.txt_orders.Size = new System.Drawing.Size(401, 360);
            this.txt_orders.TabIndex = 0;
            // 
            // lbl_orders
            // 
            this.lbl_orders.AutoSize = true;
            this.lbl_orders.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_orders.Location = new System.Drawing.Point(243, 9);
            this.lbl_orders.Name = "lbl_orders";
            this.lbl_orders.Size = new System.Drawing.Size(120, 39);
            this.lbl_orders.TabIndex = 1;
            this.lbl_orders.Text = "Orders";
            // 
            // txt_completed
            // 
            this.txt_completed.Location = new System.Drawing.Point(631, 186);
            this.txt_completed.Name = "txt_completed";
            this.txt_completed.Size = new System.Drawing.Size(100, 22);
            this.txt_completed.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(556, 136);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(232, 32);
            this.label1.TabIndex = 3;
            this.label1.Text = "Completed Order";
            // 
            // btn_completed
            // 
            this.btn_completed.Location = new System.Drawing.Point(631, 226);
            this.btn_completed.Name = "btn_completed";
            this.btn_completed.Size = new System.Drawing.Size(104, 39);
            this.btn_completed.TabIndex = 4;
            this.btn_completed.Text = "Submit";
            this.btn_completed.UseVisualStyleBackColor = true;
            this.btn_completed.Click += new System.EventHandler(this.btn_completed_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btn_completed);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txt_completed);
            this.Controls.Add(this.lbl_orders);
            this.Controls.Add(this.txt_orders);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt_orders;
        private System.Windows.Forms.Label lbl_orders;
        private System.Windows.Forms.TextBox txt_completed;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_completed;
    }
}


namespace ChangeMachine.WFormsApp
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.UxTxtProductAmount = new System.Windows.Forms.TextBox();
            this.UxTxtPaidAmount = new System.Windows.Forms.TextBox();
            this.UxTxtChangeResult = new System.Windows.Forms.TextBox();
            this.UxBtnCalculate = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(132, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Valor do Produto:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(363, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Valor Pago:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(41, 105);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "Troco:";
            // 
            // UxTxtProductAmount
            // 
            this.UxTxtProductAmount.Location = new System.Drawing.Point(170, 22);
            this.UxTxtProductAmount.Name = "UxTxtProductAmount";
            this.UxTxtProductAmount.Size = new System.Drawing.Size(100, 26);
            this.UxTxtProductAmount.TabIndex = 3;
            // 
            // UxTxtPaidAmount
            // 
            this.UxTxtPaidAmount.Location = new System.Drawing.Point(460, 22);
            this.UxTxtPaidAmount.Name = "UxTxtPaidAmount";
            this.UxTxtPaidAmount.Size = new System.Drawing.Size(100, 26);
            this.UxTxtPaidAmount.TabIndex = 4;
            // 
            // UxTxtChangeResult
            // 
            this.UxTxtChangeResult.Enabled = false;
            this.UxTxtChangeResult.Location = new System.Drawing.Point(45, 128);
            this.UxTxtChangeResult.Multiline = true;
            this.UxTxtChangeResult.Name = "UxTxtChangeResult";
            this.UxTxtChangeResult.Size = new System.Drawing.Size(209, 174);
            this.UxTxtChangeResult.TabIndex = 5;
            // 
            // UxBtnCalculate
            // 
            this.UxBtnCalculate.Location = new System.Drawing.Point(367, 130);
            this.UxBtnCalculate.Name = "UxBtnCalculate";
            this.UxBtnCalculate.Size = new System.Drawing.Size(87, 33);
            this.UxBtnCalculate.TabIndex = 6;
            this.UxBtnCalculate.Text = "Calcular";
            this.UxBtnCalculate.UseVisualStyleBackColor = true;
            this.UxBtnCalculate.Click += new System.EventHandler(this.UxBtnCalculate_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(744, 350);
            this.Controls.Add(this.UxBtnCalculate);
            this.Controls.Add(this.UxTxtChangeResult);
            this.Controls.Add(this.UxTxtPaidAmount);
            this.Controls.Add(this.UxTxtProductAmount);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Changeman Chine";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox UxTxtProductAmount;
        private System.Windows.Forms.TextBox UxTxtPaidAmount;
        private System.Windows.Forms.TextBox UxTxtChangeResult;
        private System.Windows.Forms.Button UxBtnCalculate;
    }
}


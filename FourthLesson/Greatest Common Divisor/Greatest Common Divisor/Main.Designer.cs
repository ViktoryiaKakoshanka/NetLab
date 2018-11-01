namespace GreatestCommonDivisorProgram
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.groupOfNumbers = new System.Windows.Forms.GroupBox();
            this.numbersForGCD = new System.Windows.Forms.TextBox();
            this.GCDStain = new System.Windows.Forms.Button();
            this.GCDEuclide = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.groupResults = new System.Windows.Forms.GroupBox();
            this.lblresult = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.groupOfNumbers.SuspendLayout();
            this.groupResults.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupOfNumbers
            // 
            this.groupOfNumbers.Controls.Add(this.numbersForGCD);
            this.groupOfNumbers.Controls.Add(this.GCDStain);
            this.groupOfNumbers.Controls.Add(this.GCDEuclide);
            this.groupOfNumbers.Controls.Add(this.label1);
            this.groupOfNumbers.Location = new System.Drawing.Point(12, 12);
            this.groupOfNumbers.Name = "groupOfNumbers";
            this.groupOfNumbers.Size = new System.Drawing.Size(319, 129);
            this.groupOfNumbers.TabIndex = 1;
            this.groupOfNumbers.TabStop = false;
            // 
            // numbersForGCD
            // 
            this.numbersForGCD.Location = new System.Drawing.Point(9, 43);
            this.numbersForGCD.Name = "numbersForGCD";
            this.numbersForGCD.Size = new System.Drawing.Size(298, 20);
            this.numbersForGCD.TabIndex = 3;
            // 
            // GCDStain
            // 
            this.GCDStain.Location = new System.Drawing.Point(6, 98);
            this.GCDStain.Name = "GCDStain";
            this.GCDStain.Size = new System.Drawing.Size(301, 23);
            this.GCDStain.TabIndex = 2;
            this.GCDStain.Text = "Расчитать НОД методом Стейна";
            this.toolTip1.SetToolTip(this.GCDStain, "Метод расчитывает НОД только для первых двух чисел");
            this.GCDStain.UseVisualStyleBackColor = true;
            this.GCDStain.Click += new System.EventHandler(this.GCDStain_Click);
            // 
            // GCDEuclide
            // 
            this.GCDEuclide.Location = new System.Drawing.Point(6, 69);
            this.GCDEuclide.Name = "GCDEuclide";
            this.GCDEuclide.Size = new System.Drawing.Size(301, 23);
            this.GCDEuclide.TabIndex = 2;
            this.GCDEuclide.Text = "Расчитать НОД методом Евклида";
            this.GCDEuclide.UseVisualStyleBackColor = true;
            this.GCDEuclide.Click += new System.EventHandler(this.GCDEuclide_Click);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(6, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(301, 23);
            this.label1.TabIndex = 2;
            this.label1.Text = "Введите числа для вычисления НОД отделяя пробелом";
            // 
            // groupResults
            // 
            this.groupResults.Controls.Add(this.lblresult);
            this.groupResults.Cursor = System.Windows.Forms.Cursors.Hand;
            this.groupResults.Location = new System.Drawing.Point(12, 168);
            this.groupResults.Name = "groupResults";
            this.groupResults.Size = new System.Drawing.Size(319, 166);
            this.groupResults.TabIndex = 2;
            this.groupResults.TabStop = false;
            this.groupResults.Text = "Результат вычисления";
            this.toolTip1.SetToolTip(this.groupResults, "Очистить окно результатов");
            // 
            // lblresult
            // 
            this.lblresult.AutoSize = true;
            this.lblresult.Location = new System.Drawing.Point(7, 23);
            this.lblresult.Name = "lblresult";
            this.lblresult.Size = new System.Drawing.Size(0, 13);
            this.lblresult.TabIndex = 0;
            // 
            // toolTip1
            // 
            this.toolTip1.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.toolTip1.ToolTipTitle = "Подсказка";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(344, 347);
            this.Controls.Add(this.groupResults);
            this.Controls.Add(this.groupOfNumbers);
            this.Name = "Form1";
            this.Text = "Вычисление НОД";
            this.groupOfNumbers.ResumeLayout(false);
            this.groupOfNumbers.PerformLayout();
            this.groupResults.ResumeLayout(false);
            this.groupResults.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox groupOfNumbers;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button GCDEuclide;
        private System.Windows.Forms.GroupBox groupResults;
        private System.Windows.Forms.TextBox numbersForGCD;
        private System.Windows.Forms.Label lblresult;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button GCDStain;
    }
}


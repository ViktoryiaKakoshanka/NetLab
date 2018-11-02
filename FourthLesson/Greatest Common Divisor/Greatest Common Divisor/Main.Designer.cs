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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.groupOfNumbers = new System.Windows.Forms.GroupBox();
            this.numbersForGCD = new System.Windows.Forms.TextBox();
            this.GCDStain = new System.Windows.Forms.Button();
            this.GCDEuclide = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.groupResults = new System.Windows.Forms.GroupBox();
            this.lblresult = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.createBarChar = new System.Windows.Forms.Button();
            this.comboPalette = new System.Windows.Forms.ComboBox();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.comboTypeChart = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupOfNumbers.SuspendLayout();
            this.groupResults.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
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
            this.groupOfNumbers.Size = new System.Drawing.Size(319, 130);
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
            this.GCDStain.Click += new System.EventHandler(this.GCD_Click);
            // 
            // GCDEuclide
            // 
            this.GCDEuclide.Location = new System.Drawing.Point(6, 69);
            this.GCDEuclide.Name = "GCDEuclide";
            this.GCDEuclide.Size = new System.Drawing.Size(301, 23);
            this.GCDEuclide.TabIndex = 2;
            this.GCDEuclide.Text = "Расчитать НОД методом Евклида";
            this.GCDEuclide.UseVisualStyleBackColor = true;
            this.GCDEuclide.Click += new System.EventHandler(this.GCD_Click);
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
            this.groupResults.Location = new System.Drawing.Point(12, 148);
            this.groupResults.Name = "groupResults";
            this.groupResults.Size = new System.Drawing.Size(319, 186);
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
            // chart1
            // 
            chartArea1.AlignmentOrientation = System.Windows.Forms.DataVisualization.Charting.AreaAlignmentOrientations.Horizontal;
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(352, 55);
            this.chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(425, 274);
            this.chart1.TabIndex = 3;
            this.chart1.Text = "chart1";
            // 
            // createBarChar
            // 
            this.createBarChar.Enabled = false;
            this.createBarChar.Location = new System.Drawing.Point(629, 18);
            this.createBarChar.Name = "createBarChar";
            this.createBarChar.Size = new System.Drawing.Size(148, 23);
            this.createBarChar.TabIndex = 2;
            this.createBarChar.Text = "Построить Гистограмму";
            this.createBarChar.UseVisualStyleBackColor = true;
            this.createBarChar.Click += new System.EventHandler(this.createBarChar_Click);
            // 
            // comboPalette
            // 
            this.comboPalette.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboPalette.FormattingEnabled = true;
            this.comboPalette.Location = new System.Drawing.Point(352, 20);
            this.comboPalette.Name = "comboPalette";
            this.comboPalette.Size = new System.Drawing.Size(128, 21);
            this.comboPalette.TabIndex = 4;
            // 
            // comboTypeChart
            // 
            this.comboTypeChart.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboTypeChart.FormattingEnabled = true;
            this.comboTypeChart.Location = new System.Drawing.Point(486, 20);
            this.comboTypeChart.Name = "comboTypeChart";
            this.comboTypeChart.Size = new System.Drawing.Size(119, 21);
            this.comboTypeChart.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(349, 4);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Цветовая палитра";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(483, 4);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Тип диаграммы";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(789, 347);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboTypeChart);
            this.Controls.Add(this.comboPalette);
            this.Controls.Add(this.createBarChar);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.groupResults);
            this.Controls.Add(this.groupOfNumbers);
            this.Name = "Form1";
            this.Text = "Вычисление НОД";
            this.groupOfNumbers.ResumeLayout(false);
            this.groupOfNumbers.PerformLayout();
            this.groupResults.ResumeLayout(false);
            this.groupResults.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

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
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Button createBarChar;
        private System.Windows.Forms.ComboBox comboPalette;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.ComboBox comboTypeChart;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}


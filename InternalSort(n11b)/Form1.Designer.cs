namespace InternalSort_n11b_
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.tabControlMain = new System.Windows.Forms.TabControl();
            this.tabPageVisual = new System.Windows.Forms.TabPage();
            this.buttonSort = new System.Windows.Forms.Button();
            this.buttonGenerate = new System.Windows.Forms.Button();
            this.tabPageChart = new System.Windows.Forms.TabPage();
            this.chartSort = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.labelCount = new System.Windows.Forms.Label();
            this.numericUpDownCount = new System.Windows.Forms.NumericUpDown();
            this.buttonStartPlot = new System.Windows.Forms.Button();
            this.numericUpDownStep = new System.Windows.Forms.NumericUpDown();
            this.labelStep = new System.Windows.Forms.Label();
            this.tabControlMain.SuspendLayout();
            this.tabPageVisual.SuspendLayout();
            this.tabPageChart.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartSort)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownStep)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControlMain
            // 
            this.tabControlMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControlMain.Controls.Add(this.tabPageVisual);
            this.tabControlMain.Controls.Add(this.tabPageChart);
            this.tabControlMain.Location = new System.Drawing.Point(2, 2);
            this.tabControlMain.Name = "tabControlMain";
            this.tabControlMain.SelectedIndex = 0;
            this.tabControlMain.Size = new System.Drawing.Size(1101, 443);
            this.tabControlMain.TabIndex = 0;
            // 
            // tabPageVisual
            // 
            this.tabPageVisual.Controls.Add(this.buttonSort);
            this.tabPageVisual.Controls.Add(this.buttonGenerate);
            this.tabPageVisual.Location = new System.Drawing.Point(4, 22);
            this.tabPageVisual.Name = "tabPageVisual";
            this.tabPageVisual.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageVisual.Size = new System.Drawing.Size(1093, 417);
            this.tabPageVisual.TabIndex = 0;
            this.tabPageVisual.Text = "Визуализация";
            this.tabPageVisual.UseVisualStyleBackColor = true;
            // 
            // buttonSort
            // 
            this.buttonSort.Location = new System.Drawing.Point(436, 354);
            this.buttonSort.Name = "buttonSort";
            this.buttonSort.Size = new System.Drawing.Size(129, 35);
            this.buttonSort.TabIndex = 0;
            this.buttonSort.Text = "Сортировать";
            this.buttonSort.UseVisualStyleBackColor = true;
            this.buttonSort.Click += new System.EventHandler(this.buttonSort_Click);
            // 
            // buttonGenerate
            // 
            this.buttonGenerate.Location = new System.Drawing.Point(633, 354);
            this.buttonGenerate.Name = "buttonGenerate";
            this.buttonGenerate.Size = new System.Drawing.Size(129, 35);
            this.buttonGenerate.TabIndex = 1;
            this.buttonGenerate.Text = "Сгенерировать";
            this.buttonGenerate.UseVisualStyleBackColor = true;
            this.buttonGenerate.Click += new System.EventHandler(this.buttonGenerate_Click);
            // 
            // tabPageChart
            // 
            this.tabPageChart.Controls.Add(this.numericUpDownStep);
            this.tabPageChart.Controls.Add(this.labelStep);
            this.tabPageChart.Controls.Add(this.buttonStartPlot);
            this.tabPageChart.Controls.Add(this.numericUpDownCount);
            this.tabPageChart.Controls.Add(this.labelCount);
            this.tabPageChart.Controls.Add(this.chartSort);
            this.tabPageChart.Location = new System.Drawing.Point(4, 22);
            this.tabPageChart.Name = "tabPageChart";
            this.tabPageChart.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageChart.Size = new System.Drawing.Size(1093, 417);
            this.tabPageChart.TabIndex = 1;
            this.tabPageChart.Text = "Анализ";
            this.tabPageChart.UseVisualStyleBackColor = true;
            // 
            // chartSort
            // 
            chartArea1.Name = "ChartArea1";
            this.chartSort.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chartSort.Legends.Add(legend1);
            this.chartSort.Location = new System.Drawing.Point(7, 7);
            this.chartSort.Name = "chartSort";
            this.chartSort.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.SeaGreen;
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.Color = System.Drawing.Color.Red;
            series1.Legend = "Legend1";
            series1.Name = "Сравнения";
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series2.Legend = "Legend1";
            series2.Name = "Перестановки ссылок";
            this.chartSort.Series.Add(series1);
            this.chartSort.Series.Add(series2);
            this.chartSort.Size = new System.Drawing.Size(876, 403);
            this.chartSort.TabIndex = 0;
            this.chartSort.Text = "chart1";
            // 
            // labelCount
            // 
            this.labelCount.AutoSize = true;
            this.labelCount.Location = new System.Drawing.Point(915, 22);
            this.labelCount.Name = "labelCount";
            this.labelCount.Size = new System.Drawing.Size(99, 13);
            this.labelCount.TabIndex = 1;
            this.labelCount.Text = "Кол-во элементов";
            // 
            // numericUpDownCount
            // 
            this.numericUpDownCount.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numericUpDownCount.Location = new System.Drawing.Point(918, 39);
            this.numericUpDownCount.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericUpDownCount.Name = "numericUpDownCount";
            this.numericUpDownCount.Size = new System.Drawing.Size(120, 20);
            this.numericUpDownCount.TabIndex = 2;
            this.numericUpDownCount.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // buttonStartPlot
            // 
            this.buttonStartPlot.Location = new System.Drawing.Point(918, 141);
            this.buttonStartPlot.Name = "buttonStartPlot";
            this.buttonStartPlot.Size = new System.Drawing.Size(120, 23);
            this.buttonStartPlot.TabIndex = 3;
            this.buttonStartPlot.Text = "Построить";
            this.buttonStartPlot.UseVisualStyleBackColor = true;
            this.buttonStartPlot.Click += new System.EventHandler(this.buttonStartPlot_Click);
            // 
            // numericUpDownStep
            // 
            this.numericUpDownStep.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDownStep.Location = new System.Drawing.Point(918, 89);
            this.numericUpDownStep.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericUpDownStep.Name = "numericUpDownStep";
            this.numericUpDownStep.Size = new System.Drawing.Size(120, 20);
            this.numericUpDownStep.TabIndex = 5;
            this.numericUpDownStep.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // labelStep
            // 
            this.labelStep.AutoSize = true;
            this.labelStep.Location = new System.Drawing.Point(915, 72);
            this.labelStep.Name = "labelStep";
            this.labelStep.Size = new System.Drawing.Size(27, 13);
            this.labelStep.TabIndex = 4;
            this.labelStep.Text = "Шаг";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1103, 446);
            this.Controls.Add(this.tabControlMain);
            this.Name = "Form1";
            this.Text = "Form1";
            this.tabControlMain.ResumeLayout(false);
            this.tabPageVisual.ResumeLayout(false);
            this.tabPageChart.ResumeLayout(false);
            this.tabPageChart.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartSort)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownStep)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControlMain;
        private System.Windows.Forms.TabPage tabPageVisual;
        private System.Windows.Forms.TabPage tabPageChart;
        private System.Windows.Forms.Button buttonSort;
        private System.Windows.Forms.Button buttonGenerate;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartSort;
        private System.Windows.Forms.Button buttonStartPlot;
        private System.Windows.Forms.NumericUpDown numericUpDownCount;
        private System.Windows.Forms.Label labelCount;
        private System.Windows.Forms.NumericUpDown numericUpDownStep;
        private System.Windows.Forms.Label labelStep;
    }
}


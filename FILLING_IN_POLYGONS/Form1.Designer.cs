namespace FILLING_IN_POLYGONS
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.colorSelection = new System.Windows.Forms.ComboBox();
            this.clear = new System.Windows.Forms.Button();
            this.fillType = new System.Windows.Forms.ComboBox();
            this.PaintOver = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.Window;
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox1.Location = new System.Drawing.Point(6, 8);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(951, 297);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
            // 
            // colorSelection
            // 
            this.colorSelection.FormattingEnabled = true;
            this.colorSelection.Items.AddRange(new object[] {
            "Черный",
            "Красный",
            "Зеленый",
            "Синий"});
            this.colorSelection.Location = new System.Drawing.Point(87, 402);
            this.colorSelection.Name = "colorSelection";
            this.colorSelection.Size = new System.Drawing.Size(191, 24);
            this.colorSelection.TabIndex = 2;
            this.colorSelection.Text = "Цвет линии";
            this.colorSelection.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged);
            // 
            // clear
            // 
            this.clear.Location = new System.Drawing.Point(703, 398);
            this.clear.Name = "clear";
            this.clear.Size = new System.Drawing.Size(206, 78);
            this.clear.TabIndex = 3;
            this.clear.Text = "Очистить";
            this.clear.UseVisualStyleBackColor = true;
            this.clear.Click += new System.EventHandler(this.btClear_Click);
            // 
            // fillType
            // 
            this.fillType.FormattingEnabled = true;
            this.fillType.Items.AddRange(new object[] {
            "ориентированного многоугольника",
            "неориентированного многоугольника"});
            this.fillType.Location = new System.Drawing.Point(87, 452);
            this.fillType.Name = "fillType";
            this.fillType.Size = new System.Drawing.Size(191, 24);
            this.fillType.TabIndex = 4;
            this.fillType.Text = "Тип закрашивания";
            this.fillType.SelectedIndexChanged += new System.EventHandler(this.comboBox3_SelectedIndexChanged);
            // 
            // PaintOver
            // 
            this.PaintOver.Location = new System.Drawing.Point(383, 399);
            this.PaintOver.Name = "PaintOver";
            this.PaintOver.Size = new System.Drawing.Size(212, 77);
            this.PaintOver.TabIndex = 5;
            this.PaintOver.Text = "Закрасить";
            this.PaintOver.UseVisualStyleBackColor = true;
            this.PaintOver.Click += new System.EventHandler(this.PaintOver_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(964, 551);
            this.Controls.Add(this.PaintOver);
            this.Controls.Add(this.fillType);
            this.Controls.Add(this.clear);
            this.Controls.Add(this.colorSelection);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ComboBox colorSelection;
        private System.Windows.Forms.Button clear;
        private System.Windows.Forms.ComboBox fillType;
        private System.Windows.Forms.Button PaintOver;
    }
}


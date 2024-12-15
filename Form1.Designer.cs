namespace WindowsFormsLab1
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
            this.imageBox1 = new Emgu.CV.UI.ImageBox();
            this.buttonLoadImage = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.buttonProcessChannel = new System.Windows.Forms.Button();
            this.imageBox2 = new Emgu.CV.UI.ImageBox();
            this.buttonConvertToGrayscale = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonConvertToSepia = new System.Windows.Forms.Button();
            this.trackBarBrightness = new System.Windows.Forms.TrackBar();
            this.trackBarContrast = new System.Windows.Forms.TrackBar();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBoxConvertToHSV = new System.Windows.Forms.ComboBox();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.buttonMedianBlur = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.buttonApplyFilter = new System.Windows.Forms.Button();
            this.buttonLogicalAnd = new System.Windows.Forms.Button();
            this.buttonLogicalXor = new System.Windows.Forms.Button();
            this.buttonLogicalNot = new System.Windows.Forms.Button();
            this.buttonLoadSecondImage_Click = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.imageBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarBrightness)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarContrast)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.SuspendLayout();
            // 
            // imageBox1
            // 
            this.imageBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.imageBox1.Location = new System.Drawing.Point(16, 10);
            this.imageBox1.Name = "imageBox1";
            this.imageBox1.Size = new System.Drawing.Size(301, 430);
            this.imageBox1.TabIndex = 2;
            this.imageBox1.TabStop = false;
            // 
            // buttonLoadImage
            // 
            this.buttonLoadImage.Location = new System.Drawing.Point(633, 12);
            this.buttonLoadImage.Name = "buttonLoadImage";
            this.buttonLoadImage.Size = new System.Drawing.Size(155, 35);
            this.buttonLoadImage.TabIndex = 3;
            this.buttonLoadImage.Text = "Добавить изображение";
            this.buttonLoadImage.UseVisualStyleBackColor = true;
            this.buttonLoadImage.Click += new System.EventHandler(this.buttonLoadImage_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(633, 66);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(71, 21);
            this.comboBox1.TabIndex = 5;
            // 
            // buttonProcessChannel
            // 
            this.buttonProcessChannel.Location = new System.Drawing.Point(712, 66);
            this.buttonProcessChannel.Name = "buttonProcessChannel";
            this.buttonProcessChannel.Size = new System.Drawing.Size(76, 21);
            this.buttonProcessChannel.TabIndex = 6;
            this.buttonProcessChannel.Text = "Применить";
            this.buttonProcessChannel.UseVisualStyleBackColor = true;
            this.buttonProcessChannel.Click += new System.EventHandler(this.buttonProcessChannel_Click);
            // 
            // imageBox2
            // 
            this.imageBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.imageBox2.Location = new System.Drawing.Point(323, 10);
            this.imageBox2.Name = "imageBox2";
            this.imageBox2.Size = new System.Drawing.Size(301, 430);
            this.imageBox2.TabIndex = 7;
            this.imageBox2.TabStop = false;
            // 
            // buttonConvertToGrayscale
            // 
            this.buttonConvertToGrayscale.Location = new System.Drawing.Point(633, 93);
            this.buttonConvertToGrayscale.Name = "buttonConvertToGrayscale";
            this.buttonConvertToGrayscale.Size = new System.Drawing.Size(79, 26);
            this.buttonConvertToGrayscale.TabIndex = 8;
            this.buttonConvertToGrayscale.Text = "Создать ч/б";
            this.buttonConvertToGrayscale.UseVisualStyleBackColor = true;
            this.buttonConvertToGrayscale.Click += new System.EventHandler(this.buttonConvertToGrayscale_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(630, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Канал:";
            // 
            // buttonConvertToSepia
            // 
            this.buttonConvertToSepia.Location = new System.Drawing.Point(717, 93);
            this.buttonConvertToSepia.Name = "buttonConvertToSepia";
            this.buttonConvertToSepia.Size = new System.Drawing.Size(69, 26);
            this.buttonConvertToSepia.TabIndex = 10;
            this.buttonConvertToSepia.Text = "Сепия";
            this.buttonConvertToSepia.UseVisualStyleBackColor = true;
            this.buttonConvertToSepia.Click += new System.EventHandler(this.buttonConvertToSepia_Click);
            // 
            // trackBarBrightness
            // 
            this.trackBarBrightness.Location = new System.Drawing.Point(637, 135);
            this.trackBarBrightness.Maximum = 100;
            this.trackBarBrightness.Minimum = -100;
            this.trackBarBrightness.Name = "trackBarBrightness";
            this.trackBarBrightness.Size = new System.Drawing.Size(153, 45);
            this.trackBarBrightness.TabIndex = 11;
            this.trackBarBrightness.Scroll += new System.EventHandler(this.trackBarBrightness_Scroll);
            // 
            // trackBarContrast
            // 
            this.trackBarContrast.Location = new System.Drawing.Point(633, 186);
            this.trackBarContrast.Maximum = 100;
            this.trackBarContrast.Name = "trackBarContrast";
            this.trackBarContrast.Size = new System.Drawing.Size(153, 45);
            this.trackBarContrast.TabIndex = 12;
            this.trackBarContrast.Value = 50;
            this.trackBarContrast.Scroll += new System.EventHandler(this.trackBarContrast_Scroll);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(630, 122);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "Яркость";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(630, 170);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 13);
            this.label3.TabIndex = 14;
            this.label3.Text = "Контраст";
            // 
            // comboBoxConvertToHSV
            // 
            this.comboBoxConvertToHSV.FormattingEnabled = true;
            this.comboBoxConvertToHSV.Location = new System.Drawing.Point(633, 321);
            this.comboBoxConvertToHSV.Name = "comboBoxConvertToHSV";
            this.comboBoxConvertToHSV.Size = new System.Drawing.Size(153, 21);
            this.comboBoxConvertToHSV.TabIndex = 16;
            this.comboBoxConvertToHSV.SelectedIndexChanged += new System.EventHandler(this.comboBoxConvertToHSV_SelectedIndexChanged);
            // 
            // trackBar1
            // 
            this.trackBar1.Location = new System.Drawing.Point(633, 348);
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(153, 45);
            this.trackBar1.TabIndex = 17;
            this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(634, 272);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(0, 13);
            this.label4.TabIndex = 18;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(630, 305);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(98, 13);
            this.label5.TabIndex = 19;
            this.label5.Text = "Выбор параметра";
            // 
            // buttonMedianBlur
            // 
            this.buttonMedianBlur.Location = new System.Drawing.Point(633, 385);
            this.buttonMedianBlur.Name = "buttonMedianBlur";
            this.buttonMedianBlur.Size = new System.Drawing.Size(153, 22);
            this.buttonMedianBlur.TabIndex = 21;
            this.buttonMedianBlur.Text = "Медианное размытие";
            this.buttonMedianBlur.UseVisualStyleBackColor = true;
            this.buttonMedianBlur.Click += new System.EventHandler(this.buttonMedianBlur_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(633, 413);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox1.Size = new System.Drawing.Size(153, 50);
            this.textBox1.TabIndex = 22;
            // 
            // buttonApplyFilter
            // 
            this.buttonApplyFilter.Location = new System.Drawing.Point(712, 469);
            this.buttonApplyFilter.Name = "buttonApplyFilter";
            this.buttonApplyFilter.Size = new System.Drawing.Size(74, 25);
            this.buttonApplyFilter.TabIndex = 23;
            this.buttonApplyFilter.Text = "Применить";
            this.buttonApplyFilter.UseVisualStyleBackColor = true;
            this.buttonApplyFilter.Click += new System.EventHandler(this.buttonApplyFilter_Click);
            // 
            // buttonLogicalAnd
            // 
            this.buttonLogicalAnd.Location = new System.Drawing.Point(633, 254);
            this.buttonLogicalAnd.Name = "buttonLogicalAnd";
            this.buttonLogicalAnd.Size = new System.Drawing.Size(87, 21);
            this.buttonLogicalAnd.TabIndex = 24;
            this.buttonLogicalAnd.Text = "Пересечение";
            this.buttonLogicalAnd.UseVisualStyleBackColor = true;
            this.buttonLogicalAnd.Click += new System.EventHandler(this.buttonLogicalAnd_Click_1);
            // 
            // buttonLogicalXor
            // 
            this.buttonLogicalXor.Location = new System.Drawing.Point(633, 281);
            this.buttonLogicalXor.Name = "buttonLogicalXor";
            this.buttonLogicalXor.Size = new System.Drawing.Size(87, 21);
            this.buttonLogicalXor.TabIndex = 25;
            this.buttonLogicalXor.Text = "Исключение";
            this.buttonLogicalXor.UseVisualStyleBackColor = true;
            this.buttonLogicalXor.Click += new System.EventHandler(this.buttonLogicalXor_Click);
            // 
            // buttonLogicalNot
            // 
            this.buttonLogicalNot.Location = new System.Drawing.Point(633, 227);
            this.buttonLogicalNot.Name = "buttonLogicalNot";
            this.buttonLogicalNot.Size = new System.Drawing.Size(87, 21);
            this.buttonLogicalNot.TabIndex = 26;
            this.buttonLogicalNot.Text = "Дополнение";
            this.buttonLogicalNot.UseVisualStyleBackColor = true;
            this.buttonLogicalNot.Click += new System.EventHandler(this.buttonLogicalNot_Click);
            // 
            // buttonLoadSecondImage_Click
            // 
            this.buttonLoadSecondImage_Click.Location = new System.Drawing.Point(726, 254);
            this.buttonLoadSecondImage_Click.Name = "buttonLoadSecondImage_Click";
            this.buttonLoadSecondImage_Click.Size = new System.Drawing.Size(89, 48);
            this.buttonLoadSecondImage_Click.TabIndex = 27;
            this.buttonLoadSecondImage_Click.Text = "Второе изображение";
            this.buttonLoadSecondImage_Click.UseVisualStyleBackColor = true;
            this.buttonLoadSecondImage_Click.Click += new System.EventHandler(this.buttonLoadSecondImage_Click_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(884, 525);
            this.Controls.Add(this.buttonLoadSecondImage_Click);
            this.Controls.Add(this.buttonLogicalNot);
            this.Controls.Add(this.buttonLogicalXor);
            this.Controls.Add(this.buttonLogicalAnd);
            this.Controls.Add(this.buttonApplyFilter);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.buttonMedianBlur);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.trackBar1);
            this.Controls.Add(this.comboBoxConvertToHSV);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.trackBarContrast);
            this.Controls.Add(this.trackBarBrightness);
            this.Controls.Add(this.buttonConvertToSepia);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonConvertToGrayscale);
            this.Controls.Add(this.imageBox2);
            this.Controls.Add(this.buttonProcessChannel);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.buttonLoadImage);
            this.Controls.Add(this.imageBox1);
            this.Name = "Form1";
            this.Text = "Фотофильтры";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.imageBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarBrightness)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarContrast)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Emgu.CV.UI.ImageBox imageBox1;
        private System.Windows.Forms.Button buttonLoadImage;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button buttonProcessChannel;
        private Emgu.CV.UI.ImageBox imageBox2;
        private System.Windows.Forms.Button buttonConvertToGrayscale;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonConvertToSepia;
        private System.Windows.Forms.TrackBar trackBarBrightness;
        private System.Windows.Forms.TrackBar trackBarContrast;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBoxConvertToHSV;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button buttonMedianBlur;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button buttonApplyFilter;
        private System.Windows.Forms.Button buttonLogicalAnd;
        private System.Windows.Forms.Button buttonLogicalXor;
        private System.Windows.Forms.Button buttonLogicalNot;
        private System.Windows.Forms.Button buttonLoadSecondImage_Click;
    }
}


namespace Sklad
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.CBUnits = new System.Windows.Forms.ComboBox();
            this.CBProvider = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.CBGrupa = new System.Windows.Forms.ComboBox();
            this.DGSklad = new System.Windows.Forms.DataGridView();
            this.BAddRowToTable = new System.Windows.Forms.Button();
            this.TBKilkist = new System.Windows.Forms.TextBox();
            this.TBCina = new System.Windows.Forms.TextBox();
            this.TBVyrobnyk = new System.Windows.Forms.TextBox();
            this.TBNazva = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.записатиТаблицюToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.зчитатиТаблицюToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.записатиВБДToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.зчитатиЗБДToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.фільтруватиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.встановитиФільтрToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.знятиФільтрToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сортуватиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.встановитиКритерійСортуванняToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сортуватиПоГрупіToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.пошукToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.пошукПоНазвіToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.друкToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DGSkladSum = new System.Windows.Forms.DataGridView();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGSklad)).BeginInit();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGSkladSum)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.splitContainer1.Panel1.Controls.Add(this.CBUnits);
            this.splitContainer1.Panel1.Controls.Add(this.CBProvider);
            this.splitContainer1.Panel1.Controls.Add(this.label8);
            this.splitContainer1.Panel1.Controls.Add(this.label7);
            this.splitContainer1.Panel1.Controls.Add(this.CBGrupa);
            this.splitContainer1.Panel1.Controls.Add(this.DGSklad);
            this.splitContainer1.Panel1.Controls.Add(this.BAddRowToTable);
            this.splitContainer1.Panel1.Controls.Add(this.TBKilkist);
            this.splitContainer1.Panel1.Controls.Add(this.TBCina);
            this.splitContainer1.Panel1.Controls.Add(this.TBVyrobnyk);
            this.splitContainer1.Panel1.Controls.Add(this.TBNazva);
            this.splitContainer1.Panel1.Controls.Add(this.label6);
            this.splitContainer1.Panel1.Controls.Add(this.label5);
            this.splitContainer1.Panel1.Controls.Add(this.label4);
            this.splitContainer1.Panel1.Controls.Add(this.label3);
            this.splitContainer1.Panel1.Controls.Add(this.label2);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            this.splitContainer1.Panel1.Controls.Add(this.menuStrip1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.DGSkladSum);
            this.splitContainer1.Size = new System.Drawing.Size(803, 455);
            this.splitContainer1.SplitterDistance = 320;
            this.splitContainer1.TabIndex = 0;
            // 
            // CBUnits
            // 
            this.CBUnits.FormattingEnabled = true;
            this.CBUnits.Location = new System.Drawing.Point(456, 61);
            this.CBUnits.Name = "CBUnits";
            this.CBUnits.Size = new System.Drawing.Size(54, 21);
            this.CBUnits.TabIndex = 18;
            // 
            // CBProvider
            // 
            this.CBProvider.FormattingEnabled = true;
            this.CBProvider.Location = new System.Drawing.Point(350, 61);
            this.CBProvider.Name = "CBProvider";
            this.CBProvider.Size = new System.Drawing.Size(100, 21);
            this.CBProvider.TabIndex = 17;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(453, 47);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(60, 13);
            this.label8.TabIndex = 16;
            this.label8.Text = "Од. виміру";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(361, 47);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(79, 13);
            this.label7.TabIndex = 15;
            this.label7.Text = "Постачальник";
            // 
            // CBGrupa
            // 
            this.CBGrupa.FormattingEnabled = true;
            this.CBGrupa.Location = new System.Drawing.Point(12, 62);
            this.CBGrupa.Name = "CBGrupa";
            this.CBGrupa.Size = new System.Drawing.Size(121, 21);
            this.CBGrupa.TabIndex = 14;
            // 
            // DGSklad
            // 
            this.DGSklad.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGSklad.Location = new System.Drawing.Point(0, 89);
            this.DGSklad.Name = "DGSklad";
            this.DGSklad.Size = new System.Drawing.Size(800, 228);
            this.DGSklad.TabIndex = 12;
            this.DGSklad.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.DGSklad_CellValidating);
            this.DGSklad.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGSklad_CellValueChanged);
            // 
            // BAddRowToTable
            // 
            this.BAddRowToTable.Location = new System.Drawing.Point(737, 27);
            this.BAddRowToTable.Name = "BAddRowToTable";
            this.BAddRowToTable.Size = new System.Drawing.Size(54, 61);
            this.BAddRowToTable.TabIndex = 11;
            this.BAddRowToTable.Text = "Додати";
            this.BAddRowToTable.UseVisualStyleBackColor = true;
            this.BAddRowToTable.Click += new System.EventHandler(this.BAddRowToTable_Click);
            // 
            // TBKilkist
            // 
            this.TBKilkist.Location = new System.Drawing.Point(622, 63);
            this.TBKilkist.Name = "TBKilkist";
            this.TBKilkist.Size = new System.Drawing.Size(95, 20);
            this.TBKilkist.TabIndex = 10;
            // 
            // TBCina
            // 
            this.TBCina.Location = new System.Drawing.Point(516, 62);
            this.TBCina.Name = "TBCina";
            this.TBCina.Size = new System.Drawing.Size(100, 20);
            this.TBCina.TabIndex = 9;
            // 
            // TBVyrobnyk
            // 
            this.TBVyrobnyk.Location = new System.Drawing.Point(245, 62);
            this.TBVyrobnyk.Name = "TBVyrobnyk";
            this.TBVyrobnyk.Size = new System.Drawing.Size(100, 20);
            this.TBVyrobnyk.TabIndex = 8;
            // 
            // TBNazva
            // 
            this.TBNazva.Location = new System.Drawing.Point(139, 62);
            this.TBNazva.Name = "TBNazva";
            this.TBNazva.Size = new System.Drawing.Size(100, 20);
            this.TBNazva.TabIndex = 7;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(619, 47);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Кількість";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(548, 47);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Ціна";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(270, 46);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Виробник";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(167, 46);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Назва";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(53, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Група";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(336, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Дані таблиці";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлToolStripMenuItem,
            this.фільтруватиToolStripMenuItem,
            this.сортуватиToolStripMenuItem,
            this.пошукToolStripMenuItem,
            this.друкToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(803, 24);
            this.menuStrip1.TabIndex = 13;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // файлToolStripMenuItem
            // 
            this.файлToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.записатиТаблицюToolStripMenuItem,
            this.зчитатиТаблицюToolStripMenuItem,
            this.записатиВБДToolStripMenuItem,
            this.зчитатиЗБДToolStripMenuItem});
            this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            this.файлToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.файлToolStripMenuItem.Text = "Файл";
            // 
            // записатиТаблицюToolStripMenuItem
            // 
            this.записатиТаблицюToolStripMenuItem.Name = "записатиТаблицюToolStripMenuItem";
            this.записатиТаблицюToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.записатиТаблицюToolStripMenuItem.Text = "Записати таблицю";
            this.записатиТаблицюToolStripMenuItem.Click += new System.EventHandler(this.записатиТаблицюToolStripMenuItem_Click);
            // 
            // зчитатиТаблицюToolStripMenuItem
            // 
            this.зчитатиТаблицюToolStripMenuItem.Name = "зчитатиТаблицюToolStripMenuItem";
            this.зчитатиТаблицюToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.зчитатиТаблицюToolStripMenuItem.Text = "Зчитати таблицю";
            this.зчитатиТаблицюToolStripMenuItem.Click += new System.EventHandler(this.зчитатиТаблицюToolStripMenuItem_Click);
            // 
            // записатиВБДToolStripMenuItem
            // 
            this.записатиВБДToolStripMenuItem.Name = "записатиВБДToolStripMenuItem";
            this.записатиВБДToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.записатиВБДToolStripMenuItem.Text = "Записати в БД";
            this.записатиВБДToolStripMenuItem.Click += new System.EventHandler(this.записатиВБДToolStripMenuItem_Click);
            // 
            // зчитатиЗБДToolStripMenuItem
            // 
            this.зчитатиЗБДToolStripMenuItem.Name = "зчитатиЗБДToolStripMenuItem";
            this.зчитатиЗБДToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.зчитатиЗБДToolStripMenuItem.Text = "Зчитати З БД";
            this.зчитатиЗБДToolStripMenuItem.Click += new System.EventHandler(this.зчитатиЗБДToolStripMenuItem_Click);
            // 
            // фільтруватиToolStripMenuItem
            // 
            this.фільтруватиToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.встановитиФільтрToolStripMenuItem,
            this.знятиФільтрToolStripMenuItem});
            this.фільтруватиToolStripMenuItem.Name = "фільтруватиToolStripMenuItem";
            this.фільтруватиToolStripMenuItem.Size = new System.Drawing.Size(86, 20);
            this.фільтруватиToolStripMenuItem.Text = "Фільтрувати";
            // 
            // встановитиФільтрToolStripMenuItem
            // 
            this.встановитиФільтрToolStripMenuItem.Name = "встановитиФільтрToolStripMenuItem";
            this.встановитиФільтрToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.встановитиФільтрToolStripMenuItem.Text = "Встановити фільтр";
            this.встановитиФільтрToolStripMenuItem.Click += new System.EventHandler(this.встановитиФільтрToolStripMenuItem_Click);
            // 
            // знятиФільтрToolStripMenuItem
            // 
            this.знятиФільтрToolStripMenuItem.Name = "знятиФільтрToolStripMenuItem";
            this.знятиФільтрToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.знятиФільтрToolStripMenuItem.Text = "Зняти фільтр";
            this.знятиФільтрToolStripMenuItem.Click += new System.EventHandler(this.знятиФільтрToolStripMenuItem_Click);
            // 
            // сортуватиToolStripMenuItem
            // 
            this.сортуватиToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.встановитиКритерійСортуванняToolStripMenuItem,
            this.сортуватиПоГрупіToolStripMenuItem});
            this.сортуватиToolStripMenuItem.Name = "сортуватиToolStripMenuItem";
            this.сортуватиToolStripMenuItem.Size = new System.Drawing.Size(76, 20);
            this.сортуватиToolStripMenuItem.Text = "Сортувати";
            // 
            // встановитиКритерійСортуванняToolStripMenuItem
            // 
            this.встановитиКритерійСортуванняToolStripMenuItem.Name = "встановитиКритерійСортуванняToolStripMenuItem";
            this.встановитиКритерійСортуванняToolStripMenuItem.Size = new System.Drawing.Size(254, 22);
            this.встановитиКритерійСортуванняToolStripMenuItem.Text = "Встановити критерій сортування";
            this.встановитиКритерійСортуванняToolStripMenuItem.Click += new System.EventHandler(this.встановитиКритерійСортуванняToolStripMenuItem_Click);
            // 
            // сортуватиПоГрупіToolStripMenuItem
            // 
            this.сортуватиПоГрупіToolStripMenuItem.Name = "сортуватиПоГрупіToolStripMenuItem";
            this.сортуватиПоГрупіToolStripMenuItem.Size = new System.Drawing.Size(254, 22);
            this.сортуватиПоГрупіToolStripMenuItem.Text = "Сортувати по групі";
            this.сортуватиПоГрупіToolStripMenuItem.Click += new System.EventHandler(this.сортуватиПоГрупіToolStripMenuItem_Click);
            // 
            // пошукToolStripMenuItem
            // 
            this.пошукToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.пошукПоНазвіToolStripMenuItem});
            this.пошукToolStripMenuItem.Name = "пошукToolStripMenuItem";
            this.пошукToolStripMenuItem.Size = new System.Drawing.Size(58, 20);
            this.пошукToolStripMenuItem.Text = "Пошук";
            // 
            // пошукПоНазвіToolStripMenuItem
            // 
            this.пошукПоНазвіToolStripMenuItem.Name = "пошукПоНазвіToolStripMenuItem";
            this.пошукПоНазвіToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.пошукПоНазвіToolStripMenuItem.Text = "Пошук по назві";
            this.пошукПоНазвіToolStripMenuItem.Click += new System.EventHandler(this.пошукПоНазвіToolStripMenuItem_Click);
            // 
            // друкToolStripMenuItem
            // 
            this.друкToolStripMenuItem.Name = "друкToolStripMenuItem";
            this.друкToolStripMenuItem.Size = new System.Drawing.Size(46, 20);
            this.друкToolStripMenuItem.Text = "Друк";
            this.друкToolStripMenuItem.Click += new System.EventHandler(this.друкToolStripMenuItem_Click);
            // 
            // DGSkladSum
            // 
            this.DGSkladSum.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGSkladSum.Location = new System.Drawing.Point(0, 2);
            this.DGSkladSum.Name = "DGSkladSum";
            this.DGSkladSum.Size = new System.Drawing.Size(800, 124);
            this.DGSkladSum.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(803, 455);
            this.Controls.Add(this.splitContainer1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DGSklad)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGSkladSum)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridView DGSklad;
        private System.Windows.Forms.Button BAddRowToTable;
        private System.Windows.Forms.TextBox TBKilkist;
        private System.Windows.Forms.TextBox TBCina;
        private System.Windows.Forms.TextBox TBVyrobnyk;
        private System.Windows.Forms.TextBox TBNazva;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView DGSkladSum;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem записатиТаблицюToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem зчитатиТаблицюToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem фільтруватиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem встановитиФільтрToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem знятиФільтрToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem сортуватиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem встановитиКритерійСортуванняToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem сортуватиПоГрупіToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem пошукToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem пошукПоНазвіToolStripMenuItem;
        private System.Windows.Forms.ComboBox CBGrupa;
        private System.Windows.Forms.ToolStripMenuItem друкToolStripMenuItem;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.ComboBox CBUnits;
        private System.Windows.Forms.ComboBox CBProvider;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ToolStripMenuItem записатиВБДToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem зчитатиЗБДToolStripMenuItem;
    }
}


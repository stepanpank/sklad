using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Drawing;
using System.IO;
using System.Drawing.Printing;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sklad
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        private TSklad MySklad;
        public static string GlStringParameter;
        private Container component;
        private Font printFont;
        private StreamReader streamToPrint;
        private void Form1_Load(object sender, EventArgs e)
        {
            MySklad = new TSklad();
            // Прив'яжемо DataGridView, що на формі Form1 до SkladView, який поставлено на таблицю TabSklad:
            DGSklad.DataSource = MySklad.TabSklad;
            DGSklad.DataSource = MySklad.SkladView;
            MySklad.CreateDovGrupa();
            MySklad.AddComboGrupa(DGSklad);
            foreach (DataRow r in MySklad.DovGrupa.Rows) // Для кожного рядка rr із таблиці DovGrupa
            {
                string s = (string)r["Група"];
                CBGrupa.Items.Add(r["Група"]); // Додаємо у "випадайку" контрола ComboBox елементи із довідника
            }
            MySklad.CreateDovProvider();
            MySklad.AddComboProvider(DGSklad);
            foreach (DataRow r in MySklad.DovProvider.Rows) // Для кожного рядка rr із таблиці DovGrupa
            {
                string s = (string)r["Постачальник"];
                CBProvider.Items.Add(r["Постачальник"]); // Додаємо у "випадайку" контрола ComboBox елементи із довідника
            }
            MySklad.CreateDovUnits();
            MySklad.AddComboUnits(DGSklad);
            foreach (DataRow r in MySklad.DovUnits.Rows) // Для кожного рядка rr із таблиці DovGrupa
            {
                string s = (string)r["Од.виміру"];
                CBUnits.Items.Add(r["Од.виміру"]); // Додаємо у "випадайку" контрола ComboBox елементи із довідника
            }
        }

        private void BAddRowToTable_Click(object sender, EventArgs e)
        {
            Decimal pPcina = 0;
            Int32 pKilkist = 0;
            try
            {
                if (TBCina.Text != "")
                    pPcina = Convert.ToDecimal(TBCina.Text);
            }
            catch
            {
                MessageBox.Show("Введіть у поле ціни числове значення");
                return;
            }
            try
            {
                if (TBKilkist.Text != "")
                    pKilkist = Convert.ToInt32(TBKilkist.Text);
            }
            catch
            {
                MessageBox.Show("Введіть у поле кількості числове значення");
                return;
            }
            MySklad.TSkladAddRow(CBGrupa.Text, TBNazva.Text, TBVyrobnyk.Text, CBProvider.Text, CBUnits.Text, pKilkist, pPcina);
            MySklad.SetSumy(DGSkladSum);
        }

        private void записатиТаблицюToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MySklad.ZapTabFile();
            MessageBox.Show("Таблиця записана");
        }

        private void зчитатиТаблицюToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MySklad.ReadTabFile(DGSkladSum);
        }

        private void DGSklad_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            int i, j; decimal vart, kilk, cin;
            i = e.RowIndex; // Індекс рядка
            j = e.ColumnIndex; // Індекс стовпця
            if (i < 0) return; // Якщо i < 0 або j < 0, то це – заголовок стовпця або рядка
            if (j < 0) return;
            if ((DGSklad.Columns[j].Name == "Кількість") ^ (DGSklad.Columns[j].Name == "Ціна"))
            // Якщо змінювалась ціна або кількість
            {
                try // Спробуємо, бо, можливо, введено не числа у поле ціни або кількості
                {
                    cin = (decimal)DGSklad.Rows[i].Cells["Ціна"].Value;
                    kilk = Convert.ToDecimal((Int32)DGSklad.Rows[i].Cells["Кількість"].Value);
                    vart = kilk * cin; // Вартість
                    DGSklad.Rows[i].Cells["Вартість"].Value = vart; // Запишемо вартість у комірку гріда
                }
                catch { }
            }
            MySklad.SetSumy(DGSkladSum);
        }

        private void встановитиФільтрToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form FiltrDialog = new FServ(); // Створюємо екземпляр форми FServ і назвемо його FiltrDialog
                                            // Встановимо текст заголовку форми FServ
            FiltrDialog.Text = "Введіть критерій фільтруванна - наприклад: Група = 'Книги' & Ціна < 70";
            GlStringParameter = MySklad.FiltrCriteria;
            /* Відкриємо форму у режимі діалогу. Це означає, що наступний оператор, що слідує за оператором FiltrDialog.ShowDialog(); буде
            виконуватись лише після того, як буде закрито форму, яку викликали */
            FiltrDialog.ShowDialog();
            MySklad.TSkladValFiltr(GlStringParameter, DGSklad);
        }

        private void знятиФільтрToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GlStringParameter = ""; // Відмінити фільтрування таблиці
            MySklad.TSkladValFiltr(GlStringParameter, DGSklad);
        }

        private void встановитиКритерійСортуванняToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form SortDialog = new FServ(); // Створюємо екземпляр форми FServ і називаємо його SortDialog
                                           // Встановимо текст заголовку форми FServ
            SortDialog.Text = "Введіть критерій сортування - наприклад: Виробник, Ціна Desc";
            GlStringParameter = MySklad.SortCriteria;
            /* Відкриємо форму у режимі діалогу. Це означає, що оператор, який слідує за оператором FiltrDialog.ShowDialog(); буде
            виконуватись лише після того, як буде закрито форму, яку було викликано (тут – SortDialog) */
            SortDialog.ShowDialog();
            MySklad.TSkladValSort(GlStringParameter, DGSklad, DGSkladSum);
        }

        private void сортуватиПоГрупіToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GlStringParameter = "Група, Назва";
            MySklad.TSkladValSort(GlStringParameter, DGSklad, DGSkladSum);
        }

        private void пошукПоНазвіToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string sNazva; // Встановимо текст заголовку форми FServ
            Form SeekDialog = new FServ(); // Створюємо екземпляр форми FServ і називаємо його SeekDialog
            SeekDialog.Text = "Введіть назву:";
            /* Відкриваємо форму у режимі діалогу. Це означає, що що оператор, який слідує за оператором SeekDialog.ShowDialog(); буде
            виконуватись лише після того, коли буде закрито форму, яку було викликано (тут SeekDialog) */
            SeekDialog.ShowDialog();
            MySklad.SeekNazva(GlStringParameter, DGSklad);
        }

        private void DGSklad_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            decimal cin; Int32 kilk;
            if (DGSklad.Columns[e.ColumnIndex].Name == "Ціна") // Якщо змінювалась ціна
            {
                if (DGSklad.Rows[e.RowIndex].IsNewRow)
                {
                    return;
                } // Не можна перевіряти дані у новому рядку
                  // Перевіряємо, чи введені дані можна трактувати як десяткове число
                if (!decimal.TryParse(e.FormattedValue.ToString(), out cin))
                // Метод TryParse поверне значення true, якщо можна і false, якщо ні. e.FormattedValue – введене значення
                {
                    MessageBox.Show("Введіть, будь ласка, числове значення у поле ціни .");
                    // e.Cancel = true; - Відмінити введення не правильного значення
                }
            }
            if (DGSklad.Columns[e.ColumnIndex].Name == "Кількість") // Якщо змінювалась кількість
            {
                if (DGSklad.Rows[e.RowIndex].IsNewRow)
                { return; } // Не можна перевіряти дані у новому рядку
                            // Перевіряємо, чи введені дані можна трактувати як ціле число
                            // Метод TryParse поверне значення true, якщо можна і false, якщо ні. e.FormattedValue – введене значення
                if (!Int32.TryParse(e.FormattedValue.ToString(), out kilk))
                {
                    MessageBox.Show("Введіть,будь ласка, ціле числове значення у поле кількості.");
                    e.Cancel = true; // Відмінити введення не правильного значення
                }
            }
        }

        private void друкToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                streamToPrint = new StreamReader
               ("C:\\My Documents\\MyFile.txt");

                try
                {
                    printFont = new Font("Arial", 10);
                    PrintDocument pd = new PrintDocument();
                    pd.PrintPage += new PrintPageEventHandler
                       (this.pd_PrintPage);
                    pd.Print();
                }
                finally
                {
                    streamToPrint.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void pd_PrintPage(object sender, PrintPageEventArgs ev)
        {
            float linesPerPage = 0;
            float yPos = 0;
            int count = 0;
            float leftMargin = ev.MarginBounds.Left;
            float topMargin = ev.MarginBounds.Top;
            string line = null;

            // Calculate the number of lines per page.
            linesPerPage = ev.MarginBounds.Height /
               printFont.GetHeight(ev.Graphics);

            // Print each line of the file.
            while (count < linesPerPage &&
               ((line = streamToPrint.ReadLine()) != null))
            {
                yPos = topMargin + (count *
                   printFont.GetHeight(ev.Graphics));
                ev.Graphics.DrawString(line, printFont, Brushes.Black,
                   leftMargin, yPos, new StringFormat());
                count++;
            }

            // If more lines exist, print another page.
            if (line != null)
                ev.HasMorePages = true;
            else
                ev.HasMorePages = false;
        }

        private void записатиВБДToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SqlConnection SqlConnection1 = new SqlConnection(); // Оголосили з'єднання SqlConnection1

            SqlCommand cmd = new SqlCommand(); // Оголосили команду
            cmd.Connection = SqlConnection1; // Назначили команді з'єднання
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "spSkladTabRead"; // Назначили команді сторед-процедуру
            SqlConnection1.ConnectionString = "Data Source=DESKTOP-4TCJ0IE\\SQLEXPRESS;Initial Catalog=Sklad;Integrated Security=True";
            SqlConnection1.Open(); // Відкриємо з'єднання з сервером
            SqlDataReader SqlIn = cmd.ExecuteReader(); // Оголосили DataReader
            MySklad.TabSklad.Rows.Clear(); // Очистили таблицю
            while (SqlIn.Read()) // Запустили датарідер
            {
                DataRow rowSklad = MySklad.TabSklad.NewRow(); // Створюємо новий рядок таблиці TabSklad класу Sklad
                int nn; decimal d1, d2, d3;
                nn = SqlIn.GetInt32(0);
                rowSklad["N_пп"] = SqlIn.GetInt32(0); // присвоюємо значенням полів значення, отримані з таблиці бази даних
                rowSklad["Група"] = SqlIn.GetString(1);
                rowSklad["Назва"] = SqlIn.GetString(2);
                rowSklad["Виробник"] = SqlIn.GetString(3);
                rowSklad["Ціна"] = SqlIn.GetDecimal(4);
                rowSklad["Кількість"] = SqlIn.GetInt32(5);
                d1 = (decimal)rowSklad["Ціна"];
                d2 = (int)rowSklad["Кількість"];
                d3 = d1 * d2;
                rowSklad["Вартість"] = (decimal)rowSklad["Ціна"] * (int)rowSklad["Кількість"];
                MySklad.TabSklad.Rows.Add(rowSklad); // Додаємо сформований рядок до таблиці
            }
            SqlConnection1.Close();
        }

        private void зчитатиЗБДToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SqlConnection SqlConnection1 = new SqlConnection();// Оголосили з'єднання SqlConnection1
            SqlCommand cmd = new SqlCommand(); // Оголосили команду
            cmd.Connection = SqlConnection1; // Назначили команді з'єднання
            cmd.CommandType = CommandType.StoredProcedure;
            SqlTransaction tranPlSave;
            SqlConnection1.ConnectionString = "Data Source=DESKTOP-4TCJ0IE\\SQLEXPRESS;Initial Catalog=Sklad;Integrated Security=True";
            SqlConnection1.Open(); // Відкрили з'єднання

            tranPlSave = SqlConnection1.BeginTransaction("tranPlSave");
            cmd.Transaction = tranPlSave;
            // Такий вигляд має заголовок сторед-процедури для записування рядка таблиці у склад:
            // spZapSklad(@N_pp as int,@Grupa as nvarchar(255),@Nazva as nvarchar(255),@Vyrobnyk as nvarchar(255),
            //@Cina as decimal(12,2),@Kilkist as int )
            // Організовуємо колекцію параметрів для сторед процедури:
            cmd.Parameters.Clear();
            try
            {
                cmd.CommandText = "spClearSklad";// Назначили команді сторед-процедуру для очищення таблиці склад у базі
                cmd.ExecuteNonQuery(); // Очистили таблицю склад у базі
                cmd.CommandText = "spZapSklad"; // Назначили команді сторед-процедуру для записування у таблицю склад у базі
                foreach (DataRow rr in MySklad.TabSklad.Rows) //Для кожного рядка rr із таблиці TabSklad
                {
                    cmd.Parameters.Clear();
                    SqlParameter par1 = new SqlParameter("@N_pp", SqlDbType.Int);
                    par1.Value = rr["N_пп"];
                    SqlParameter par2 = new SqlParameter("@Grupa", SqlDbType.NVarChar, 255);
                    par2.Value = rr["Група"];
                    SqlParameter par3 = new SqlParameter("@Nazva", SqlDbType.NVarChar, 255);
                    par3.Value = rr["Назва"];
                    SqlParameter par4 = new SqlParameter("@Vyrobnyk", SqlDbType.NVarChar, 255);
                    par4.Value = rr["Виробник"];
                    SqlParameter par5 = new SqlParameter("@Cina", SqlDbType.Decimal, 12);
                    par5.Value = rr["Ціна"];
                    SqlParameter par6 = new SqlParameter("@Kilkist", SqlDbType.Int);
                    par6.Value = rr["Кількість"];
                    cmd.Parameters.Add(par1);
                    cmd.Parameters.Add(par2);
                    cmd.Parameters.Add(par3);
                    cmd.Parameters.Add(par4);
                    cmd.Parameters.Add(par5);
                    cmd.Parameters.Add(par6);
                    cmd.ExecuteNonQuery();
                }
                tranPlSave.Commit(); // Підтвердити всі зміни у базі
            }
            catch
            {
                tranPlSave.Rollback(); // Виконати "відкат" у випадку невдалого записування
            }
            SqlConnection1.Close(); 
            MessageBox.Show("Таблиця записана у базу даних");
        }
    }

    public class TSklad
    {
        public DataTable TabSklad = new DataTable();
        public DataView SkladView;
        public string FiltrCriteria; // Поле для зберігання критерію фільтрування
        public string SortCriteria; // Поле для зберігання критерію сортуванн
        public DataGridViewComboBoxColumn cGrupaCB;
        public DataTable DovGrupa = new DataTable();
        public DataGridViewComboBoxColumn cProviderCB;
        public DataTable DovProvider = new DataTable();
        public DataGridViewComboBoxColumn cUnitsCB;
        public DataTable DovUnits = new DataTable();

        public TSklad()
        {
            /* Створюємо стовпці таблиці. Тут cNpp, cNameGroup, cNameProduct, cProduser, cCount, cPrise, cVartist - назви
            об'єктів типу DataColumn, а кириличні слова у лапках - значення їхніх властивості ColumName. Назва стовпця ColumName може бути і
            кириличною */
            DataColumn cNpp = new DataColumn("N_пп");
            DataColumn cNameGroup = new DataColumn("Група");
            DataColumn cNameProduct = new DataColumn("Назва");
            DataColumn cProduser = new DataColumn("Виробник");
            DataColumn сProvider = new DataColumn("Постачальник");
            DataColumn cUnits = new DataColumn("Од.виміру");
            DataColumn cCount = new DataColumn("Кількість");
            DataColumn cPrise = new DataColumn("Ціна");
            DataColumn cVartist = new DataColumn("Вартість");
            SkladView = new DataView(TabSklad);
            // Оголошуємо типи даних, що будуть зберігатись у стовпцях
            cNpp.DataType = System.Type.GetType("System.Int32");
            cNameGroup.DataType = System.Type.GetType("System.String");
            cProduser.DataType = System.Type.GetType("System.String");
            сProvider.DataType = System.Type.GetType("System.String");
            cUnits.DataType = System.Type.GetType("System.String");
            cCount.DataType = System.Type.GetType("System.Int32");
            cPrise.DataType = System.Type.GetType("System.Decimal");
            cVartist.DataType = System.Type.GetType("System.Decimal");
            // Додаємо стовпці до таблиці
            TabSklad.Columns.Add(cNpp);
            TabSklad.Columns.Add(cNameGroup);
            TabSklad.Columns.Add(cNameProduct);
            TabSklad.Columns.Add(cProduser);
            TabSklad.Columns.Add(сProvider);
            TabSklad.Columns.Add(cUnits);
            TabSklad.Columns.Add(cPrise);
            TabSklad.Columns.Add(cCount);
            TabSklad.Columns.Add(cVartist);
        }
        public void TSkladAddRow(string pNameGroup, string pNameProduct, string pProduser, string pProvider, string pUnits, int pCount, decimal pPrise)
        {
            int nn;
            nn = TabSklad.Rows.Count;
            // Оголошуємо змінну rowSklad як рядок таблиці TabSklad
            // Такий рядок буде містити поля з тими ж назвами, що й стовпці таблиці
            DataRow rowSklad = TabSklad.NewRow();
            rowSklad["N_пп"] = nn++; // Присвоюємо полям значення, які отримані через параметри
            rowSklad["Група"] = pNameGroup;
            rowSklad["Назва"] = pNameProduct;
            rowSklad["Виробник"] = pProduser;
            rowSklad["Постачальник"] = pProvider;
            rowSklad["Од.виміру"] = pUnits;
            rowSklad["Ціна"] = pPrise;
            rowSklad["Кількість"] = pCount;
            rowSklad["Вартість"] = pCount * pPrise;
            TabSklad.Rows.Add(rowSklad); // Додаємо сформований рядок до таблиці
            /* Ми могли б звертатись до відповідного поля рядка таблиці через його числовий індекс починаючи з 0. Наприклад рядок rowSklad["N_пп"] =
            nn++; можна переписати у вигляді rowSklad[0] = nn++;, а рядок rowSklad["Виробник"] = pProduser; – переписати так: rowSklad[3] = pProduser; */
        }
        public void ColumnPropSet(DataGridView DGV)
        {
            /* Цей метод задає деякі властивості стовпцям. Тут встановлено заголовки стовпців, хоча вони і по замовчуванню були б такі, що перейшли б із
            назв стовпців таблиці */
            DGV.Columns["N_пп"].HeaderText = "№п/п";
            DGV.Columns["Група"].HeaderText = "Група";
            DGV.Columns["Назва"].HeaderText = "Назва";
            DGV.Columns["Виробник"].HeaderText = "Виробник";
            DGV.Columns["Постачальник"].HeaderText = "Постачальник";
            DGV.Columns["Од.виміру"].HeaderText = "Од.виміру";
            DGV.Columns["Ціна"].HeaderText = "Ціна";
            DGV.Columns["Кількість"].HeaderText = "Кількість";
            DGV.Columns["Вартість"].HeaderText = "Вартість";
            // Оскільки номер і вартість формуються програмно, то заборонимо користувачу вводити у них дані
            DGV.Columns["N_пп"].ReadOnly = true;
            DGV.Columns["Вартість"].ReadOnly = true;
            DGV.Columns["N_пп"].Width = 40; // Задаємо ширини стовпців
            DGV.Columns["Група"].Width = 100;
            DGV.Columns["Назва"].Width = 160;
            DGV.Columns["Виробник"].Width = 160;
            DGV.Columns["Постачальник"].Width = 160;
            DGV.Columns["Од.виміру"].Width = 70;
            DGV.Columns["Ціна"].Width = 70;
            DGV.Columns["Кількість"].Width = 70;
            DGV.Columns["Вартість"].Width = 70;
            // Встановимо колір першого стовпця у зелений
            // Цей оператор теж лише для ілюстрації можливості встановлення кольорів стовпців
            DGV.Columns[0].DefaultCellStyle.BackColor = Color.Green;
        }
        public void ZapTabFile()
        {
            // ZapTabFile – метод для записування таблиці у текстовий файл із назвою FtabSklad.txt
            string sNameFile, textRow;
            // Визначимо за допомогою методу Directory.GetCurrentDirectory() ім’я каталогу із *.exe-файлом проекту, для
            // наступного записування туда нашої таблиці
            string sdir = Directory.GetCurrentDirectory();
            sNameFile = sdir + @"\FTabSklad.txt"; // Ім’я файлу з таблицею
            try // Пробуємо виконати
            {
                if (File.Exists(sNameFile)) // Якщо такий файл існує, то знищимо його і створитмо новий
                {
                    File.Delete(sNameFile);
                }
                using (StreamWriter sw = new StreamWriter(sNameFile))
                {
                    foreach (DataRow rr in TabSklad.Rows)
                    {
                        textRow = rr["Група"] + ";" + rr["Назва"] + ";" + rr["Виробник"] + ";" + rr["Постачальник"] + ";" + rr["Од.виміру"] + ";" + Convert.ToString(rr["Кількість"]) + ";" + Convert.ToString(rr["Ціна"]);
                        sw.WriteLine(textRow); // Записуємо рядок у файл
                    }
                }
            }
            catch (Exception e) // Якщо не вдалось записати, видаємо повідомлення про помилку
            {
                MessageBox.Show("Таблиця не записана");
            }
        }
        public void ReadTabFile(DataGridView DGS)
        {
            string sNameFile, textRow;
            string pGrupa, pNazva, pVyrobnyk, pProvider, pUnits, sKilkist, sCina; int pKilkist; decimal PCina; int i, ip;
            // Визначаємо каталог із файлом , у який нами було записано таблицю
            TabSklad.Rows.Clear(); // Очищаємо усі попередні рядки таблиці, які можливо були туди заведені
            string sdir = Directory.GetCurrentDirectory();
            sNameFile = sdir + @"\FTabSklad.txt"; // Це повне ім’я файлу, який містить таблицю
            using (StreamReader sr = new StreamReader(sNameFile))
            {
                while (sr.Peek() >= 0) // Читаємо рядки доти, доки вони є у файлі, sr - StreamReader
                {
                    pGrupa = ""; pNazva = ""; pVyrobnyk = ""; pProvider = ""; pUnits = ""; sKilkist = ""; sCina = "";
                    textRow = sr.ReadLine();
                    /* StreamReader запише у змінну textRow черговий рядок файлу. Оскільки поля, при записуванні у файл, ми розділяли символом ';', то
                    тепер шукаємо його за допомогою методу IndexOf для типу string */
                    i = textRow.IndexOf(';') - 1;
                    for (int j = 0; j <= i; j++) // Перші символи від 0 до і-1 – це група товару, то
                    {
                        pGrupa = pGrupa + textRow[j]; // переписуємо їх у змінну pGrupa
                    }
                    ip = i + 2; // Запам'ятовуємо позицію першого розділювача
                    i = textRow.IndexOf(';', ip) - 1; // Знаходимо наступний розділювач
                    for (int j = ip; j <= i; j++)
                    {
                        pNazva = pNazva + textRow[j];
                    } // Символи від ip до і-1 – назва товару
                    ip = i + 2; // Запам'ятовуємо позицію другого розділювача
                    i = textRow.IndexOf(';', ip) - 1; // Знаходимо наступний розділювач
                    for (int j = ip; j <= i; j++)
                    {
                        pVyrobnyk = pVyrobnyk + textRow[j]; // Символи від ip до і-1 – виробник товару
                    }
                    ip = i + 2; // Запам'ятовуємо позицію другого розділювача
                    i = textRow.IndexOf(';', ip) - 1; // Знаходимо наступний розділювач
                    for (int j = ip; j <= i; j++)
                    {
                        pProvider = pProvider + textRow[j]; // Символи від ip до і-1 – виробник товару
                    }
                    ip = i + 2; // Запам'ятовуємо позицію другого розділювача
                    i = textRow.IndexOf(';', ip) - 1; // Знаходимо наступний розділювач
                    for (int j = ip; j <= i; j++)
                    {
                        pUnits = pUnits + textRow[j]; // Символи від ip до і-1 – виробник товару
                    }
                    ip = i + 2; // Запам’ятовуємо позицію третього розділювача
                    i = textRow.IndexOf(';', ip) - 1; // Знаходимо наступний розділювач
                    for (int j = ip; j <= i; j++)
                    {
                        sKilkist = sKilkist + textRow[j]; // Символи від ip до і-1 – кількість товару
                    }
                    ip = i + 2; // Запам'ятовуємо позицію четвертого розділювача
                    for (int j = ip; j <= textRow.Length - 1; j++)
                    {
                        sCina = sCina + textRow[j]; // Символи від ip до кінця рядка – ціна товару
                    }
                    // Перетворюємо рядкові значення кількості і ціни відповідно у int32 і Decimal
                    pKilkist = Convert.ToInt32(sKilkist);
                    PCina = Convert.ToDecimal(sCina);
                    // Додаємо новий рядок до таблиці використовуючи метод TSkladAddRow
                    TSkladAddRow(pGrupa, pNazva, pVyrobnyk, pProvider, pUnits, pKilkist, PCina);

                }
            }
            SetSumy(DGS);
        }
        public void TSkladValFiltr(String PFilter, DataGridView DGV)
        {
            try
            {
                SkladView.RowFilter = PFilter; // Встановлюємо значення фільтру
                FiltrCriteria = PFilter;
                DGV.DataSource = SkladView; // Призначаємо гріду – SkladView, як джерело даних
            }
            catch
            {
                MessageBox.Show("Введений Фільтр не правильний");
                return;
            }
        }
        public void TSkladValSort(String PSort, DataGridView DGV, DataGridView DGVSum)
        {
            try
            {
                SkladView.Sort = PSort; // Встановлюємо критерій сортування
                SortCriteria = PSort;
                DGV.DataSource = SkladView; // Назначаємо гріду DGV – SkladView, як джерело даних
                DGV.Refresh();
            }
            catch
            {
                MessageBox.Show("Введений критерій сортування не правильний");
                return;
            }
        }
        public void SeekNazva(string sNazva, DataGridView DGV)
        {
            int nn; // nn – номер шуканого рядка
            nn = -5; // Від'ємне значення буде у нас означати, що рядок з шуканою назвою не знайдено
            for (int i = 0; i < DGV.Rows.Count; i++) // Для кожного рядка rr із DGV
            {
                if ((string)DGV.Rows[i].Cells["Назва"].Value == sNazva)
                {
                    nn = i; // Якщо назви співпали, то ми знайшли шуканий рядок. Записуємо його номер у nn і виходимо з циклу
                    break;
                }
            }
            if (nn >= 0) // Якщо рядок знайдено, то показуємо його і виділяємо
            {
                DGV.FirstDisplayedCell = DGV.Rows[nn].Cells["Назва"];
                DGV.Rows[nn].Selected = true; // Виділити знайдений рядок
                DGV.CurrentCell = DGV.Rows[nn].Cells["Назва"]; // Встановимо знайдений рядок як поточний
            }
            else
            {
                MessageBox.Show("Значення не знайдено");
            }
        }
        public void SetSumy(DataGridView DGV)
        {
            string sGrupa, ssort;
            decimal DSuma;
            int i;
            DataTable TabSkladSum = new DataTable(); // Оголошуємо public-змінну TabSkladSum типу DataTable
                                                     // Таблиця підсумків буде складатись із 2 стовпців - група та вартість.
            DataColumn cNameGroupS = new DataColumn("Група ");
            DataColumn cVartistS = new DataColumn("Вартість ");
            // Оголошуємо типи даних, що будуть зберігатись у стовпцях
            cNameGroupS.DataType = System.Type.GetType("System.String");
            cVartistS.DataType = System.Type.GetType("System.Decimal");
            // Додаєм стовпці до таблиці
            TabSkladSum.Columns.Add(cNameGroupS);
            TabSkladSum.Columns.Add(cVartistS);
            ssort = SkladView.Sort; // Запам’ятаємо можливо заданий користувачем критерій сортування
            SkladView.Sort = "Група"; // Встановимо сортування по групах товару. SkladView.Count – кількість рядків
            i = 0;
            while (i < SkladView.Count) // Цикл для всіх рядків із таблиці TabSklad, що впорядкована по групах
            {
                sGrupa = (string)SkladView[i]["Група"]; // Обираємо чергову групу товару
                DSuma = 0.0M; // Обнулюємо значення суми вартостей для кожної групи
                while ((i < SkladView.Count) & (sGrupa == (string)SkladView[i]["Група"]))
                {
                    try // Можливо у якомусь рядку не записана вартість, тому скористаємось засобами try - catch
                    {
                        DSuma = DSuma + (decimal)SkladView[i]["Вартість"]; // Накопичуємо суму вартостей по групі
                    }
                    catch
                    {
                        SkladView[i]["Вартість"] = 0M;
                    }
                    i = i + 1;
                    if (i == SkladView.Count) { break; }
                }
                DataRow rowSkladSum = TabSkladSum.NewRow(); // Створюємо новий рядок у таблиці підсумків
                rowSkladSum["Група "] = sGrupa; // Записуємо значення назви групи
                rowSkladSum["Вартість "] = DSuma; // Записуємо значення суми вартостей по групі
                TabSkladSum.Rows.Add(rowSkladSum); // Додаємо сформований рядок до таблиці підсумків
            }
            DGV.DataSource = TabSkladSum; // Призначаємо TabSkladSum як джерело даних для гріда
            SkladView.Sort = SortCriteria; // Відновимо критерій сортування, тому що для сум було встановлено сортування по групі
        }
        public void CreateDovGrupa()
        {
            // Оголошуємо public-змінну TabSkladSum типу DataTable
            // Таблиця DovGrupa буде складатись із одного стовпця – назва групи товару.
            DataColumn cNameGroup = new DataColumn("Група");
            // Оголошуємо тип даних, які будуть зберігатись у стовпці
            cNameGroup.DataType = System.Type.GetType("System.String");
            DovGrupa.Columns.Add(cNameGroup); // Додаємо стовпець до таблиці
            DataRow rowSklad0 = DovGrupa.NewRow();
            rowSklad0[cNameGroup] = "Книги";
            DovGrupa.Rows.Add(rowSklad0); // Додаємо сформований рядок до таблиці
            DataRow rowSklad1 = DovGrupa.NewRow();
            rowSklad1[cNameGroup] = "CD";
            DovGrupa.Rows.Add(rowSklad1); // Додаємо сформований рядок до таблиці
            DataRow rowSklad2 = DovGrupa.NewRow();
            rowSklad2[cNameGroup] = "DVD";
            DovGrupa.Rows.Add(rowSklad2); // Додаємо сформований рядок до таблиці
            DataRow rowSklad3 = DovGrupa.NewRow();
            rowSklad3[cNameGroup] = "Мобілки";
            DovGrupa.Rows.Add(rowSklad3); // Додаємо сформований рядок до таблиці
            DataRow rowSklad4 = DovGrupa.NewRow();
            rowSklad4[cNameGroup] = "Плеєри";
            DovGrupa.Rows.Add(rowSklad4); // Додаємо сформований рядок до таблиці
            DataRow rowSklad5 = DovGrupa.NewRow();
            rowSklad5[cNameGroup] = "Аксессуари";
            DovGrupa.Rows.Add(rowSklad5); // Додаємо сформований рядок до таблиці
            DataRow rowSklad6 = DovGrupa.NewRow();
            rowSklad6[cNameGroup] = "Дисплеї";
            DovGrupa.Rows.Add(rowSklad6); // Додаємо сформований рядок до таблиці
            DataRow rowSklad7 = DovGrupa.NewRow();
            rowSklad7[cNameGroup] = "Корпуси";
            DovGrupa.Rows.Add(rowSklad7); // Додаємо сформований рядок до таблиці
            DataRow rowSklad8 = DovGrupa.NewRow();
            rowSklad8[cNameGroup] = "Блоки живлення";
            DovGrupa.Rows.Add(rowSklad8); // Додаємо сформований рядок до таблиці
            DataRow rowSklad9 = DovGrupa.NewRow();
            rowSklad9[cNameGroup] = "Клавіатури";
            DovGrupa.Rows.Add(rowSklad9); // Додаємо сформований рядок до таблиці
            int nn = DovGrupa.Rows.Count;
        }
        public void CreateDovProvider()
        {
            // Оголошуємо public-змінну TabSkladSum типу DataTable
            // Таблиця DovGrupa буде складатись із одного стовпця – назва групи товару.
            DataColumn сProvider = new DataColumn("Постачальник");
            // Оголошуємо тип даних, які будуть зберігатись у стовпці
            сProvider.DataType = System.Type.GetType("System.String");
            DovProvider.Columns.Add(сProvider); // Додаємо стовпець до таблиці
            DataRow rowSklad0 = DovProvider.NewRow();
            rowSklad0[сProvider] = "ПАТ";
            DovProvider.Rows.Add(rowSklad0); // Додаємо сформований рядок до таблиці
            DataRow rowSklad1 = DovProvider.NewRow();
            rowSklad1[сProvider] = "ТзОВ";
            DovProvider.Rows.Add(rowSklad1); // Додаємо сформований рядок до таблиці
            DataRow rowSklad2 = DovProvider.NewRow();
            rowSklad2[сProvider] = "ПрАТ";
            DovProvider.Rows.Add(rowSklad2); // Додаємо сформований рядок до таблиці
            int nn = DovProvider.Rows.Count;
        }
        public void CreateDovUnits()
        {
            // Оголошуємо public-змінну TabSkladSum типу DataTable
            // Таблиця DovGrupa буде складатись із одного стовпця – назва групи товару.
            DataColumn pUnits = new DataColumn("Од.виміру");
            // Оголошуємо тип даних, які будуть зберігатись у стовпці
            pUnits.DataType = System.Type.GetType("System.String");
            DovUnits.Columns.Add(pUnits); // Додаємо стовпець до таблиці
            DataRow rowSklad0 = DovUnits.NewRow();
            rowSklad0[pUnits] = "шт";
            DovUnits.Rows.Add(rowSklad0); // Додаємо сформований рядок до таблиці
            DataRow rowSklad1 = DovUnits.NewRow();
            rowSklad1[pUnits] = "10шт";
            DovUnits.Rows.Add(rowSklad1); // Додаємо сформований рядок до таблиці
            DataRow rowSklad2 = DovUnits.NewRow();
            rowSklad2[pUnits] = "100шт";
            DovUnits.Rows.Add(rowSklad2); // Додаємо сформований рядок до таблиці
            int nn = DovUnits.Rows.Count;
        }
        public void AddComboGrupa(DataGridView DGV)
        {
            DataGridViewComboBoxColumn cGrupaCB = new DataGridViewComboBoxColumn();
            cGrupaCB.DataPropertyName = "Група";
            cGrupaCB.Name = "cNameGroupComb"; // Назва нового стовпця
            cGrupaCB.HeaderText = "Група"; // Заголовок на гріді нового стовпця
            cGrupaCB.DropDownWidth = 200; // Ширина "випадайки"
            cGrupaCB.Width = 120; // Ширина стовпця
            cGrupaCB.MaxDropDownItems = 7; // Кількість рядків випадайки, які одночасно будуть видимі
            cGrupaCB.FlatStyle = FlatStyle.Flat;
            cGrupaCB.ValueType = System.Type.GetType("System.string"); // Тип даних нового стовпця
            String s; Int32 n;
            n = DovGrupa.Rows.Count;
            foreach (DataRow r in DovGrupa.Rows) // Для кожного рядка r із таблиці DovGrupa
            {
                s = (string)r["Група"];
                cGrupaCB.Items.AddRange(r["Група"]); // Додаємо у "випадайку" елементи із довідника
            }
            DGV.Columns.Add(cGrupaCB); // Додаємо новий стовбець до гріда
                                       // Перезаписати значення комірок із старого стовпця у новий
            String ss;
            // Для кожного рядка rr контрола DGV типу DataGridView
            foreach (DataGridViewRow rrr in DGV.Rows)
            {
                ss = (string)rrr.Cells["Група"].Value; // ss – значення комірки назви групи у старому стовпці
                                                       // Перезаписуєм значення комірки старого стовпця у комірку нового стовпця
                rrr.Cells["Група"].Value = rrr.Cells["Група"].Value;
            }
            DGV.Columns.Remove("Група"); // Вилучаємо старий стовбець типу DataGridViewTextBoxColumn
            DGV.Columns["cNameGroupcomb"].Name = "Група"; // Перейменовуємо новий у старе ім’я
            DGV.Columns["Група"].DisplayIndex = 1; // Встановлюємо порядок виведення стовпця у гріді
            DGV.Refresh(); // Оновлюємо DataGridView

        }
        public void AddComboProvider(DataGridView DGV)
        {
            DataGridViewComboBoxColumn cProviderCB = new DataGridViewComboBoxColumn();
            cProviderCB.DataPropertyName = "Постачальник";
            cProviderCB.Name = "cProviderComb"; // Назва нового стовпця
            cProviderCB.HeaderText = "Постачальник"; // Заголовок на гріді нового стовпця
            cProviderCB.DropDownWidth = 200; // Ширина "випадайки"
            cProviderCB.Width = 120; // Ширина стовпця
            cProviderCB.MaxDropDownItems = 7; // Кількість рядків випадайки, які одночасно будуть видимі
            cProviderCB.FlatStyle = FlatStyle.Flat;
            cProviderCB.ValueType = System.Type.GetType("System.string"); // Тип даних нового стовпця
            String s; Int32 n;
            n = DovProvider.Rows.Count;
            foreach (DataRow r in DovProvider.Rows) // Для кожного рядка r із таблиці DovGrupa
            {
                s = (string)r["Постачальник"];
                cProviderCB.Items.AddRange(r["Постачальник"]); // Додаємо у "випадайку" елементи із довідника
            }
            DGV.Columns.Add(cProviderCB); // Додаємо новий стовбець до гріда
                                          // Перезаписати значення комірок із старого стовпця у новий
            String ss;
            // Для кожного рядка rr контрола DGV типу DataGridView
            foreach (DataGridViewRow rrr in DGV.Rows)
            {
                ss = (string)rrr.Cells["Постачальник"].Value; // ss – значення комірки назви групи у старому стовпці
                                                              // Перезаписуєм значення комірки старого стовпця у комірку нового стовпця
                rrr.Cells["Постачальник"].Value = rrr.Cells["Постачальник"].Value;
            }
            DGV.Columns.Remove("Постачальник"); // Вилучаємо старий стовбець типу DataGridViewTextBoxColumn
            DGV.Columns["cProvidercomb"].Name = "Постачальник"; // Перейменовуємо новий у старе ім’я
            DGV.Columns["Постачальник"].DisplayIndex = 1; // Встановлюємо порядок виведення стовпця у гріді
            DGV.Refresh(); // Оновлюємо DataGridView

        }
        public void AddComboUnits(DataGridView DGV)
        {
            DataGridViewComboBoxColumn cUnitsCB = new DataGridViewComboBoxColumn();
            cUnitsCB.DataPropertyName = "Од.виміру";
            cUnitsCB.Name = "cUnitsComb"; // Назва нового стовпця
            cUnitsCB.HeaderText = "Од.виміру"; // Заголовок на гріді нового стовпця
            cUnitsCB.DropDownWidth = 200;
            cUnitsCB.Width = 120;// Ширина стовпця
            cUnitsCB.MaxDropDownItems = 7; // Кількість рядків випадайки, які одночасно будуть видимі
            cUnitsCB.FlatStyle = FlatStyle.Flat;
            cUnitsCB.ValueType = System.Type.GetType("System.string"); // Тип даних нового стовпця
            String s; Int32 n;
            n = DovUnits.Rows.Count;
            foreach (DataRow r in DovUnits.Rows) // Для кожного рядка r із таблиці DovGrupa
            {
                s = (string)r["Од.виміру"];
                cUnitsCB.Items.AddRange(r["Од.виміру"]); // Додаємо у "випадайку" елементи із довідника
            }
            DGV.Columns.Add(cUnitsCB); // Додаємо новий стовбець до гріда
                                       // Перезаписати значення комірок із старого стовпця у новий
            String ss;
            // Для кожного рядка rr контрола DGV типу DataGridView
            foreach (DataGridViewRow rrr in DGV.Rows)
            {
                ss = (string)rrr.Cells["Од.виміру"].Value; // ss – значення комірки назви групи у старому стовпці
                                                           // Перезаписуєм значення комірки старого стовпця у комірку нового стовпця
                rrr.Cells["Од.виміру"].Value = rrr.Cells["Од.виміру"].Value;
            }
            DGV.Columns.Remove("Од.виміру"); // Вилучаємо старий стовбець типу DataGridViewTextBoxColumn
            DGV.Columns["cUnitscomb"].Name = "Од.виміру"; // Перейменовуємо новий у старе ім’я
            DGV.Columns["Од.виміру"].DisplayIndex = 1; // Встановлюємо порядок виведення стовпця у гріді
            DGV.Refresh(); // Оновлюємо DataGridView

        }
    }
}

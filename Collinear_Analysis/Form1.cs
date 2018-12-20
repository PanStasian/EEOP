using System;
using System.Windows.Forms;
using Microsoft.Win32;
using System.Reflection;
using Excel = Microsoft.Office.Interop.Excel;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms.DataVisualization.Charting;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using Data = System.Collections.Generic.KeyValuePair<int, int>;
//using static alglib;

namespace Collinear_Analysis
{
    public partial class Form1 : Form
    {
        double[,] rez;
        int sumRow = 0;

        double[,] correlationMat;// = new double[5, 5];

        double min = 0;
        double max = 0;
        int mini = 0, minj = 0;
        int maxi = 0, maxj = 0;


        double[,] matrs;

        public Form1()
        {
            InitializeComponent();
        }

        private void GetFile_Click(object sender, EventArgs e)
        {

        }

        private void Setmatr()
        {
            matr.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            DataGridViewCellStyle styleMiddle = new DataGridViewCellStyle();
            styleMiddle.BackColor = System.Drawing.Color.Orange;

            DataGridViewCellStyle styleHigh = new DataGridViewCellStyle();
            styleHigh.BackColor = System.Drawing.Color.OrangeRed;

            DataGridViewCellStyle styleVeryHigh = new DataGridViewCellStyle();
            styleVeryHigh.BackColor = System.Drawing.Color.Red;

            DataGridViewCellStyle styleLow = new DataGridViewCellStyle();
            styleLow.BackColor = System.Drawing.Color.Yellow;

            DataGridViewCellStyle styleLowest = new DataGridViewCellStyle();
            styleLowest.BackColor = System.Drawing.Color.LightBlue;

            DataGridViewCellStyle styleLowLow = new DataGridViewCellStyle();
            styleLowLow.BackColor = System.Drawing.Color.LightGray;

            DataGridViewCellStyle styleFunc = new DataGridViewCellStyle();
            styleFunc.BackColor = System.Drawing.Color.Purple;

            for (int i = 0; i < matr.Rows.Count; i++)
            {
                for (int j = 0; j < matr.Rows[i].Cells.Count; j++)
                {
                    double cell = double.Parse(matr.Rows[i].Cells[j].Value.ToString());
                    if ((cell >= 0.1 && cell <= 0.3) || (cell >= -0.3 && cell <= -0.1))
                        matr.Rows[i].Cells[j].Style = styleLowest;
                    else if ((cell > 0.3 && cell < 0.5) || (cell < -0.3 && cell > -0.5))
                        matr.Rows[i].Cells[j].Style = styleLow;
                    else if ((cell >= 0.5 && cell <= 0.7) || (cell <= -0.5 && cell >= -0.7))
                        matr.Rows[i].Cells[j].Style = styleMiddle;
                    else if ((cell > 0.7 && cell <= 0.9) || (cell < -0.7 && cell >= -0.9))
                        matr.Rows[i].Cells[j].Style = styleHigh;
                    else if ((cell > 0.9 && cell <= 0.99) || (cell < -0.9 && cell >= -0.99))
                        matr.Rows[i].Cells[j].Style = styleVeryHigh;
                    else if ((cell > 0.99 && cell <= 1) || (cell < -0.99 && cell >= -1))
                        matr.Rows[i].Cells[j].Style = styleVeryHigh;
                    else matr.Rows[i].Cells[j].Style = styleLowLow;
                }
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            dt.DataSource = string.Empty;
            matr.Columns.Clear();


            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Файл Excel|*.XLSX;*.XLS"; ;

            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                textBox1.Text = dialog.FileName;
                OleDbConnection connection = new OleDbConnection(string.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties=\"Excel 12.0 Xml;HDR=YES\";", dialog.FileName));
                OleDbDataAdapter adapter = new OleDbDataAdapter("SELECT * FROM [Лист1$]", connection);
                DataTable table = new DataTable();
                adapter.Fill(table);
                dt.DataSource = table;
                foreach (DataGridViewColumn item in dt.Columns)
                {
                    item.SortMode = DataGridViewColumnSortMode.NotSortable;
                }
                dt.SelectionMode = DataGridViewSelectionMode.FullColumnSelect;
                connection.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int i = 0;
            int j = 0;

            int colCount = 0;
            int rowCount = 0;

            if (dt.SelectedCells.Count > 0)
            {
                matrs = new double[dt.RowCount, dt.SelectedColumns.Count];
                colCount = dt.SelectedColumns.Count;
                rowCount = dt.RowCount;
            }
            else
            {
                matrs = new double[dt.RowCount, dt.ColumnCount - 1];
                colCount = dt.ColumnCount - 1;
                rowCount = dt.RowCount;
            }


            //Input values from stats
            //with all columns
            if (dt.SelectedColumns.Count == 0)
            {
                for (i = 0; i < rowCount; i++)
                {
                    for (j = 0; j < colCount; j++)
                    {
                        matrs[i, j] = Convert.ToDouble(dt.Rows[i].Cells[j + 1].Value);
                    }
                }
            }
            //with selected columns
            else
            {
                foreach (DataGridViewRow row in dt.Rows)
                {
                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        if (cell.Selected)
                        {
                            matrs[i, j] = Convert.ToDouble(cell.Value);
                            j++;
                            if (j >= matrs.GetLength(1))
                            {
                                j = 0;
                                i++;
                            }
                            if (j >= dt.SelectedColumns.Count) i++;
                        }
                    }
                }
            }

            correlationMat = new double[colCount, colCount];

            double[,] x;
            double[,] y;
            x = new double[matrs.GetLength(0), 1];
            y = new double[matrs.GetLength(0), 1];
            int k = 0;
            int l = 0;
            int sumRow = matrs.GetLength(0);// - 1;
            double sumx = 0;
            double sumy = 0;
            double sumxy = 0;
            double sumxx = 0;
            double sumyy = 0;
            double avrx = 0;
            double avry = 0;
            double avrxy = 0;
            double dispx = 0;
            double dispy = 0;
            double avrsqrx = 0;
            double avrsqry = 0;
            double koefkorel = 0;
            matr.RowCount = matrs.GetLength(1);
            matr.ColumnCount = matrs.GetLength(1);

            for (l = 0; l < matrs.GetLength(1); l++)
            {
                for (k = 0; k < matrs.GetLength(1); k++)
                {
                    sumx = 0;
                    sumy = 0;
                    sumxy = 0;
                    sumxx = 0;
                    sumyy = 0;
                    avrx = 0;
                    avry = 0;
                    avrxy = 0;
                    dispx = 0;
                    dispy = 0;
                    avrsqrx = 0;
                    avrsqry = 0;
                    koefkorel = 0;
                    for (i = 0; i < sumRow; i++)
                    {
                        for (j = 0; j < 1; j++)
                        {
                            x[i, j] = matrs[i, l];
                            sumx = sumx + x[i, j];
                            y[i, j] = matrs[i, k];
                            sumy = sumy + y[i, j];
                            sumxy = sumxy + x[i, j] * y[i, j];
                            sumxx = sumxx + x[i, j] * x[i, j];
                            sumyy = sumyy + y[i, j] * y[i, j];
                        }
                        avrx = sumx / sumRow;
                        avry = sumy / sumRow;
                        avrxy = sumxy / sumRow;
                        dispx = sumxx / sumRow - avrx * avrx;
                        dispy = sumyy / sumRow - avry * avry;
                        avrsqrx = Math.Sqrt(dispx);
                        avrsqry = Math.Sqrt(dispy);
                        koefkorel = Math.Round((avrxy - avrx * avry) / (avrsqrx * avrsqry), 3);
                    }
                    matr.Rows[l].Cells[k].Value = koefkorel;
                    correlationMat[l, k] = double.Parse(matr.Rows[l].Cells[k].Value.ToString());
                }

                matr.Columns[l].HeaderText = dt.Columns[l + 1].HeaderText;
                matr.Rows[l].HeaderCell.Value = dt.Columns[l + 1].HeaderText;

            }

            Setmatr();

            double[,] rez;
            rez = new double[1, matr.ColumnCount];

            for (i = 0; i < 1; i++)
            {
                for (j = 0; j < matr.ColumnCount; j++)
                {
                    rez[i, j] = Convert.ToDouble(matr.Rows[i].Cells[j].Value);
                }
            }


            min = 10;
            max = 0;
            for (i = 0; i < rez.GetLength(0); i++)
            {
                for (j = 0; j < rez.GetLength(1); j++)
                {
                    if (min > rez[i, j] && rez[i, j] >= 0 && rez[i, j] < 1)
                    {
                        min = rez[i, j];
                        mini = i;
                        minj = j;
                    }
                    if (max < rez[i, j] && rez[i, j] >= 0 && rez[i, j] < 1)
                    {
                        max = rez[i, j];
                        maxi = i;
                        maxj = j;
                    }
                }
            }

            Analysis();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int i = 0;
            int j = 0;
            double[,] matrs;
            matrs = new double[dt.RowCount - 1, dt.ColumnCount - 1];

            for (i = 0; i < matrs.GetLength(0); i++)
            {
                for (j = 0; j < matrs.GetLength(1); j++)
                {
                    matrs[i, j] = Convert.ToDouble(dt.Rows[i].Cells[j + 1].Value);
                }
            }

            double[] avr;
            double[] sumkv;
            double[] disp;
            double[,] matrs2;
            matrs2 = new double[dt.RowCount - 1, dt.ColumnCount];
            sumRow = matrs.GetLength(0);
            avr = new double[matrs.GetLength(1)];
            sumkv = new double[matrs.GetLength(1)];
            disp = new double[matrs.GetLength(1)];
            double summ = 0;
            // Середнє
            for (j = 0; j < matrs.GetLength(1); j++)
            {
                summ = 0;
                for (i = 0; i < matrs.GetLength(0); i++)
                {
                    summ += matrs[i, j];
                }
                avr[j] = summ / sumRow;
            }
            // Дисперсія
            for (j = 0; j < matrs.GetLength(1); j++)
            {
                summ = 0;
                for (i = 0; i < matrs.GetLength(0); i++)
                {
                    summ += (matrs[i, j] - avr[j]) * (matrs[i, j] - avr[j]);
                }
                disp[j] = summ / sumRow;
            }

            normDt.Columns.Add(new DataGridViewColumn() { HeaderText = dt.Columns[1].HeaderText, CellTemplate = new DataGridViewTextBoxCell() });
            normDt.Columns.Add(new DataGridViewColumn() { HeaderText = dt.Columns[2].HeaderText, CellTemplate = new DataGridViewTextBoxCell() });
            normDt.Columns.Add(new DataGridViewColumn() { HeaderText = dt.Columns[3].HeaderText, CellTemplate = new DataGridViewTextBoxCell() });
            normDt.Columns.Add(new DataGridViewColumn() { HeaderText = dt.Columns[4].HeaderText, CellTemplate = new DataGridViewTextBoxCell() });
            normDt.Columns.Add(new DataGridViewColumn() { HeaderText = dt.Columns[5].HeaderText, CellTemplate = new DataGridViewTextBoxCell() });

            int n = matrs.GetLength(0);
            for (i = 0; i < n; i++)
            {
                for (j = 0; j < matrs.GetLength(1); j++)
                {
                    matrs2[i, j] = (matrs[i, j] - avr[j]) / Math.Sqrt(disp[j] * sumRow);
                    if (j == 0) normDt.Rows.Add();
                    normDt.Rows[i].Cells[j].Value = Math.Round(matrs2[i, j] * 1000, 2) / 1000.0;
                }

            }

            rez = new double[matr.RowCount, matr.ColumnCount];
            for (i = 0; i < matr.RowCount; i++)
            {
                for (j = 0; j < matr.ColumnCount; j++)
                {
                    rez[i, j] = Math.Round(Convert.ToDouble(matr.Rows[i].Cells[j].Value), 1);
                }
            }
           //var xiii = Math.Round(invchisquaredistribution(matr.ColumnCount, 0.55), 2);//chisquaredistribution(10, 0.05);
            const double xitable = 3.9403;
            //XiTable_Tb.Text = xiii.ToString();//xitable.ToString();
            XiTable_Tb.Text = xitable.ToString();
            double det = Math.Round(DetGauss(rez),5);
            Det_Tb.Text = det.ToString();
            double xi = Math.Round(-(sumRow - 1 - (2 * 5 + 5) / 5) * Math.Log(det, Math.E),2);
            Xi_Tb.Text = xi.ToString();

            if (xi > xitable)
            {
                CompareXi.Text = ">";
                StudentFunc();
            }
            else
            {
                MessageBox.Show("Между параметрами не существует мультколлинеарности");
                CompareXi.Text = "<";
            }
            //button3.Enabled = false;


        }

        public double DetGauss(double[,] M)
        {
            double det = 1; // Хранит определитель, который вернёт функция
            int n = M.GetLength(0); // Размерность матрицы
            int k = 0;
            const double E = 1E-9; // Погрешность вычислений

            for (int i = 0; i < n; i++)
            {
                k = i;
                for (int j = i + 1; j < n; j++)
                    if (Math.Abs(M[j, i]) > Math.Abs(M[k, i]))
                        k = j;

                if (Math.Abs(M[k, i]) < E)
                {
                    det = 0;
                    break;
                }
                Swap(ref M, i, k);

                if (i != k) det *= -1;

                det *= M[i, i];

                for (int j = i + 1; j < n; j++)
                    M[i, j] /= M[i, i];

                for (int j = 0; j < n; j++)
                    if ((j != i) && (Math.Abs(M[j, i]) > E))
                        for (k = i + 1; k < n; k++)
                            M[j, k] -= M[i, k] * M[j, i];
            }
            return det;
        }

        public void Swap(ref double[,] M, int row1, int row2)
        {
            double s = 0;

            for (int i = 0; i < M.GetLength(1); i++)
            {
                s = M[row1, i];
                M[row1, i] = M[row2, i];
                M[row2, i] = s;
            }
        }

        private void Analysis()
        {
            analysisTb.Text = "Наименьший коэффициент корелляции: " + min + " параметра " + matr.Rows[mini].HeaderCell.Value + " к параметру " + matr.Rows[minj].HeaderCell.Value + "\n" +
                "Самый большой коэффициент корелляции: " + max + " параметра " + matr.Rows[maxi].HeaderCell.Value + " к параметру " + matr.Rows[maxj].HeaderCell.Value;
        }

        public static double[,] Inversing(double[,] matrix, int len)
        {
            double[,] ob = new double[len, len];

            for (int i = 0; i < len; i++)
            {
                for (int j = 0; j < len; j++)
                {
                    if (i == j)
                    { ob[i, j] = 1; }
                    else
                    { ob[i, j] = 0; }

                }

            }

            double arg;
            int i1;

            for (int j = 0; j < len;)
            {
                for (int i = 0; i < len;)
                {
                    if (i != j)
                    {
                        arg = matrix[i, j] / matrix[j, j];
                        for (i1 = 0; i1 < len;)
                        {
                            matrix[i, i1] = matrix[i, i1] - matrix[j, i1] * arg;
                            ob[i, i1] = ob[i, i1] - ob[j, i1] * arg;
                            i1++;
                        }
                    }
                    i++;
                }
                j++;
            }

            for (int j = 0; j < len; j++)
            {
                for (int i = 0; i < len; i++)
                {
                    double arg_2;
                    if (i == j)
                    {
                        arg_2 = matrix[i, j];
                        for (i1 = 0; i1 < len;)
                        {
                            matrix[i, i1] = matrix[i, i1] / arg_2;
                            ob[i, i1] = ob[i, i1] / arg_2;
                            i1++;
                        }
                    }

                }
            }
            return ob;
        }



        private bool Fisher(double[,] ober)
        {

            const double fish = 2.866;
            FisherTB.Text = fish.ToString();

            double[] fisher = new double[rez.GetLength(0)];
            for (int i = 0; i < InverseMatrix.RowCount - 1; i++)
            {
                fisher[i] = Math.Round((ober[i, i] - 1) * (sumRow - rez.GetLength(0)) / (rez.GetLength(0) - 1), 2);
            }

            for (int i = 0; i < fisher.Length; i++)
            {
                Fishers_Tb.Text += InverseMatrix.Columns[i].HeaderText + ": " + fisher[i] + "\r\n";
            }

            for (int i = 0; i < InverseMatrix.RowCount - 1; i++)
            {
                if (fisher[i] > fish)
                    return true;
            }
            return false;

        }

        private void StudentFunc()
        {
            //Обернена матриця
            double[,] ober = Inversing(correlationMat, correlationMat.GetLength(0));

            for (int i = 0; i < correlationMat.GetLength(0); i++)
            {
                for (int j = 0; j < correlationMat.GetLength(1); j++)
                {
                    if (i == 0)
                        InverseMatrix.Columns.Add("col", dt.Columns[j + 1].HeaderText);
                    if (j == 0)
                        InverseMatrix.Rows.Add();
                    InverseMatrix.Rows[i].Cells[j].Value = Math.Round(ober[i, j],2);
                    rez[i, j] = ober[i, j];
                }
            }

            //Коефіцієнти фішера

            if (!Fisher(ober))
            {
                MessageBox.Show("Между параметрами не существует мультколлинеарности");
            }

            double[,] matrparkoef = new double[rez.GetLength(0), rez.GetLength(1)];
            for (int i = 0; i < InverseMatrix.RowCount - 1; i++)
            {
                for (int j = 0; j < InverseMatrix.ColumnCount; j++)
                {
                    if (i == 0)
                    {
                        Partial.Columns.Add("col" + j, dt.Columns[j + 1].HeaderText);
                    }
                    matrparkoef[i, j] = Math.Round(-rez[i, j] / (Math.Sqrt(rez[i, i] * rez[j, j])), 2);
                    if (j == 0) Partial.Rows.Add();
                    Partial.Rows[i].Cells[j].Value = Math.Round(matrparkoef[i, j],2);
                }
            }

            double[,] krst = new double[rez.GetLength(0), rez.GetLength(1)];
            const double st = 2.08596;
            double stud = StudentTest(0.05, 25);//studenttdistribution(25, 0.5);
            StudentTb.Text = st.ToString();

            DataGridViewCellStyle styleMiddle = new DataGridViewCellStyle();
            styleMiddle.BackColor = System.Drawing.Color.Yellow;

            for (int i = 0; i < Partial.RowCount - 1; i++)
            {
                for (int j = 0; j < Partial.ColumnCount; j++)
                {
                    if (i == 0)
                        Student.Columns.Add("col" + j, dt.Columns[j + 1].HeaderText);
                    if (j == 0)
                        Student.Rows.Add();
                    if (j > i)
                    {
                        krst[i, j] = matrparkoef[i, j] * Math.Sqrt(sumRow - rez.GetLength(0)) / Math.Sqrt(1 - matrparkoef[i, j] * matrparkoef[i, j]);
                        Student.Rows[i].Cells[j].Value = Math.Round(krst[i, j],2);
                        if (krst[i, j] > st)
                        {
                            dependants.Add(new Data(i, j));
                            Student.Rows[i].Cells[j].Style = styleMiddle;
                            StudentAnalysisTb.Text += Student.Columns[i].HeaderText + " и " + Student.Columns[j].HeaderText + " \r\n";
                        }
                    }

                }
            }
            MessageBox.Show("Мультиколлинеарность существует между следующими параметрами: " + StudentAnalysisTb.Text);
        }

        List<Data> dependants = new List<Data>();
        private void button4_Click(object sender, EventArgs e)
        {
            //dependants.RemoveAt(2);
            List<int> toThrowAway = new List<int>();
            int checksThatExist = 0;
            int checkThatNotMain = 0;
            for (int i = 0; i < dependants.Count; i++)
            {
                if (dependants[i].Key == 0)
                {
                    int temp = dependants[i].Value;
                    toThrowAway.Add(dependants[i].Value);
                    foreach (var item in dependants)
                    {
                        if (toThrowAway.Count > 0)
                        {
                            if (temp != item.Value)
                            {
                                checksThatExist++;
                            }
                            if (temp == item.Value && item.Key == 0)
                            {
                                checkThatNotMain++;
                            }
                        }
                    }
                    if (checksThatExist == dependants.Count - 1 /*&& checksThatExist>=checkThatNotMain*/)
                        toThrowAway.Remove(temp);
                    checksThatExist = 0;
                }
            }

            toThrowAway = toThrowAway.Distinct().ToList();
            RegressionAnalysis(toThrowAway);
        }

        private void RegressionAnalysis(List<int> toThrowAway)
        {
            CoefReg.Columns.Clear();
            formula_Tb.Text = string.Empty;

            double[][] result = new double[dt.RowCount][];

            for (int i = 0; i < dt.RowCount; i++)
            {
                if (toThrowAway.Count == 0 && dt.SelectedColumns.Count == 0)
                    result[i] = new double[dt.ColumnCount - 1];
                else if (dt.SelectedColumns.Count > 0)
                    result[i] = new double[dt.SelectedColumns.Count];
                else if (toThrowAway.Count > 0)
                    result[i] = new double[(dt.ColumnCount - 1) - toThrowAway.Count];
            }

            if (toThrowAway.Count == 0 && dt.SelectedColumns.Count == 0)
            {
                int n = dt.ColumnCount - 1;
                for (int i = 0; i < dt.RowCount; ++i)
                {
                    for (int j = 0; j < n; j++)
                    {
                        result[i][j] = double.Parse(dt.Rows[i].Cells[j + 1].Value.ToString());
                    }
                }
            }
            else if (toThrowAway.Count > 0)
            {
                int n = (dt.ColumnCount - 1) - toThrowAway.Count;
                int j1 = 0;
                for (int i = 0; i < dt.RowCount; ++i)
                {
                    for (int j = 0; j < /*n*/dt.ColumnCount; j++)
                    {
                        if (double.TryParse(dt.Rows[i].Cells[j].Value.ToString(), out double res1))
                        {
                            if (!toThrowAway.Contains(j))
                            {
                                result[i][j1] = double.Parse(dt.Rows[i].Cells[j/* + 1*/].Value.ToString());
                                j1++;
                                if (j1 >= result[i].Length) j1 = 0;
                            }
                        }
                    }
                }
            }
            else if (dt.SelectedColumns.Count > 0)
            {
                int n = dt.SelectedColumns.Count;
                int j1 = 0;
                for (int i = 0; i < dt.RowCount; ++i)
                {
                    for (int j = 0; j < dt.Columns.Count; j++)
                    {
                        if (dt.Columns[j].Selected)
                        {
                            result[i][j1] = double.Parse(dt.Rows[i].Cells[j].Value.ToString());
                            j1++;
                            if (j1 >= n) j1 = 0;
                        }
                    }
                }
            }

            double[][] design = Design(result);

            var res = Solve(design, toThrowAway);

            double R2 = RSquared(result, res);
            
            CoefReg.Columns.Add("col", "Параметр");
            CoefReg.Columns.Add("col", "Коэффициент");

            if (toThrowAway.Count == 0 && dt.SelectedColumns.Count == 0)
            {
                for (int i = 0; i < dt.ColumnCount - 1; i++)
                {
                    CoefReg.Rows.Add(dt.Columns[i + 1].HeaderText, res[i]);
                }
                CoefReg.Rows.Add("R-квадратная", Math.Round(R2 * 100, 0).ToString() + " %");
                string formula = "y = " + Math.Round(res[0], 2);
                for(int i = 1; i < res.Length; i++)
                {
                    string sign = res[i] > 0 ? " + " : " - ";
                    formula += sign + Math.Abs(Math.Round(res[i],2)).ToString() + "X(" + dt.Columns[i].HeaderText + ") " + " ";
                }
                formula_Tb.Text = formula;
            }

            else if (toThrowAway.Count > 0)
            {
                for (int i = 0; i < dt.ColumnCount - 1; i++)
                {
                    if (!toThrowAway.Contains(dt.Columns[i + 1].Index - 1))
                        CoefReg.Rows.Add(dt.Columns[i + 1].HeaderText, res[i]);
                }
                CoefReg.Rows.Add("R-квадратная", Math.Round(R2 * 100, 0).ToString() + " %");
                string formula = "y = " + Math.Round(res[0], 2);
                for (int i = 1; i < res.Length; i++)
                {
                    string sign = res[i] > 0 ? " + " : " - ";
                    formula += sign + Math.Abs(Math.Round(res[i], 2)).ToString() + "X(" + CoefReg.Rows[i].Cells[0].Value + ") " + " ";
                }
                formula_Tb.Text = formula;
            }

            else if (dt.SelectedColumns.Count > 0)
            {
                for (int i = dt.SelectedColumns.Count-1; i>=0;i--)
                {
                    CoefReg.Rows.Add(dt.SelectedColumns[i].HeaderText, res[dt.SelectedColumns.Count-i-1]);
                }
                CoefReg.Rows.Add("R-квадратная", Math.Round(R2 * 100, 0).ToString() + " %");
                string formula = "y = " + Math.Round(res[0], 2);
                for (int i = 1; i < res.Length; i++)
                {
                    string sign = res[i] > 0 ? " + " : " - ";
                    formula += sign + Math.Abs(Math.Round(res[i], 2)).ToString() + "X(" + dt.SelectedColumns[dt.SelectedColumns.Count-i-1].HeaderText + ") " + " ";
                }
                formula_Tb.Text = formula;
            }
            //MessageBox.Show(formula_Tb.Text);
            
        }

        private void dt_ColumnAdded(object sender, DataGridViewColumnEventArgs e)
        {
        }

        private static double[,] Transposition(double[,] matr)
        {
            double[,] trans = new double[matr.GetLength(1), matr.GetLength(0)];
            for (int i = 0; i < matr.GetLength(1); i++)
            {
                for (int j = 0; j < matr.GetLength(0); j++)
                {
                    trans[i, j] = matr[j, i];
                }
            }
            return trans;
        }


        static double[,] Multiplication(double[,] a, double[,] b)
        {
            if (a.GetLength(1) != b.GetLength(0)) throw new Exception("Матрицы нельзя перемножить");
            double[,] r = new double[a.GetLength(0), b.GetLength(1)];
            for (int i = 0; i < a.GetLength(0); i++)
            {
                for (int j = 0; j < b.GetLength(1); j++)
                {
                    for (int k = 0; k < b.GetLength(0); k++)
                    {
                        r[i, j] += Math.Round(a[i, k] * b[k, j], 1);
                    }
                }
            }
            return r;
        }


        public static double StudentTest(double t, double df)
        {
            // Для df с очень большими целыми значениями или
            // двойной точности. Адаптировано из ACM-алгоритма 395.
            // Возвращает двухстороннее (2-tail) p-значение.
            double n = df; // для синхронизации с ACM-именем параметра
            double a, b, y;

            t = t * t;
            y = t / n;
            b = y + 1.0;
            if (y > 1.0E-6) y = Math.Log(b);
            a = n - 0.5;
            b = 48.0 * a * a;
            y = a * y;

            y = (((((-0.4 * y - 3.3) * y - 24.0) * y - 85.5) /
              (0.8 * y * y + 100.0 + b) + y + 3.0) / b + 1.0) *
              Math.Sqrt(y);
            return 2.0 * Gauss(-y); // ACM-алгоритм 209
        }

        public static double Gauss(double z)
        {
            // ввод = z-value (от -inf до +inf)
            // вывод = p под кривой стандартного нормального
            // распределения от -inf до z, например,
            // если z = 0.0, функция возвращает 0.5000

            // ACM-алгоритм #209
            double y; // случайная переменная (scratch variable) в 209
            double p; // результат, называемый z в 209
            double w; // случайная переменная в 209

            if (z == 0.0)
                p = 0.0;
            else
            {
                y = Math.Abs(z) / 2;
                if (y >= 3.0)
                {
                    p = 1.0;
                }
                else if (y < 1.0)
                {
                    w = y * y;
                    p = ((((((((0.000124818987 * w
                      - 0.001075204047) * w + 0.005198775019) * w
                      - 0.019198292004) * w + 0.059054035642) * w
                      - 0.151968751364) * w + 0.319152932694) * w
                      - 0.531923007300) * w + 0.797884560593) * y * 2.0;
                }
                else
                {
                    y = y - 2.0;
                    p = (((((((((((((-0.000045255659 * y
                      + 0.000152529290) * y - 0.000019538132) * y
                      - 0.000676904986) * y + 0.001390604284) * y
                      - 0.000794620820) * y - 0.002034254874) * y
                      + 0.006549791214) * y - 0.010557625006) * y
                      + 0.011630447319) * y - 0.009279453341) * y
                      + 0.005353579108) * y - 0.002141268741) * y
                      + 0.000535310849) * y + 0.999936657524;
                }
            }

            if (z > 0.0)
                return (p + 1.0) / 2;
            else
                return (1.0 - p) / 2;
        }


        double[] Solve(double[][] design, List<int> toThrowAway)
        {
            // find linear regression coefficients
            // 1. peel off X matrix and Y vector
            int rows = design.Length;
            int cols = design[0].Length;
            
            double[][] X = MatrixCreate(rows, cols - 1);
            double[][] Y = MatrixCreate(rows, 1); // a column vector

            int j;
            int j1 = 0;
            for (int i = 0; i < rows; ++i)
            {
                for (j = 0; j < cols; ++j)
                {
                    if (j != 1)
                    {
                        X[i][j1] = design[i][j];
                        j1++;
                        if (j1 >= cols - 1) j1 = 0;
                    }
                }
            }

            for (int i = 0; i < rows; ++i)
            {
                for (j = 0; j < cols; ++j)
                {
                    Y[i][0] = design[i][1]; // Y column
                }
            }

            // 2. B = inv(Xt * X) * Xt * y
            double[][] Xt = MatrixTranspose(X);
            double[][] XtX = MatrixProduct(Xt, X);
            double[][] inv = MatrixInverse(XtX);
            double[][] invXt = MatrixProduct(inv, Xt);

            double[][] mResult = MatrixProduct(invXt, Y);
            double[] result = MatrixToVector(mResult);
            return result;
        } // Solve

        double[][] MatrixCreate(int rows, int cols)
        {
            // allocates/creates a matrix initialized to all 0.0
            // do error checking here
            double[][] result = new double[rows][];
            for (int i = 0; i < rows; ++i)
                result[i] = new double[cols];
            return result;
        }

        double[][] MatrixTranspose(double[][] matrix)
        {
            int rows = matrix.Length;
            int cols = matrix[0].Length;
            double[][] result = MatrixCreate(cols, rows); // note indexing
            for (int i = 0; i < rows; ++i)
            {
                for (int j = 0; j < cols; ++j)
                {
                    result[j][i] = matrix[i][j];
                }
            }
            return result;
        } // TransposeMatrix

        double[][] MatrixProduct(double[][] matrixA, double[][] matrixB)
        {
            int aRows = matrixA.Length; int aCols = matrixA[0].Length;
            int bRows = matrixB.Length; int bCols = matrixB[0].Length;
            if (aCols != bRows)
                throw new Exception("Несоответствующие матрицы");

            double[][] result = MatrixCreate(aRows, bCols);

            for (int i = 0; i < aRows; ++i) // each row of A
                for (int j = 0; j < bCols; ++j) // each col of B
                    for (int k = 0; k < aCols; ++k) // could use k < bRows
                        result[i][j] += matrixA[i][k] * matrixB[k][j];


            return result;
        }

        double[][] MatrixInverse(double[][] matrix)
        {
            int n = matrix.Length;
            double[][] result = MatrixDuplicate(matrix);

            int[] perm;
            int toggle;
            double[][] lum = MatrixDecompose(matrix, out perm, out toggle);
            if (lum == null)
                throw new Exception("Невозможно рассчитать");

            double[] b = new double[n];
            for (int i = 0; i < n; ++i)
            {
                for (int j = 0; j < n; ++j)
                {
                    if (i == perm[j])
                        b[j] = 1.0;
                    else
                        b[j] = 0.0;
                }

                double[] x = HelperSolve(lum, b); // use decomposition

                for (int j = 0; j < n; ++j)
                    result[j][i] = x[j];
            }
            return result;
        }

        double[] MatrixToVector(double[][] matrix)
        {
            // single column matrix to vector
            int rows = matrix.Length;
            int cols = matrix[0].Length;
            if (cols != 1)
                throw new Exception("Несоответствующая матрица");
            double[] result = new double[rows];
            for (int i = 0; i < rows; ++i)
                result[i] = matrix[i][0];
            return result;
        }

        double[][] MatrixDuplicate(double[][] matrix)
        {
            // allocates/creates a duplicate of a matrix
            double[][] result = MatrixCreate(matrix.Length, matrix[0].Length);
            for (int i = 0; i < matrix.Length; ++i) // copy the values
                for (int j = 0; j < matrix[i].Length; ++j)
                    result[i][j] = matrix[i][j];
            return result;
        }

        double[][] MatrixDecompose(double[][] matrix, out int[] perm,
          out int toggle)
        {
            // Doolittle LUP decomposition with partial pivoting.
            // returns: result is L (with 1s on diagonal) and U;
            // perm holds row permutations; toggle is +1 or -1 (even or odd)
            int rows = matrix.Length;
            int cols = matrix[0].Length;
            if (rows != cols)
                throw new Exception("Неквадратная матрица");

            int n = rows; // convenience

            double[][] result = MatrixDuplicate(matrix); // 

            perm = new int[n]; // set up row permutation result
            for (int i = 0; i < n; ++i) { perm[i] = i; }

            toggle = 1; // toggle tracks row swaps

            for (int j = 0; j < n - 1; ++j) // each column
            {
                double colMax = Math.Abs(result[j][j]);
                int pRow = j;

                for (int i = j + 1; i < n; ++i) // reader Matt V needed this:
                {
                    if (Math.Abs(result[i][j]) > colMax)
                    {
                        colMax = Math.Abs(result[i][j]);
                        pRow = i;
                    }
                }
                // Not sure if this approach is needed always, or not.

                if (pRow != j) // if largest value not on pivot, swap rows
                {
                    double[] rowPtr = result[pRow];
                    result[pRow] = result[j];
                    result[j] = rowPtr;

                    int tmp = perm[pRow]; // and swap perm info
                    perm[pRow] = perm[j];
                    perm[j] = tmp;

                    toggle = -toggle; // adjust the row-swap toggle
                }

                if (result[j][j] == 0.0)
                {
                    // find a good row to swap
                    int goodRow = -1;
                    for (int row = j + 1; row < n; ++row)
                    {
                        if (result[row][j] != 0.0)
                            goodRow = row;
                    }

                   //if (goodRow == -1)
                   //    throw new Exception("Cannot use Doolittle's method");

                    // swap rows so 0.0 no longer on diagonal
                    double[] rowPtr = result[goodRow];
                    result[goodRow] = result[j];
                    result[j] = rowPtr;

                    int tmp = perm[goodRow]; // and swap perm info
                    perm[goodRow] = perm[j];
                    perm[j] = tmp;

                    toggle = -toggle; // adjust the row-swap toggle
                }
                // -------------------------------------------------------------

                //if (Math.Abs(result[j][j]) < 1.0E-20) // deprecated
                //  return null; // consider a throw

                for (int i = j + 1; i < n; ++i)
                {
                    result[i][j] /= result[j][j];
                    for (int k = j + 1; k < n; ++k)
                    {
                        result[i][k] -= result[i][j] * result[j][k];
                    }
                }

            } // main j column loop

            return result;
        } // MatrixDecompose

        double[] HelperSolve(double[][] luMatrix, double[] b)
        {
            // before calling this helper, permute b using the perm array
            // from MatrixDecompose that generated luMatrix
            int n = luMatrix.Length;
            double[] x = new double[n];
            b.CopyTo(x, 0);

            for (int i = 1; i < n; ++i)
            {
                double sum = x[i];
                for (int j = 0; j < i; ++j)
                    sum -= luMatrix[i][j] * x[j];
                x[i] = sum;
            }

            x[n - 1] /= luMatrix[n - 1][n - 1];
            for (int i = n - 2; i >= 0; --i)
            {
                double sum = x[i];
                for (int j = i + 1; j < n; ++j)
                    sum -= luMatrix[i][j] * x[j];
                x[i] = sum / luMatrix[i][i];
            }

            return x;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Excel.Application excelapp = new Excel.Application();
            Excel.Workbook workbook = excelapp.Workbooks.Add();
            try
            {
                Excel.Worksheet worksheet = workbook.ActiveSheet;
                worksheet.Name = "Матрица коллинеарности";
                for (int i = 1; i < matr.RowCount + 1; i++)
                {
                    for (int j = 1; j < matr.ColumnCount + 1; j++)
                    {
                        worksheet.Rows[i].Columns[j] = matr.Rows[i - 1].Cells[j - 1].Value;
                    }
                }
                
                Excel.Worksheet newWorksheet;
                newWorksheet = workbook.Sheets.Add();
                newWorksheet.Name = "Критерии Стьюдента";
                if (Student.Columns.Count > 0)
                {
                    for (int k = 1; k < Student.RowCount; k++)
                    {
                        for (int l = 1; l < Student.ColumnCount + 1; l++)
                        {
                            newWorksheet.Rows[k].Columns[l] = Student.Rows[k - 1].Cells[l - 1].Value;
                        }
                    }
                }

                Excel.Worksheet newWorksheet1;
                newWorksheet1 = workbook.Sheets.Add();
                newWorksheet1.Name = "Регресионный анализ";
                if (CoefReg.Columns.Count > 0)
                {
                    for (int i = 1; i < CoefReg.RowCount + 1; i++)
                    {
                        for (int j = 1; j < CoefReg.ColumnCount + 1; j++)
                        {
                            newWorksheet1.Rows[i].Columns[j] = CoefReg.Rows[i - 1].Cells[j - 1].Value;
                        }
                    }
                }
                excelapp.AlertBeforeOverwriting = false;
                workbook.SaveAs(@"S:\кпи\4\Еколого-економічна оптимізація виробництва\save\eeop.xls");
                excelapp.Quit();

                MessageBox.Show(@"Файл сохранен в: S:\кпи\4\Еколого-економічна оптимізація виробництва\save\eeop.xls");
            }
            catch
            {

            }
            finally
            {
                excelapp.Quit();
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void analysisTb_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            Excel.Application excelapp = new Excel.Application();
            Excel.Workbook workbook = excelapp.Workbooks.Add();
            try
            {
                Excel.Worksheet worksheet = workbook.ActiveSheet;
                worksheet.Name = "Матрица коллинеарности";
                for (int i = 1; i < matr.RowCount + 1; i++)
                {
                    for (int j = 1; j < matr.ColumnCount + 1; j++)
                    {
                        worksheet.Rows[i].Columns[j] = matr.Rows[i - 1].Cells[j - 1].Value;
                    }
                }

                Excel.Worksheet newWorksheet;
                newWorksheet = workbook.Sheets.Add();
                newWorksheet.Name = "Критерии Стьюдента";
                if (Student.Columns.Count > 0)
                {
                    for (int k = 1; k < Student.RowCount; k++)
                    {
                        for (int l = 1; l < Student.ColumnCount + 1; l++)
                        {
                            newWorksheet.Rows[k].Columns[l] = Student.Rows[k - 1].Cells[l - 1].Value;
                        }
                    }
                }

                Excel.Worksheet newWorksheet1;
                newWorksheet1 = workbook.Sheets.Add();
                newWorksheet1.Name = "Регресионный анализ";
                if (CoefReg.Columns.Count > 0)
                {
                    for (int i = 1; i < CoefReg.RowCount + 1; i++)
                    {
                        for (int j = 1; j < CoefReg.ColumnCount + 1; j++)
                        {
                            newWorksheet1.Rows[i].Columns[j] = CoefReg.Rows[i - 1].Cells[j - 1].Value;
                        }
                    }
                }
                excelapp.AlertBeforeOverwriting = false;
                workbook.SaveAs(@"S:\кпи\4\Еколого-економічна оптимізація виробництва\save\eeop.xls");
                excelapp.Quit();

                MessageBox.Show(@"Файл сохранен в: S:\кпи\4\Еколого-економічна оптимізація виробництва\save\eeop.xls");
            }
            catch
            {

            }
            finally
            {
                excelapp.Quit();
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Excel.Application excelapp = new Excel.Application();
            Excel.Workbook workbook = excelapp.Workbooks.Add();
            try
            {
                Excel.Worksheet worksheet = workbook.ActiveSheet;
                worksheet.Name = "Матрица коллинеарности";
                for (int i = 1; i < matr.RowCount + 1; i++)
                {
                    for (int j = 1; j < matr.ColumnCount + 1; j++)
                    {
                        worksheet.Rows[i].Columns[j] = matr.Rows[i - 1].Cells[j - 1].Value;
                    }
                }

                Excel.Worksheet newWorksheet;
                newWorksheet = workbook.Sheets.Add();
                newWorksheet.Name = "Критерии Стьюдента";
                if (Student.Columns.Count > 0)
                {
                    for (int k = 1; k < Student.RowCount; k++)
                    {
                        for (int l = 1; l < Student.ColumnCount + 1; l++)
                        {
                            newWorksheet.Rows[k].Columns[l] = Student.Rows[k - 1].Cells[l - 1].Value;
                        }
                    }
                }

                Excel.Worksheet newWorksheet1;
                newWorksheet1 = workbook.Sheets.Add();
                newWorksheet1.Name = "Регресионный анализ";
                if (CoefReg.Columns.Count > 0)
                {
                    for (int i = 1; i < CoefReg.RowCount + 1; i++)
                    {
                        for (int j = 1; j < CoefReg.ColumnCount + 1; j++)
                        {
                            newWorksheet1.Rows[i].Columns[j] = CoefReg.Rows[i - 1].Cells[j - 1].Value;
                        }
                    }
                }
                excelapp.AlertBeforeOverwriting = false;
                workbook.SaveAs(@"S:\кпи\4\Еколого-економічна оптимізація виробництва\save\eeop.xls");
                excelapp.Quit();

                MessageBox.Show(@"Файл сохранен в: S:\кпи\4\Еколого-економічна оптимізація виробництва\save\eeop.xls");
            }
            catch
            {

            }
            finally
            {
                excelapp.Quit();
            }
        }

        double[][] Design(double[][] data)
        {
            // add a leading col of 1.0 values
            int rows = data.Length;
            int cols = data[0].Length;
            double[][] result = MatrixCreate(rows, cols + 1);
            for (int i = 0; i < rows; ++i)
                result[i][0] = 1.0;

            for (int i = 0; i < rows; ++i)
                for (int j = 0; j < cols; ++j)
                    result[i][j + 1] = data[i][j];

            return result;
        }

        double RSquared(double[][] data, double[] coef)
        {
            // 'coefficient of determination'
            int rows = data.Length;
            int cols = data[0].Length;

            // 1. compute mean of y
            double ySum = 0.0;
            for (int i = 0; i < rows; ++i)
                ySum += data[i][0]; // first column
            double yMean = ySum / rows;

            // 2. sum of squared residuals & tot sum squares
            double ssr = 0.0;
            double sst = 0.0;
            double y; // actual y value
            double predictedY; // using the coef[] 
            for (int i = 0; i < rows; ++i)
            {
                y = data[i][0]; // get actual y

                predictedY = coef[0]; // start w/ intercept constant
                for (int j = 0; j < cols - 1; ++j) // j is col of data
                    predictedY += coef[j + 1] * data[i][j+1]; // careful
                

                ssr += (y - predictedY) * (y - predictedY);
                sst += (y - yMean) * (y - yMean);
            }

            if (sst == 0.0)
                throw new Exception("All y values equal");
            else
                return 1.0 - (ssr / sst);
        }
    }
}




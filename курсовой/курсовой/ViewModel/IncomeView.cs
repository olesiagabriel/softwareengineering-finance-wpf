using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL;
using BLL.Models;
using System.Windows;
using System.IO;
using iTextSharp;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace курсовой
{
    public class IncomeView : VM
    {
        DBDataOperation bd;
        public System.Windows.Window w;
  
        public List<INCOME_GUIDE_Model> IncomeGuide { get; set; }
        private List<Order2> _IncomeDataGrid;
        public List<Order2> IncomeDataGrid {
            get {
                return _IncomeDataGrid;
            }
            set {
                _IncomeDataGrid = value;
                OnProperty("IncomeDataGrid");
            }
        }
        //для получения данных из комбобокса
        private INCOME_GUIDE_Model _iNCOME;
        public INCOME_GUIDE_Model iNCOME
        {
            get
            {
                return _iNCOME;
            }
            set
            {
                _iNCOME= value;
                OnProperty("iNCOME");
            }
        }

        //для получения данных из датапикчер1
        private DateTime _iNCOMEDate;
        public DateTime iNCOMEDate
        {
            get
            {
                return _iNCOMEDate;
            }
            set
            {
                _iNCOMEDate = value;
                OnProperty("iNCOMEDate");
            }
        }
        private DateTime _iNCOMEDate1;
        public DateTime iNCOMEDate1
        {
            get
            {
                return _iNCOMEDate1;
            }
            set
            {
                _iNCOMEDate1 = value;
                OnProperty("iNCOMEDate1");
                
            }
        }
        private DateTime _iNCOMEDate2;
        public DateTime iNCOMEDate2
        {
            get
            {
                return _iNCOMEDate2;
            }
            set
            {
                _iNCOMEDate2 = value;
                OnProperty("iNCOMEDate2");
            }
        }
        private string _iNCOMESize;
        public string iNCOMESize
        {
            get
            {
                return _iNCOMESize;
            }
            set
            {
                _iNCOMESize = value;
                OnProperty("iNCOMESize");
            }
        }
        private string _iNCOMESum;
        public string iNCOMESum
        {
            get
            {
                return _iNCOMESum;
            }
            set
            {
                _iNCOMESum = value;
                OnProperty("iNCOMESum");
            }
        }


        public RelayCommand AddIncome {
            //добавление дохода
            get
            {
                return new RelayCommand(o =>
                {
                    //тело действия
                    INCOME_Model income = new INCOME_Model();
                    income.income_user_FK = App.id;

                    income.income_date = iNCOMEDate;
                    income.income_size = Convert.ToInt32(iNCOMESize);
                    income.income_guide_FK = Convert.ToInt32(iNCOME.income_guide_code_ID);
                    bd.CreateINCOME(income);
                    MessageBox.Show("Доход успешно добавлен");
                    iNCOMEDate = DateTime.Now;
                    iNCOMESize = "0";
                });
            }
        }


        public RelayCommand UpdateIncomeDataGrid
        {//обновление данных в датагриде при изменении дат
            get
            {
                return new RelayCommand(o =>
                {
                    IncomeDataGrid = bd.GetINCOMESELECT(iNCOMEDate1, iNCOMEDate2, App.id);
                    double r = 0;
                    for (int i = 0; i < IncomeDataGrid.Count; i++)
                    {
                        r += (double)IncomeDataGrid[i].income_size;
                    }
                    iNCOMESum = "Итого " + r.ToString();
                });
            }
        }

        public RelayCommand Expense
        {
            get
            {
                return new RelayCommand(o =>
                {
                    Window4 window4 = new Window4();
                    window4.Show();
                    w.Close();
                });
            }
        }
        public RelayCommand Print
        {
            get
            {
                return new RelayCommand(o =>
                {
                    iTextSharp.text.Document doc = new iTextSharp.text.Document();


                    PdfWriter.GetInstance(doc, new FileStream("Доходы" +iNCOMEDate1.Year + iNCOMEDate1.Month + iNCOMEDate1.Day + "_" + iNCOMEDate2.Year + iNCOMEDate2.Month + iNCOMEDate2.Day + ".pdf", FileMode.Create));


                    doc.Open();


                    BaseFont baseFont = BaseFont.CreateFont("C:\\Windows\\Fonts\\arial.ttf", BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);
                    iTextSharp.text.Font font = new iTextSharp.text.Font(baseFont, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL);

                    PdfPTable table = new PdfPTable(3);


                    PdfPCell cell = new PdfPCell(new Phrase("Доходы " + iNCOMEDate1.ToString() + "-" + iNCOMEDate2.ToString(), font));

                    cell.Colspan = IncomeDataGrid.Count;
                    cell.HorizontalAlignment = 1;

                    cell.Border = 0;
                    table.AddCell(cell);





                    for (int j = 0; j < IncomeDataGrid.Count; j++)
                    {

                        table.AddCell(new Phrase(IncomeDataGrid[j].income_type.ToString(), font));
                        table.AddCell(new Phrase(IncomeDataGrid[j].income_date.ToString(), font));
                        table.AddCell(new Phrase(IncomeDataGrid[j].income_size.ToString(), font));

                    }

                    PdfPCell cell2 = new PdfPCell(new Phrase(iNCOMESum.ToString(), font));

                    cell2.Colspan = IncomeDataGrid.Count;
                    cell2.HorizontalAlignment = 1;

                    cell2.Border = 0;
                    table.AddCell(cell2);
                    doc.Add(table);

                    doc.Close();

                    MessageBox.Show("Pdf-документ сохранен");

                });
            }
        }

        public RelayCommand MyProfile
        {
            get
            {
                return new RelayCommand(o =>
                {
                    Window1 window = new Window1();
                    window.Show();
                    w.Close();
                });
            }
        }
        public RelayCommand Cancel
        {
            get
            {
                return new RelayCommand(o =>
                {
                    MainWindow window = new MainWindow();
                    window.Show();
                    App.id = 0;
                    w.Close();
                });
            }
        }

        public IncomeView(DBDataOperation myBd, System.Windows.Window w2)
        {
            bd = myBd;
            
            IncomeGuide = bd.GetINCOME_GUIDE();
            iNCOMEDate = DateTime.Now;
            iNCOMESize = "0";
            iNCOMEDate2 = DateTime.Now;
            iNCOMEDate1 = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            IncomeDataGrid = bd.GetINCOMESELECT(iNCOMEDate1, iNCOMEDate2, App.id);
            w = w2;
            double r = 0;
            for (int i = 0; i < IncomeDataGrid.Count; i++)
            {
                r += (double)IncomeDataGrid[i].income_size;
            }
           iNCOMESum = "Итого " + r.ToString();
        }
    }
}

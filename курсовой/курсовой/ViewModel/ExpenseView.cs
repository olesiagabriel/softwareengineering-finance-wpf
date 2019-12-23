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

namespace курсовой.ViewModel
{
   public  class ExpenseView: VM
    {

        DBDataOperation bd;
        public System.Windows.Window w;
        public List<EXPENSE_GUIDE_Model> ExpenseGuide { get; set; }
   
        private List<Order> _ExpenseDataGrid;
        public List<Order> ExpenseDataGrid
        {
            get
            {
                return _ExpenseDataGrid;
            }
            set
            {
                _ExpenseDataGrid = value;
                OnProperty("ExpenseDataGrid");
            }
        }
        //для получения данных из комбобокса
        private EXPENSE_GUIDE_Model _EXPENSE;
        public EXPENSE_GUIDE_Model EXPENSE
        {
            get
            {
                return _EXPENSE;
            }
            set
            {
                _EXPENSE = value;
                OnProperty("EXPENSE");
            }
        }

        //для получения данных из датапикчер1
        private DateTime _EXPENSEDate;
        public DateTime EXPENSEDate
        {
            get
            {
                return _EXPENSEDate;
            }
            set
            {
                _EXPENSEDate = value;
                OnProperty("EXPENSEDate");
            }
        }
        private DateTime _EXPENSEDate1;
        public DateTime EXPENSEDate1
        {
            get
            {
                return _EXPENSEDate1;
            }
            set
            {
                _EXPENSEDate1 = value;
                OnProperty("EXPENSEDate1");

            }
        }
        private DateTime _EXPENSEDate2;
        public DateTime EXPENSEDate2
        {
            get
            {
                return _EXPENSEDate2;
            }
            set
            {
                _EXPENSEDate2 = value;
                OnProperty("EXPENSEDate2");
            }
        }
        private string _EXPENSESize;
        public string EXPENSESize
        {
            get
            {
                return _EXPENSESize;
            }
            set
            {
                _EXPENSESize = value;
                OnProperty("EXPENSESize");
            }
        }

        private string _EXPENSESum;
        public string EXPENSESum
        {
            get
            {
                return _EXPENSESum;
            }
            set
            {
                _EXPENSESum = value;
                OnProperty("EXPENSESum");
            }
        }


        public RelayCommand AddExpense
        {//добавление расхода
            get
            {
                return new RelayCommand(o =>
                {
                    //тело действия
                    EXPENSE_Model expense = new EXPENSE_Model();
                    expense.expense_user_FK = App.id;

                    expense.expense_date = EXPENSEDate;
                    expense.expense_size = Convert.ToInt32(EXPENSESize);
                    expense.expense_guide_FK = Convert.ToInt32(EXPENSE.expense_guide_code_ID);
                    bd.CreateEXPENSE(expense);
                    MessageBox.Show("Расход успешно добавлен");
                    EXPENSEDate = DateTime.Now;
                    EXPENSESize = "0";
                });
            }
        }


        public RelayCommand UpdateExpenseDataGrid
        {
            get
            {
                return new RelayCommand(o =>
                {
                    ExpenseDataGrid = bd.GetEXPENSESELECT(EXPENSEDate1, EXPENSEDate2, App.id);
                    double r = 0;
                    for (int i = 0; i < ExpenseDataGrid.Count; i++)
                    {
                        r += (double)ExpenseDataGrid[i].expense_size;
                    }
                    EXPENSESum = "Итого " + r.ToString();
                });
            }
        }

        public RelayCommand Income
        {
            get
            {
                return new RelayCommand(o =>
                {
                    Window2 window = new Window2();
                    window.Show();
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

                    
                    PdfWriter.GetInstance(doc, new FileStream("Расходы" + EXPENSEDate1.Year+ EXPENSEDate1.Month+ EXPENSEDate1.Day + "_" + EXPENSEDate2.Year + EXPENSEDate2.Month + EXPENSEDate2.Day + ".pdf", FileMode.Create));

                   
                    doc.Open();

                   
                    BaseFont baseFont = BaseFont.CreateFont("C:\\Windows\\Fonts\\arial.ttf", BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);
                    iTextSharp.text.Font font = new iTextSharp.text.Font(baseFont, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL);

                     PdfPTable table = new PdfPTable(3);

                
                        PdfPCell cell = new PdfPCell(new Phrase("Расходы "+ EXPENSEDate1.ToString()+"-"+ EXPENSEDate2.ToString(), font));

                        cell.Colspan = ExpenseDataGrid.Count;
                        cell.HorizontalAlignment = 1;
                     
                        cell.Border = 0;
                        table.AddCell(cell);

                        
                       

                       
                        for (int j = 0; j < ExpenseDataGrid.Count; j++)
                        {
                            
                                table.AddCell(new Phrase(ExpenseDataGrid[j].expense_type.ToString(), font));
                                table.AddCell(new Phrase(ExpenseDataGrid[j].expense_date.ToString(), font));
                                table.AddCell(new Phrase(ExpenseDataGrid[j].expense_size.ToString(), font));
                          
                        }
                        
                        PdfPCell cell2 = new PdfPCell(new Phrase(EXPENSESum.ToString(), font));

                    cell2.Colspan = ExpenseDataGrid.Count;
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

        public ExpenseView(DBDataOperation myBd, System.Windows.Window w2)
        {
            bd = myBd;
            ExpenseGuide = bd.GetEXPENSE_GUIDE();
            
            EXPENSEDate = DateTime.Now;
            EXPENSESize = "0";
            EXPENSEDate2 = DateTime.Now;
            EXPENSEDate1 = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            ExpenseDataGrid = bd.GetEXPENSESELECT(EXPENSEDate1, EXPENSEDate2, App.id);
            w = w2;
            double r = 0;
            for (int i = 0; i < ExpenseDataGrid.Count; i++)
            {
                r += (double)ExpenseDataGrid[i].expense_size;
            }
            EXPENSESum = "Итого "+r.ToString();
        }
    }
}


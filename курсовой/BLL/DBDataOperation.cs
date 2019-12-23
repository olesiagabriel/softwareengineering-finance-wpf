using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using BLL.Models;


namespace BLL
{
    public class DBDataOperation
    {
        
            private Model1 db;
            public DBDataOperation()
            {
                db = new Model1();

            }
            public List<EXPENSE_Model> GetEXPENSE()
            {
                return db.EXPENSEs.ToList().Select(i => new EXPENSE_Model(i)).ToList();

            }
            public List<EXPENSE_GUIDE_Model> GetEXPENSE_GUIDE()
            {
                return db.EXPENSE_GUIDEs.ToList().Select(i => new EXPENSE_GUIDE_Model(i)).ToList();

            }
            public List<INCOME_Model> GetINCOME()
            {
                return db.INCOMEs.ToList().Select(i => new INCOME_Model(i)).ToList();

            }
            public List<INCOME_GUIDE_Model> GetINCOME_GUIDE()
            {
                return db.INCOME_GUIDEs.ToList().Select(i => new INCOME_GUIDE_Model(i)).ToList();

            }
            public List<USER_Model> GetUSER()
            {
                return db.USERs.ToList().Select(i => new USER_Model(i)).ToList();

            }
        //функция определяет есть ли пользователь с таким логином и паролем в базе
       public int GetUSER(string login, string password)
        {
            var k= db.USERs.ToList().Where(i => i.login==login && i.password==password).ToList();
            if (k.Count > 0)
            {
                return k[0].user_code_ID;
            }
            else
            {
                return 0;
            }
                 
        }
        //определяет есть ли пользовательс таким логином
        public bool GetUSER(string login)
        {
            var k = db.USERs.ToList().Where(i => i.login == login ).ToList();
            if (k.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        public List<USER_Model> GetUSER(int id)
        {

            
            var k = db.USERs.ToList().Where(i => i.user_code_ID == id ).Select(i => new USER_Model(i)).ToList();
            return k;
                              
        }

        public bool Save()
            {
                if (db.SaveChanges() > 0) return true;
                return false;
            }

            public void DeleteEXPENSE_GUIDE(int id)
            {
            EXPENSE_GUIDE e = db.EXPENSE_GUIDEs.Find(id);
                if (e != null)
                {
                    db.EXPENSE_GUIDEs.Remove(e);
                    Save();
                }
            }
            public void CreateEXPENSE_GUIDE(EXPENSE_GUIDE_Model e)
            {
                db.EXPENSE_GUIDEs.Add(new EXPENSE_GUIDE()
                {
                    expense_guide_code_ID = e.expense_guide_code_ID,
                    expense_type = e.expense_type
        });
                Save();

            }
        public void CreateUSER(USER_Model u)
        {
            db.USERs.Add(new USER()
            {
            user_code_ID = u.user_code_ID,
            name = u.name,
            surname = u.surname,
            login = u.login,
            password = u.password,
            limit_size = 0
        });
            Save();

        }
        public void CreateINCOME(INCOME_Model i)

        {
            db.INCOMEs.Add(new INCOME()
            {
                income_code_ID = i.income_code_ID,
                income_user_FK = (int)i.income_user_FK,
                income_guide_FK = (int)i.income_guide_FK,
                income_date = (DateTime)i.income_date,
                income_size = (int)i.income_size
            });
            Save();
        }
        public void CreateEXPENSE(EXPENSE_Model i)

        {
            db.EXPENSEs.Add(new EXPENSE()
            {
                expense_code_ID = (int)i.expense_code_ID,
                expense_user_FK = (int)i.expense_user_FK,
                expense_guide_FK = (int)i.expense_guide_FK,
                expense_date = i.expense_date,
                expense_size = (int)i.expense_size
            });
            Save();
        }

        public void UpdateUSER(USER_Model e)
        {
            USER ph = db.USERs.Find(e.user_code_ID);



            ph.user_code_ID = e.user_code_ID;
            ph.name=e.name;
            ph.surname = e.surname;
            ph.password = e.password;
            ph.limit_size =(decimal) e.limit_size;

             
            Save();
        }

        public void UpdateEXPENSE_GUIDE(EXPENSE_GUIDE_Model e)
            {
            EXPENSE_GUIDE ph = db.EXPENSE_GUIDEs.Find(e.expense_guide_code_ID);

            ph.expense_guide_code_ID = e.expense_guide_code_ID;
            ph.expense_type = e.expense_type;
                Save();
            }
        public void UpdateINCOME_GUIDE(INCOME_GUIDE_Model e)
        {
            INCOME_GUIDE ph = db.INCOME_GUIDEs.Find(e.income_guide_code_ID);

            ph.income_guide_code_ID = e.income_guide_code_ID;
            ph.income_type = e.income_type;
            Save();
        }

        public List<Order2> GetINCOMESELECT(DateTime date1, DateTime date2, int id_user)
        {
            System.Data.SqlClient.SqlParameter p1= new System.Data.SqlClient.SqlParameter("@date1",date1);
            System.Data.SqlClient.SqlParameter p2 = new System.Data.SqlClient.SqlParameter("@date2", date2);
            System.Data.SqlClient.SqlParameter p3 = new System.Data.SqlClient.SqlParameter("@id_user", id_user);
            var result = db.Database.SqlQuery<Order2>("INCOMESELECT @date1, @date2, @id_user", p1, p2,p3).ToList();

            return result;

        }
        public List<Order> GetEXPENSESELECT(DateTime date1, DateTime date2, int id_user)
        {
            System.Data.SqlClient.SqlParameter p1 = new System.Data.SqlClient.SqlParameter("@date1", date1);
            System.Data.SqlClient.SqlParameter p2 = new System.Data.SqlClient.SqlParameter("@date2", date2);
            System.Data.SqlClient.SqlParameter p3 = new System.Data.SqlClient.SqlParameter("@id_user", id_user);
            var result = db.Database.SqlQuery<Order>("EXPENSESELECT @date1, @date2, @id_user", p1, p2, p3).ToList();

            return result;

        }


    }
}

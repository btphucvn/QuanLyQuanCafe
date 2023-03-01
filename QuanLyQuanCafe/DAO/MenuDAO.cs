using QuanLyQuanCafe.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace QuanLyQuanCafe.DAO
{
    class MenuDAO
    {
        public static MenuDAO instance;
        public static MenuDAO Instance
        {
            get { if (instance == null) instance = new MenuDAO(); return MenuDAO.instance; }
        }
        private MenuDAO()
        {

        }
        public List<Menu> GetListMenuByTable(int id)
        {
            List<Menu> listMenu = new List<Menu>();

            DataTable data = DataProvider.Instance.ExecuteQuery("" +
                "SELECT f.name,bi.count,f.price,f.price*bi.count  as totalPrice " +
                "FROM dbo.BillInfo as bi, dbo.Bill AS b, dbo.Food AS f " +
                "WHERE bi.idBill = b.id AND bi.idFood = f.id AND b.status=0 AND b.idTable ="+id);
            foreach (DataRow item in data.Rows)
            {
                Menu menu = new Menu(item);
                listMenu.Add(menu);
            }

            return listMenu;
        }

    }
}

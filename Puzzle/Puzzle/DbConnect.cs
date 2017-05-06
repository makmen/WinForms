using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Puzzle
{
    public class DbConnect
    {
        private puzzleEntities db;

        public DbConnect()
        {
            db = new puzzleEntities();
        }

        public void GetRestults(int countItems)
        {
            List<Game> listBook = // get Book from db
            (from game in db.Game
             select game).ToList();
            foreach (Game str in listBook)
            {
                MessageBox.Show(str.Count + " " + str.Title);
            }
        }
    }
}

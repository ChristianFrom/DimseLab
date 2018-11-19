using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DimseLab
{
    class Dims
    {
        public string _name { get; set; }
        public string _keywords { get; set; }
        public DateTime _lendingdate { get; set; }
        public DateTime _duedate { get; set; }

        public Dims(string name, string keywords, DateTime lendingdate, DateTime duedate)
        {
            _name = name;
            _keywords = keywords;
            _lendingdate = lendingdate;
            _duedate = duedate;
        }
    }
}

using LibraryManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Helper
{
    interface IBorrowBook
    {
        void ReduceBookCountAvailability(BorrowedBy borrowedBy); 
    }
}

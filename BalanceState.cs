using System;

namespace lab{
    class BalanceState{
        double _sum;
        DateTime _date;

        public BalanceState(double sum, DateTime date){
            Sum = sum;
            Date = date;
        }

        public double Sum { get => _sum; set => _sum = value; }
        public DateTime Date { get => _date; set => _date = value; }
    }
}
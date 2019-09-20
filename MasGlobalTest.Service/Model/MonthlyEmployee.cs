namespace MasGlobalTest.Service.Model
{
    public class MonthlyEmployee : IEmployeeAnualSalary
    {
        public double CalculateAnualSalary(double montlySalary)
        {
            return montlySalary * 12;
        }
    }
}

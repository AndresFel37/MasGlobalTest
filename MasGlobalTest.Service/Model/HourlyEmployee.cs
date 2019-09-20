namespace MasGlobalTest.Service.Model
{
    public class HourlyEmployee : IEmployeeAnualSalary
    {
        public double CalculateAnualSalary(double hourlySalary)
        {
            return (120 * hourlySalary * 12);
        }
    }
}

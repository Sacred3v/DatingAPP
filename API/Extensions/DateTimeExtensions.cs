namespace API.Extensions;

public static class DateTimeExtensions
{
    public static int CalculateAge(this DateOnly db){
        var today = DateOnly.FromDateTime(DateTime.Now);
        var age = today.Year - db.Year;
        return (db>today.AddYears(-age))? age--:age;
    }
}
using Microsoft.EntityFrameworkCore;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;

namespace noob.IntegrationTests.Extensions;

public static class EntityFrameworkExtensions
{
    /// <summary>
    /// Loads a SQL file as string from the calling directory
    /// SQL file must be named the same as the calling class name 
    /// </summary>
    /// <returns>Results of executing SQL file</returns>
    public static IQueryable<T> FromSqlFile<T>(this DbSet<T> dbSet, [CallerFilePath] string filePath = "") where T : class
    {
        var sqlFilePath = filePath.Replace(".cs", ".sql");
        using StreamReader file = File.OpenText(sqlFilePath);
            var rawSql = file.ReadToEnd();
            return dbSet.FromSqlRaw(rawSql);
    }
}

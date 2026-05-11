using System;
using System.Data;
using Npgsql;

namespace transportation
{
    public static class AuthService
    {

        public static CurrentUser Login(string login, string password)
        {
            string query = @"
                select
                    u.id,
                    u.login,
                    u.password_hash,
                    u.is_active,
                    r.name as role_name
                from users u
                join roles r on r.id = u.role_id
                where u.login = @login
                limit 1;";

            DataTable table = DbHelper.ExecuteQuery(query, new NpgsqlParameter("@login", login));
            if (table.Rows.Count == 0)
                return null;

            DataRow row = table.Rows[0];
            bool isActive = Convert.ToBoolean(row["is_active"]);
            if (!isActive)
                return null;

            string storedHash = row["password_hash"].ToString();
            if (!PasswordHasher.VerifyPassword(password, storedHash))
                return null;

            return new CurrentUser
            {
                Id = Convert.ToInt32(row["id"]),
                Login = row["login"].ToString(),
                RoleName = row["role_name"].ToString(),
                IsActive = isActive
            };
        }
    }
}

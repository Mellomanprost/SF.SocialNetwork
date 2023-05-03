using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SF.SocialNetwork.Clich.Models.Users;

namespace SF.SocialNetwork.Clich.Data
{
    public class GenerateUsers
    {
        public readonly string[] maleNames = new string[] { "Александр", "Борис", "Василий", "Игорь", "Даниил", "Сергей", "Евгений", "Алексей", "Геогрий", "Валентин" };
        public readonly string[] femaleNames = new string[] { "Анна", "Мария", "Станислава", "Елена" };
        public readonly string[] lastNames = new string[] { "Тестов", "Титов", "Потапов", "Джабаев", "Иванов" };

        public List<User> Populate(int count)
        {
            var users = new List<User>();
            for (int i = 1; i < count; i++)
            {
                string firstName;
                var rand = new Random();

                var male = rand.Next(1, 2) == 1;

                var lastName = lastNames[rand.Next(0, lastNames.Length - 1)];
                if (male)
                {
                    firstName = maleNames[rand.Next(0, maleNames.Length - 1)];
                }
                else
                {
                    lastName = lastName + "a";
                    firstName = femaleNames[rand.Next(0, femaleNames.Length - 1)];
                }

                var item = new User()
                {
                    FirstName = firstName,
                    LastName = lastName,
                    BirthDate = DateTime.Now.AddDays(-rand.Next(1, (DateTime.Now - DateTime.Now.AddYears(-25)).Days)),
                    Email = "test" + rand.Next(0, 1204) + "@test.com",
                };

                item.UserName = item.Email;
                item.Image = "https://external-content.duckduckgo.com/iu/?u=https%3A%2F%2Fi.ytimg.com%2Fvi%2F_M4_Naupl7g%2Fmaxresdefault.jpg&f=1&nofb=1&ipt=e383df3bc3e8ab7f4556c94646b40b0fb5b5a63bc377a6da41c9943b980dc306&ipo=images";
                
                users.Add(item);
            }

            return users;
        }
    }
}

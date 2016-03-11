namespace EFTesting
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;

    public class Program
    {
        public static void Main(string[] args)
        {
            using (var db = new TelerikAcademyEntities())
            {
                Expression<Func<Project, bool>> expression = pr => pr.ProjectID == 1;

                Console.WriteLine(expression.Body);

                Func<Project, bool> function = pr => pr.ProjectID == 1;

                var project = db.Projects
                    //.Where(pj => pj.ProjectID == 1)
                    //.FirstOrDefault();
                    //.FirstOrDefault(pj => pj.ProjectID == 1);
                    .FirstOrDefault(expression);

                Console.WriteLine(project.Name);

                // var p = db.Projects.Find(1);

                var list = new List<Project>();

                //list.FirstOrDefault(pr => pr.ProjectID == 1);
                list.FirstOrDefault(function);

                var town = new Town
                {
                    Name = "Sofia from console"
                };

                db.Towns.Add(town);
                db.SaveChanges();
            }
        }
    }
}

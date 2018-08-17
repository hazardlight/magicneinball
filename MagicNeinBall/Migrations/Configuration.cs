namespace MagicNeinBall.Migrations
{
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<MagicNeinBall.Models.FortuneDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "MagicNeinBall.Models.FortuneDBContext";
        }

        protected override void Seed(MagicNeinBall.Models.FortuneDBContext context)
        {


            context.Fortunes.AddOrUpdate(f => f.fortuneText,
                new Fortune { fortuneText = "Nope" },
                new Fortune { fortuneText = "Definitely NOT" },
                new Fortune { fortuneText = "Just give up your dreams" },
                new Fortune { fortuneText = "Can't do that" },
                new Fortune { fortuneText = "NEIN" },
                new Fortune { fortuneText = "No, your path is blocked" },
                new Fortune { fortuneText = "You are not the ONE" },
                new Fortune { fortuneText = "Failure in perpetuity" },
                new Fortune { fortuneText = "Trying is only a waste of time" },
                new Fortune { fortuneText = "Your ambition is eclipsed by futility" },
                new Fortune { fortuneText = "Don't even bother" },
                new Fortune { fortuneText = "Time will not remember your effort" }
                );
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}

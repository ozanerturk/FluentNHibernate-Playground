using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Tool.hbm2ddl;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhibernatePlayGround
{

    //♪ At a time, this file could be hard to understand for you.
    // push yourself to understand
    public static class Configuration
    {
        private const string ConnectionString = "Data Source=.;Initial Catalog=NHibernatePlayGround; Integrated Security=True;";

        private static ISessionFactory CreateSessionFactory(bool setupDb)
        {
            var cfg = Fluently.Configure()
              .Database(MsSqlConfiguration.MsSql2012.ShowSql().ConnectionString(ConnectionString))
              .Mappings(m => m.FluentMappings.AddFromAssemblyOf<Domain.Domain>());

            if (setupDb)
            {
                new SchemaExport(cfg.BuildConfiguration()).Create(true, true);
            }
            return cfg.BuildSessionFactory();
        }


        public static void SetupSchemaByConfigure()
        {
            CreateSessionFactory(true);
        }

        //♪ now you're like : "Omfg, What the fuck is this 'Action' shit!!!". Why dont you take a look ?
        public static void WorkWithTransaction(Action<ISession> action)
        {
            using (var factory = CreateSessionFactory(false))
            {
                using (var session = factory.OpenSession())
                {
                    // ♪ if you dont know what does transaction mean,
                    //It is good time to learn. Ask to uncle Google,learn and do not come back here until you got the idea.
                    using (var trnx = session.BeginTransaction())
                    {
                        try
                        {
                            action.Invoke(session);
                            trnx.Commit();

                        }
                        catch (Exception e)
                        {
                            // ♪ If you got exception, maybe you could want to add breakpoint here and analyze exception 
                            Console.WriteLine(e.ToString());
                            trnx.Rollback();
                        }
                        finally
                        {
                            session.Close();
                        }
                    }
                }
            }

        }

    }

}

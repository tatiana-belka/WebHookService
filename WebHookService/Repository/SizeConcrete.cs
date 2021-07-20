using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebhooksAPIStore.Models;
using WebhooksAPIStore.MoviesContext;
using Dapper;
using System.Data.SqlClient;
using Microsoft.Extensions.Options;

namespace WebhooksAPIStore.Repository
{
    public class SizeConcrete : ISize
    {
        private DatabaseContext _context;
        private ConnectionStrings _connectionstrings;

        public SizeConcrete(DatabaseContext context, IOptions<ConnectionStrings> connectionstrings)
        {
            _context = context;
            _connectionstrings = connectionstrings.Value;
        }

        public List<SizeTB> GetSizeList()
        {
            try
            {
                var hitsList = (from services in _context.SizeTB select services).ToList();
                hitsList.Insert(0, new SizeTB { SizeDisplay = "---Choose Max Request---", SizeID = -1 });
                return hitsList;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<string> GetChartsWebhooksreport()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(Convert.ToString(_connectionstrings.DatabaseConnection)))
                {
                    var parameter = new DynamicParameters();
                    return con.Query<string>("Usp_GetChartsMoviesreport", null, null, false,0, System.Data.CommandType.StoredProcedure).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<string> GetChartsUrlreport()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(Convert.ToString(_connectionstrings.DatabaseConnection)))
                {
                    var parameter = new DynamicParameters();
                    return con.Query<string>("Usp_GetChartsMusicreport", null, null, false, 0, System.Data.CommandType.StoredProcedure).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}

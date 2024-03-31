using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Bamanna.DouDian.MultiTenancy.HostDashboard.Dto;

namespace Bamanna.DouDian.MultiTenancy.HostDashboard
{
    public interface IIncomeStatisticsService
    {
        Task<List<IncomeStastistic>> GetIncomeStatisticsData(DateTime startDate, DateTime endDate,
            ChartDateInterval dateInterval);
    }
}
using System.Collections.Generic;
using Bamanna.DouDian.Auditing.Dto;
using Bamanna.DouDian.Dto;

namespace Bamanna.DouDian.Auditing.Exporting
{
    public interface IAuditLogListExcelExporter
    {
        FileDto ExportToFile(List<AuditLogListDto> auditLogListDtos);

        FileDto ExportToFile(List<EntityChangeListDto> entityChangeListDtos);
    }
}

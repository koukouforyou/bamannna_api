using System.Collections.Generic;
using Bamanna.DouDian.Authorization.Users.Dto;
using Bamanna.DouDian.Dto;

namespace Bamanna.DouDian.Authorization.Users.Exporting
{
    public interface IUserListExcelExporter
    {
        FileDto ExportToFile(List<UserListDto> userListDtos);
    }
}
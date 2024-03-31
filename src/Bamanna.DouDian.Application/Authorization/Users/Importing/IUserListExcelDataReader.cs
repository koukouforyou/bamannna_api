using System.Collections.Generic;
using Bamanna.DouDian.Authorization.Users.Importing.Dto;
using Abp.Dependency;

namespace Bamanna.DouDian.Authorization.Users.Importing
{
    public interface IUserListExcelDataReader: ITransientDependency
    {
        List<ImportUserDto> GetUsersFromExcel(byte[] fileBytes);
    }
}

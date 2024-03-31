using System.Collections.Generic;
using Bamanna.DouDian.Authorization.Users.Importing.Dto;
using Bamanna.DouDian.Dto;

namespace Bamanna.DouDian.Authorization.Users.Importing
{
    public interface IInvalidUserExporter
    {
        FileDto ExportToFile(List<ImportUserDto> userListDtos);
    }
}

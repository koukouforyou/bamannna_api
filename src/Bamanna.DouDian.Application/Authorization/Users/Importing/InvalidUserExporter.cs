﻿using System.Collections.Generic;
using Abp.Collections.Extensions;
using Bamanna.DouDian.Authorization.Users.Importing.Dto;
using Bamanna.DouDian.DataExporting.Excel.EpPlus;
using Bamanna.DouDian.Dto;
using Bamanna.DouDian.Storage;

namespace Bamanna.DouDian.Authorization.Users.Importing
{
    public class InvalidUserExporter : EpPlusExcelExporterBase, IInvalidUserExporter
    {
        public InvalidUserExporter(ITempFileCacheManager tempFileCacheManager)
            : base(tempFileCacheManager)
        {
        }

        public FileDto ExportToFile(List<ImportUserDto> userListDtos)
        {
            return CreateExcelPackage(
                "InvalidUserImportList.xlsx",
                excelPackage =>
                {
                    var sheet = excelPackage.Workbook.Worksheets.Add(L("InvalidUserImports"));
                    sheet.OutLineApplyStyle = true;

                    AddHeader(
                        sheet,
                        L("UserName"),
                        L("Name"),
                        L("Surname"),
                        L("EmailAddress"),
                        L("PhoneNumber"),
                        L("Password"),
                        L("Roles"),
                        L("Refuse Reason")
                        );

                    AddObjects(
                        sheet, 2, userListDtos,
                        _ => _.UserName,
                        _ => _.Name,
                        _ => _.Surname,
                        _ => _.EmailAddress,
                        _ => _.PhoneNumber,
                        _ => _.Password,
                        _ => _.AssignedRoleNames.JoinAsString(","),
                        _ => _.Exception
                        );

                    for (var i = 1; i <= 9; i++)
                    {
                        sheet.Column(i).AutoFit();
                    }
                });
        }
    }
}

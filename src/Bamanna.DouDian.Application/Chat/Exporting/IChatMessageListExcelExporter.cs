using System.Collections.Generic;
using Bamanna.DouDian.Chat.Dto;
using Bamanna.DouDian.Dto;

namespace Bamanna.DouDian.Chat.Exporting
{
    public interface IChatMessageListExcelExporter
    {
        FileDto ExportToFile(List<ChatMessageExportDto> messages);
    }
}

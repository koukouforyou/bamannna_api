// ***********************************************************************
// Assembly         : Bamanna.DouDian.Infrasturcture.Modules.Application
// Author           : david
// Created          : 10-08-2016
//
// Last Modified By : david
// Last Modified On : 10-08-2016
// ***********************************************************************
// <copyright file="FileDto.cs" company="">
//     Copyright ©  2016
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.ComponentModel.DataAnnotations;
using Abp.Application.Services.Dto;

namespace Bamanna.DouDian.Infrasturcture.Modules.Common.Dto
{
    /// <summary>
    /// 文件传输类
    /// </summary>
    /// <seealso cref="Bamanna.DouDian.Infrasturcture.Modules.Common.Dto.UnifyEntityDtoBase" />
    public class FileDto : UnifyEntityDtoBase
    {
        /// <summary>
        /// Gets or sets the name of the file.
        /// </summary>
        /// <value>The name of the file.</value>
        [Required]
        public string FileName { get; set; }

        /// <summary>
        /// Gets or sets the type of the file.
        /// </summary>
        /// <value>The type of the file.</value>
        [Required]
        public string FileType { get; set; }

        /// <summary>
        /// Gets or sets the file token.
        /// </summary>
        /// <value>The file token.</value>
        [Required]
        public string FileToken { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="FileDto"/> class.
        /// </summary>
        public FileDto()
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FileDto"/> class.
        /// </summary>
        /// <param name="fileName">Name of the file.</param>
        /// <param name="fileType">Type of the file.</param>
        public FileDto(string fileName, string fileType)
        {
            FileName = fileName;
            FileType = fileType;
            FileToken = Guid.NewGuid().ToString("N");
        }
    }
}

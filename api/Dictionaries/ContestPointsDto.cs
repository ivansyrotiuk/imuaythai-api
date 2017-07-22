﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MuaythaiSportManagementSystemApi.Models;

namespace MuaythaiSportManagementSystemApi.Dictionaries
{
    public class ContestPointsDto
    {
        public int Id { get; set; }
        public int ContestTypeId { get; set; }
        public int ContestRangeId { get; set; }
        public int? InstitutionId { get; set; }
        public decimal Points { get; set; }

        public ContestTypeDto ContestType { get; set; }
        public ContestRangeDto ContestRange { get; set; }
        public Institution Institution { get; set; }

        public static explicit operator ContestPointsDto(ContestTypePoints points)
        {
            return new ContestPointsDto
            {
                Id = points.Id,
                Points = points.Points,
                ContestRange = points.ContestRange != null ? (ContestRangeDto)points.ContestRange : new ContestRangeDto(),
                ContestType = points.ContestType != null ? (ContestTypeDto)points.ContestType : new ContestTypeDto()
            };
        }
    }
}

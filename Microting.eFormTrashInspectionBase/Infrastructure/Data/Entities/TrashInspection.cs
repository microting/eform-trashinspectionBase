/*
The MIT License (MIT)

Copyright (c) 2007 - 2019 microting

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
*/
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Microting.eFormApi.BasePn.Infrastructure.Database.Base;

namespace Microting.eFormTrashInspectionBase.Infrastructure.Data.Entities
{

    public class TrashInspection : BaseEntity
    {

        public TrashInspection()
        {
            TrashInspectionCases = new HashSet<TrashInspectionCase>();
        }

        public string WeighingNumber { get; set; }

        public DateTime Date { get; set; }

        public DateTime Time { get; set; }

        public string RegistrationNumber { get; set; }

        public string TrashFraction { get; set; }
        
        [ForeignKey("Fraction")]
        public int? FractionId { get; set; }

        public string Eak_Code { get; set; }

        public string Producer { get; set; }

        public string Transporter { get; set; }
        
        [ForeignKey("Installation")]
        public int? InstallationId { get; set; }

        public bool MustBeInspected { get; set; }
        
        public int Status { get; set; }
        
        [ForeignKey("Segment")]
        public int? SegmentId { get; set; }
        
        public bool ExtendedInspection { get; set; }
        
        public bool InspectionDone { get; set; }
        
        public virtual ICollection<TrashInspectionCase> TrashInspectionCases { get; set; }
    }
}
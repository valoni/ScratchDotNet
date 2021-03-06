﻿//-------------------------------------------------------------------------
//  (c) 2015 Pervasive Digital LLC
//
//  This file is part of Scratch for .Net Micro Framework
//
//  "Scratch for .Net Micro Framework" is free software: you can 
//  redistribute it and/or modify it under the terms of the 
//  GNU General Public License as published by the Free Software 
//  Foundation, either version 3 of the License, or (at your option) 
//  any later version.
//
//  "Scratch for .Net Micro Framework" is distributed in the hope that
//  it will be useful, but WITHOUT ANY WARRANTY; without even the implied
//  warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See
//  the GNU General Public License for more details.
//
//  You should have received a copy of the GNU General Public License
//  along with "Scratch for .Net Micro Framework". If not, 
//  see <http://www.gnu.org/licenses/>.
//
//-------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PervasiveDigital.Scratch.Common
{
    public class FirmwareImage
    {
        private Guid _id;
        private List<Guid> _assemblyIds;

        public Guid Id 
        { 
            get
            {
                if (_id == Guid.Empty)
                {
                    _id = Guid.NewGuid();
                }
                return _id;
            }
            set { _id = value; }
        }

        public string Name { get; set; }
        public string AppName { get; set; }
        public string Description { get; set; }
        public string ImageCreatedBy { get; set; }
        public string SupportUrl { get; set; }

        public string ConfigurationExtensionSource { get; set; }
        public string ScratchExtension { get; set; }
        public string DriverSource { get; set; }
        public string DriverName { get; set; }

        public Version AppVersion { get; set; }
        public Version TargetFrameworkVersion { get; set; }
        public Version SolutionBuildVersion { get; set; }

        public List<Guid> RequiredAssemblies
        {
            get
            {
                if (_assemblyIds == null)
                    _assemblyIds = new List<Guid>();
                return _assemblyIds;
            }
            set { _assemblyIds = value; }
        }
    }
}
